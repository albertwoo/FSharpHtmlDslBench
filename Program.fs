open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open Falco.Markup
open Feliz.ViewEngine
open Giraffe.ViewEngine
open System
open BenchmarkDotNet.Attributes

(*
* ToRun: dotnet run -c Release 
* Results: https://hamy.xyz/labs/2024-02_fsharp-html-dsl-long-page-benchmarks
*)

type TemplateProps = 
    {
        Items : string list
    }


module FunBlazorDemo =
    open Microsoft.Extensions.DependencyInjection
    open Fun.Blazor

    let services = ServiceCollection().AddLogging()
    let serviceProvider = services.BuildServiceProvider()

    let renderFunBlazor 
        (props : TemplateProps)
        : string 
        =
        let page = 
            html' {
                body {
                    table {
                        tr {
                            th { "item" }
                        }
                        for i in props.Items do
                            tr {
                                td { i }
                            }
                    }
                }
            }

        (html.renderAsString serviceProvider page).Result
        

[<MemoryDiagnoser>]
type HtmlDslLongPageBenchmarks() =

    let itemCount = 10_000

    let testItems = 
        seq {0 .. itemCount}
        |> Seq.map 
            (fun _ -> Guid.NewGuid().ToString())
        |> Seq.toList

    let renderGiraffeView 
        (props : TemplateProps)
        : string 
        =
        let page = 
            html [] [
                body [] [
                    table [] [
                        tr [] [
                              th [] [
                                  Text "item"
                              ];
                        ];
                        yield! (
                            props.Items
                            |> List.map(
                                fun i ->
                                    tr [] [
                                        td [] [
                                            Text i
                                        ];
                                    ];
                            )
                        )
                    ]
                ]
            ]

        page
        |> RenderView.AsString.htmlDocument

    let renderFalcoMarkup
        (props : TemplateProps)
        : string
        =
        let page =
            Elem.html [] [
                Elem.body [] [
                    Elem.table [] [
                        Elem.tr [] [
                            Elem.th [] [
                                Text.raw "item"
                            ]
                        ]
                        yield! (
                            props.Items
                            |> List.map(
                                fun i ->
                                    Elem.tr [] [
                                        Elem.td [] [
                                            Text.raw i
                                        ];
                                    ];
                            )
                        )
                    ]
                ]
            ]
            
        page
        |> renderNode

    let renderFelizViewEngine 
        (props : TemplateProps)
        : string 
        = 
        let page = 
            Html.html [
                Html.body [
                    Html.table [
                        prop.children [ 
                            Html.tr [
                                Html.th [
                                    prop.text "item"
                                ]
                            ]
                            yield! (
                                props.Items
                                |> List.map(
                                    fun i ->
                                        Html.tr [
                                            Html.td [
                                                prop.text i
                                            ];
                                        ];
                                )
                            )
                        ]
                    ]
                ]
            ]

        page
        |> Render.htmlView


    [<Benchmark(Baseline = true)>]
    member __.RunGiraffeView() =  
        renderGiraffeView { Items = testItems }

    [<Benchmark>]
    member __.RunFalcoMarkup() =  
        renderFalcoMarkup { Items = testItems }

    [<Benchmark>]
    member __.RunFelizViewEngine() =  
        renderFelizViewEngine { Items = testItems }

    [<Benchmark>]
    member __.RunFunBlazor() =  
        FunBlazorDemo.renderFunBlazor { Items = testItems }

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let summary = BenchmarkRunner.Run<HtmlDslLongPageBenchmarks>();

    0 // return an integer exit code
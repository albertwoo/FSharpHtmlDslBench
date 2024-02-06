Benchmark for fsharp html dsl based on [this docs](https://hamy.xyz/labs/2024-02_fsharp-html-dsl-long-page-benchmarks)

And the code is also based on https://replit.com/@HamiltonGreene/2024-01long-page-html-rendering-benchmarks%23main.fs

Just added [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) related stuff.


BenchmarkDotNet v0.13.10, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

| Method             | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------- |-----------:|----------:|----------:|------:|--------:|----------:|---------:|---------:|----------:|------------:|
| RunGiraffeView     | 1,171.2 us |  23.34 us |  32.71 us |  1.00 |    0.00 |  332.0313 | 330.0781 | 166.0156 |   2.45 MB |        1.00 |
| RunFalcoMarkup     | 1,327.8 us |  26.02 us |  30.97 us |  1.13 |    0.03 |  332.0313 | 330.0781 | 166.0156 |   2.22 MB |        0.91 |
| RunFelizViewEngine | 5,852.8 us | 113.27 us | 125.90 us |  4.99 |    0.17 | 1445.3125 | 781.2500 | 203.1250 |    9.2 MB |        3.75 |
| RunFunBlazor       |   819.3 us |  12.47 us |  11.66 us |  0.70 |    0.03 |  218.7500 | 179.6875 | 130.8594 |   1.04 MB |        0.42 |
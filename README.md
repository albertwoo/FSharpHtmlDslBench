Benchmark for fsharp html dsl based on [this docs](https://hamy.xyz/labs/2024-02_fsharp-html-dsl-long-page-benchmarks)

And the code is also based on https://replit.com/@HamiltonGreene/2024-01long-page-html-rendering-benchmarks%23main.fs

Just added [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) related stuff.


BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


| Method             | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------- |-----------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| RunGiraffeView     |   802.3 us | 15.92 us | 35.28 us |  1.00 |    0.00 | 166.0156 | 166.0156 | 166.0156 |   2.45 MB |        1.00 |
| RunFalcoMarkup     |   825.1 us | 16.39 us | 28.70 us |  1.03 |    0.05 | 166.0156 | 166.0156 | 166.0156 |   2.22 MB |        0.91 |
| RunFelizViewEngine | 3,524.9 us | 44.78 us | 41.89 us |  4.47 |    0.24 | 730.4688 | 562.5000 | 164.0625 |    9.2 MB |        3.75 |
| RunFunBlazor       |   566.8 us | 10.52 us |  9.32 us |  0.72 |    0.04 | 179.6875 | 154.2969 | 135.7422 |   1.04 MB |        0.42 |
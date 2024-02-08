Benchmark for fsharp html dsl based on [this docs](https://hamy.xyz/labs/2024-02_fsharp-html-dsl-long-page-benchmarks)

And the code is also based on https://replit.com/@HamiltonGreene/2024-01long-page-html-rendering-benchmarks%23main.fs

Just added [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) related stuff.


BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

5000 items results:

| Method             | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------- |-----------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| RunGiraffeView     |   788.8 us | 15.47 us | 31.24 us |  1.00 |    0.00 | 166.0156 | 166.0156 | 166.0156 |   2.45 MB |        1.00 |
| RunFalcoMarkup     |   825.8 us | 16.29 us | 25.84 us |  1.04 |    0.05 | 166.0156 | 166.0156 | 166.0156 |   2.22 MB |        0.91 |
| RunFelizViewEngine | 3,395.6 us | 66.09 us | 70.72 us |  4.28 |    0.18 | 730.4688 | 562.5000 | 164.0625 |    9.2 MB |        3.75 |
| RunFunBlazor       |   555.2 us | 10.85 us | 16.24 us |  0.70 |    0.03 | 173.8281 | 149.4141 | 129.8828 |   1.04 MB |        0.42 |

10_000 items results:

| Method             | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|--------:|----------:|----------:|---------:|----------:|------------:|
| RunGiraffeView     |  1.637 ms | 0.0299 ms | 0.0280 ms |  1.00 |    0.00 |  332.0313 |  332.0313 | 332.0313 |    4.9 MB |        1.00 |
| RunFalcoMarkup     |  1.705 ms | 0.0325 ms | 0.0387 ms |  1.04 |    0.03 |  332.0313 |  332.0313 | 332.0313 |   4.44 MB |        0.91 |
| RunFelizViewEngine | 10.221 ms | 0.1976 ms | 0.2705 ms |  6.23 |    0.18 | 1562.5000 | 1015.6250 | 328.1250 |   18.4 MB |        3.76 |
| RunFunBlazor       |  1.236 ms | 0.0244 ms | 0.0532 ms |  0.75 |    0.03 |  285.1563 |  251.9531 | 199.2188 |   2.08 MB |        0.42 |

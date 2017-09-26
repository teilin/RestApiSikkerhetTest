``` ini

BenchmarkDotNet=v0.10.9, OS=Mac OS X 10.12
Processor=Intel Core i7-5557U CPU 3.10GHz (Broadwell), ProcessorCount=4
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |          Method |       Mean |     Error |    StdDev |
 |---------------- |-----------:|----------:|----------:|
 |       PlainText |   2.119 us | 0.0410 us | 0.0472 us |
 | EncryptedString | 226.563 us | 4.0929 us | 3.8285 us |

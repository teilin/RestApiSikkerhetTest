``` ini

BenchmarkDotNet=v0.10.9, OS=Mac OS X 10.12
Processor=Intel Core i7-5557U CPU 3.10GHz (Broadwell), ProcessorCount=4
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |          Method |      Mean |     Error |    StdDev |
 |---------------- |----------:|----------:|----------:|
 |       PlainText |  1.254 us | 0.0100 us | 0.0093 us |
 | EncryptedString | 16.489 us | 0.0530 us | 0.0470 us |

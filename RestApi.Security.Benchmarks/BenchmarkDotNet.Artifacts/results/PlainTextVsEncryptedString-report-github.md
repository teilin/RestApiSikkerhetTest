``` ini

BenchmarkDotNet=v0.10.9, OS=Mac OS X 10.12
Processor=Intel Core i7-5557U CPU 3.10GHz (Broadwell), ProcessorCount=4
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT DEBUG
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |          Method |      Mean |     Error |    StdDev |
 |---------------- |----------:|----------:|----------:|
 |       PlainText |  1.325 us | 0.0205 us | 0.0192 us |
 | EncryptedString | 17.316 us | 0.3168 us | 0.3771 us |

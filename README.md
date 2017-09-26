# RestApi.Security

Biblotek for å kryptere og dekryptere spesifikke properties i modeller.

## EncryptionKeySample

Serialize
{
  "UserName": "sys",
  "UserPassword": "znUS/hixVCRgyHkO2M/scvh7t60Z5nmVs8HVRgrIGPM=",
  "FavoriteColor": "Pink",
  "CreditCardNumber": "gqw880k27qhk0hDxLxMFMrfLMkDY4b5jsV2ni5o9W3CsrWQqu4Sx2gurmXnZC5nk"
}
----
Deserialize
Brukernavn: sys
Kredittkortnummer: 998877665544332211
Favorittfarge: Pink
Password: supersecretpwd

# Benchmarks

KK

## Benchmark ved å plaintext og kryptere felter

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
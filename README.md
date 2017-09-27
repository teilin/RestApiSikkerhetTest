# RestApi.Security.Demo

Demo / test biblotek for å teste måter å kryptere enkelte properties i modeller i ASP.Net Core REST service.

## EncryptionKeySample

Modellen i eksempelet hvor to av propertiene vil bli kryptert.

```
public class UserInfo
{
    public string UserName { get; set; }

    [JsonEncrypt]
    public string UserPassword { get; set; }

    public string FavoriteColor { get; set; }

    [JsonEncrypt]
    public string CreditCardNumber { get; set; }
}
```

Serialize
```
{
  "UserName": "sys",
  "UserPassword": "znUS/hixVCRgyHkO2M/scvh7t60Z5nmVs8HVRgrIGPM=",
  "FavoriteColor": "Pink",
  "CreditCardNumber": "gqw880k27qhk0hDxLxMFMrfLMkDY4b5jsV2ni5o9W3CsrWQqu4Sx2gurmXnZC5nk"
}
```
----
Deserialize
```
Brukernavn: sys
Kredittkortnummer: 998877665544332211
Favorittfarge: Pink
Password: supersecretpwd
```

# Benchmarks

Benchmarksettene brukt er en enkel klasse med fire properties. To av propertiene har JsonEncrypt
attributtet.

## Kryptering

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

 ## Dekryptering

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

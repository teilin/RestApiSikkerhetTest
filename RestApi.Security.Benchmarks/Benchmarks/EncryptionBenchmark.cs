using System;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using RestApi.Security.Attributes;
using RestApi.Security.Resolvers;
using RestApi.Security.Benchmarks.Models;

namespace RestApi.Security.Benchmarks.Benchmarks
{
    public class EncryptionBenchmark
    {
        private readonly UserInfo data;
        private readonly JsonSerializerSettings settings;

        public EncryptionBenchmark()
        {
            settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new EncryptedStringPropertyResolver("super-secret-encryption-string");

            data = new UserInfo()
            {
                UserName = "sys",
                CreditCardNumber = "998877665544332211",
                FavoriteColor = "Pink",
                UserPassword = "supersecretpwd"
            };
        }

        [Benchmark]
        public string PlainText() => JsonConvert.SerializeObject(data);

        [Benchmark]
        public string EncryptedString() => JsonConvert.SerializeObject(data, settings);
    }
}

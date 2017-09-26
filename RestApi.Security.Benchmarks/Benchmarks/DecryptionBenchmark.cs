using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using RestApi.Security.Attributes;
using RestApi.Security.Resolvers;
using RestApi.Security.Benchmarks.Models;

namespace RestApi.Security.Benchmarks.Benchmarks
{
    public class DecryptionBenchmark
    {
		private readonly UserInfo data;
		private readonly JsonSerializerSettings settings;
        private readonly string encryptedString;
        private readonly string plaintextString;

        public DecryptionBenchmark()
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

            plaintextString = JsonConvert.SerializeObject(data);
            encryptedString = JsonConvert.SerializeObject(data, settings);
        }

        [Benchmark]
        public UserInfo PlainText() => JsonConvert.DeserializeObject<UserInfo>(plaintextString);

        [Benchmark]
        public UserInfo EncryptedString() => JsonConvert.DeserializeObject<UserInfo>(encryptedString, settings);
    }
}

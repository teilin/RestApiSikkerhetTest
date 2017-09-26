using System;
using EncryptionKeySample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestApi.Security.Resolvers;

namespace EncryptionKeySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var userInfo = new UserInfo
                {
                    UserName = "sys",
                    CreditCardNumber = "998877665544332211",
                    FavoriteColor = "Pink",
                    UserPassword = "supersecretpwd"
                };

                var settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                settings.ContractResolver = new EncryptedStringPropertyResolver("super-secret-encryption-string");

                Console.WriteLine("Serialize");
                var json = JsonConvert.SerializeObject(userInfo, settings);
                Console.WriteLine(json);
                Console.WriteLine("----");

                Console.WriteLine("Deserialize");
                var userInfo2 = JsonConvert.DeserializeObject<UserInfo>(json, settings);

                Console.WriteLine("Brukernavn: " + userInfo2.UserName);
                Console.WriteLine("Kredittkortnummer: " + userInfo2.CreditCardNumber);
                Console.WriteLine("Favorittfarge: " + userInfo2.FavoriteColor);
                Console.WriteLine("Password: " + userInfo2.UserPassword);

                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
        }
    }
}

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestApi.Security.Attributes;
using RestApi.Security.ValueProvider;

namespace RestApi.Security.Resolvers
{
    public class EncryptedStringPropertyResolver : DefaultContractResolver
    {
        private byte[] encryptionKeyBytes;

        public EncryptedStringPropertyResolver(string encryptionKey)
        {
            if (encryptionKey == null)
                throw new ArgumentNullException(nameof(encryptionKey));

            using(var sha = new SHA256Managed())
            {
                encryptionKeyBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(encryptionKey));
            }
        }

        protected override System.Collections.Generic.IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = base.CreateProperties(type, memberSerialization);

            foreach(JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if(pi != null && pi.GetCustomAttribute(typeof(JsonEncryptAttribute), true) != null)
                {
                    prop.ValueProvider = new EncryptedStringValueProvider(pi, encryptionKeyBytes);
                }
            }

            return props;
        }
    }
}

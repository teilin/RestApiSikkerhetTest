using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestApi.Security.Attributes;
using RestApi.Security.ValueProvider;

namespace RestApi.Security.Resolvers
{
    public class EncryptedCertificatePropertyResolver : DefaultContractResolver
    {
        private readonly byte[] encryptionKeyBytes;

        public EncryptedCertificatePropertyResolver(X509Certificate certificate)
        {
            if (certificate == null)
                throw new ArgumentNullException(nameof(certificate));

            encryptionKeyBytes = certificate.GetPublicKey();
        }

		protected override System.Collections.Generic.IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			var props = base.CreateProperties(type, memberSerialization);

			foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
			{
				PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
				if (pi != null && pi.GetCustomAttribute(typeof(JsonEncryptAttribute), true) != null)
				{
					prop.ValueProvider = new EncryptedStringValueProvider(pi, encryptionKeyBytes);
				}
			}

			return props;
		}
    }
}

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RestApi.Security.ValueProvider
{
    public class EncryptedStringValueProvider : IValueProvider
    {
		private readonly PropertyInfo targetProperty;
		private readonly byte[] encryptionKey;

		public EncryptedStringValueProvider(PropertyInfo targetProperty, byte[] encryptionKey)
		{
			this.targetProperty = targetProperty;
			this.encryptionKey = encryptionKey;
		}

		public object GetValue(object target)
		{
			string value = (string)targetProperty.GetValue(target);
			byte[] buffer = Encoding.UTF8.GetBytes(value);

			using (MemoryStream inputStream = new MemoryStream(buffer, false))
			using (MemoryStream outputStream = new MemoryStream())
			using (AesManaged aes = new AesManaged { Key = encryptionKey })
			{
				byte[] iv = aes.IV;  // first access generates a new IV
				outputStream.Write(iv, 0, iv.Length);
				outputStream.Flush();

				ICryptoTransform encryptor = aes.CreateEncryptor(encryptionKey, iv);
				using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
				{
					inputStream.CopyTo(cryptoStream);
				}

				return Convert.ToBase64String(outputStream.ToArray());
			}
		}

		public void SetValue(object target, object value)
		{
			byte[] buffer = Convert.FromBase64String((string)value);

			using (MemoryStream inputStream = new MemoryStream(buffer, false))
			using (MemoryStream outputStream = new MemoryStream())
			using (AesManaged aes = new AesManaged { Key = encryptionKey })
			{
				byte[] iv = new byte[16];
				int bytesRead = inputStream.Read(iv, 0, 16);
				if (bytesRead < 16)
				{
					throw new CryptographicException("IV is missing or invalid.");
				}

				ICryptoTransform decryptor = aes.CreateDecryptor(encryptionKey, iv);
				using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
				{
					cryptoStream.CopyTo(outputStream);
				}

				string decryptedValue = Encoding.UTF8.GetString(outputStream.ToArray());
				targetProperty.SetValue(target, decryptedValue);
			}
		}
    }
}

using System;
using RestApi.Security.Attributes;

namespace RestApi.Security.Benchmarks.Models
{
    public class UserInfo
    {
		public string UserName { get; set; }

		[JsonEncrypt]
		public string UserPassword { get; set; }

		public string FavoriteColor { get; set; }

		[JsonEncrypt]
		public string CreditCardNumber { get; set; }
    }
}

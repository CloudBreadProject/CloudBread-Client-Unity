using System;

namespace CloudBread.Authentication
{
	public class AuthenticationFacebook
	{
		public AuthenticationFacebook ()
		{
		}

		class AuthData{
			public string authenticationToken { get; set; }
			public AzureUserData user { get; set; }
		}

		class AzureUserData{
			public string userId { get; set; }
		}
	}
}


using System;

namespace CloudBread.Authentication
{
	public class AuthenticationToken
	{
	}

	public class FacebookGoogleAuthenticationToken : AuthenticationToken
	{
		public string access_token;
	}

	public class GoogleAuthenticationToken : AuthenticationToken
	{
		public string access_token;
		public string id_token;
		public string authorization_code;
	}

	public class MicrosoftAuthenticationToken : AuthenticationToken
	{
		public string authenticationToken;
	}
}


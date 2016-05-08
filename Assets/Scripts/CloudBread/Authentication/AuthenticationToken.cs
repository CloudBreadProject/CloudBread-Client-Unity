using System;
using UnityEngine;

namespace CloudBread.Authentication
{
	public class AuthenticationToken
	{
		static int request;
		static int response;
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

//	[Serializable]
	public partial class FacebookAuthenticationToken {
		[SerializeField]
		public Request request;

		[SerializeField]
		public Response response;


		public struct Response{

		}

		public struct Request {
			[SerializeField]
			public string authenticationToken;

			[SerializeField]
			public AzureUserData user;

			[Serializable]
			public struct AzureUserData {
				[SerializeField]
				public string userId;
			}
		}
	}

	[Serializable]
	public struct FacebookAuthenticationTokenResponse {

		[SerializeField]
		public string authenticationToken;

		[SerializeField]
		public AzureUserData user;

		[Serializable]
		public struct AzureUserData {
			[SerializeField]
			public string userId;
		}
	}



	class AuthData{
		public string authenticationToken { get; set; }
		public AzureUserData user { get; set; }
	}

	class AzureUserData{
		public string userId { get; set; }
	}
}


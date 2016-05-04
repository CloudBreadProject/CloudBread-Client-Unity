using System;
using UnityEngine;
//using Unity

namespace CloudBread.Authentication
{
	public class UserAuth : MonoBehaviour
	{
		public UserAuth ()
		{
		}

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

		public enum AuthenticationProvider
		{
			// Summary:
			//     Microsoft Account authentication provider.
			MicrosoftAccount = 0,
			//
			// Summary:
			//     Google authentication provider.
			Google = 1,
			//
			// Summary:
			//     Twitter authentication provider.
			Twitter = 2,
			//
			// Summary:
			//     Facebook authentication provider.
			Facebook = 3,
		}

		private Action<string,WWW> Callback_Success;
		private Action<string,WWW> Callback_Error;

		public void Login(AuthenticationProvider provider, string ServerAddress, string token, Action<string, WWW> callback_success, Action<string, WWW> callback_error){
			var path = ".auth/login/" + provider.ToString().ToLower();

			AuthenticationToken authToken = CreateToken(provider, token);

			string json = JsonUtility.ToJson(authToken);
			print (json);

			Callback_Success = callback_success;
			Callback_Error = callback_error;

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			helper.POST ("Login", ServerAddress + path, json);
		}

		public void Login(string ServerAddress, AuthenticationProvider provider, AuthenticationToken token, Action<string, WWW> callback_success, Action<string, WWW> callback_error){
			var path = ".auth/login/" + provider.ToString().ToLower();

			string json = JsonUtility.ToJson(token);
			print (json);

			Callback_Success = callback_success;
			Callback_Error = callback_error;

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			helper.POST ("Login", ServerAddress + path, json);
		}

		public void OnHttpRequest(string id, WWW www) {
			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest -= OnHttpRequest;

			if (www.error != null) {
				//			Debug.Log ("[Error] " + www.error);
				Callback_Error(id,www);
			} else {
				//			Debug.Log (www.text);
				Callback_Success(id, www);
			}
		} 

		private static AuthenticationToken CreateToken(AuthenticationProvider provider, string token)
		{
			AuthenticationToken authToken = new AuthenticationToken();
			switch (provider)
			{
			case AuthenticationProvider.Facebook:
			case AuthenticationProvider.Google:
			case AuthenticationProvider.Twitter:
				{
					authToken = new FacebookGoogleAuthenticationToken() { access_token = token };
					break;
				}
			case AuthenticationProvider.MicrosoftAccount:
				{
					authToken = new MicrosoftAuthenticationToken() { authenticationToken = token };
					break;
				}
			}
			return authToken;
		}
	}


}


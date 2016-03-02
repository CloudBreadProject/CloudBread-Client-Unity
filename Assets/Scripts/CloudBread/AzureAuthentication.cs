using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class AzureAuthentication : MonoBehaviour {
	
	public class AuthenticationToken
	{
	}
	public class FacebookGoogleAuthenticationToken : AuthenticationToken
	{
		public string access_token;
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

	private string ServerAddress = "";

	private Action<string,WWW> Callback_Success;
	private Action<string,WWW> Callback_Error;

	public void Login(AuthenticationProvider provider, string ServerAddress, string token, Action<string, WWW> callback_success, Action<string, WWW> callback_error){
		var path = ".auth/login/" + provider.ToString().ToLower();

		AuthenticationToken authToken = CreateToken(provider, token);

		var json = JsonParser.Write(authToken);
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


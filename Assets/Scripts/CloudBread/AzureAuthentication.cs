using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class AzureAuthentication : MonoBehaviour {

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

//	public AzureAuthentication (AuthenticationProvider provider, string ServerAddress, Action<string, Dictionary<string, object>> callback){
//		this.ServerAddress = ServerAddress;
//	}

	public void Login(AuthenticationProvider provider, string ServerAddress, string token){
		var path = "login/" + provider.ToString().ToLower();

		AuthenticationToken authToken = CreateToken(provider, token);

		var json = JsonParser.Write(authToken);
		print (json);

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;

		helper.POST ("a", ServerAddress + path, json);

	}

	public void OnHttpRequest(string id, WWW www) {
		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest -= OnHttpRequest;

		if (www.error != null) {
			Debug.Log ("[Error] " + www.error);
//			RequestResultJson = www.error;
		} else {
			Debug.Log (www.text);
		}
	}

//	public LoginHandler(IRestResponse<MobileServiceUser> restResponse, RestRequestAsyncHandle handle){
//
//	}

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

	public string CreateToken(string actual_user_id, string accessToken){
		string json = "{ \"facebook\":{ \"userId\":\"Facebook:"+actual_user_id + "\", \"accessToken\":\"" + accessToken + "\" } }";
		Debug.Log (json);
		return json;
	}


}

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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class CBLoginUI : CBBaseUI {

	// Use this for initialization
	void Start () {
//		azure_auth = new AzureAuthentication ();
	}

	private AzureAuthentication azure_auth;

	private string facebookToken = "";
	private string facebookUserID = "";

	private void facbookLogin(){

		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...

			var perms = new List<string>(){"public_profile", "email", "user_friends"};
			FB.LogInWithReadPermissions(perms, AuthCallback);
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}
		

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
			Debug.Log (aToken.TokenString);
			facebookToken = aToken.TokenString;
			facebookUserID = aToken.UserId;
//			var a = azure_auth.CreateToken (aToken.UserId, aToken.TokenString);
			AzureAuthentication azure = new AzureAuthentication();
			azure.Login (AzureAuthentication.AuthenticationProvider.Facebook, ServerAddress, facebookToken);
//			Debug.Log (a);

		} else {
			Debug.Log("User cancelled login");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	public void OnGUI()
	{
		GUILayout.BeginArea (MainAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ();
					if (GUILayout.Button ("Facebook 인증", GUILayout.Width (100))) {
						facbookLogin ();
						
					}
					GUILayout.Button ("Twitter 인증", GUILayout.Width (100));
					GUILayout.Button ("Google ID 인증", GUILayout.Width (100));
					GUILayout.Button ("Microsoft ID 인증", GUILayout.Width (100));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
					GUILayout.Label ("UserID : ", GUILayout.Width (200));
					GUILayout.Label (facebookUserID, GUILayout.Width (200));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
					GUILayout.Label ("Facebook Token : ", GUILayout.Width (200));
					GUILayout.Label (facebookToken, GUILayout.Width (200));
				GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
		GUILayout.EndArea ();

	}


}

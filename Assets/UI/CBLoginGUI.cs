using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class CBLoginUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		azure_auth = new AzureAuthentication ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private AzureAuthentication azure_auth;

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
			var a = azure_auth.CreateToken (aToken.UserId, aToken.TokenString);
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
			if (GUILayout.Button ("Facebook 인증", GUILayout.Width (100))) {
				facbookLogin ();
				
			}
			if (GUILayout.Button ("Facebook web", GUILayout.Width (100))) {
				
			Application.ExternalCall("GetCurrentUser");
			}
			GUILayout.Button ("Twitter 인증", GUILayout.Width (100));
			GUILayout.Button ("Google ID 인증", GUILayout.Width (100));
			GUILayout.Button ("Microsoft ID 인증", GUILayout.Width (100));
		GUILayout.EndArea ();

	}


}

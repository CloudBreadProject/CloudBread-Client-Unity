using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using Facebook.Unity;

public class ExampleCBFacebookAuthUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width/2 - (_contentWidth/2), 50, _contentWidth, Screen.height - 50);
	}

	private string ServerAddress = "https://<Your Address>.azurewebsites.net/";

	private AzureAuthentication azureAuth;

	private string facebookToken = "";
	private string facebookUserID = "";

	private bool facebookLogined = false;
	private bool acquireUserToken = false;

	private string AuthToken;
	private string UserID;

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

			facebookToken = aToken.TokenString;
			facebookUserID = aToken.UserId;
			facebookLogined = true;

			// AuzreAuthentication 을 사용하여 인증 토큰 가져 오기
			azureAuth = new AzureAuthentication();
			azureAuth.Login (AzureAuthentication.AuthenticationProvider.Facebook, ServerAddress, facebookToken, Login_success, Login_error);

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

	public void Login_success(string id, WWW www){
		acquireUserToken = true;

		string resultJson = www.text;
		AuthData resultData = JsonParser.Read<AuthData> (resultJson);
		AuthToken = resultData.authenticationToken;
		UserID = resultData.user.userId;

		AzureMobileAppRequestHelper.AuthToken = AuthToken;

		ResponseJSonData = resultJson;
	}

	public void Login_error(string id, WWW www){
		ResponseJSonData = "[Error] : " + www.error;

	}


	private Rect _contentAreaRect;
	private float _contentWidth = 700;
	private Vector2 scrollPosition;
	private string ResponseJSonData;

	public void OnGUI()
	{
		GUILayout.BeginArea (_contentAreaRect);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(_contentAreaRect.width), GUILayout.Height(_contentAreaRect.height));
		GUILayout.BeginVertical ();
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Facebook 인증", GUILayout.Width (170))) {
			facbookLogin ();
		}
		GUILayout.Button ("Twitter 인증", GUILayout.Width (170));
		GUILayout.Button ("Google ID 인증", GUILayout.Width (170));
		GUILayout.Button ("Microsoft ID 인증", GUILayout.Width (170));
		GUILayout.EndHorizontal ();

		if (facebookLogined) {
			GUILayout.Label ("");
			GUILayout.Label ("Facebook Data : ");
			GUILayout.BeginVertical ("box");
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("UserID : ", GUILayout.Width (150));
			GUILayout.Label (facebookUserID, GUILayout.Width (450));
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("Facebook Token : ", GUILayout.Width (150));
			GUILayout.Label (facebookToken, GUILayout.Width (450));
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();

		}

		if (acquireUserToken) {
			GUILayout.Label ("");
			GUILayout.Label ("User Auth Data : ");
			GUILayout.BeginVertical ("box");
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("Authentication Token : ", GUILayout.Width (150));
			GUILayout.Label (AuthToken, GUILayout.Width (450));
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("User ID : ", GUILayout.Width (150));
			GUILayout.Label (UserID, GUILayout.Width (450));
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
		}
		GUILayout.Label ("");
		GUILayout.Label ("Request Result : ");
		ResponseJSonData = GUILayout.TextArea (ResponseJSonData, GUILayout.Width(_contentWidth-35), GUILayout.Height(300));
		GUILayout.EndVertical ();
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}
}

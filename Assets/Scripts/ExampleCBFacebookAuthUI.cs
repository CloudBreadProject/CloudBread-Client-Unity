using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using Facebook.Unity;

public class ExampleCBFacebookAuthUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width/2 - (_contentWidth/2), 10, _contentWidth, Screen.height - 50);
	}

	private string ServerAddress = "https://<Your Address>.azurewebsites.net/";

	private AzureAuthentication azureAuth;

	private string facebookToken = "";
	private string facebookUserID = "";

	private bool facebookLogined = false;
	private bool acquireUserToken = false;

	private string AuthToken;
	private string UserID;

	// @TODO Facebook Login SDK Active!
	private void facbookLogin(){
	}

	// @TODO get Facebook Token using Facebook SDK

	// @TODO get Response
	public void Login_success(string id, WWW www){
		acquireUserToken = true;

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

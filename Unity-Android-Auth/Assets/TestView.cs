using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class TestView : MonoBehaviour {

	private string statusStr = "";
	private string TokenStr = "";
	private string idToken = "";

	private string userName = "";
	private string userEmail = "";

	private GUIStyle myStyle = new GUIStyle();

	// Use this for initialization
	void Start () {

		myStyle.fontSize = 50;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void buttonClicked(){


		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			print("Success : "+success);
			statusStr = success.ToString();

			var token = PlayGamesPlatform.Instance.GetServerAuthCode();
			TokenStr = token;
			print(token);
			//			print(PlayGamesPlatform.Instance.GetIdToken().ToString());

			idToken = PlayGamesPlatform.Instance.GetIdToken();

			userName = PlayGamesPlatform.Instance.GetUserDisplayName();

			userEmail = PlayGamesPlatform.Instance.GetUserEmail();

//			PlayGamesPlatform.Instance.getid

//			GooglePlayGames.OurUtils.PlayGamesHelperObject.RunOnGameThread(() => {
//
//				PlayGamesPlatform.Instance.GetServerAuthCode((string code) =>
//					{                            
////						Debug.Log("Status: " + status.ToString());
////						Debug.Log("Code: " + code);
//						token = code;
//					});
//
//			});


		});

//		GoogleSignInAccount
	}


	void OnGUI(){
		GUILayout.Label ("aaa");
		GUILayout.BeginVertical ();
		{
			GUILayout.Label (statusStr, myStyle);

			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("GetServerAuthCode : ", myStyle);
				GUILayout.TextField (TokenStr, myStyle);
			}
			GUILayout.EndHorizontal ();


			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("IDToken : ", myStyle);

				GUILayout.TextField (idToken, myStyle);

			}
			GUILayout.EndHorizontal ();


			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Text : ", myStyle);
				GUILayout.TextField ("aaa", myStyle);

			}
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("User Name  : ", myStyle);
				GUILayout.TextField (userName, myStyle);

			}
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Email  : ", myStyle);
				GUILayout.TextField (userEmail, myStyle);

			}
			GUILayout.EndHorizontal ();

			if (GUI.Button (new Rect (10, 500, 100, 50), "Generate"))
				buttonClicked ();
		}
		GUILayout.EndVertical ();
	}
}

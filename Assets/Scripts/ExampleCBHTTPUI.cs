using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class ExampleCBHTTPUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width/2 - _contentWidth / 2, Screen.height/2 - _contentHeight / 2, _contentWidth, _contentHeight);
	}

	private string ServerAddress = "https://<Your Address>.azurewebsites.net/";
	private string PathString = "api/ping";

	private string ResponseData = "";
	private string RequestData = "";

	/*
	 * 	// Headers
	/*
		Accept:application/json
		X-ZUMO-VERSION:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		X-ZUMO-FEATURES:AJ
		ZUMO-API-VERSION:2.0.0
		Content-Type:application/json
	 *
	 */
	private void HTTPRequestSend (){
		var serverEndPoint = ServerAddress + "api/ping";

		Dictionary<string, string> Header = new Dictionary<string, string> ();

		Header.Add ("Accept", "application/json");
		Header.Add ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		Header.Add ("X-ZUMO-FEATURES", "AJ");
		Header.Add ("ZUMO-API-VERSION", "2.0.0");
		Header.Add ("Content-Type", "application/json");

		WWW www = new WWW(serverEndPoint, null, Header);
		StartCoroutine(WaitForRequest(www));
	}
		
	private void HTTPRequestAuthSend(){
		var serverEndPoint = ServerAddress + "api/ping";

		Dictionary<string, string> Header = new Dictionary<string, string> ();
		Header.Add ("Accept", "application/json");
		Header.Add ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		Header.Add ("X-ZUMO-FEATURES", "AJ");
		Header.Add ("ZUMO-API-VERSION", "2.0.0");
		Header.Add ("Content-Type", "application/json");
		if(AzureMobileAppRequestHelper.AuthToken!= null)
			Header.Add ("x-zumo-auth", AzureMobileAppRequestHelper.AuthToken);


		WWW www = new WWW(serverEndPoint, null, Header);
		StartCoroutine(WaitForRequest(www));
	}

	private IEnumerator  WaitForRequest(WWW www) {

		yield return www;

		if (www.error != null) {
			
			ResponseData = "[Error] " + www.error;

		} else {
			
			ResponseData = www.text;

		}

		www.Dispose();
	}

	private Rect _contentAreaRect;
	private float _contentWidth = 600;
	private float _contentHeight = 800;

	public void OnGUI(){
		GUILayout.BeginArea(_contentAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Server Address : ", GUILayout.Width(100));
					ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(_contentWidth - 125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Path : ", GUILayout.Width(100));
					PathString = GUILayout.TextField(PathString, GUILayout.Width(_contentWidth-125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
					if (GUILayout.Button ("Send", GUILayout.Width (80))) {
						HTTPRequestSend ();
					}
					if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
						HTTPRequestAuthSend ();
					}
				GUILayout.EndHorizontal ();
				GUILayout.Label ("");
				GUILayout.Label ("Request Data : ");
				RequestData = GUILayout.TextArea (RequestData, GUILayout.Width(_contentWidth), GUILayout.Height(50));

				GUILayout.Label ("");
				GUILayout.Label ("Response Data : ");
				ResponseData = GUILayout.TextArea (ResponseData, GUILayout.Width(_contentWidth), GUILayout.Height(300));
			GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

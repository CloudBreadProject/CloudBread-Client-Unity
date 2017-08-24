using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using System.Text;

public class CBMainGUI : CBBaseUI
{
	// Use this for initialization
	void Start () {
		ContentAreaRect = new Rect (MainAreaRect.width/2 - (contentWidth/2), MainAreaRect.y, contentWidth, MainAreaRect.height);
	}

	public int contentWidth = 700;
	private Rect ContentAreaRect;

	private string PathString = "api/ping";

	// Headers
	/*
	 * 	Accept-Encoding:gzip
		Accept:application/json
		X-ZUMO-VERSION:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		X-ZUMO-FEATURES:AJ
		ZUMO-API-VERSION:2.0.0
		User-Agent:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		Content-Type:application/json

		Accept-Encoding: gzip, deflate, sdch
		Accept-Language: ko-KR,ko;q=0.8,en-US;q=0.6,en;q=0.4

	 *
	 */

	private void HTTPRequestSend (){
		var serverEndPoint = ServerAddress + PathString;

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
		var serverEndPoint = ServerAddress + PathString;

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
			RequestResultJson = "[Error]" + www.error;
		}else{
			RequestResultJson = www.text;
		}
		www.Dispose();
	}
		

	public void OnGUI(){
		GUILayout.BeginArea(ContentAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Server Address : ", GUILayout.Width(180));
					ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(500));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Path : ", GUILayout.Width(180));
					PathString = GUILayout.TextField(PathString, GUILayout.Width(500));
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
					GUILayout.Label ("결 과 : ");
					
		RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Width(contentWidth), GUILayout.Height(300));
			GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

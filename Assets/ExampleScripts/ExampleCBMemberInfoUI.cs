using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;

public class ExampleCBMemberInfoUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width/2 - _contentWidth, 50, _contentWidth, _contentHeight);
		_contentAreaRect2 = new Rect (Screen.width/2, 50, _contentWidth, _contentHeight);

		Request_CBSelLoginInfo ();
	}

	private string ServerAddress = "https://<Your Address>.azurewebsites.net/";

	private string PathStringLogin = "api/CBSelLoginInfo";
	private string PathStringUpdate = "api/CBCOMUdtMember";

	private string requestData_Login = "";
	private string responseData_Login = "";

	private string requestData_Update = "";
	private string responseData_Update = "";

	Dictionary <string, object> [] ResultDicData;

	private CloudBreadAzure cloudbread;

	// Request Data
	//		"memberID": "aaa",
	//		"memberPWD": "MemberPWD",
	//		"LastDeviceID": "LastDeviceID",
	//		"LastIPaddress": "LastIPaddress",
	//		"LastMACAddress": "LastMACAddress"

	// @TODO Request "CBSelLoginInfo"
	private void Request_CBSelLoginInfo(){
		
	}

	// @TODO Response Callback Method
	private void CallBack_SelLoginInfo(string jsonString, Dictionary<string, object>[] jsonRequestData){
		
	}

	// @TODO Request "CBCOMUdtMember"
	private void Request_CBCOMUdtMember(Dictionary<string, object> rawDicData){
		
	}

	// @TODO Response Callback Method
	private void CallBack_UdtMember(string JsonStr, Dictionary<string,object>[] JsonData){
		
	}
		
	private void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){
		print ("" + row + " 번째 User Clicked");
		modifyClickedBool = true;
		Request_CBCOMUdtMember (rawDicData);
	}

	private Rect _contentAreaRect;
	private Rect _contentAreaRect2;
	private float _contentWidth = 600;
	private float _contentHeight = 700;
	private Vector2 _scrollPosition;
	private Vector2 _scrollPosition2;

	private bool modifyClickedBool = false;

	public void OnGUI()
	{
		GUILayout.BeginArea(_contentAreaRect);
			GUILayout.BeginHorizontal ();
				_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(600), GUILayout.Height(_contentAreaRect.height));
					GUILayout.BeginVertical ();
						GUILayout.BeginHorizontal ("box");
							GUILayout.Label ("Server Address : ");
							GUILayout.TextField (ServerAddress + "api/CBSelLoginInfo");
						GUILayout.EndHorizontal ();

						GUILayout.BeginVertical();

							GUILayout.BeginVertical ();
								GUILayout.Label ("Request Json Data");
								requestData_Login = GUILayout.TextArea (requestData_Login);
								GUILayout.Label ("");
								GUILayout.Label ("Response Json Data : ");
								responseData_Login = GUILayout.TextArea (responseData_Login);
							GUILayout.EndVertical ();
							GUILayout.Label ("");
							drawTablewithButtonUserInfo(ResultDicData, "memberID");

						GUILayout.EndVertical();
					GUILayout.EndVertical ();
				GUILayout.EndScrollView ();
			GUILayout.EndHorizontal ();
		GUILayout.EndArea ();

		GUILayout.BeginArea (_contentAreaRect2);
		if (modifyClickedBool) {
			_scrollPosition2 = GUILayout.BeginScrollView(_scrollPosition2, GUILayout.Width(600), GUILayout.Height(_contentAreaRect2.height));
				GUILayout.BeginVertical ();
					GUILayout.BeginHorizontal ("box");
						GUILayout.Label ("Server Address : ");
						GUILayout.TextField (ServerAddress + "api/CBCOMUdtMember");
					GUILayout.EndHorizontal ();

					GUILayout.BeginHorizontal();

						GUILayout.BeginVertical ();
						GUILayout.Label ("Request Json Data");
						requestData_Update = GUILayout.TextArea (requestData_Update);
						GUILayout.Label ("");
						GUILayout.Label ("Response Json Data : ");
						responseData_Update = GUILayout.TextArea (responseData_Update);
						GUILayout.EndVertical ();

					GUILayout.EndHorizontal();
				GUILayout.EndVertical ();
			GUILayout.EndScrollView ();
		}

		GUILayout.EndArea ();

	}



	// 세로 테이블
	private void drawTablewithButtonUserInfo(Dictionary<string,object>[] data, string primarykey){
		if (data != null) {
			List<string> headerDatas = new List<string> (data [0].Keys);

			GUILayout.BeginVertical ("box");
			for (int i = 0; i < headerDatas.Count; i++) {
				GUILayout.BeginHorizontal ();
				var headerKey = headerDatas [i];
				GUILayout.Label(headerKey, GUILayout.Width(150));
				for (int j = 0; j < data.Length; j++) {
					var dataDic = data [j];
					if (headerKey.Equals (primarykey)) 
						GUILayout.Label ((string)dataDic [headerKey], GUILayout.Width (120));
					else
						data[j][headerKey] = GUILayout.TextField ((string) dataDic [headerKey], GUILayout.Width (120));
				}
				GUILayout.EndHorizontal ();

			}

			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("", GUILayout.Width (145));
			for (int j = 0; j < data.Length; j++) {
				if (GUILayout.Button ("수 정", GUILayout.Width(120))) {
					modifyClickedBool = true;
					ModifyButtonClicked(j, data[j]);
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();

		}
	}
}

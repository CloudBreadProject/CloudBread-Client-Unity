/*
 * User Info View
 * SelLoginInfo
 * ComUdtMember
 *   "memberID": "aaa",
 *	 "memberPWD": "MemberPWD",
 *	 "LastDeviceID": "LastDeviceID",
 *	 "LastIPaddress": "LastIPaddress",
 *	 "LastMACAddress": "LastMACAddress"
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;

public class CBUserInfoUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		cloudbread = new CloudBreadAzure (ServerAddress);
		cloudbread.CBSelLoginInfo (CallBack);

		var header = cloudbread.CBSelLoginInfoHeaderDIc;
		var jsonStr = JsonParser.WritePretty (header);
		requestJson = jsonStr;

	}

	private CloudBreadAzure cloudbread;

	private string requestJson = "";

	Vector2 scrollPosition2;
	private bool modifyClickedBool = false;

	private string requestJson_modify = "";
	private string responseJson_modify = "";

	public override void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){
		print ("" + row + " 번째 User Clicked");

		cloudbread.CBCOMUdtMember (rawDicData, CallBack_UdtMember);
		var headerDic = cloudbread.CBCOMUdtMemberHeaderDic;
		requestJson_modify = JsonParser.WritePretty (headerDic);
	}

	private void CallBack_UdtMember(string JsonStr, Dictionary<string,object>[] JsonData){
		responseJson_modify = JsonStr;
	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		GUILayout.BeginHorizontal ();
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(600), GUILayout.Height(MainAreaRect.height));
		GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Server Address : ");
				GUILayout.TextField (ServerAddress + "api/CBSelLoginInfo");
			GUILayout.EndHorizontal ();

			GUILayout.BeginVertical();
				
				GUILayout.BeginVertical ();
					GUILayout.Label ("Request Json Data");
					requestJson = GUILayout.TextArea (requestJson);
					GUILayout.Label ("");
					GUILayout.Label ("Response Json Data : ");
					RequestResultJson = GUILayout.TextArea (RequestResultJson);
				GUILayout.EndVertical ();
				GUILayout.Label ("");
				drawTablewithButtonUserInfo(ResultDicData, "memberID");
				
			GUILayout.EndVertical();
		GUILayout.EndVertical ();
		GUILayout.EndScrollView ();

		if (modifyClickedBool) {
			scrollPosition2 = GUILayout.BeginScrollView(scrollPosition2, GUILayout.Width(600), GUILayout.Height(MainAreaRect.height));
			GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Server Address : ");
				GUILayout.TextField (ServerAddress + "api/CBCOMUdtMember");
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal();

				GUILayout.BeginVertical ();
					GUILayout.Label ("Request Json Data");
					requestJson_modify = GUILayout.TextArea (requestJson_modify);
					GUILayout.Label ("");
					GUILayout.Label ("Response Json Data : ");
					responseJson_modify = GUILayout.TextArea (responseJson_modify);
				GUILayout.EndVertical ();

			GUILayout.EndHorizontal();
			GUILayout.EndVertical ();
			GUILayout.EndScrollView ();
		}
		GUILayout.EndHorizontal ();
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

[System.Serializable]
public class CBUserData{
	
}

/*
 * [
 * 	{
 * 		"memberID":"aaa",
 * 		"memberPWD":"MemberPWD",
 * 		"emailAddress":"aaa@aa.com",	
 * 		"emailConfirmedYN":"Y",
 * 		"phoneNumber1":"PhoneNumber1",
 * 		"phoneNumber2":"PhoneNumber2",
 * 		"piNumber":"PINumber",
 * 		"name1":"Name1",
 * 		"name2":"Name2",
 * 		"name3":"Name3",
 * 		"dob":"19900101",
 * 		"recommenderID":"RecommenderID",
 * 		"memberGroup":"MemberGroup",
 * 		"lastDeviceID":"MemberPWD",
 * 		"lastIPaddress":"MemberPWD",
 * 		"lastLoginDT":"2016-02-27 06:51:40.0001935",
 * 		"lastLogoutDT":"2016-02-26 16:50:00.5590381",
 * 		"lastMACAddress":"MemberPWD",
 * 		"accountBlockYN":"N",
 * 		"accountBlockEndDT":"1900-01-01",
 * 		"anonymousYN":"N",
 * 		"_3rdAuthProvider":"3rdAuthProvider",
 * 		"_3rdAuthID":"3rdAuthIDaaa",
 * 		"_3rdAuthParam":"3rdAuthParam",
 * 		"pushNotificationID":"PushNotificationID",
 * 		"pushNotificationProvider":"PushNotificationProvider",
 * 		"pushNotificationGroup":"PushNotificationGroup",
 * 		"sCol1":"sCol1",
 * 		"sCol2":"sCol2",
 * 		"sCol3":"sCol3",
 * 		"sCol4":"sCol4",
 * 		"sCol5":"sCol5",
 * 		"sCol6":"sCol6",
 * 		"sCol7":"sCol7",
 * 		"sCol8":"sCol8",
 * 		"sCol9":"sCol9",
 * 		"sCol10":"sCol10"
 * 	}
 * ]
 */

public class CBMemberItem
{
	public string memberID;
	public string memberPWD;
	public string emilAddress;
	public string emailConfirmedYN;
	public string phoneNumber1;
	public string phoneNumber2;
	public string piNumber;

}

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
//		CBSelLoginInfoController api = new CBSelLoginInfoController(ServerAddress, SelLoginInfo_Success, SelLoginInfo_Error);

	}

	private void SelLoginInfo_Success(string id, WWW www){
		Debug.Log ("[SelLoginInfo_Success]" + www.text);
	}

	private void SelLoginInfo_Error(string id, WWW www){
		Debug.Log ("[SelLoginInfo_Error]" + www.text);
	}

	private CloudBreadAzure cloudbread;

//	public void CallBack(string jsonString, Dictionary<string, object>[] jsonRequestData){
//		print ("call back methods");
//		ResultDicData = jsonRequestData;
//		RequestResultJson = jsonString;
////		print ("call back methods");
//	}

	private string [] _headerString = {
		"memberID",
		"memberPWD",
		"emailAddress",
		"emailConfirmedYN",
		"phoneNumber1",
		"name1"
	};

//	public void OnGUI()
//	{
//		GUILayout.BeginArea(MainAreaRect);
//			GUILayout.BeginVertical();
//				drawTitleRow(titleData:_headerString);
//				if( ResultDicData!= null)
//					drawTablewithButton (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData);
//
//					RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
//			GUILayout.EndVertical();
//		GUILayout.EndArea ();
//
//	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(MainAreaRect.width), GUILayout.Height(MainAreaRect.height));
			GUILayout.BeginVertical();
				if (ResultDicData != null) {
//					List<string> headers = new List<string>( ResultDicData[0].Keys);
//					drawTitleRow(titleData:headers);
					drawTablewithButtonUserInfo (ResultDicData.Length,  ResultDicData, "memberID");
				}

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}


	public override void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){
		print ("" + row + " 번째 User Clicked");

		cloudbread.CBCOMUdtMember (rawDicData, CallBack);
	}

	public void CallBack2(string jsonString, Dictionary<string, object>[] jsonRequestData){
		print ("call back methods");
//		ResultDicData = jsonRequestData;
		//		print ("call back methods");
	}

	private void drawTablewithButtonUserInfo(int row, Dictionary<string, object>[] data, string PrimaryKey){
		List<string> headerDatas = new List<string>( ResultDicData[0].Keys);
		drawTitleRow (headerDatas);

		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < headerDatas.Count; i++) {
				string key = headerDatas [i];
				if(!key.Equals(PrimaryKey)){
					dic[key] = GUILayout.TextField ((string)dic[key], GUILayout.Width (100));
				}else
					GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}
			if (GUILayout.Button ("수 정", GUILayout.Width (80))) {
				ModifyButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
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

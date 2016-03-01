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

		CBSelLoginInfoController api = new CBSelLoginInfoController(ServerAddress, SelLoginInfo_Success, SelLoginInfo_Error);

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
			GUILayout.BeginVertical();
				GUILayout.BeginHorizontal ();
					GUILayout.Label (ServerEndPoint);
					GUILayout.Button ("확인");
				GUILayout.EndHorizontal ();
				drawTitleRow (_headerString);
				if (ResultDicData != null) {
//					List<string> headers = new List<string>( ResultDicData[0].Keys);
//					drawTitleRow(titleData:headers);
					drawTablewithButton (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData, "memberID");
				}

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
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

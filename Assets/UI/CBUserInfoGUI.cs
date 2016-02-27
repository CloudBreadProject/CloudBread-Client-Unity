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
		ServerEndPoint = ServerAddress + "api/CBSelLoginInfo";
//		ServerEndPoint = "http://dw-cloudbread2.azurewebsites.net/api/CBSelLoginInfo";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	private string jsonareastring = "";
	private Dictionary<string, object>[] LoginInfoData;

	private string [] _headerString = {"memberID", "memberPWD", "emailAddress", "emailConfirmedYN", "phoneNumber1","name1"};

	public Dictionary<string, object> CreateJsonData(){
		//		"memberID": "aaa",
		//		"memberPWD": "MemberPWD",
		//		"LastDeviceID": "LastDeviceID",
		//		"LastIPaddress": "LastIPaddress",
		//		"LastMACAddress": "LastMACAddress"
		var JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "aaa");
		JsonDic.Add ("memberPWD", "MemberPWD");
		JsonDic.Add ("LastDeviceID", "LastDeviceID");
		JsonDic.Add ("LastIPaddress", "LastIPaddress");
		JsonDic.Add ("LastMACAddress", "LastMACAddress");

		return JsonDic;
	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
			GUILayout.BeginVertical();
//				drawTable (1, _headerString.Length, _headerString);
				drawTitleRow(titleData:_headerString);
				if(LoginInfoData != null)
					drawTable (LoginInfoData.Length, _headerString.Length, _headerString, LoginInfoData);

				jsonareastring = GUILayout.TextArea (jsonareastring, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndArea ();

	}

	void OnHttpRequest(int id, WWW www) {
		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest -= OnHttpRequest;

		if (www.error != null) {
			Debug.Log ("[Error] " + www.error);
		} else {
			Debug.Log (www.text);
			jsonareastring = www.text;
			LoginInfoData = (Dictionary<string, object>[]) JsonParser.Read2Object(jsonareastring);

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

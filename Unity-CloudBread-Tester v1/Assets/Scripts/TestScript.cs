using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;

public class TestScript : MonoBehaviour {
	string jsonTest = "[{\"noticeID\":\"NoticeID1\",\"noticeCategory1\":\"NoticeCategory1\",\"noticeCategory2\":\"NoticeCategory2\",\"noticeCategory3\":\"NoticeCategory3\",\"targetGroup\":\"TargetGroup\",\"targetOS\":\"TargetOS\",\"targetDevice\":\"TargetDevice\",\"noticeImageLink\":\"NoticeImageLink\",\"title\":\"title1\",\"content\":\"content\",\"sCol1\":\"sCol1\",\"sCol2\":\"sCol2\",\"sCol3\":\"sCol3\",\"sCol4\":\"sCol4\",\"sCol5\":\"sCol5\",\"sCol6\":\"sCol6\",\"sCol7\":\"sCol7\",\"sCol8\":\"sCol8\",\"sCol9\":\"sCol9\",\"sCol10\":\"sCol10\"},{\"noticeID\":\"NoticeID2\",\"noticeCategory1\":\"NoticeCategory1\",\"noticeCategory2\":\"NoticeCategory2\",\"noticeCategory3\":\"NoticeCategory3\",\"targetGroup\":\"TargetGroup\",\"targetOS\":\"TargetOS\",\"targetDevice\":\"TargetDevice\",\"noticeImageLink\":\"NoticeImageLink\",\"title\":\"title2\",\"content\":\"content\",\"sCol1\":\"sCol1\",\"sCol2\":\"sCol2\",\"sCol3\":\"sCol3\",\"sCol4\":\"sCol4\",\"sCol5\":\"sCol5\",\"sCol6\":\"sCol6\",\"sCol7\":\"sCol7\",\"sCol8\":\"sCol8\",\"sCol9\":\"sCol9\",\"sCol10\":\"sCol10\"},{\"noticeID\":\"NoticeID3\",\"noticeCategory1\":\"NoticeCategory1\",\"noticeCategory2\":\"NoticeCategory2\",\"noticeCategory3\":\"NoticeCategory3\",\"targetGroup\":\"TargetGroup\",\"targetOS\":\"TargetOS\",\"targetDevice\":\"TargetDevice\",\"noticeImageLink\":\"NoticeImageLink\",\"title\":\"title3\",\"content\":\"content\",\"sCol1\":\"sCol1\",\"sCol2\":\"sCol2\",\"sCol3\":\"sCol3\",\"sCol4\":\"sCol4\",\"sCol5\":\"sCol5\",\"sCol6\":\"sCol6\",\"sCol7\":\"sCol7\",\"sCol8\":\"sCol8\",\"sCol9\":\"sCol9\",\"sCol10\":\"sCol10\"},{\"noticeID\":\"NoticeID4\",\"noticeCategory1\":\"NoticeCategory1\",\"noticeCategory2\":\"NoticeCategory2\",\"noticeCategory3\":\"NoticeCategory3\",\"targetGroup\":\"TargetGroup\",\"targetOS\":\"TargetOS\",\"targetDevice\":\"TargetDevice\",\"noticeImageLink\":\"NoticeImageLink\",\"title\":\"title4\",\"content\":\"content\",\"sCol1\":\"sCol1\",\"sCol2\":\"sCol2\",\"sCol3\":\"sCol3\",\"sCol4\":\"sCol4\",\"sCol5\":\"sCol5\",\"sCol6\":\"sCol6\",\"sCol7\":\"sCol7\",\"sCol8\":\"sCol8\",\"sCol9\":\"sCol9\",\"sCol10\":\"sCol10\"}]";
	// Use this for initialization
	void Start () {
		TestString = CBAuthentication.AES_decrypt (token, keyValue, keyValue);

		Notice [] notice = (Notice[]) JsonFx.Json.JsonReader.Deserialize<Notice[]> (jsonTest);

		print ("======================================");
		print (notice [0].id);

		string str = JsonFx.Json.JsonWriter.Serialize(notice);
		print ("======================================");
		print (str);

//		var a = JsonFx.Json.JsonReader.Deserialize<Dictionary<string,string>>(

//		string jsontest2 = "[{\"memberID\":\"test0\",\"level\":\"1\",\"exps\":\"0\",\"points\":\"0\",\"userSTAT1\":\"\"{\\\"totalFloor\\\":1,\\\"maxFloor\\\":1,\\\"maxHp\\\":3,\\\"atk\\\":1,\\\"evade\\\":50,\\\"hit\\\":0,\\\"totalGold\\\":0,\\\"haveGold\\\":0,\\\"totalJewel\\\":0,\\\"haveJewel\\\":0,\\\"inGameGainHeart\\\":0,\\\"totalMonKill\\\":0}\"\",\"userSTAT2\":\"\",\"userSTAT3\":\"\",\"userSTAT4\":\"\",\"userSTAT5\":\"\",\"userSTAT6\":\"\",\"userSTAT7\":\"\",\"userSTAT8\":\"\",\"userSTAT9\":\"\",\"userSTAT10\":\"\",\"sCol1\":\"\",\"sCol2\":\"\",\"sCol3\":\"\",\"sCol4\":\"\",\"sCol5\":\"\",\"sCol6\":\"\",\"sCol7\":\"\",\"sCol8\":\"\",\"sCol9\":\"\",\"sCol10\":\"\"}]";
		Notice oneNotice = new Notice();
		oneNotice.noticeCategory1 = jsonTest;
		string strjson = JsonFx.Json.JsonWriter.Serialize (oneNotice);
		print (strjson);
		var requestDic= JsonFx.Json.JsonReader.Deserialize<Dictionary<string, string>>(strjson);
		print ((string)requestDic["noticeCategory1"]);

		StartCoroutine (SelGameInfo ());

		testJson ();
	}

	IEnumerator SelGameInfo(){
		var serverAdd = "https://decemberocho-cb-fe-ma-dev.azurewebsites.net/api/";
		string url = serverAdd + "CBComSelMemberGameInfoes";

		Dictionary<string,string> body = new Dictionary<string, string> ();
		body.Add ("memberID", "betatest");

		string json = JsonFx.Json.JsonWriter.Serialize (body);
		byte[] jsonbyt = Encoding.UTF8.GetBytes (json);

		WWW www = new WWW (url, jsonbyt, AzureMobileAppRequestHelper.getHeader ());

		print ("~~~~~~~~~~~~~~~~~~~~~~~~~");

		yield return www;

		print (www.text);
//		genString = "";
//		var replacedString = www.text.Replace("\\\"", "");
//		print (replacedString);
		var requestDic= JsonFx.Json.JsonReader.Deserialize<Dictionary<string,string>[]>(www.text);

		Dictionary<string,string> tempDic = requestDic [0];
		print (tempDic ["userSTAT1"]);
//		print(requestDic["userSTAT1"]);

//		var rereplaceString = requestDic ["userSTAT1"].Replace ("&", "\"");
//		print (rereplaceString);

	}

	void testJson(){
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private CBAuthentication Auth;

	private string token = "AFk2+yRQHyvOhJEPZjUYEz4W02jFb+ZNq3od6e/45wJC/YfSZLkmEgzJPkDeeNbzKkveANjfZSlSO/6VXrXpe7GGzGWyFMNJQt5vyJU26H+4liV57PcJg4mJh8A5lJM3jZi4DJaVmO8Bwa+buaOYHA==";
	private string keyValue = "1234567890123456";

	private string TestString = "";

	void OnGUI(){
		GUILayout.BeginVertical ();
		TestString = GUILayout.TextArea (TestString);
		GUILayout.EndVertical ();
	}
}

//[System.Serializable]
public class Notice {

//	[JsonProperty(PropertyName = "FooBar")]

	[JsonFx.Json.JsonName("noticeID")]
	public string id;

	public string noticeCategory1;
	public string noticeCategory2;
	public string noticeCategory3;
	public string targetGroup;
	public string targetOS;
	public string targetDevice;
	public string noticeImageLink;
	public string title;
	public string content;
	public string sCol1;
	public string sCol2;
	public string sCol3;
	public string sCol4;
	public string sCol5;
	public string sCol6;
	public string sCol7;
	public string sCol8;
	public string sCol9;
	public string sCol10;

	[JsonFx.Json.JsonIgnore]
	public string a;
}
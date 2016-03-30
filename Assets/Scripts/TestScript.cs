using UnityEngine;
using System.Collections;
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
//{
//	"noticeID": "NoticeID1",
//	"noticeCategory1": "NoticeCategory1",
//	"noticeCategory2": "NoticeCategory2",
//	"noticeCategory3": "NoticeCategory3",
//	"targetGroup": "TargetGroup",
//	"targetOS": "TargetOS",
//	"targetDevice": "TargetDevice",
//	"noticeImageLink": "NoticeImageLink",
//	"title": "title1",
//	"content": "content",
//	"sCol1": "sCol1",
//	"sCol2": "sCol2",
//	"sCol3": "sCol3",
//	"sCol4": "sCol4",
//	"sCol5": "sCol5",
//	"sCol6": "sCol6",
//	"sCol7": "sCol7",
//	"sCol8": "sCol8",
//	"sCol9": "sCol9",
//	"sCol10": "sCol10"
//},
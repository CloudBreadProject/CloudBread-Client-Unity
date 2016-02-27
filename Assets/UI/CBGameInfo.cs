/*
 * 
 * 	MemberGameInfo 테이블의 정보를 표시 
	MemberGameInfo 테이블의 데이터를 텍스트 박스에 표시 - B37 SelMemberGameInfo
	MemberGameInfo 수정시 텍스트를 수정하고 수정 버튼을 누르면 – B58 CBComUdtMemberGameInfoes

	sCol 컬럼인 여분의 컬럼은 nvarchar(max) 데이터임. 컬럼이 부족할 경우 sCol에 json 기반으로 추가 데이터를 저장/조회도 가능

 */



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBGameInfo : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelMemberGameInfoStages";
		//		ServerEndPoint = "http://dw-cloudbread2.azurewebsites.net/api/CBSelLoginInfo";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string[] _headerString = {"memberGameInfoStageID", "memberID", "stageName", "stageStatus", "category1", "stageStat1"};

	public Dictionary<string, object> CreateJsonData(){
		//		"memberID": "aaa",
		//		"memberPWD": "MemberPWD",
		//		"LastDeviceID": "LastDeviceID",
		//		"LastIPaddress": "LastIPaddress",
		//		"LastMACAddress": "LastMACAddress"
		var JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "aaa");

		return JsonDic;
	}

	public void OnGUI(){
		GUILayout.BeginArea(MainAreaRect);
			GUILayout.BeginVertical();
				//				drawTable (1, _headerString.Length, _headerString);
				drawTitleRow(titleData:_headerString);
				if( ResultDicData!= null)
					drawTable (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData);

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndArea ();
	
		
//		string[] datas = {
//			"memberid",
//			"phonenumber1",
//			"phonenumber2",
//			"plnumber",
//			"name1",
//			"memberid",
//			"phonenumber1",
//			"phonenumber2",
//			"plnumber",
//			"name1"
//		};
//		drawTable (2, 5, datas);
	}
}

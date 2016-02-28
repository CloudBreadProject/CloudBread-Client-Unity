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
using AssemblyCSharp;

public class CBMemberGameInfoGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		cloudbread = new CloudBreadAzure (ServerAddress);
		cloudbread.CBComSelMemberGameInfoes (CallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private CloudBreadAzure cloudbread;

	private string[] _headerString = {
		"memberID",
		"level",
		"exps",
		"points",
		"userSTAT1"
	};

//	public void OnGUI(){
//		GUILayout.BeginArea(MainAreaRect);
//			GUILayout.BeginVertical();
//				//				drawTable (1, _headerString.Length, _headerString);
//				drawTitleRow(titleData:_headerString);
//				if( ResultDicData!= null)
//					drawTablewithButton (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData, "memberID");
//
//				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
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
//								List<string> headers = new List<string>( ResultDicData[0].Keys);
//								drawTitleRow(titleData:headers);
			drawTablewithButton (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData, "memberID");
		}

		RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
		GUILayout.EndVertical();
		GUILayout.EndArea ();

	}

	public override void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){
		print ("" + row + " 번째 User Clicked");

		cloudbread.CBComUdtMemberGameInfoes (rawDicData, CallBack);
	}
}

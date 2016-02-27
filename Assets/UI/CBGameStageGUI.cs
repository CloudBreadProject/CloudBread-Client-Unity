/*
 * MemberGameInfoStage 테이블의 정보를 표시

Member의 스테이지 리스트를 표시 B46 SelMemberGameInfoStages
개별 스테이지 상세 정보를 표시 B63 CBCOMSelMemberGameInfoStages
스테이지 정보 수정일 경우  B64 CBComUdtMemberGameInfoStages 수행
스테이지 추가시 B44 UdtMemberGameInfoStage 수행해 memberGameInfo와 Stage Insert를 수행


*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBGameStageGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelMemberGameInfoStages";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string [] _headerString = {"memberGameInfoStageID", "memberID","stageName","stageStatus","category1", "category2"};

	public Dictionary<string, object> CreateJsonData(){
		var JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "aaa");

		return JsonDic;
	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		GUILayout.BeginVertical();
		//				drawTable (1, _headerString.Length, _headerString);
		drawTitleRow(titleData:_headerString);
		if( ResultDicData!= null)
			drawTable (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData);

		RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
		GUILayout.EndVertical();
		GUILayout.EndArea ();

	}
}

/*
 * 이벤트 처리
GameEvents는 이벤트 정보를 저장하고, GameEventMember는 이벤트에 참여한(추가로 이벤트 참여 제한) member를 기록하는 테이블
이벤트는 기간에 따라 표시되고 member의 조건에 맞는 이벤트 데이터 조회됨
이벤트들 리스트 조회를 위해 B12 SelGameEvents 수행
클라이언트 화면에서는 “이벤트 참여”버튼을 누르면 B13 UdtGameEventMemberToItem 수행해 MemberItem에 이벤트 아이템 등을 저장. 
UdtGameEventMemberToItem을 수행하면 내부에서 GameEventMember에 저장되고, 이후 조건에 따라 리스팅 되지 않음.

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBEventsGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelGameEvents";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string [] _headerString = {"gameEventID" ,"eventCategory1", "eventCategory2", "eventCategory3", "itemListID", "itemCount", "itemstatus","title", "content"};


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

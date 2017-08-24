/*Notices 테이블의 정보를 표시
공지사항은 기간에 따라 표시되고 기간 조건에 맞는 데이터 조회만 존재

공지사항들 조회를 위해 B11 SelNotices 수행
클라이언트 화면에서는 “오늘 하루 표시하지 않음”버튼을 주고, SelNotices 를 해도 하루간 표시하지 않도록 클라이언트에 저장하도록 클라이언트 개발자가 수행하는 방안을 권장
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBNoticeGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelNotices";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	private string[] _headerString = {
//		"noticeID",
//		"noticeCategory1",
//		"noticeCategory2",
//		"targetGroup",
//		"targetOS",
//		"targetDevice",
//		"noticeImageLink",
//		"title",
//		"content"
//	};

	public Dictionary<string, object> CreateJsonData(){
		var JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "aaa");

		return JsonDic;
	}

	private void NotShowNotice(int row, Dictionary<string, object> NoticeData){

	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(MainAreaRect.width), GUILayout.Height(MainAreaRect.height));
			GUILayout.BeginVertical();
				//				drawTable (1, _headerString.Length, _headerString);
//				drawTitleRow(titleData:_headerString);
		if (ResultDicData != null)
			drawTablewithButtonNotice (ResultDicData.Length, ResultDicData);
//					drawTable (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData);

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}

	private void drawTablewithButtonNotice(int row, Dictionary<string, object>[] data){
		List<string> headerDatas = new List<string>( ResultDicData[0].Keys);
		drawTitleRow (headerDatas);

		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < headerDatas.Count; i++) {
				string key = headerDatas [i];
//				if(!key.Equals("PrimaryKey")){
//					dic[key] = GUILayout.TextField ((string)dic[key], GUILayout.Width (100));
//				}else
					GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}
			if (GUILayout.Button ("오늘은 보지 않음", GUILayout.Width (100))) {
				NotShowNotice (row, dic);
//				ModifyButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}
}

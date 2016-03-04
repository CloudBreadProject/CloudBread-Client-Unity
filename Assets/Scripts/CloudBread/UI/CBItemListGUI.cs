/*
 * 
 * 
 * 
 *	ItemLists 테이블의 정보를 표시
	아이템의 목록을 표시하고, 구매 버튼을 누르면 item 구매가 이루어지도록 처리하는 상점 루틴
	전체 아이템 목록 조회 : B19 SelItemListAll
	개별 아이템 목록 조회 / 수정 : B55 CBComSelItemList1 / B56 CBComUdtItemList1
	구매버튼을 누르면 B24 AddUseMemberItem 루틴 처리
	현금성아이템구매는 B27 AddMemberItemPurchase 루틴 처리(Purchase에 상세 정보 기록)

 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class CBItemListGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		cloudbread = new CloudBreadAzure(ServerAddress);
		cloudbread.CBSelItemListAll(CallBack);
		var header = cloudbread.CBSelItemListAllHeader;
		CBSelItemListReqeustJson = JsonParser.WritePretty (header);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private CloudBreadAzure cloudbread;
	public string CBSelItemListReqeustJson = "";

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(MainAreaRect.width), GUILayout.Height(MainAreaRect.height));
			GUILayout.BeginVertical();
				GUILayout.BeginHorizontal ();
		GUILayout.Label ("Server Address : " , GUILayout.Width(80));
					GUILayout.TextField (ServerAddress + "api/CBSelItemListAll");
				GUILayout.EndHorizontal ();
				GUILayout.Label ("");
				GUILayout.Label ("Request Json : ");
				CBSelItemListReqeustJson = GUILayout.TextArea (CBSelItemListReqeustJson);
				GUILayout.Label ("");
				if( ResultDicData!= null)
//					drawTablewithButton2 (ResultDicData.Length, ResultDicData, "memberID");
					drawTablewithButtonItemList(ResultDicData, "");
				GUILayout.Label ("");
				GUILayout.Label ("Response Json : ");
				RequestResultJson = GUILayout.TextArea (RequestResultJson);
			GUILayout.EndVertical();
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}

	public void DetailButtonClicked(int row, Dictionary<string, object> rawDicData){
		cloudbread.CBComSelItemList1(rawDicData["itemListID"].ToString(), CallBack);
	}

	// 세로 테이블
	private void drawTablewithButtonItemList(Dictionary<string,object>[] data, string primarykey){
		if (data != null) {
			List<string> headerDatas = new List<string> (data [0].Keys);

			GUILayout.BeginVertical ("box");
			for (int i = 0; i < headerDatas.Count; i++) {
				GUILayout.BeginHorizontal ();
				var headerKey = headerDatas [i];
				GUILayout.Label(headerKey, GUILayout.Width(150));
				for (int j = 0; j < data.Length; j++) {
					var dataDic = data [j];
					if (headerKey.Equals (primarykey)) 
						GUILayout.Label ((string)dataDic [headerKey], GUILayout.Width (120));
					else
						data[j][headerKey] = GUILayout.TextField ((string) dataDic [headerKey], GUILayout.Width (120));
				}
				GUILayout.EndHorizontal ();

			}

			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("", GUILayout.Width (145));
			for (int j = 0; j < data.Length; j++) {
				GUILayout.BeginVertical ();
					
					if (GUILayout.Button ("Delete", GUILayout.Width (120))) {
						DetailButtonClicked (j, data [j]);
					}
				GUILayout.EndVertical ();
			}
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();

		}
	}
}
/*
 *   {
    "rownum": "1",
    "itemListID": "itemid1",
    "itemName": "ItemName1",
    "itemDescription": "ItemDescription",
    "itemPrice": "10",
    "itemSellPrice": "10",
    "itemCategory1": "ItemCategory1",
    "itemCategory2": "ItemCategory2",
    "itemCategory3": "ItemCategory3",
    "sCol1": "sCol1",
    "sCol2": "sCol2",
    "sCol3": "sCol3",
    "sCol4": "sCol4",
    "sCol5": "sCol5",
    "sCol6": "sCol6",
    "sCol7": "sCol7",
    "sCol8": "sCol8",
    "sCol9": "sCol9",
    "sCol10": "sCol10"
  },
  */
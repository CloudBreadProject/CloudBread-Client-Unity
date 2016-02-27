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

public class CBItemListGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress +"/api/CBSelItemListAll";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string [] _headerString = {"rownum", "itemListID", "itemName", "itemDescription", "itemPrice", "itemSellPrice", "itemCategory1"};

	public Dictionary<string, object> CreateJsonData(){
		/*
		 * {
			  "memberID": "aaa",
			  "page": "1",  // Page number
			  "pageSize": "5"   // Page size
			}
		 */
		Dictionary<string, object> jsonDic = new Dictionary<string, object> ();
		jsonDic.Add ("memberID", "aaa");
		jsonDic.Add ("page", "1");
		jsonDic.Add ("pageSize", "5");
		return jsonDic;
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
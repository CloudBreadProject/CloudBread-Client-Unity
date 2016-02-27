/*
 * MemberItems 테이블의 정보를 표시
Members와 MemberItems는 1:N의 관계 – 아이템이 인벤에 있을 경우(UPDATE)와 없을 경우(INSERT)에 따라 처리가 달라짐
보유한 아이템의 리스트를 표시 B20 SelMemberItems
개별 아이템의 상세 정보를 표시 B53 CBComSelMemberItem
사용을 누를 경우 B41 AddUseMemberItem 수행 – 파라미터 INSERT UPDATE DELETE 관련 내용 주의
수정일 경우  B54 CBComUdtMemberItem 수행


*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBUserItemGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelMemberItems";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string[] _headerString = {
		"rownum",
		"itemListsItemName",
		"itemListsItemDescription",
		"itemListsItemPrice",
		"itemListsItemSellPrice"
	};

	public Dictionary<string, object> CreateJsonData(){
		/*
		 * {
			  "memberID": "aaa",
			  "Page": "1", // page number
			  "PageSize": "5" // page size
			}
		 */
		Dictionary<string, object> JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "aaa");
		JsonDic.Add ("Page", "1");
		JsonDic.Add ("PageSize", "5");

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
/*
 *   {
    "rownum": "1",
    "itemListsItemName": "ItemName1",
    "itemListsItemDescription": "ItemDescription",
    "itemListsItemPrice": "10",
    "itemListsItemSellPrice": "10",
    "itemListsItemCategory1": "ItemCategory1",
    "itemListsItemCategory2": "ItemCategory2",
    "itemListsItemCategory3": "ItemCategory3",
    "itemListssCol1": "sCol1",
    "itemListssCol2": "sCol2",
    "itemListssCol3": "sCol3",
    "itemListssCol4": "sCol4",
    "itemListssCol5": "sCol5",
    "itemListssCol6": "sCol6",
    "itemListssCol7": "sCol7",
    "itemListssCol8": "sCol8",
    "itemListssCol9": "sCol9",
    "itemListssCol10": "sCol10",
    "memberItemsMemberItemID": "MemberItemsID1",
    "memberItemsMemberID": "aaa",
    "memberItemsItemListID": "itemid1",
    "memberItemsItemCount": "1",
    "memberItemsItemStatus": "ItemStatus",
    "memberItemssCol1": "sCol1",
    "memberItemssCol2": "sCol2",
    "memberItemssCol3": "sCol3",
    "memberItemssCol4": "sCol4",
    "memberItemssCol5": "sCol5",
    "memberItemssCol6": "sCol6",
    "memberItemssCol7": "sCol7",
    "memberItemssCol8": "sCol8",
    "memberItemssCol9": "sCol9",
    "memberItemssCol10": "sCol10"
  },
  */
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
using AssemblyCSharp;

public class CBUserItemGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		cloudbread = new CloudBreadAzure(ServerAddress);
		cloudbread.CBSelMemberItems(CallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	CloudBreadAzure cloudbread;
		
	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(MainAreaRect.width), GUILayout.Height(MainAreaRect.height));
			GUILayout.BeginVertical();
				//				drawTable (1, _headerString.Length, _headerString);
//				drawTitleRow(titleData:_headerString);
				if( ResultDicData!= null)
					drawTablewithButton2 (ResultDicData.Length, ResultDicData, "rownum");

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}

	private void drawTablewithButton2(int row, Dictionary<string, object>[] data, string PrimaryKey){
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
			if (GUILayout.Button ("수 정", GUILayout.Width (80))) {
				ModifyButtonClicked (j, dic);
			}
			if (GUILayout.Button ("조 회", GUILayout.Width (80))) {
				UseButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	public override void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){

	}

	public void UseButtonClicked(int row, Dictionary<string, object> rawDicData){
		cloudbread.CBComSelItemList1(rawDicData["itemListID"].ToString(), CallBack);
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
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

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private CloudBreadAzure cloudbread;

//	public void CallBack(string jsonString, Dictionary<string, object>[] jsonRequestData){
//		print ("call back methods");
//		ResultDicData = jsonRequestData;
//		RequestResultJson = jsonString;
//		//		print ("call back methods");
//	}

	private string [] _headerString = {"rownum", "itemListID", "itemName", "itemDescription", "itemPrice", "itemSellPrice", "itemCategory1"};


	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
			GUILayout.BeginVertical();
				//				drawTable (1, _headerString.Length, _headerString);
				drawTitleRow(titleData:_headerString);
				if( ResultDicData!= null)
					drawTablewithButton2 (ResultDicData.Length, _headerString.Length, ResultDicData, "memberID");

				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndArea ();

	}

	private void drawTablewithButton2(int row, int col, Dictionary<string, object>[] data, string PrimaryKey){
		List<string> headerDatas = new List<string>( ResultDicData[0].Keys);
		drawTitleRow (headerDatas);

		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < col; i++) {
				string key = headerDatas [i];
				if(!key.Equals("PrimaryKey")){
					dic[key] = GUILayout.TextField ((string)dic[key], GUILayout.Width (100));
				}else
					GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}
			if (GUILayout.Button ("수 정", GUILayout.Width (80))) {
				ModifyButtonClicked (j, dic);
			}
			if (GUILayout.Button ("조 회", GUILayout.Width (80))) {
				DetailButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

//	private void 
	public override void ModifyButtonClicked(int row, Dictionary<string, object> rawDicData){
		cloudbread.CBComUdtItemList1(rawDicData, CallBack);

	}

	public void DetailButtonClicked(int row, Dictionary<string, object> rawDicData){
		cloudbread.CBComSelItemList1(rawDicData["itemListID"].ToString(), CallBack);
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
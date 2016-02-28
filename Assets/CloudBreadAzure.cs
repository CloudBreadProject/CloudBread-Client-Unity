using UnityEngine;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class CloudBreadAzure
	{
		public CloudBreadAzure (string ServerAddress)
		{
			this.ServerAddress = ServerAddress;
		}

		public string ServerAddress = "";

		private Action<string, Dictionary<string, object>[]> _requestCallback = null;

		// POST api/CBSelLoginInfo
		public void CBSelLoginInfo(Action<string, Dictionary<string,object>[]> callback){
			string ServerEndPoint = ServerAddress + "api/CBSelLoginInfo";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			//		"memberID": "aaa",
			//		"memberPWD": "MemberPWD",
			//		"LastDeviceID": "LastDeviceID",
			//		"LastIPaddress": "LastIPaddress",
			//		"LastMACAddress": "LastMACAddress"
			var JsonDic = new Dictionary<string, object> ();
			JsonDic.Add ("memberID", "aaa");
			JsonDic.Add ("memberPWD", "MemberPWD");
			JsonDic.Add ("LastDeviceID", "LastDeviceID");
			JsonDic.Add ("LastIPaddress", "LastIPaddress");
			JsonDic.Add ("LastMACAddress", "LastMACAddress");

			helper.POST (2, ServerEndPoint, JsonDic);

			_requestCallback = callback;

		}

		// POST api/CBSelLoginInfo request
		public void OnHttpRequest(int id, WWW www) {
			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest -= OnHttpRequest;

			if (www.error != null) {
				Debug.Log ("[Error] " + www.error);
			} else {
				Debug.Log (www.text);
//				RequestResultJson = www.text;
				var ResultDicData = (Dictionary<string, object>[]) JsonParser.Read2Object(www.text);
				_requestCallback (www.text, ResultDicData);

			}
		}

		// POST api/CBCOMUdtMember
		public void CBCOMUdtMember(Dictionary<string, object> updateItem, Action<string, Dictionary<string, object>[]> callback){
			string ServerEndPoint = ServerAddress + "api/CBCOMUdtMember";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			updateItem.Add ("TimeZoneID", "Korea Standard Time");

			helper.POST (2, ServerEndPoint, updateItem);

			_requestCallback = callback;
		}

		// POST api/CBCOMUdtMember request
//		public void 

		/*
		 * 
		 * 
		 * MemberGameInfo
		 */
		// POST api/CBComSelMemberGameInfoes
		public void CBComSelMemberGameInfoes(Action<string, Dictionary<string,object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBComSelMemberGameInfoes";

			/*
			 * {
				  "memberID": "aaa"
				}
			 */

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			var JsonDic = new Dictionary<string, object> ();
			JsonDic.Add ("memberID", "aaa");

			helper.POST (2, ServerEndPoint, JsonDic);

			_requestCallback = callback;
		}

		// POST api/CBComUdtMemberGameInfoes
		public void CBComUdtMemberGameInfoes(Dictionary<string, object> updateItem, Action<string, Dictionary<string,object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBComUdtMemberGameInfoes";

			/*
			 * 
			 * {
				  "MemberID": "ccc", // where
				  "Level": "9",
				  "Exps": "99",
				  "Points": "999",
				  "UserSTAT1": "UserSTAT1",
				  "UserSTAT2": "UserSTAT2",
				  "UserSTAT3": "UserSTAT3",
				  "UserSTAT4": "UserSTAT4",
				  "UserSTAT5": "UserSTAT5",
				  "UserSTAT6": "UserSTAT6",
				  "UserSTAT7": "UserSTAT7",
				  "UserSTAT8": "UserSTAT8",
				  "UserSTAT9": "UserSTAT9",
				  "UserSTAT10": "UserSTAT10",
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
				}
			 */

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			helper.POST (4, ServerEndPoint, updateItem);
			_requestCallback = callback;
		}


		/*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * Item
		 */
		// POST api/CBSelItemListAll
		public void CBSelItemListAll(Action<string, Dictionary<string,object>[]> callback){
			string ServerEndPoint = ServerAddress + "api/CBSelItemListAll";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

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

			helper.POST (3, ServerEndPoint, jsonDic);

			_requestCallback = callback;

		}

		/*
		 * 개별 아이템 목록 조회
		 */
		// POST api/CBComSelItemList1
		public void CBComSelItemList1(string itemListID, Action<string, Dictionary<string, object>[]> callback){
			string ServerEndPoint = ServerAddress + "api/CBComSelItemList1";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
				  "memberID": "aaa",
				  "itemListID": "itemid1"
				}
		   	 */
			Dictionary<string, object> jsondic = new Dictionary<string, object> ();
			jsondic.Add ("memberID", "aaa");
			jsondic.Add ("itemListID", itemListID);

			helper.POST (1, ServerEndPoint, jsondic);

			_requestCallback = callback;
		}

		/*
		 * 개별 아이템 목록 수정
		 */
		// POST api/CBComUdtItemList1
		public void CBComUdtItemList1(Dictionary<string, object> updateData, Action<string, Dictionary<string, object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBComUdtItemList1";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
				  "memberID": "aaa",
				  "itemListID": "itemid1", // where
				  "itemName": "ItemNameNew",
				  "itemDescription": "ItemDescription",
				  "itemPrice": "80",
				  "itemSellPrice": "80",
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
				}
			 */
//			Dictionary<string, object> jsondic = new Dictionary<string, object> ();


			helper.POST (1, ServerEndPoint, updateData);
			_requestCallback = callback;

		}

		// POST api/AddUseMemberItem
		public void AddUseMemberItem(){

		}

		// POST api/AddMemberItemPurchase 
		public void AddMemberItemPurchase (){
		}

		/*
		 * 
		 * 
		 * 
		 * 
		 * 게이머 소유 아이템
		 * CBUserItem
		 */

		// POST api/CBSelMemberItems
		public void CBSelMemberItems(Action<string, Dictionary<string, object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBSelMemberItems";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

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

			helper.POST (2, ServerEndPoint, JsonDic);

			_requestCallback = callback;
		}

		// POST api/CBComSelMemberItem
		public void CBComSelMemberItem(string memberItemID, Action<string, Dictionary<string,object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBComSelMemberItem";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
				  "memberID": "aaa",
				  "memberItemID": "MemberItemsID1"
				}
			 */

			Dictionary<string, object> jsonDic = new Dictionary<string, object> ();
			jsonDic.Add ("memberID", "aaa");
			jsonDic.Add ("memberItemID", memberItemID);

			helper.POST (5, ServerEndPoint, jsonDic);

			_requestCallback = callback;
		}

		public enum InsertorUpdate { INSERT , UPDATE};

		// POST api/AddUseMemberItem 
		public void CBAddUseMemberItem(InsertorUpdate insertUpdate , Action<string, Dictionary<string,object>[]> callback){
			var serverEndPoint = ServerAddress + "api/CBAddMemberItemPurchase";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
					"InsertORUpdate": "UPDATE", // UPDATE MemberItems update, MemberItemPurchases insert, MemberGameInfoes update
					"MemberItemID_MemberItems": "MemberItemsID2", // where
					"MemberID_MemberItems": "aaa", // ref
					"ItemListID_MemberItems": "itemid2", // ref
					"ItemCount_MemberItems": "20", 
					"ItemStatus_MemberItems": "ItemStatus_MemberItems", 
					"sCol1_MemberItems": "sCol1_MemberItems", 
					"sCol2_MemberItems": "sCol2_MemberItems", 
					"sCol3_MemberItems": "sCol3_MemberItems", 
					"sCol4_MemberItems": "sCol4_MemberItems", 
					"sCol5_MemberItems": "sCol5_MemberItems", 
					"sCol6_MemberItems": "sCol6_MemberItems", 
					"sCol7_MemberItems": "sCol7_MemberItems", 
					"sCol8_MemberItems": "sCol8_MemberItems", 
					"sCol9_MemberItems": "sCol9_MemberItems", 
					"sCol10_MemberItems": "sCol10_MemberItems", 
					"MemberID_MemberItemPurchases": "aaa", // ref
					"ItemListID_MemberItemPurchases": "itemid2", // ref 
					"PurchaseQuantity_MemberItemPurchases": "20", 
					"PurchasePrice_MemberItemPurchases": "2000000", 
					"PGinfo1_MemberItemPurchases": "PGinfo1_MemberItemPurchases", 
					"PGinfo2_MemberItemPurchases": "PGinfo2_MemberItemPurchases", 
					"PGinfo3_MemberItemPurchases": "PGinfo3_MemberItemPurchases", 
					"PGinfo4_MemberItemPurchases": "PGinfo4_MemberItemPurchases", 
					"PGinfo5_MemberItemPurchases": "PGinfo5_MemberItemPurchases", 
					"PurchaseDeviceID_MemberItemPurchases": "PurchaseDeviceID_MemberItemPurchases", 
					"PurchaseDeviceIPAddress_MemberItemPurchases": "ipaddress", 
					"PurchaseDeviceMACAddress_MemberItemPurchases": "macaddress", 
					"PurchaseDT_MemberItemPurchases": "2016-01-01 00:00:00.0000000 +00:00", 
					"PurchaseCancelYN_MemberItemPurchases": "N", 
					"PurchaseCancelDT_MemberItemPurchases": "", 
					"PurchaseCancelingStatus_MemberItemPurchases": "", 
					"PurchaseCancelReturnedAmount_MemberItemPurchases": "", 
					"PurchaseCancelDeviceID_MemberItemPurchases": "PurchaseCancelDeviceID_MemberItemPurchases", 
					"PurchaseCancelDeviceIPAddress_MemberItemPurchases": "ipaddress", 
					"PurchaseCancelDeviceMACAddress_MemberItemPurchases": "PurchaseCancelDeviceMACAddress_MemberItemPurchases", 
					"sCol1_MemberItemPurchases": "sCol1_MemberItemPurchases", 
					"sCol2_MemberItemPurchases": "sCol2_MemberItemPurchases", 
					"sCol3_MemberItemPurchases": "sCol3_MemberItemPurchases", 
					"sCol4_MemberItemPurchases": "sCol4_MemberItemPurchases", 
					"sCol5_MemberItemPurchases": "sCol5_MemberItemPurchases", 
					"sCol6_MemberItemPurchases": "sCol6_MemberItemPurchases", 
					"sCol7_MemberItemPurchases": "sCol7_MemberItemPurchases", 
					"sCol8_MemberItemPurchases": "sCol8_MemberItemPurchases", 
					"sCol9_MemberItemPurchases": "sCol9_MemberItemPurchases", 
					"sCol10_MemberItemPurchases": "sCol10_MemberItemPurchases", 
					"MemberID_MemberGameInfoes": "aaa", // where
					"Level_MemberGameInfoes": "22", 
					"Exps_MemberGameInfoes": "222", 
					"Points_MemberGameInfoes": "2222", 
					"UserSTAT1_MemberGameInfoes": "UserSTAT1_MemberGameInfoes", 
					"UserSTAT2_MemberGameInfoes": "UserSTAT2_MemberGameInfoes", 
					"UserSTAT3_MemberGameInfoes": "UserSTAT3_MemberGameInfoes", 
					"UserSTAT4_MemberGameInfoes": "UserSTAT4_MemberGameInfoes", 
					"UserSTAT5_MemberGameInfoes": "UserSTAT5_MemberGameInfoes", 
					"UserSTAT6_MemberGameInfoes": "UserSTAT6_MemberGameInfoes", 
					"UserSTAT7_MemberGameInfoes": "UserSTAT7_MemberGameInfoes", 
					"UserSTAT8_MemberGameInfoes": "UserSTAT8_MemberGameInfoes", 
					"UserSTAT9_MemberGameInfoes": "UserSTAT9_MemberGameInfoes", 
					"UserSTAT10_MemberGameInfoes": "UserSTAT10_MemberGameInfoes", 
					"sCol1_MemberGameInfoes": "sCol1_MemberGameInfoes", 
					"sCol2_MemberGameInfoes": "sCol2_MemberGameInfoes", 
					"sCol3_MemberGameInfoes": "sCol3_MemberGameInfoes", 
					"sCol4_MemberGameInfoes": "sCol4_MemberGameInfoes", 
					"sCol5_MemberGameInfoes": "sCol5_MemberGameInfoes", 
					"sCol6_MemberGameInfoes": "sCol6_MemberGameInfoes", 
					"sCol7_MemberGameInfoes": "sCol7_MemberGameInfoes", 
					"sCol8_MemberGameInfoes": "sCol8_MemberGameInfoes", 
					"sCol9_MemberGameInfoes": "sCol9_MemberGameInfoes", 
					"sCol10_MemberGameInfoes": "sCol10_MemberGameInfoes"
					}*/
			Dictionary<string, object> jsonDic = new Dictionary<string, object> ();
			jsonDic.Add ("InsertORUpdate", insertUpdate);

		}

		// POST api/CBComUdtMemberItem 
		public void CBComUdtMemberItem (){
			var ServerEndPoint = ServerAddress + "api/CBComUdtMemberItem";

			/*
			 * {
				  "MemberItemID": "MemberItemsID3", // where
				  "MemberID": "aaa", // ref
				  "ItemListID": "itemid3", //ref
				  "ItemCount": "9",
				  "ItemStatus": "ItemStatus",
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
				}
			 */ 
		}

		/*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 */

		// POST api/SelMemberGameInfoStages
		public void SelMemberGameInfoStages(Action<string, Dictionary<string, object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBSelMemberGameInfoStages";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
				  "memberID": "aaa"
				}
			 * 
			 */ 

			var JsonDic = new Dictionary<string, object> ();
			JsonDic.Add ("memberID", "aaa");

			helper.POST (12, ServerEndPoint, JsonDic);
			_requestCallback = callback;
		}

		// POST api/CBCOMSelMemberGameInfoStages
		public void CBCOMSelMemberGameInfoStages(Action<string, Dictionary<string, object>[]> callback){
			var ServerEndPoint = ServerAddress + "api/CBComSelMemberGameInfoStages";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			/*
			 * {
				  "memberID": "aaa",
				  "MemberGameInfoStageID": "MemberGameInfoStageID1"
				}
			 */

			var jsonDic = new Dictionary<string,object> ();
			jsonDic.Add ("memberID", "aaa");

			helper.POST (34, ServerEndPoint, jsonDic);
			_requestCallback = callback;

		}

		// POST api/CBComUdtMemberGameInfoStages 
		public void CBComUdtMemberGameInfoStages (){
			var ServerEndPoint = ServerAddress + "api/CBComUdtMemberGameInfoStages";

			/*
			 * {
				  "MemberGameInfoStageID": "MemberGameInfoStageID4", // where
				  "MemberID": "bbb", //ref
				  "StageName": "NewStageName",
				  "StageStatus": "ChangeAllInfo",
				  "Category1": "Category1",
				  "Category2": "Category2",
				  "Category3": "Category3",
				  "Mission1": "Mission1",
				  "Mission2": "Mission2",
				  "Mission3": "Mission3",
				  "Mission4": "Mission4",
				  "Mission5": "Mission5",
				  "Points": "100",
				  "StageStat1": "StageStat1",
				  "StageStat2": "StageStat2",
				  "StageStat3": "StageStat3",
				  "StageStat4": "StageStat4",
				  "StageStat5": "StageStat5",
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
				}
			 */
		}

		// POST api/UdtMemberGameInfoStage 
		public void UdtMemberGameInfoStage (){
//			var ServerEndPoint = ServerAddress + "
		}

		/*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 공지 사항
		 * Notice
		 */
		// POST api/CBSelNotices 
		public void CBSelNotices (){
			var ServerEndPoint = ServerAddress + "api/CBSelNotices";

			/*
			 * {
				  "memberID": "aaa"
				}
			 */

		}

		/*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 */
		// POST api/SelGameEvents 
		public void SelGameEvents (){
			var ServerEndPoint = ServerAddress + "api/CBSelGameEvents";

			/*
			 * {
				  "memberID": "bbb"
				}
			 */
		}

		// POST api/UdtGameEventMemberToItem 
		public void UdtGameEventMemberToItem (){
			var ServerEndPoint = ServerAddress + "api/CBUdtGameEventMemberToItem";

			/*
			 * {
					"InsertORUpdate": "UPDATE", // UPDATE to MemberItem
					"MemberItemID_MemberItems": "MemberItemsID5",  // update : ref data
					"MemberID_MemberItems": "aaa", // ref
					"ItemListID_MemberItems": "itemid4", // ref
					"ItemCount_MemberItems": "4",
					"ItemStatus_MemberItems": "ItemStatus",
					"sCol1_MemberItems": "sCol1",
					"sCol2_MemberItems": "sCol2",
					"sCol3_MemberItems": "sCol3",
					"sCol4_MemberItems": "sCol4",
					"sCol5_MemberItems": "sCol5",
					"sCol6_MemberItems": "sCol6",
					"sCol7_MemberItems": "sCol7",
					"sCol8_MemberItems": "sCol8",
					"sCol9_MemberItems": "sCol9",
					"sCol10_MemberItems": "sCol10",
					"eventID_GameEventMember": "evtid4", // ref
					"MemberID_GameEventMember": "aaa", // ref
					"sCol1_GameEventMember": "sCol1",
					"sCol2_GameEventMember": "sCol2",
					"sCol3_GameEventMember": "sCol3",
					"sCol4_GameEventMember": "sCol4",
					"sCol5_GameEventMember": "sCol5",
					"sCol6_GameEventMember": "sCol6",
					"sCol7_GameEventMember": "sCol7",
					"sCol8_GameEventMember": "sCol8",
					"sCol9_GameEventMember": "sCol9",
					"sCol10_GameEventMember": "sCol10"
				}
				*/


		}


		/*
		 * 
		 * 
		 * 
		 * Coupons
		 */ 
		// POST api/CBSelCoupons
		public void CBSelCoupons (){
			var ServerEndPoint = ServerAddress + "api/CBSelCoupons";

			/*
			 * {
				  "memberID": "bbb"
				}
			 * 
			 */

		}

		// POST api/CBUdtCouponMember
		public void CBUdtCouponMember (){
			var ServerEndPoint = ServerAddress + "api/CBUdtCouponMember";

			/*
			 * {
					"InsertORUpdate":   "INSERT",    // insert to memberitem
					"CouponID_Coupon":   "cpid3",    // ref
					"MemberItemID_MemberItems":   "MemberItemsID30",   // INSERT : new value, UPDATE : MemberItemID ref value
					"MemberID_MemberItems":   "aaa",  // ref
					"ItemListID_MemberItems":   "itemid3",  // ref
					"ItemCount_MemberItems":   "3",
					"ItemStatus_MemberItems":   "ItemStatus",
					"sCol1_MemberItems":   "sCol1",
					"sCol2_MemberItems":   "sCol2",
					"sCol3_MemberItems":   "sCol3",
					"sCol4_MemberItems":   "sCol4",
					"sCol5_MemberItems":   "sCol5",
					"sCol6_MemberItems":   "sCol6",
					"sCol7_MemberItems":   "sCol7",
					"sCol8_MemberItems":   "sCol8",
					"sCol9_MemberItems":   "sCol9",
					"sCol10_MemberItems":   "sCol10",
					"CouponID_CouponMember":   "cpid3",    // ref
					"MemberID_CouponMember":   "aaa",  // ref
					"sCol1_CouponMember":   "sCol1",
					"sCol2_CouponMember":   "sCol2",
					"sCol3_CouponMember":   "sCol3",
					"sCol4_CouponMember":   "sCol4",
					"sCol5_CouponMember":   "sCol5",
					"sCol6_CouponMember":   "sCol6",
					"sCol7_CouponMember":   "sCol7",
					"sCol8_CouponMember":   "sCol8",
					"sCol9_CouponMember":   "sCol9",
					"sCol10_CouponMember":   "sCol10"
				}
			 */

		}

	}
}


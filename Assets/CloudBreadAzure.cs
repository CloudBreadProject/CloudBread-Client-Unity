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
		public void SelMemberGameInfo(){

		}



		// POST api/SelItemListAll
		public void SelItemListAll(){

		}

		/*
		 * 개별 아이템 목록 조회
		 */
		// POST api/CBComSelItemList1
		public void CBComSelItemList1(){
			
		}

		/*
		 * 개별 아이템 목록 수정
		 */
		// POST api/CBComUdtItemList1
		public void CBComUdtItemList1(){

		}

		// POST api/AddUseMemberItem
		public void AddUseMemberItem(){

		}

		// POST api/AddMemberItemPurchase 
		public void AddMemberItemPurchase (){
		}

		// POST api/SelMemberItems
		public void SelMemberItems(){
		}

		// POST api/CBComSelMemberItem
		public void CBComSelMemberItem(){
		}

		// POST api/AddUseMemberItem 
		public void CBAddUseMemberItem(){
		}

		// POST api/CBComUdtMemberItem 
		public void CBComUdtMemberItem (){
		}

		// POST api/SelMemberGameInfoStages
		public void SelMemberGameInfoStages(){
		}

		// POST api/CBCOMSelMemberGameInfoStages
		public void CBCOMSelMemberGameInfoStages(){
		}

		// POST api/CBComUdtMemberGameInfoStages 
		public void CBComUdtMemberGameInfoStages (){
		}

		// POST api/UdtMemberGameInfoStage 
		public void UdtMemberGameInfoStage (){
		}

		// POST api/CBSelNotices 
		public void CBSelNotices (){
			
		}

		// POST api/SelGameEvents 
		public void SelGameEvents (){
		}

		// POST api/UdtGameEventMemberToItem 
		public void UdtGameEventMemberToItem (){
		}

		// POST api/SelCoupons 
		public void SelCoupons (){
		}

		// POST api/UdtCouponMember 
		public void UdtCouponMember (){
		}

	}
}


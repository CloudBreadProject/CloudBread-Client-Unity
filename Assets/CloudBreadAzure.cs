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

		// api/CBSelLoginInfo
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

		// api/CBSelLoginInfo request
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

		// api/CBCOMUdtMember
		public void CBCOMUdtMember(Dictionary<string, object> updateItem, Action<string, Dictionary<string, object>[]> callback){
			string ServerEndPoint = ServerAddress + "api/CBCOMUdtMember";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += OnHttpRequest;

			updateItem.Add ("TimeZoneID", "Korea Standard Time");

			helper.POST (2, ServerEndPoint, updateItem);

			_requestCallback = callback;
		}

		// api/CBCOMUdtMember request
//		public void 


	}
}


using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class CBCOMUdtMemberController : APIController
	{
		private const string BehaviorID = "B08";

		public class InputParams
		{
			public string MemberID { get; set; }
			public string MemberPWD { get; set; }
			public string EmailAddress { get; set; }
			public string EmailConfirmedYN { get; set; }
			public string PhoneNumber1 { get; set; }
			public string PhoneNumber2 { get; set; }
			public string PINumber { get; set; }
			public string Name1 { get; set; }
			public string Name2 { get; set; }
			public string Name3 { get; set; }
			public string DOB { get; set; }
			public string RecommenderID { get; set; }
			public string MemberGroup { get; set; }
			public string LastDeviceID { get; set; }
			public string LastIPaddress { get; set; }
			public string LastLoginDT { get; set; }
			public string LastLogoutDT { get; set; }
			public string LastMACAddress { get; set; }
			public string AccountBlockYN { get; set; }
			public string AccountBlockEndDT { get; set; }
			public string AnonymousYN { get; set; }
			public string _3rdAuthProvider { get; set; }
			public string _3rdAuthID { get; set; }
			public string _3rdAuthParam { get; set; }
			public string PushNotificationID { get; set; }
			public string PushNotificationProvider { get; set; }
			public string PushNotificationGroup { get; set; }
			public string sCol1 { get; set; }
			public string sCol2 { get; set; }
			public string sCol3 { get; set; }
			public string sCol4 { get; set; }
			public string sCol5 { get; set; }
			public string sCol6 { get; set; }
			public string sCol7 { get; set; }
			public string sCol8 { get; set; }
			public string sCol9 { get; set; }
			public string sCol10 { get; set; }
			public string TimeZoneID { get; set; }
		}

		public CBCOMUdtMemberController (InputParams p, string serverAddress, Action<string, WWW> callback_success, Action<string, WWW> callback_error)
			: base (serverAddress, callback_success, callback_error)
		{
			var path = "api/CBCOMUdtMember";

			var jsonStr = JsonParser.Write (p);


			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += Helper_OnHttpRequest;
			helper.POST (BehaviorID, serverAddress + path, jsonStr);
		}
	}
}


//// POST api/CBCOMUdtMember
//public void CBCOMUdtMember(Dictionary<string, object> updateItem, Action<string, Dictionary<string, object>[]> callback){
//	string ServerEndPoint = ServerAddress + "api/CBCOMUdtMember";
//
//	WWWHelper helper = WWWHelper.Instance;
//	helper.OnHttpRequest += OnHttpRequest;
//
//	updateItem.Add ("TimeZoneID", "Korea Standard Time");
//
//	helper.POST (2, ServerEndPoint, updateItem);
//
//	_requestCallback = callback;
//}

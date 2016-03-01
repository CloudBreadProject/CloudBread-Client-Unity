using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class CBSelLoginInfoController : APIController
	{
		private const string BehaviorID = "B06";

		public class InputParams
		{
			public string memberID { get; set; }
			public string memberPWD {
				get;
				set;
			}
			public string LastDeviceID {
				get;
				set;
			}
			public string LastIPaddress {
				get;
				set;
			}
			public string LastMACAddress {
				get;
				set;
			}
		}
			
		public CBSelLoginInfoController (string serverAddress, Action<string, WWW> callback_success, Action<string, WWW> callback_error)
			: base (serverAddress, callback_success, callback_error)
		{
			string ServerEndPoint = serverAddress + "api/CBSelLoginInfo";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += base.Helper_OnHttpRequest;

			var jsonStr = JsonParser.Write (new InputParams {
				memberID = "aaa",
				memberPWD = "MemberPWD",
				LastDeviceID = SystemInfo.deviceUniqueIdentifier,
				LastIPaddress = Network.player.ipAddress,
				LastMACAddress = "LastMACAddress"
			});

			helper.POST (BehaviorID, ServerEndPoint, jsonStr);

		}
	}
}


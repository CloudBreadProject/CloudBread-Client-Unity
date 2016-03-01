using UnityEngine;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class CBVersionController :APIController
	{
		private const string BehaviorID = "A01";

		public CBVersionController (string serverAddress, Action<string, WWW> callback_success, Action<string, WWW> callback_error )
			:base(serverAddress, callback_success, callback_error)
		{
			string ServerEndPoint = serverAddress + "api/ver";

			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest += Helper_OnHttpRequest;

			helper.get (BehaviorID, ServerEndPoint);
		}

	}
}


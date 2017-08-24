using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class APIController
	{
		public string ServerAddress;

		public Action<string, WWW> Callback_error;
		public Action<string, WWW> Callback_success;

		public APIController(string ServerAddress, Action<string, WWW> callback_success, Action<string,WWW> callback_error){
			this.ServerAddress = ServerAddress;
			this.Callback_success = callback_success;
			this.Callback_error = callback_error;
		}

		public void Helper_OnHttpRequest (string id, WWW www)
		{
			WWWHelper helper = WWWHelper.Instance;
			helper.OnHttpRequest -= Helper_OnHttpRequest;

			if (www.error != null) {
				Debug.Log ("[" + id + "] " + www.error);
				Callback_error (id, www);
			} else {
				Debug.Log ("[" + id + "] " + www.text);
				Callback_success (id, www);
			}
		}

		
	}
}


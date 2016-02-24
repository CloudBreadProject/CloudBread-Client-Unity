using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class CBBaseAPI
	{

		private string API_VERSION = "2.0.0";
		private string _auth_token = "";
		private string _api_version;

		public CBBaseAPI ()
		{
			
		}

		public Dictionary<string, string> getDefaultHeader(){
			var header = new Dictionary<string, string> (); 
			header["ZUMO-API-VERSION"] = _api_version;
			header ["X-ZUMO-AUTH"] = _auth_token;
			header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
			header ["X-ZUMO-FEATURES"] = "AJ";
			header ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
			header ["Content-Type"] = "application/json";
			header["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";

			return header;
		}
	}
}


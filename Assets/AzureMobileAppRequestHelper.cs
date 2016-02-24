using System;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class AzureMobileAppRequestHelper
	{
		// Header Default
		// ZUMO-API-VERSION
		private string _api_version = "2.0.0";
		// X-ZUMO-AUTH
		private string _auth_token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJzaWQ6YzZhZTNhOTQ3NTdiMDM3N2Y5OTgyZmQwODJhZWVhMmMiLCJpZHAiOiJmYWNlYm9vayIsInZlciI6IjMiLCJpc3MiOiJodHRwczovL2R3LWNsb3VkYnJlYWQteXMuYXp1cmV3ZWJzaXRlcy5uZXQvIiwiYXVkIjoiaHR0cHM6Ly9kdy1jbG91ZGJyZWFkLXlzLmF6dXJld2Vic2l0ZXMubmV0LyIsImV4cCI6MTQ1NjEyODc5MiwibmJmIjoxNDU2MTI1MTkyfQ.CTMp5Myw287z76WhxolzAmPebLUqeFTcSXFdw-VoRXU";


		public AzureMobileAppRequestHelper ()
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


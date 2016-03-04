using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class AzureMobileAppRequestHelper
	{

		// Header Default

		// ZUMO-API-VERSION
		private static string _api_version = "2.0.0";

//		public static AuthData auth_data;

		public static string AuthToken;

		private CBAuthentication cbAuth;

		public AzureMobileAppRequestHelper ()
		{
			cbAuth = new CBAuthentication ();
		}

		public AzureMobileAppRequestHelper (string azureEndPoint, string token/*, MobileServiceUser User*/)
		{
			cbAuth = new CBAuthentication ();
		}

//		public string setServerAdd(string address){
//			char lastChar = address [address.Length];
//			if (lastChar.CompareTo ("/") == 0) {
//				return address.Substring (0, address.Length - 1);
//			};
//
//			return address;
//		}

		public void setTokenJson(string result){
			Debug.Log ("[AzureMobileAppRequest] " + result);
			var resultDic = (Dictionary<string, object>) JsonParser.Read2Object(result);
			cbAuth.token = (string) resultDic ["token"];
			Debug.Log ("[token] " + cbAuth.token);
			var crypt = CBAuthentication.AES_decrypt (cbAuth.token, "1234567890123456", "1234567890123456");

			Debug.Log ("[token decrypt] " + crypt);



		}

		public Dictionary<string, string> getDefaultHeader(){
			var header = new Dictionary<string, string> (); 
			header["ZUMO-API-VERSION"] = _api_version;

//			header ["Accept-Encoding"] = "gzip";
			header ["Accept"] = "application/json";

			header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
			header ["X-ZUMO-FEATURES"] = "AJ";
			header ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
			header ["Content-Type"] = "application/json";
//			header["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";

			if (AuthToken != null) {
				header ["X-ZUMO-AUTH"] = AuthToken;
			}
		
			return header;
		}

		public static Dictionary<string, string> getHeader(){
			Dictionary<string,string> header = new Dictionary<string,string> ();

			header["ZUMO-API-VERSION"] = _api_version;

//			header ["Accept-Encoding"] = "gzip";
			header ["Accept"] = "application/json";

			header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
			header ["X-ZUMO-FEATURES"] = "AJ";
			header ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
			header ["Content-Type"] = "application/json";
//			header["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";

			if (AuthToken != null) {
				header ["X-ZUMO-AUTH"] = AuthToken;
			}

			return header;
		}
			
	}
}


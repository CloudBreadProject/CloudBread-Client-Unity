using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;
using RestSharp;

public class WWWHelper : MonoBehaviour {

	public delegate void HttpRequestDelegate(string id, WWW www);

	public event HttpRequestDelegate OnHttpRequest;

	private int requestId;

	static WWWHelper current = null;

	static GameObject container = null;

	// Single-ton
	public static WWWHelper Instance {
		get {
			if (current == null) {
				container = new GameObject();
				container.name = "WWWHelper";
				current = container.AddComponent(typeof(WWWHelper)) as WWWHelper;
			}
			return current;
		}
	}

	public Dictionary<string, string> HeaderDic;

	public void get(string url){
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest ("1", www));

	}

	public void get(string id, string url) {
		var header = getHeaders ();
		WWW www = new WWW (url, null, header);
		
		StartCoroutine(WaitForRequest(id, www));
	}

	// POST with Dictionary JsonData
	public void POST(int id, string url, Dictionary<string, object> JsonData){
		WWWForm form = new WWWForm ();

//		if (HeaderDic == null) {
//			HeaderDic = getHeaders ();
//		}
		HeaderDic = AzureMobileAppRequestHelper.getHeader();
		foreach (KeyValuePair<string, string> post_arg in HeaderDic) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

		string jsonString = JsonParser.Write (JsonData);
		byte[] jsonByte = Encoding.UTF8.GetBytes(jsonString.ToCharArray());

		WWW www = new WWW(url, jsonByte, HeaderDic);
		StartCoroutine(WaitForRequest("" + id, www));

	}

	// POST with string JsonData
	public void POST(string id, string url, string JsonData){
//		WWWForm form = new WWWForm ();

//		if (HeaderDic == null) {
//			HeaderDic = getHeaders ();
//		}
		HeaderDic = AzureMobileAppRequestHelper.getHeader();

		WWW www = new WWW(url, Encoding.UTF8.GetBytes(JsonData), HeaderDic);
		StartCoroutine(WaitForRequest(id, www));
	}

	private IEnumerator  WaitForRequest(string id, WWW www) {

		yield return www;


		bool hasCompleteListener = (OnHttpRequest != null);

		if (hasCompleteListener) {
			OnHttpRequest(id, www);
		}
			
		www.Dispose();
	}

	private Dictionary<string, string> getHeaders(Dictionary<string, string> header){
		header ["Accept-Encoding"] = "gzip";
		header ["Accept"] = "application/json";

		header["ZUMO-API-VERSION"] = "2.0.0";
		header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		header ["X-ZUMO-FEATURES"] = "AJ";
		header ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
		header ["Content-Type"] = "application/json";
		header["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		header ["x-zumo-auth"] = "ChangeHereForAuthentication";
		return header;
	}

	private Dictionary<string, string> getHeaders(){
		var header = new Dictionary<string, string> ();
		header ["Accept-Encoding"] = "gzip";
		header ["Accept"] = "application/json";
		
		header["ZUMO-API-VERSION"] = "2.0.0";
		header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		header ["X-ZUMO-FEATURES"] = "AJ";
		header ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
		header ["Content-Type"] = "application/json";
		header["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		header ["x-zumo-auth"] = "ChangeHereForAuthentication";
		return header;
	}

	private void POSTwithRestSharp(int id, string url, string resource, Dictionary<string, object> JsonData){
		var client = new RestClient(url);
		// client.Authenticator = new HttpBasicAuthenticator(username, password);

		var request = new RestRequest(resource, Method.POST);
		//		request.RequestFormat = DataFormat.Json;

		//		request.Parameters.Clear();
		request.AddParameter("application/json", JsonParser.Write(JsonData) , ParameterType.RequestBody);

		//		request.AddParameter(
		//		equest.AddParameter("text/json", body, ParameterType.RequestBody);
		//		request.add
		//		request.AddBody (new TestMember {
		////			memberID = "aaa";
		////			memberPWD = "MemberPWD";
		//			memberID = "aaa", memberPWD = "MemberPWD", LastDeviceID = "LastDeviceID", LastIPaddress = "LastIPaddress", LastMACAddress = "LastMACAddress"
		//		});
		//		request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
		//		request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

		// easily add HTTP Headers
		//		request.AddHeader("header", "value");
		request.AddHeader( "ZUMO-API-VERSION", "2.0.0" );
		request.AddHeader ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		request.AddHeader ("X-ZUMO-FEATURES", "AJ");
		request.AddHeader ("X-ZUMO-INSTALLATION-ID", "fe52b710-0312-4cad-8d53-dfd28d4c6f9b");
		request.AddHeader ("Content-Type", "application/json");
		request.AddHeader ("User-Agent", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		request.AddHeader ("Accept", "application/json");
		request.AddHeader ("Accept-Encoding", "gzip");
		request.AddHeader ("x-zumo-auth", "ChangeHereForAuthentication");

		//		List<string> headerDatas = new List<string>( JsonData.Keys);
		//		foreach (var headerkey in headerDatas) {
		//			request.AddParameter(headerkey, JsonData[headerkey], ParameterType.RequestBody);
		//		}

		client.ExecuteAsync(request, response => {
			print((string)response.Content);
			print((string)("" + response.RawBytes[0] + " / " + response.RawBytes[1] + " / " + response.RawBytes[2]));

			string encodedStringssss = Convert.ToBase64String(response.RawBytes);
			print("[ToBase64String] : " + encodedStringssss);

			// utf-8 인코딩
			byte [] bytesForEncoding = Encoding.UTF8.GetBytes ( response.Content ) ;
			string encodedString = Convert.ToBase64String (bytesForEncoding );
			print ("[request utf8 encoded] : " + encodedString);
			// utf-8 디코딩
			byte[] decodedBytes = Convert.FromBase64String (encodedString );
			string decodedString = Encoding.UTF8.GetString (response.RawBytes );

			byte[] decodedStringdd = Convert.FromBase64String(decodedString);
			string decodedStringsss = Encoding.Unicode.GetString(decodedStringdd);
			print ("[Request utf8 decoded~~~~~~] : " + decodedStringdd);
			//			RequestResultJson = decodedString;
			print ("[Request utf8 decoded] : " + decodedString);


			// utf-8 인코딩
			byte [] bytesForEncoding2 = Encoding.Unicode.GetBytes ( response.Content ) ;
			string encodedString2 = Convert.ToBase64String (bytesForEncoding2 );
			print ("[request uni encoded] : " + encodedString2);
			// utf-8 디코딩
			byte[] decodedBytes2 = Convert.FromBase64String (encodedString2 );
			string decodedString2 = Encoding.Default.GetString (response.RawBytes );

			//			RequestResultJson = decodedString;
			print ("[Request uni decoded] : " + decodedString2);
		});
	}
}
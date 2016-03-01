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

	public void get(string url){
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest ("1", www));

	}

	public void get(string id, string url) {
		WWWForm form = getHeader ();
//		WWW www = new WWW (url, form);

		var header = getHeaders (form.headers);
		WWW www = new WWW (url, null, header);
		
		StartCoroutine(WaitForRequest("" + id, www));
	}

	public void get(int id, string url, WWWForm form, Dictionary<string, string> header)
	{
//		WWWForm form = getHeader();


	}

	public void POST(int id, string url, Dictionary<string, object> JsonData){
		WWWForm form = new WWWForm ();

		var data = getHeaders (form.headers);
//		byte[] jsonDataByte = 
		foreach (KeyValuePair<string, string> post_arg in data) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

		string jsonString = JsonParser.Write (JsonData);
		byte[] jsonByte = Encoding.UTF8.GetBytes(jsonString.ToCharArray());

		WWW www = new WWW(url, jsonByte, data);
		StartCoroutine(WaitForRequest("" + id, www));

	}

	public void POST(string id, string url, string json){
		WWWForm form = new WWWForm ();

		var data = getHeaders (form.headers);
		//		byte[] jsonDataByte = 
//		foreach (KeyValuePair<string, string> post_arg in data) {
//			form.AddField(post_arg.Key, post_arg.Value);
//		}

//		string jsonString = JsonParser.Write (JsonData);
//		byte[] jsonByte = Encoding.UTF8.GetBytes(jsonString.ToCharArray());

		WWW www = new WWW(url, Encoding.UTF8.GetBytes(json), data);
		StartCoroutine(WaitForRequest(id, www));
	}

	class TestMember{
		//		"memberID": "aaa",
		//		"memberPWD": "MemberPWD",
		//		"LastDeviceID": "LastDeviceID",
		//		"LastIPaddress": "LastIPaddress",
		//		"LastMACAddress": "LastMACAddress"
		public string memberID;
		public string memberPWD;
		public string LastDeviceID;
		public string LastIPaddress;
		public string LastMACAddress;
	}
	public void POSTwithRestSharp(int id, string url, string resource, Dictionary<string, object> JsonData){
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

//	public void post(int id, string url, Dictionary<string, string> data) {
//		WWWForm form = new WWWForm();
////		WWWForm form = getHeader();
//
//		data = getHeaders ();
//
//		foreach (KeyValuePair<string, string> post_arg in data) {
//			form.AddField(post_arg.Key, post_arg.Value);
//		}
//
//		WWW www = new WWW(url, form);
//		StartCoroutine(WaitForRequest(id, www));
//	}
//
//	public void post(int id, string url) {
//		WWWForm form = new WWWForm();
////		WWWForm form = getUserInfoBody();
//
////		var data = getHeaders ();
//		var data = getHeaders(form.headers);
//		byte[] jsondata = getUserInfoBody ();
//
//		foreach (KeyValuePair<string, string> post_arg in data) {
//			form.AddField(post_arg.Key, post_arg.Value);
//		}
//
////		WWW www = new WWW(url, form);chrome://net-internals/
////		WWW www = new WWW(url, form.data, data);
//		WWW www = new WWW(url, jsondata, data);
//		StartCoroutine(WaitForRequest(id, www));
//	}	

	public void POST(string url){
		WWW www = new WWW (url);
		StartCoroutine(WaitForRequest("1", www));
	}


	private IEnumerator  WaitForRequest(string id, WWW www) {

		yield return www;


		bool hasCompleteListener = (OnHttpRequest != null);

		if (hasCompleteListener) {
			OnHttpRequest(id, www);
		}


		www.Dispose();
	}

	private byte[] getUserInfoBody(){
//		"memberID": "aaa",
//		"memberPWD": "MemberPWD",
//		"LastDeviceID": "LastDeviceID",
//		"LastIPaddress": "LastIPaddress",
//		"LastMACAddress": "LastMACAddress"
		string json = "{ \"memberID\": \"aaa\",\"memberPWD\": \"MemberPWD\",\"LastDeviceID\": \"LastDeviceID\",\"LastIPaddress\": \"LastIPaddress\",\"LastMACAddress\": \"LastMACAddress\"}";
//		byte [] jsonArr = Encoding.UTF8.GetBytes(json.ToCharArray());
		byte [] jsonArr= Encoding.UTF8.GetBytes(json.ToCharArray());
//		byte [] jsonArr = (byte ) json.ToCharArray();

//		WWWForm form = new WWWForm();
//		form.AddField ("memberID", "aaa");
//		form.AddField ("memberPWD", "MemberPWD");
//		form.AddField ("LastDeviceID", "LastDeviceID");
//		form.AddField ("LastIPaddress", "LastIPaddress");
//		form.AddField ("LastMACAddress", "LastMACAddress");

		return jsonArr;
	}

	private WWWForm getHeader(){
		WWWForm form = new WWWForm();
		form.AddField( "ZUMO-API-VERSION", "2.0.0" );
		form.AddField ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		form.AddField ("X-ZUMO-FEATURES", "AJ");
		form.AddField ("X-ZUMO-INSTALLATION-ID", "fe52b710-0312-4cad-8d53-dfd28d4c6f9b");
		form.AddField ("Content-Type", "application/json");
		form.AddField ("User-Agent", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		form.AddField ("Accept", "application/json");
		form.AddField ("Accept-Encoding", "gzip");
		form.AddField ("x-zumo-auth", "ChangeHereForAuthentication");

//		Hashtable headers = form.headers;
		byte[] rawData = form.data;
//		string url = "www.myurl.com";

//		// Add a custom header to the request.
//		// In this case a basic authentication to access a password protected resource.
//		headers["Authorization"] = "Basic " + System.Convert.ToBase64String(
//			System.Text.Encoding.ASCII.GetBytes("username:password"));
		

//		// Post a request to an URL with our custom headers
//		WWW www = new WWW(url, rawData, headers);
//		yield return www;
//		//.. process results from WWW request here...

		return form;
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

//		form.AddField ("Accept", "application/json");
//		form.AddField ("Accept-Encoding", "gzip");

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

		//		form.AddField ("Accept", "application/json");
		//		form.AddField ("Accept-Encoding", "gzip");

		return header;
	}


}
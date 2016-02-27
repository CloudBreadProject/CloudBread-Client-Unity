using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;

public class WWWHelper : MonoBehaviour {

	public delegate void HttpRequestDelegate(int id, WWW www);

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
		StartCoroutine (WaitForRequest (1, www));

	}

	public void get(int id, string url) {
		WWWForm form = getHeader ();
//		WWW www = new WWW (url, form);

		var header = getHeaders (form.headers);
		WWW www = new WWW (url, form.data, header);
		
		StartCoroutine(WaitForRequest(id, www));
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
		StartCoroutine(WaitForRequest(id, www));

	}

	public void post(int id, string url, Dictionary<string, string> data) {
		WWWForm form = new WWWForm();
//		WWWForm form = getHeader();

		data = getHeaders ();

		foreach (KeyValuePair<string, string> post_arg in data) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(id, www));
	}

	public void post(int id, string url) {
		WWWForm form = new WWWForm();
//		WWWForm form = getUserInfoBody();

//		var data = getHeaders ();
		var data = getHeaders(form.headers);
		byte[] jsondata = getUserInfoBody ();

		foreach (KeyValuePair<string, string> post_arg in data) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

//		WWW www = new WWW(url, form);chrome://net-internals/
//		WWW www = new WWW(url, form.data, data);
		WWW www = new WWW(url, jsondata, data);
		StartCoroutine(WaitForRequest(id, www));
	}

	public void POST(string url){
		WWW www = new WWW (url);
		StartCoroutine(WaitForRequest(1, www));
	}


	private IEnumerator  WaitForRequest(int id, WWW www) {

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
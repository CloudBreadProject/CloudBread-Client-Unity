using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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


	public void get(int id, string url) {
		WWWForm form = getHeader ();
//		WWW www = new WWW (url, form);

		var header = getHeaders (form.headers);
		WWW www = new WWW (url, form.data, header);
		
		StartCoroutine(WaitForRequest(id, www));
	}


	public void post(int id, string url, Dictionary<string, string> data) {
		WWWForm form = new WWWForm();

		foreach (KeyValuePair<string, string> post_arg in data) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

			WWW www = new WWW(url, form);chrome://net-internals/
		StartCoroutine(WaitForRequest(id, www));
	}


	private IEnumerator  WaitForRequest(int id, WWW www) {

		yield return www;


		bool hasCompleteListener = (OnHttpRequest != null);

		if (hasCompleteListener) {
			OnHttpRequest(id, www);
		}


		www.Dispose();
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

	private Dictionary<string, string> getHeaders(Dictionary<string, string> hedaer){
		
		hedaer["ZUMO-API-VERSION"] = "2.0.0";
		hedaer["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		hedaer ["X-ZUMO-FEATURES"] = "AJ";
		hedaer ["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
		hedaer ["Content-Type"] = "application/json";
		hedaer["User-Agent"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
		hedaer ["X-ZUMO-AUTH"] = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJzaWQ6YzZhZTNhOTQ3NTdiMDM3N2Y5OTgyZmQwODJhZWVhMmMiLCJpZHAiOiJmYWNlYm9vayIsInZlciI6IjMiLCJpc3MiOiJodHRwczovL2R3LWNsb3VkYnJlYWQteXMuYXp1cmV3ZWJzaXRlcy5uZXQvIiwiYXVkIjoiaHR0cHM6Ly9kdy1jbG91ZGJyZWFkLXlzLmF6dXJld2Vic2l0ZXMubmV0LyIsImV4cCI6MTQ1NjEyODc5MiwibmJmIjoxNDU2MTI1MTkyfQ.CTMp5Myw287z76WhxolzAmPebLUqeFTcSXFdw-VoRXU";

//		form.AddField ("Accept", "application/json");
//		form.AddField ("Accept-Encoding", "gzip");

		return hedaer;
	}


}
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssemblyCSharp;

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
		var header = AzureMobileAppRequestHelper.getHeader();
		WWW www = new WWW (url, null, header);
		
		StartCoroutine(WaitForRequest(id, www));
	}

	// POST with Dictionary JsonData
	public void POST(int id, string url, Dictionary<string, object> JsonData){
		string jsonString = JsonParser.Write (JsonData);
		POST (id.ToString(), url, jsonString);
	}

	// POST with string JsonData
	public void POST(string id, string url, string JsonData){
		var HeaderDic = AzureMobileAppRequestHelper.getHeader();

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
}
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TestString = CBAuthentication.AES_decrypt (token, keyValue, keyValue);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private CBAuthentication Auth;

	private string token = "AFk2+yRQHyvOhJEPZjUYEz4W02jFb+ZNq3od6e/45wJC/YfSZLkmEgzJPkDeeNbzKkveANjfZSlSO/6VXrXpe7GGzGWyFMNJQt5vyJU26H+4liV57PcJg4mJh8A5lJM3jZi4DJaVmO8Bwa+buaOYHA==";
	private string keyValue = "1234567890123456";

	private string TestString = "";

	void OnGUI(){
		GUILayout.BeginVertical ();
		TestString = GUILayout.TextArea (TestString);
		GUILayout.EndVertical ();
	}
}

using UnityEngine;
using System.Collections;

public class CBEncryptTextGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void EncryptButtonClicked (){

	}

	private void DecryptButtonClicked(){

	}

	private string PlainTextString = "";
	private string EncryptTextString = "";

	public void OnGUI(){
		GUILayout.BeginArea(MainAreaRect);
		GUILayout.BeginHorizontal ();

		GUILayout.BeginVertical();
		GUILayout.Label ("Plain Text");
		PlainTextString = GUILayout.TextArea (PlainTextString, GUILayout.Width(500));
		if(GUILayout.Button("Encrypt", GUILayout.Width(220))){
			EncryptButtonClicked ();
		}
		if (GUILayout.Button ("Copy to Clipboard", GUILayout.Width(220))) {

		}
			
		GUILayout.EndVertical ();
	
		GUILayout.BeginVertical ();
		GUILayout.Label ("Encrypt Text");
		EncryptTextString = GUILayout.TextArea (EncryptTextString, GUILayout.Width(500));
		if (GUILayout.Button ("Decrypt", GUILayout.Width (220))) {
			DecryptButtonClicked ();
		}
		if (GUILayout.Button ("Copy to Clipboard", GUILayout.Width (220))) {

		}
		GUILayout.EndVertical ();

		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
	}
}

using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class CBEncryptTextGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ContentAreaRect = new Rect (MainAreaRect.width/2 - (contentWidth/2), MainAreaRect.y, contentWidth, MainAreaRect.height);
	}
	public int contentWidth = 550;
	private Rect ContentAreaRect;

	private string AESKey = "";
	private string AESIV = "";

	private void EncryptButtonClicked (string inputData){
		EncryptTextString = CBAuthentication.AES_encrypt (inputData, AESKey, AESIV);
	}

	private void DecryptButtonClicked(string inputData){
		PlainTextString = CBAuthentication.AES_decrypt (inputData, AESKey, AESIV);
	}

	private string PlainTextString = "";
	private string EncryptTextString = "";

	public void OnGUI(){
		GUILayout.BeginArea(ContentAreaRect);
		GUILayout.BeginVertical ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("AES Key : ", GUILayout.Width(70));
		AESKey = GUILayout.TextField (AESKey, GUILayout.Width (400));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("AES IV  : ", GUILayout.Width(70));
		AESIV = GUILayout.TextField (AESIV, GUILayout.Width (400));
		GUILayout.EndHorizontal ();


		GUILayout.BeginHorizontal ();

		GUILayout.BeginVertical();
		GUILayout.Label ("Plain Text");
		PlainTextString = GUILayout.TextArea (PlainTextString, GUILayout.Width(250), GUILayout.Height(300));
		if(GUILayout.Button("Encrypt", GUILayout.Width(220))){
			EncryptButtonClicked (PlainTextString);
		}

		GUILayout.EndVertical ();
	
		GUILayout.BeginVertical ();
		GUILayout.Label ("Encrypt Text");
		EncryptTextString = GUILayout.TextArea (EncryptTextString, GUILayout.Width(250), GUILayout.Height(300));
		if (GUILayout.Button ("Decrypt", GUILayout.Width (220))) {
			DecryptButtonClicked (EncryptTextString);
		}

		GUILayout.EndVertical ();

		GUILayout.EndHorizontal ();
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

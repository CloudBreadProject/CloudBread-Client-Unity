using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBBaseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		var MainContainer = new GameObject ();
//		MainContainer.name = "Main Camera";
//		var components = MainContainer.GetComponents(typeof(CloudBreadTestUI));
//		components.GetValue(

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string ServerEndPoint;
	public string ServerAddress;

	public Rect MainAreaRect = new Rect (0, 100, Screen.width - 120, 500);


	public string resultJson;

	protected void drawTable(int row, int col, string[] data){
		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			for (int i = 0; i < col; i++) {
				GUILayout.Label (data [j * row + i], GUILayout.Width (100));
			}
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	protected void drawTitleRow(string [] titleData){
		GUILayout.BeginHorizontal ("box");
		for (int i = 0; i < titleData.Length; i++) {
			GUILayout.Label (titleData[i], GUILayout.Width (100));
		}
		GUILayout.EndHorizontal ();
	}
	protected void drawTable(int row, int col, string[] headData, Dictionary<string, object>[] data){
		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < col; i++) {
				string key = headData [i];
				GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}
}

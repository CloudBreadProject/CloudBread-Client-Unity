using UnityEngine;
using System.Collections;

public class CBBaseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI(){

//		GUILayout.BeginScrollView(new Vector2(0, 0,));

//		GUILayout.EndScrollView();
	}

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
}

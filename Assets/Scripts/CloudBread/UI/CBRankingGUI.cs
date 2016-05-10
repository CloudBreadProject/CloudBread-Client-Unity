using UnityEngine;
using System.Collections;

public class CBRankingGUI : MonoBehaviour {

//	float virtualWidth = 1920.0f;
//	float virtualHeight = 1080.0f;


	float virtualWidth = 800.0f;
	float virtualHeight = 480.0f;
	Matrix4x4 matrix;

	ArrayList RankingList;

	struct RankingRow {
		public string NickName;
		public string Score;
	}

	public void setRankingData(){

	}

	// Use this for initialization
	void Start () {
//		#if UNITY_ANDROID
			matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
//		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
//		#
		GUI.matrix = matrix;

		GUI.BeginGroup (new Rect (10, 10, Screen.width - 10, Screen.height - 10));

		GUILayout.BeginVertical ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Ranking");
		GUILayout.EndHorizontal ();

		GUILayout.Label (" ");

		for (int i = 0; i < 10; i++) {
			GUILayout.BeginHorizontal ();
			GUILayout.Label ((i+1).ToString () + ". ");
			GUILayout.Label ("Nick Name");
			GUILayout.Label ("Score");
			GUILayout.EndHorizontal ();
		}

		GUILayout.EndVertical ();

		GUI.EndGroup ();
	}

	void drawRow(){

	}
	
}

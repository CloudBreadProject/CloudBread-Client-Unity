using UnityEngine;
using System.Collections;

public class CBRankingGUI : MonoBehaviour {

//	float virtualWidth = 1920.0f;
//	float virtualHeight = 1080.0f;


	public float virtualWidth = 800.0f;
	public float virtualHeight = 480.0f;
	Matrix4x4 matrix;

	public float RealWidth = 0.0f;
	public float RealHeight = 0.0f;
	public float RealDip = 0.0f;

	ArrayList RankingList;

	public Rect rect;

	struct RankingRow {
		public string NickName;
		public string Score;
	}

	public void setRankingData(){

	}
		
	// Use this for initialization
	void Start () {
//		#if UNITY_ANDROID
//			matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
//		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Vector2 ScrollVec= new Vector2();

	public GUIContent contet;

	void OnGUI(){
		RealWidth = Screen.width;
		RealHeight = Screen.height;
		RealDip = Screen.dpi;
		GUI.matrix = matrix;

		GUI.BeginGroup (new Rect (10, 10, Screen.width - 10, Screen.height - 10));

		GUILayout.BeginVertical ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Ranking");
		GUILayout.EndHorizontal ();

		GUILayout.Label (" ");

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("나의 등수 : ");
		GUILayout.Label ("100");
		GUILayout.Label ("등");
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("100");

		GUILayout.EndHorizontal ();

		GUILayout.BeginScrollView (ScrollVec);
		for (int i = 0; i < 10; i++) {
			GUILayout.BeginHorizontal ();
			GUILayout.Label ((i+1).ToString () + ". ");
			GUILayout.Label ("Nick Name");
			GUILayout.Label ("Score");
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndScrollView ();

		GUILayout.EndVertical ();

		GUI.EndGroup ();
	}

	
}

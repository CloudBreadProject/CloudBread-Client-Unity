using UnityEngine;
using System.Collections;

public class LoginSceneScripts : MonoBehaviour {


//	private int fitScreenWidth = 480;
//	private int fitScreenHeight = 800;
//	private Vector3 guiscale = Vector2.zero; 
//
//	void Awake()
//
//	{
//		//각 디바이스 별로 2:3비율로 화면 재 세팅
//		//Screen.SetResolution(Screen.width,(Screen.width/2)*3,true);
//		Screen.SetResolution(fitScreenWidth,fitScreenHeight  ,false);
//	}

//	void OnGUI()
//
//	{
//		guiscale .x = Screen.width / fitScreenWidth;
//		guiscale .y = Screen.height / fitScreenHeight;
//		guiscale .z = 1.0f;
//
//		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiscale );
//		//TO DO 480* 800에 맞게 GUI작업 
//
//		GUILayout.BeginHorizontal ();
//
//		GUILayout.Label ("aaa");
//		GUILayout.EndHorizontal ();
//
//
//	}

//	float virtualWidth = 1920.0f;
//	float virtualHeight = 1080.0f;

	float virtualWidth = 800.0f;
	float virtualHeight = 480.0f;
	Matrix4x4 matrix;

	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
//		Matrix4x4.TRS(
	}
	void OnGUI ()
	{
		GUI.matrix = matrix;
		GUILayout.Label ("Woo");
	}
//
//	// Use this for initialization
//	void Start () {
//		Screen.autorotateToPortrait = true;
//		Screen.SetResolution (Screen.width, Screen.height / 10 * 16, false);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	void OnGUI(){
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("aaa");
//		GUILayout.Label ("22222");
//
//		GUILayout.EndHorizontal ();
//	}
}

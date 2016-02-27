using UnityEngine;
using System.Collections;

public class CBAuthenticationGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI(){
		GUILayout.BeginArea(MainAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("이 름 : ", GUILayout.Width(150));
				GUILayout.TextField ("이름을 입력해 주세요.");
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("이 메 일 : ", GUILayout.Width(150));
				GUILayout.TextField ("*****@gmail.com");
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("연 락 처 : ", GUILayout.Width(150));
				GUILayout.TextField ("010-1234-1234");
				GUILayout.EndHorizontal ();
				if (GUILayout.Button ("확 인", GUILayout.Height(50))) {

				}
			GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

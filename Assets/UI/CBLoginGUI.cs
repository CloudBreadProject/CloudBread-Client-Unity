using UnityEngine;
using System.Collections;

public class CBLoginUI : CBBaseUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
//		print ("aaaaisdjofjwonvljvof");
		GUILayout.Button ("Login View", GUILayout.Width (Screen.width));
		GUILayout.Button ("Login View", GUILayout.Width (Screen.height));

	}

}

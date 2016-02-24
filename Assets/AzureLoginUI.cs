using UnityEngine;
using System.Collections;

public class AzureLoginUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
		
		GUILayout.Button("Login View", GUILayout.Width(Screen.width));
		GUILayout.Button("Login View", GUILayout.Width(Screen.height));

	}
}

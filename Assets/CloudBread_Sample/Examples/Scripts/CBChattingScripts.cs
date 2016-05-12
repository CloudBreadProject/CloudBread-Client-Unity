using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CBChattingScripts : MonoBehaviour {

//	public GameObject ContnetChatting;

//	private GameObject gbb = new GameObject();

//	public Text text;

	// Use this for initialization
	void Start () {
//		Text t = ContnetChatting.GetComponent<Text> ();

//		GameObject childObject = Instantiate(GameObject.Find("Chat_Panel")) as GameObject;
//
//		GameObject gb = GameObject.Find("Content");
////		var g = gb.AddComponent (typeof(CBEventsGUI));
//
//		gbb.name = "aaaa";
//		gbb.transform.parent = gb.transform;
//		text = gbb.AddComponent<Text> ();
//
//		childObject.transform.parent = gb.transform;


		GameObject childObject = Instantiate (GameObject.Find ("Chat_Panel")) as GameObject;
		GameObject parentObject = GameObject.Find ("Content") as GameObject;

//		childObject.transform.parent = parentObject.transform;
		childObject.transform.SetParent(parentObject.transform, false);

//		using (GameObject childObj = Instantiate (GameObject.Find ("Chat_Panel")) as GameObject) {
//			childObj.transform.SetParent (parentObject.transform, false);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

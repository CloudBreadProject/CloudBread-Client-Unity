using UnityEngine;
using System.Collections;

public class CBGameInfo : CBBaseUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnGUI(){
		
		string[] datas = {
			"memberid",
			"phonenumber1",
			"phonenumber2",
			"plnumber",
			"name1",
			"memberid",
			"phonenumber1",
			"phonenumber2",
			"plnumber",
			"name1"
		};
		drawTable (2, 5, datas);
	}
}

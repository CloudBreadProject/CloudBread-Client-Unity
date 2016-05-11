using UnityEngine;
using UnityEngine.UI;
using System;
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

	public RankingRow[] RankingList;

	public Rect rect;

	public GUIText myRankGUIText;
	public GameObject myNameGUIText;
	public GUIText myScoreGUIText;

//	public ArrayList Ranking = new ArrayList ();

	string testJson = "[{\"element\": \"415ee4a6338615d682e16bb7e6b56f05\",\"score\": 57,\"value\": 57,\"key\": \"415ee4a6338615d682e16bb7e6b56f05\"}]";

	[Serializable]
	public struct RankingRow {
		[SerializeField]
		public string element;

		[SerializeField]
		public string score;

		[SerializeField]
		public string value;

		[SerializeField]
		public string key;
	}


	public void setRankingData(){

	}
		

	// Use this for initialization
	void Start () {
		var a = GameObject.Find ("MyNameText").GetComponent<Text>();
		a.text = "Hong";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

}

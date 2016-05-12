using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class CBRankingGUI : MonoBehaviour {

	public RankingRow[] RankingList;

//	public Rect rect;

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
		
	private const int RANK_NUM = 10;
	private GameObject [] RankingBoardRow_Gameobject = new GameObject [RANK_NUM];

	// Use this for initialization
	void Start () {
		var a = GameObject.Find ("MyNameText").GetComponent<Text>();
		a.text = "Hong";

		RankingBoardRow_Gameobject [0] = GameObject.Find ("RankingBoardRow");
		RankingBoardRow_Gameobject [0].transform.FindChild ("RnakingNumText").GetComponent<Text> ().text = "1";

		GameObject parentObject = GameObject.Find("PanelRankingBoard") as GameObject;

		for (int i = 1; i < RANK_NUM; i++) {
			RankingBoardRow_Gameobject [i] = Instantiate (RankingBoardRow_Gameobject [0]) as GameObject;
			RankingBoardRow_Gameobject[i].transform.SetParent(parentObject.transform, false);
			RankingBoardRow_Gameobject [i].transform.FindChild ("RnakingNumText").GetComponent<Text> ().text = (i + 1).ToString ();
		}

		RankingBoardRow_Gameobject [7].transform.FindChild ("NameText").GetComponent<Text> ().text = "HiHIhI";

		gridLayoutGroup = parentObject.GetComponent<GridLayoutGroup> ();
		rect = parentObject.GetComponent<RectTransform> ();

		gridLayoutGroup.cellSize = new Vector2 (rect.rect.width, 27);
		cellCount = GetComponentsInChildren<RectTransform> ().Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GridLayoutGroup gridLayoutGroup;
	RectTransform rect;
	public float height;
	public int cellCount = 2;
		
	void OnRectTransformDimensionsChange ()
	{
		if (gridLayoutGroup != null && rect != null)
		if ((rect.rect.height + (gridLayoutGroup.padding.horizontal * 2)) * cellCount < rect.rect.width)
			gridLayoutGroup.cellSize = new Vector2 (rect.rect.height, rect.rect.height);
	}
}

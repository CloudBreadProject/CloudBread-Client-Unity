using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class CBBaseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		var MainContainer = new GameObject ();
//		MainContainer.name = "Main Camera";
//		var components = MainContainer.GetComponents(typeof(CloudBreadTestUI));
//		components.GetValue(

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string ServerEndPoint;
	public string ServerAddress;

	public Rect MainAreaRect = new Rect (0, 100, Screen.width - 120, 500);


	public string RequestResultJson = "";
	public Dictionary<string, object>[] ResultDicData;

	public void OnHttpRequest(int id, WWW www) {
		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest -= OnHttpRequest;

		if (www.error != null) {
			Debug.Log ("[Error] " + www.error);
		} else {
			Debug.Log (www.text);
			RequestResultJson = www.text;
			ResultDicData = (Dictionary<string, object>[]) JsonParser.Read2Object(RequestResultJson);

		}
	}

	protected void drawTable(int row, int col, string[] data){
		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			for (int i = 0; i < col; i++) {
				GUILayout.Label (data [j * row + i], GUILayout.Width (100));
			}
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	protected void drawTitleRow(string [] titleData){
		GUILayout.BeginHorizontal ("box");
		for (int i = 0; i < titleData.Length; i++) {
			GUILayout.Label (titleData[i], GUILayout.Width (100));
		}
		GUILayout.EndHorizontal ();
	}

	protected void drawTitleRow(List<string> titleData){
		GUILayout.BeginHorizontal ("box");
		for (int i = 0; i < titleData.Count; i++) {
			GUILayout.Label (titleData[i], GUILayout.Width (100));
		}
		GUILayout.EndHorizontal ();
	}

	protected void drawTable(int row, int col, string[] headData, Dictionary<string, object>[] data){
		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < col; i++) {
				string key = headData [i];
				GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	protected void drawTablewithButton(int row, int col, string[] headData, Dictionary<string, object>[] data, string PrimaryKey){
		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < col; i++) {
				string key = headData [i];
				if(!key.Equals("memberID")){
					dic[key] = GUILayout.TextField ((string)dic[key], GUILayout.Width (100));
				}else
					GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}
			if (GUILayout.Button ("수 정", GUILayout.Width (80))) {
				ModifyButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	protected void drawTablewithButton(int row, int col, Dictionary<string, object>[] data, string PrimaryKey){
		List<string> headerDatas = new List<string>( ResultDicData[0].Keys);
		drawTitleRow (headerDatas);

		GUILayout.BeginVertical ("box");
		for (int j = 0; j < row; j++) {
			GUILayout.BeginHorizontal ("box");
			Dictionary<string,object> dic = data [j];
			for (int i = 0; i < col; i++) {
				string key = headerDatas [i];
				if(!key.Equals("PrimaryKey")){
					dic[key] = GUILayout.TextField ((string)dic[key], GUILayout.Width (100));
				}else
					GUILayout.Label ((string)dic[key], GUILayout.Width (100));
			}
			if (GUILayout.Button ("수 정", GUILayout.Width (80))) {
				ModifyButtonClicked (j, dic);
			}

			GUILayout.EndHorizontal ();
		}
		GUILayout.EndVertical ();
	}

	public virtual void ModifyButtonClicked(int row, Dictionary<string, object> rowDicData){
		print ("[CBBaseGUI] ModifyButtonClicked");
	}
}

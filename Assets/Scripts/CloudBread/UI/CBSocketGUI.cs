using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBSocketGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		_chattingAreaRect = new Rect (MainAreaRect.width/2 - (500/2), MainAreaRect.y, 500, MainAreaRect.height);
		for(int i = 0 ; i<100; i++)
			addChattingList (new ChattingMessage{ userName = "홍 윤 석", content = "aadfjfdjif"});
	}

	// Chatting Data Class
	// ex) userName = 홍윤석, content = Hi
	class ChattingMessage {
		public string userName { get; set; }
		public string content { get; set; }
	}


	// send Button Clicked
	private void sendBtnClicked(string Message){
		addChattingList (new ChattingMessage{ userName = userName, content = Message});
		scrollPosition.y = Mathf.Infinity;

	}

	// add Chatting message in Chatting window
	private void addChattingList(ChattingMessage msg){
		_chattingList.Add (msg);
	}

	private string serverAddress = "";
	private string userName = "";
	private string channelName = "";

	// Chating Message List
	private List<ChattingMessage> _chattingList = new List<ChattingMessage> ();

	private string _chattingMsg = "";
	private Rect _chattingAreaRect;

	public void OnGUI()
	{
		GUILayout.BeginArea(_chattingAreaRect);
		GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Server Address : ", GUILayout.Width(100));
				serverAddress = GUILayout.TextField (serverAddress);
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("User Name : ", GUILayout.Width(100));
				userName = GUILayout.TextField (userName);
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Channel Name : ", GUILayout.Width(100));
				channelName = GUILayout.TextField (channelName);
			GUILayout.EndHorizontal ();

			GUILayout.Label ("");

			GUILayout.BeginVertical ("box");
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(_chattingAreaRect.width), GUILayout.Height(_chattingAreaRect.height - 300));
				foreach (var msg in _chattingList) {
					GUILayout.BeginHorizontal ();
						GUILayout.Label (msg.userName, GUILayout.Width (80));
						GUILayout.TextArea (msg.content, GUILayout.Width(380));
					GUILayout.EndHorizontal ();
				}
				GUILayout.EndScrollView ();
				GUILayout.BeginHorizontal ();
					_chattingMsg = GUILayout.TextField (_chattingMsg);
					if (GUILayout.Button ("Send", GUILayout.Width(50))) {
						sendBtnClicked (_chattingMsg);
					}
				GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

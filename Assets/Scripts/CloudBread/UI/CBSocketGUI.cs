using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class CBSocketGUI : CBBaseUI {
	SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		_chattingAreaRect = new Rect (MainAreaRect.width/2 - (500/2), MainAreaRect.y, 500, MainAreaRect.height);
		for(int i = 0 ; i<100; i++)
			addChattingList (new ChattingMessage{ userName = "홍 윤 석", content = "aadfjfdjif"});
		GameObject go = GameObject.Find ("SocketIO");
		this.socket = go.GetComponent<SocketIOComponent> ();
		this.socket.On("authorized", (SocketIOEvent obj) => {
			print (obj.ToString());
		});
		this.socket.On ("channel connected", (SocketIOEvent obj) => {
			print (obj.ToString());
		});
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

		Dictionary<string, string> user = new Dictionary<string, string> ();
		user ["username"] = this.userName;
		this.socket.Emit ("authenticate user", new JSONObject(user));
	}

	private void UserSendBtnClicked(){
		Dictionary<string, string> user = new Dictionary<string, string> ();
		user ["username"] = this.userName;
		this.socket.Emit ("authenticate user", new JSONObject(user));
	}

	private void ChannalSendBtnClicked(){
		Dictionary<string, string> channel = new Dictionary<string, string> ();
		channel ["link"] = this.channelName;

		this.socket.Emit ("join channel", new JSONObject(channel));
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
			// @TODO remove after authenticated
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("User Name : ", GUILayout.Width(100));
				userName = GUILayout.TextField (userName);
				if(GUILayout.Button("SEND", GUILayout.Width(80))){
					UserSendBtnClicked();
				}
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Channel Name : ", GUILayout.Width(100));
				channelName = GUILayout.TextField (channelName);
				if(GUILayout.Button("SEND", GUILayout.Width(80))){
					ChannalSendBtnClicked();
				}
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

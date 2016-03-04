using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class CBSocketGUI : CBBaseUI {

	SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		_chattingAreaRect = new Rect (MainAreaRect.width/2 - (500/2), MainAreaRect.y, 500, MainAreaRect.height);

		GameObject go = GameObject.Find ("SocketIO");
		this.socket = go.GetComponent<SocketIOComponent> ();
		this.socket.On("authorized", (SocketIOEvent obj) => {
			print (obj.ToString());
		});
		this.socket.On ("channel connected", (SocketIOEvent obj) => {
			print (obj.ToString());
		});
	}

	private void CreateChannel(){
		Dictionary<string, string> channel = new Dictionary<string, string> ();
		channel ["link"] = channelName;

		this.socket.Emit ("join channel", new JSONObject(channel));

		_chattingChannelList.Add (channelName);
		_chattingDic.Add (channelName, new List<ChattingMessage> ());
		_msgTemp.Add ("");
	}

	// Chatting Data Class
	// ex) userName = 홍윤석, content = Hi
	class ChattingMessage {
		public string userName { get; set; }
		public string content { get; set; }
	}


	// send Button Clicked
	private void sendBtnClicked(string channelName, string Message){
		addChattingList (channelName, new ChattingMessage{ userName = userName, content = Message});

		Dictionary<string, string> user = new Dictionary<string, string> ();
		user ["username"] = this.userName;
		this.socket.Emit ("authenticate user", new JSONObject(user));
	}

	private void UserSendBtnClicked(){
		
		Dictionary<string, string> user = new Dictionary<string, string> ();
		user ["username"] = this.userName;
		registerNameBool = true;
		this.socket.Emit ("authenticate user", new JSONObject(user));
	}

	private void ChannalSendBtnClicked(string channelName){
		
		// duplication check
		var chattingChannelNameList = new List<string> (_chattingDic.Keys);
		bool duplicateFlag = false;
		foreach (var key in chattingChannelNameList) {
			if (channelName.Equals (key))
				duplicateFlag = true;
		}

		if (!duplicateFlag)
			CreateChannel ();
	}

	// add Chatting message in Chatting window
	private void addChattingList(string channel, ChattingMessage msg){
		_chattingDic [channel].Add (msg);
	}

	private string getChannelStr (int i ){
		return _chattingChannelList[i];
	}

	private void createChannel(string channelName){
		_chattingChannelList.Add(channelName);
		_chattingDic.Add (channelName, new List<ChattingMessage> ());
	}

	private int getChannelNum(){
		return _chattingChannelList.Count;
	}

	private string userName = "";
	private string channelName = "";

	// Chating Message List
	private Dictionary<string, List<ChattingMessage>> _chattingDic = new Dictionary<string, List<ChattingMessage>> ();
	private List<string> _chattingChannelList = new List<string>();
	private List<string>_msgTemp = new List<string>();

	private Rect _chattingAreaRect;
	private bool registerNameBool = false;

	public void OnGUI()
	{
		GUILayout.BeginArea(_chattingAreaRect);
		GUILayout.BeginVertical ();
		if (!registerNameBool) {
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("User Name : ", GUILayout.Width (100));
				userName = GUILayout.TextField (userName);
				if (GUILayout.Button ("SEND", GUILayout.Width (80))) {
					UserSendBtnClicked ();
				}
			GUILayout.EndHorizontal ();
		} else {
			scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (_chattingAreaRect.width), GUILayout.Height (_chattingAreaRect.height));
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("Channel Name : ", GUILayout.Width (100));
				channelName = GUILayout.TextField (channelName);
				if (GUILayout.Button ("SEND", GUILayout.Width (80))) {
					ChannalSendBtnClicked (channelName);
				}
			GUILayout.EndHorizontal ();

			for (int i = 0; i < getChannelNum(); i++){
				GUILayout.Label ("");
				GUILayout.Label (getChannelStr(i));
				GUILayout.BeginVertical ("box");
				foreach (var msg in _chattingDic[getChannelStr(i)]) {
					GUILayout.BeginHorizontal ();
					GUILayout.Label (msg.userName, GUILayout.Width (80));
					GUILayout.TextArea (msg.content, GUILayout.Width (380));
					GUILayout.EndHorizontal ();
				}
				GUILayout.BeginHorizontal ();

				_msgTemp[i] = GUILayout.TextField (_msgTemp[i]);
				if (GUILayout.Button ("Send", GUILayout.Width (50))) {
					sendBtnClicked (getChannelStr(i), _msgTemp[i]);
					_msgTemp [i] = "";
				}
				GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
			}
			GUILayout.EndScrollView ();
		}
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}

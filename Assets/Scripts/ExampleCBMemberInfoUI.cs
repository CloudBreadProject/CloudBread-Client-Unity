using UnityEngine;
using System.Collections;

public class ExampleCBMemberInfoUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width- _contentWidth, Screen.height - _contentHeight, _contentWidth, _contentHeight);
		_contentAreaRect2 = new Rect (Screen.width+ _contentWidth, Screen.height + _contentHeight, _contentWidth, _contentHeight);
	}

	private string ServerAddress = "";

	private string PathStringLogin = "api/CBSelLoginInfo";
	private string PathStringUpdate = "api/CBCOMUdtMember";

	private string requestData_Login = "";
	private string responseData_Login = "";

	private string requestData_Update = "";
	private string responseData_Update = "";



	private void HTTPRequestSend(){

	}

	private void HTTPRequestAuthSend(){

	}


	private Rect _contentAreaRect;
	private Rect _contentAreaRect2;
	private float _contentWidth = 600;
	private float _contentHeight = 800;
	private Vector2 _scrollPosition;
	private Vector2 _scrollPosition2;

	public void OnGUI(){
		GUILayout.BeginArea (_contentAreaRect);
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(_contentWidth), GUILayout.Height(_contentHeight));
				GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label("Server Address : ", GUILayout.Width(100));
				ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(_contentWidth - 125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label("Path : ", GUILayout.Width(100));
				PathStringLogin = GUILayout.TextField(PathStringLogin, GUILayout.Width(_contentWidth-125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				if (GUILayout.Button ("Send", GUILayout.Width (80))) {
					HTTPRequestSend ();
				}
				if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
					HTTPRequestAuthSend ();
				}
				GUILayout.EndHorizontal ();
				GUILayout.Label ("");
				GUILayout.Label ("Request Data : ");
				requestData_Login = GUILayout.TextArea (requestData_Login, GUILayout.Width(_contentWidth), GUILayout.Height(50));

				GUILayout.Label ("");
				GUILayout.Label ("Response Data : ");
				responseData_Login = GUILayout.TextArea (responseData_Login, GUILayout.Width(_contentWidth), GUILayout.Height(300));
				GUILayout.EndVertical ();
			GUILayout.EndScrollView ();
		GUILayout.EndArea ();

		GUILayout.BeginArea (_contentAreaRect2);
			_scrollPosition2 = GUILayout.BeginScrollView(_scrollPosition2, GUILayout.Width(_contentWidth), GUILayout.Height(_contentHeight));
				GUILayout.BeginVertical ();
					GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Server Address : ", GUILayout.Width(100));
					ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(_contentWidth - 125));
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Path : ", GUILayout.Width(100));
					PathStringUpdate = GUILayout.TextField(PathStringUpdate, GUILayout.Width(_contentWidth-125));
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ();
					if (GUILayout.Button ("Send", GUILayout.Width (80))) {
						HTTPRequestSend ();
					}
					if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
						HTTPRequestAuthSend ();
					}
					GUILayout.EndHorizontal ();
					GUILayout.Label ("");
					GUILayout.Label ("Request Data : ");
					requestData_Update = GUILayout.TextArea (requestData_Update, GUILayout.Width(_contentWidth), GUILayout.Height(50));

					GUILayout.Label ("");
					GUILayout.Label ("Response Data : ");
					responseData_Update = GUILayout.TextArea (responseData_Update, GUILayout.Width(_contentWidth), GUILayout.Height(300));
				GUILayout.EndVertical ();
			GUILayout.EndScrollView ();
		GUILayout.EndArea ();
	}
}

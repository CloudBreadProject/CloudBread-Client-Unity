using UnityEngine;
using System.Collections;
using Facebook.Unity;

public class CloudBreadTestUI : MonoBehaviour {

	private string ServerAddress = "https://dw-cloudbread-ys.azurewebsites.net/api/ping";
	private string FacebookAccessToken = "xxx";

	private enum TESTPAGE {main, login, authentication, userInfo, gameInfo, itemList, userItem, gameStage, notice, events, coupons};
	private TESTPAGE currentPage = TESTPAGE.main;

	private string textFieldString = "text filed";

	private string textAreaString = "text area";

	private string workspaceAreaString = "";
	private string jsonAreaString = "Json Area";

	void awake(){
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}
	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	private void LoginGUI(){
		
	}

	private void AuthenticationGUI(){
//		GUILayout.BeginHorizontal ("box");
		GUILayout.Button ("Facebook 인증", GUILayout.Width (100));
		GUILayout.Button ("Twitter 인증", GUILayout.Width (100));
		GUILayout.Button ("Google ID 인증", GUILayout.Width (100));
		GUILayout.Button ("Microsoft ID 인증", GUILayout.Width (100));
		ServerAddress = GUILayout.TextField (ServerAddress);
//		GUILayout.BeginHorizontal ();
	}
	private void UserInfoGUI(){
		GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("이 름 : ", GUILayout.Width(150));
				GUILayout.TextField ("이름을 입력해 주세요.");
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("이 메 일 : ", GUILayout.Width(150));
				GUILayout.TextField ("*****@gmail.com");
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("연 락 처 : ", GUILayout.Width(150));
				GUILayout.TextField ("010-1234-1234");
			GUILayout.EndHorizontal ();
			if (GUILayout.Button ("확 인", GUILayout.Height(50))) {
			}
		GUILayout.EndVertical ();
	}
	private void GameInfoGUI(){
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
	private void ItenListtGUI(){
	}
	private void UserItemGUI(){
	}
	private void GameStageGUI(){
	}
	private void NoticeGUI(){
	}
	private void EventsGUI(){
	}
	private void CouponsGUI(){
	}

	private string jsonAreaInitString = "Json Area";

	public void OnGUI()
	{
		GUILayout.BeginHorizontal ();
		GUILayout.BeginArea(new Rect(0,0,Screen.width/5, Screen.height));
			GUILayout.BeginVertical("box");
			if (GUILayout.Button ("로그인 페이지", GUILayout.Height(50))) {
				print ("Login Page");
				currentPage = TESTPAGE.login;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("인증 후 이름 \n 메일 저장", GUILayout.Height(50))) {
				print ("Authentication Page");
				currentPage = TESTPAGE.authentication;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("회원 정보", GUILayout.Height(50))) {
				print ("UserInfo Page");
				currentPage = TESTPAGE.userInfo;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게임 정보", GUILayout.Height(50))) {
				print ("GameInfo Page");
				currentPage = TESTPAGE.gameInfo;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("아이템 목록", GUILayout.Height(50))) {
				print ("ItemList Page");
				currentPage = TESTPAGE.itemList;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게이머 소유\n아이템 목록", GUILayout.Height(50))) {
				print ("UserItem Page");
				currentPage = TESTPAGE.userItem;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게임 스테이지", GUILayout.Height(50))) {
				print ("GameStage Page");
				currentPage = TESTPAGE.gameStage;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("공지사항", GUILayout.Height(50))) {
				print ("Notice Page");
				currentPage = TESTPAGE.notice;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("이벤트", GUILayout.Height(50))) {
				print ("Events Page");
				currentPage = TESTPAGE.events;
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("쿠폰", GUILayout.Height(50))) {
				print ("Coupons Page");
				currentPage = TESTPAGE.coupons;
				jsonAreaString = jsonAreaInitString;
			}
			GUILayout.EndVertical();
		GUILayout.EndArea();

		GUILayout.BeginArea (new Rect (Screen.width / 5, 0, Screen.width, Screen.height));
		GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label ("서버 주소 : ");
					ServerAddress = GUILayout.TextField (ServerAddress, GUILayout.Width(300));
					if (GUILayout.Button ("Ping 확인", GUILayout.Width(100))) {
						WWWHelper helper = WWWHelper.Instance;
						helper.OnHttpRequest += OnHttpRequest;
						helper.get (100, ServerAddress);
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label ("인증 상태 : ");
					GUILayout.Label ("페이스북");	
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label ("CloudBread 버전 : ");
					GUILayout.Label ("CloudBread ver 2.0.0-dev");
				GUILayout.EndHorizontal ();
			GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ("box", GUILayout.Height(250));
	
			switch (currentPage) {
			case TESTPAGE.main:
				break;
			case TESTPAGE.login:
				LoginGUI ();
				break;
			case TESTPAGE.authentication:
				AuthenticationGUI ();
				break;
			case TESTPAGE.userInfo:
				UserInfoGUI ();
				break;
			case TESTPAGE.gameInfo:
				GameInfoGUI ();
				break;
			case TESTPAGE.itemList:
				ItenListtGUI ();
				break;
			case TESTPAGE.userItem:
				UserItemGUI ();
				break;
			case TESTPAGE.gameStage:
				GameStageGUI ();
				break;
			case TESTPAGE.notice:
				NoticeGUI ();
				break;
			case TESTPAGE.events:
				EventsGUI ();
				break;
			case TESTPAGE.coupons:
				CouponsGUI ();
				break;
			default:
				break;
			}
			GUILayout.EndHorizontal ();
			
		jsonAreaString = GUILayout.TextArea (jsonAreaString, GUILayout.Height (300));
		
		
//			GUILayout.BeginVertical ("box");
//			GUILayout.TextArea ("aaaa", 250);
//
//			GUILayout.EndVertical ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
		GUILayout.EndHorizontal ();

	}

	void OnHttpRequest(int id, WWW www) {
		if (www.error != null) {
			Debug.Log ("[Error] " + www.error);
		} else {
			Debug.Log (www.text);
			jsonAreaString = www.text;
		}
	}


	private void drawTable(int row, int col, string[] data){
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
}

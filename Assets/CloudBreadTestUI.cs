using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class CloudBreadTestUI : MonoBehaviour {

	public string ServerAddress = "http://dw-cloudbread2.azurewebsites.net/";
	private string FacebookAccessToken = "xxx";
	public string AuthKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJzaWQ6YzZhZTNhOTQ3NTdiMDM3N2Y5OTgyZmQwODJhZWVhMmMiLCJpZHAiOiJmYWNlYm9vayIsInZlciI6IjMiLCJpc3MiOiJodHRwczovL2R3LWNsb3VkYnJlYWQteXMuYXp1cmV3ZWJzaXRlcy5uZXQvIiwiYXVkIjoiaHR0cHM6Ly9kdy1jbG91ZGJyZWFkLXlzLmF6dXJld2Vic2l0ZXMubmV0LyIsImV4cCI6MTQ1NjE1MDkxNywibmJmIjoxNDU2MTQ3MzE3fQ.YqE2gLZVAX-Q_97DydrFKRKWPSsxxncIWIqNs0xrIiE";


	private enum TESTPAGE {main, login, authentication, userInfo, memberGameInfo, itemList, userItem, gameStage, notice, events, coupons};

	private string jsonAreaString = "Json Area";
	private string jsonAreaInitString = "Json Area";

	private AzureMobileApp _azure;

	private GameObject MainContainer;
	private CBBaseUI _mainView;

	private AzureMobileAppRequestHelper requestHelper;

	// Use this for initialization
	void Start () {
		_azure = new AzureMobileApp (ServerAddress, AuthKey);
		MainContainer = new GameObject ();
		MainContainer.name = "MainView";

		requestHelper = new AzureMobileAppRequestHelper ();
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

	public void test(){

	}

	public void OnGUI()
	{
		
		GUILayout.BeginHorizontal ();
		GUILayout.BeginArea(new Rect(new Vector2(Screen.width - 120, 0), new Vector2(120, Screen.height)));
//		GUILayout.BeginArea(new Rect(0,0, Screen.width/5, Screen.height));
			GUILayout.BeginVertical("box");
			if (GUILayout.Button ("메인 페이지", GUILayout.Height(50))) {
				print ("Main Page");
				jsonAreaString = jsonAreaInitString;
				PresentationView (TESTPAGE.main);
				test ();
			}
			if (GUILayout.Button ("로그인 페이지", GUILayout.Height(50))) {
				print ("Login Page");
				jsonAreaString = jsonAreaInitString;
				PresentationView (TESTPAGE.login);
			}
			if (GUILayout.Button ("인증 후 이름 \n 메일 저장", GUILayout.Height(50))) {
				print ("Authentication Page");
				PresentationView (TESTPAGE.authentication);
				jsonAreaString = jsonAreaInitString;

			}
			if (GUILayout.Button ("회원 정보", GUILayout.Height(50))) {
				print ("UserInfo Page");
				PresentationView (TESTPAGE.userInfo);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게임 정보", GUILayout.Height(50))) {
				print ("GameInfo Page");
				PresentationView (TESTPAGE.memberGameInfo);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("아이템 목록", GUILayout.Height(50))) {
				print ("ItemList Page");
				PresentationView (TESTPAGE.itemList);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게이머 소유\n아이템 목록", GUILayout.Height(50))) {
				print ("UserItem Page");
				PresentationView (TESTPAGE.userItem);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("게임 스테이지", GUILayout.Height(50))) {
				print ("GameStage Page");
				PresentationView (TESTPAGE.gameStage);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("공지사항", GUILayout.Height(50))) {
				print ("Notice Page");
				PresentationView (TESTPAGE.notice);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("이벤트", GUILayout.Height(50))) {
				print ("Events Page");
				PresentationView (TESTPAGE.events);
				jsonAreaString = jsonAreaInitString;
			}
			if (GUILayout.Button ("쿠폰", GUILayout.Height(50))) {
				print ("Coupons Page");
				PresentationView (TESTPAGE.coupons);
				jsonAreaString = jsonAreaInitString;
			}
			GUILayout.EndVertical();
		GUILayout.EndArea();

//		GUILayout.BeginArea (new Rect (Screen.width / 5, 0, Screen.width, Screen.height));
		GUILayout.BeginArea (new Rect (0, 0, Screen.width -120, Screen.height));
		GUILayout.BeginVertical ();
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label ("서버 주소 : ", GUILayout.Width(80));
					ServerAddress = GUILayout.TextField (ServerAddress, GUILayout.Width(300));
					if (GUILayout.Button ("Ping 확인", GUILayout.Width(100))) {
						WWWHelper helper = WWWHelper.Instance;
						helper.OnHttpRequest += OnHttpRequest;
//						helper.get (10, "http://dw-cloudbread2.azurewebsites.net/api/CBSocketAuth");
//						helper.get(19, "http://dw-cloudbread2.azurewebsites.net/api/ver");
//						print(AuthenticationProvider.Facebook.ToString().ToLower());


					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
					GUILayout.BeginHorizontal ("box");
						GUILayout.Label ("인증 상태 : ");
						GUILayout.Label ("페이스북");	
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ("box");
						GUILayout.Label ("CloudBread 버전 : ");
						GUILayout.Label ("CloudBread ver 2.0.0-dev");
					GUILayout.EndHorizontal ();
				GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();

		GUILayout.BeginHorizontal ("box", GUILayout.Height(250));
	
			GUILayout.EndHorizontal ();
			/////////////////////////
//		jsonAreaString = GUILayout.TextArea (jsonAreaString, GUILayout.Height (300));
		

//			GUILayout.BeginVertical ("box");
//			GUILayout.TextArea ("aaaa", 250);
//
//			GUILayout.EndVertical ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
		GUILayout.EndHorizontal ();

	}

	void OnHttpRequest(string id, WWW www) {
		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest -= OnHttpRequest;

		if (www.error != null) {
			Debug.Log ("[Error] " + www.error);
		} else {
			Debug.Log (www.text);
			print (www.text);
			jsonAreaString = www.text;
			requestHelper.setTokenJson (www.text);
		}
	}


	private void PresentationView(TESTPAGE testpage) {
		RemoveMainView ();
			//		Destroy (GetComponents (_mainView));
		CBBaseUI ui;
		
		switch (testpage) {
		case TESTPAGE.main:
			ui = MainContainer.AddComponent (typeof(CBBaseUI)) as CBBaseUI;
			break;
		case TESTPAGE.login:
			ui = MainContainer.AddComponent(typeof(CBLoginUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.authentication:
			ui = MainContainer.AddComponent(typeof(CBAuthenticationGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.userInfo:
			ui = MainContainer.AddComponent(typeof(CBUserInfoUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.memberGameInfo:
			ui = MainContainer.AddComponent(typeof(CBMemberGameInfoGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.itemList:
			ui = MainContainer.AddComponent(typeof(CBItemListGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.userItem:
			ui = MainContainer.AddComponent(typeof(CBUserItemGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.gameStage:
			ui = MainContainer.AddComponent(typeof(CBGameStageGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.notice:
			ui = MainContainer.AddComponent(typeof(CBNoticeGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.events:
			ui = MainContainer.AddComponent(typeof(CBEventsGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		case TESTPAGE.coupons:
			ui = MainContainer.AddComponent(typeof(CBCouponsGUI)) as CBBaseUI;
			ui.enabled = true;
			break;
		default:
			ui = MainContainer.AddComponent(typeof(CBBaseUI)) as CBBaseUI;
			break;
		}

		ui.ServerAddress = ServerAddress;

	}

	private void RemoveMainView(){
		var components = MainContainer.GetComponents(typeof(CBBaseUI));

		foreach(CBBaseUI comp in components){

			//			if( !( comp instanceof MeshFilter) ){

			Destroy(comp);

			//			}

		}
	}


}

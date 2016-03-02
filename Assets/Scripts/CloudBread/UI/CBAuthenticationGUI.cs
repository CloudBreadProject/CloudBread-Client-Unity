using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class CBAuthenticationGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ContentAreaRect = new Rect (MainAreaRect.width/2 - (contentWidth/2), MainAreaRect.y, contentWidth, MainAreaRect.height);
	}

	public int contentWidth = 750;
	private Rect ContentAreaRect;

	private string memberName = "이름을 입력해 주세요.";
	private string memberEmail = "*****@gmail.com";
	private string memberPhone = "010-1234-1234";

	private void sendButtonClicked(){
		CBInsRegMemberController controller = new CBInsRegMemberController(
			new CBInsRegMemberController.InputParams{
				MemberID_Members = memberName,
				MemberPWD_Members = "MemberPWD_Members",
				Name1_Members = memberName,
				EmailAddress_Members = memberEmail,
				PhoneNumber1_Members = memberPhone
			},
			ServerAddress,
			Callback_Success,
			Callback_Error
		);
	}
		
	private void Callback_Success(string id, WWW www){
		RequestResultJson = www.text;
	}

	private void Callback_Error(string id, WWW www){
		RequestResultJson = "[Error] " + www.text;	
	}

	public void OnGUI(){
		GUILayout.BeginArea(ContentAreaRect);
//		GUILayout.FlexibleSpace();
			GUILayout.BeginVertical ();
				GUILayout.Label ("Sign in From : "); 
				GUILayout.BeginHorizontal ("box");

				GUILayout.Label ("이 름 : ", GUILayout.Width(80));
				memberName =GUILayout.TextField (memberName);
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("이 메 일 : ", GUILayout.Width(80));
				memberEmail = GUILayout.TextField (memberEmail);
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
				GUILayout.Label ("연 락 처 : ", GUILayout.Width(80));
				memberPhone = GUILayout.TextField (memberPhone);
				GUILayout.EndHorizontal ();
				if (GUILayout.Button ("확 인")) {
					sendButtonClicked ();
				}
			
				GUILayout.Label ("");
				GUILayout.Label ("Result : ");
				RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Width(contentWidth), GUILayout.Height(300));
			GUILayout.EndVertical ();
//		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
	}
}

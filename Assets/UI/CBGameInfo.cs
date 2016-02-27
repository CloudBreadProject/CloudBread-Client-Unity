/*
 * 
 * 	MemberGameInfo 테이블의 정보를 표시 
	MemberGameInfo 테이블의 데이터를 텍스트 박스에 표시 - B37 SelMemberGameInfo
	MemberGameInfo 수정시 텍스트를 수정하고 수정 버튼을 누르면 – B58 CBComUdtMemberGameInfoes

	sCol 컬럼인 여분의 컬럼은 nvarchar(max) 데이터임. 컬럼이 부족할 경우 sCol에 json 기반으로 추가 데이터를 저장/조회도 가능

 */



using UnityEngine;
using System.Collections;

public class CBGameInfo : CBBaseUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnGUI(){
		
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
}

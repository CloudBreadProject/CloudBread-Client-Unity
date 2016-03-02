/*
 * 쿠폰 처리
Coupon은 쿠폰 정보를 저장하고, CouponMember는 쿠폰을 사용한(추가로 쿠폰 사용 제한) member를 기록하는 테이블
쿠폰은 기간과 여러 member 중복 사용 가능 여부(DupeYN) 따라 표시되고 member의 조건에 맞는 쿠폰 데이터 조회됨
쿠폰들 리스트 조회를 위해 B14 SelCoupons 수행
클라이언트 화면에서는 “쿠폰 사용”버튼을 누르면 B15 UdtCouponMember 수행해 MemberItem에 이벤트 아이템 등을 저장. 
UdtCouponMember을 수행하면 내부에서 CouponMember 에 저장되고, 이후 조건에 따라 리스팅 되지 않음.

 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBCouponsGUI : CBBaseUI {

	// Use this for initialization
	void Start () {
		ServerEndPoint = ServerAddress + "api/CBSelCoupons";

		WWWHelper helper = WWWHelper.Instance;
		helper.OnHttpRequest += OnHttpRequest;
		helper.POST (2, ServerEndPoint, CreateJsonData ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string [] _headerString = {
		"couponID",
		"couponCategory1",
		"couponCategory2",
		"couponCategory3",
		"itemListID",
		"itemCount",
		"itemStatus",
		"title",
		"content"
	};


	public Dictionary<string, object> CreateJsonData(){
		var JsonDic = new Dictionary<string, object> ();
		JsonDic.Add ("memberID", "bbb");

		return JsonDic;
	}

	public void OnGUI()
	{
		GUILayout.BeginArea(MainAreaRect);
			GUILayout.BeginVertical();
			//				drawTable (1, _headerString.Length, _headerString);
			drawTitleRow(titleData:_headerString);
			if( ResultDicData!= null)
				drawTable (ResultDicData.Length, _headerString.Length, _headerString, ResultDicData);

			RequestResultJson = GUILayout.TextArea (RequestResultJson, GUILayout.Height (300));
			GUILayout.EndVertical();
		GUILayout.EndArea ();

	}
}

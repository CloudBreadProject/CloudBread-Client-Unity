using UnityEngine;
using System.Collections;
using Assets.Scripts.CloudBread;
using System.Text;

public class WWWHelper : MonoBehaviour {

    //싱글톤 구현

    static WWWHelper current = null;
    static GameObject container = null;

    public static WWWHelper Instance
    {
        get
        {
            if (current == null)
            {
                container = new GameObject();
                container.name = "WWWHelper";
                current = container.AddComponent(typeof(WWWHelper)) as WWWHelper;
            }
            return current;
        }
    }

    //Request Delegate
    public delegate void HttpRequestDelegate(string id, WWW www);

    public event HttpRequestDelegate OnHttpRequest;

    public void POST(string id, string url, string jsonData)
    {
        //헤더 추가 (AzureMobileAppRequestHelper를 만들어서 헤더 자동 생성)
        var HeaderDic = AzureMobileAppRequestHelper.getHeader();

        WWW www = new WWW(url, Encoding.UTF8.GetBytes(jsonData), HeaderDic);
        StartCoroutine(WaitForRequest(id, www));
    }

    private IEnumerator WaitForRequest(string id, WWW www)
    {
        yield return www;

        bool hasCompleteListener = (OnHttpRequest != null);

        if (hasCompleteListener)
        {
            OnHttpRequest(id, www);
        }

        www.Dispose();

    }
    
}

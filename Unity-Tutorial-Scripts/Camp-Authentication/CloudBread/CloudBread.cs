using JsonFx.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.CloudBread
{
    class CloudBread
    {
        string ServerAddress = "https://cb2-auth-demo.azurewebsites.net/";

        private Action<string, WWW> Callback;
        public void Login(AzureAuthentication.AuthenticationProvider provider, string token, Action<string, WWW> callback)
        {
            var path = ".auth/login/" + provider.ToString().ToLower();

            AzureAuthentication.AuthenticationToken authToken = AzureAuthentication.CreateToken(provider, token);

            var jsonWriter = new JsonWriter();
            var jsonStr = jsonWriter.Write(authToken);

            //WWWHelper를 사용하여 http Reqeust!
            WWWHelper helper = WWWHelper.Instance;
            helper.OnHttpRequest += OnHttpRequest;

            Callback = callback;

            helper.POST("Login", ServerAddress + path, jsonStr);
        }

        public void CBInsRegMember(Action<string, WWW> callback)
        {
            var ServerEndPoint = ServerAddress + "api/CBInsRegMember";

            WWWHelper helper = WWWHelper.Instance;
            helper.OnHttpRequest += OnHttpRequest;

            MemberData memberData = new MemberData
            {
                MemberID_Members = (string)PlayerPrefs.GetString("userId"),
                EmailAddress_Members = (string)PlayerPrefs.GetString("userId"),
                Name1_Members = (string)PlayerPrefs.GetString("nickName")
            };

            JsonWriter jsonWriter = new JsonWriter();
            string jsonBody = jsonWriter.Write(memberData);

            helper.POST("CBInsRegMember", ServerEndPoint, jsonBody);

            Callback = callback;
        }

        public void CBComUdtMemberGameInfoes(Action<string, WWW> callback)
        {
            var ServerEndPoint = ServerAddress + "api/CBComUdtMemberGameInfoes";

            WWWHelper helper = WWWHelper.Instance;
            helper.OnHttpRequest += OnHttpRequest;

            MemberGameInfo gameinfoData = new MemberGameInfo
            {
                MemberID = (string)PlayerPrefs.GetString("userId"),
                Level = 2,
                Points = PlayerPrefs.GetInt("bestScore")
            };

            JsonWriter jsonWriter = new JsonWriter();
            string jsonBody = jsonWriter.Write(gameinfoData);

            helper.POST("CBComUdtMemberGameInfoes", ServerEndPoint, jsonBody);

            Callback = callback;
        }

        public void CBRank(Action<string, WWW> callback)
        {
            var ServerEndPoint = ServerAddress + "api/CBRank";

            WWWHelper helper = WWWHelper.Instance;
            helper.OnHttpRequest += OnHttpRequest;

            Dictionary<string, string> bodyDic = new Dictionary<string, string>();
            bodyDic.Add("sid", (string)PlayerPrefs.GetString("nickName"));
            bodyDic.Add("point", (string)PlayerPrefs.GetInt("bestScore").ToString());

            JsonWriter jsonWriter = new JsonWriter();

            helper.POST("CBRank", ServerEndPoint, jsonWriter.Write(bodyDic));

            Callback = callback;
        }



        public void OnHttpRequest(string id, WWW www)
        {
            WWWHelper helper = WWWHelper.Instance;
            helper.OnHttpRequest -= OnHttpRequest;

            Callback(id, www);
        }
    }
}

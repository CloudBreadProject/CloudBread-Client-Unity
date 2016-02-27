using System;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;

namespace AssemblyCSharp
{
	public class JsonParser
	{
		public JsonParser ()
		{
		}

		public static string Write(Dictionary<string, object> obj){
			return JsonWriter.Serialize (obj);
		}

		public static Dictionary<string, object> Read(string json){
			var requestDic= JsonReader.Deserialize < Dictionary<string, object>>(json);
			return requestDic;
		}

		public static object Read2Object (string json){
//			var requestDic= JsonReader.Deserialize <List<string>>(json);
			var requestDic = JsonReader.Deserialize (json);
			return requestDic;
		}
	}
}


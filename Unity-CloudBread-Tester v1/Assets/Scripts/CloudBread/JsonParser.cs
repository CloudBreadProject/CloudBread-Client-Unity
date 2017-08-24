using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;
// Json Library Change

namespace AssemblyCSharp
{
	public class JsonParser
	{
		public JsonParser ()
		{
		}

		public static string Write(object obj){
			return JsonUtility.ToJson(obj);
//			return JsonFx.Json.JsonWriter.Serialize (obj);
		}

		public static string Write(Dictionary<string, object> obj){
			return JsonUtility.ToJson (obj);
//			return JsonWriter.Serialize (obj);
		}

		public static string WritePretty(Dictionary<string,object>[] obj){
			return WritePretty (obj);;
		}

		public static string WritePretty(object obj){

//			JsonWriterSettings settings = new JsonWriterSettings();
//			settings.PrettyPrint = true;
//			JsonFx.Json.JsonDataWriter writer = new JsonDataWriter(settings);
//
//			StringWriter wr = new StringWriter();
//			writer.Serialize(wr, obj);

//			string json = wr.ToString();

			string json = JsonUtility.ToJson (obj);

			return json;
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

		public static T Read<T>(string json){
			return JsonReader.Deserialize<T> (json);
		}
	}
}


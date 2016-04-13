using System;
using System.IO;
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

		public static string Write(object obj){
			return JsonFx.Json.JsonWriter.Serialize (obj);
		}

		public static string Write(Dictionary<string, object> obj){
			return JsonWriter.Serialize (obj);
		}

		public static string WritePretty(Dictionary<string,object>[] obj){

			JsonWriterSettings settings = new JsonWriterSettings();
			settings.PrettyPrint = true;
			JsonFx.Json.JsonDataWriter writer = new JsonDataWriter(settings);

			StringWriter wr = new StringWriter();
			writer.Serialize(wr, obj);

			string json = wr.ToString();

			return json;
		}

		public static string WritePretty(object obj){

			JsonWriterSettings settings = new JsonWriterSettings();
			settings.PrettyPrint = true;
			JsonFx.Json.JsonDataWriter writer = new JsonDataWriter(settings);

			StringWriter wr = new StringWriter();
			writer.Serialize(wr, obj);

			string json = wr.ToString();

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


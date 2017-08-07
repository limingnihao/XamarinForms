using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Community.Helps
{
    public class JsonHelp
    {
		public static T FromJson<T>(string jsonString)
		{
			if (jsonString == null || "".Equals(jsonString))
			{
				return default(T);
			}
			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
			{
				return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
			}
		}

		public static T parse<T>(string jsonString)
		{
			return FromJson<T>(jsonString);
		}

		public static string ToJson(object jsonObject)
		{
			if (jsonObject == null)
			{
				return "";
			}
			using (var ms = new MemoryStream())
			{
				new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                byte[] result = ms.ToArray();
                return Encoding.UTF8.GetString(result, 0, result.Length);
			}
		}
	}


}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace SendEmail
{
    public class Json
    {
        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="key">JSON文件中的key值</param>
        /// <returns>JSON文件中的value值</returns>
        public static string Readjson(string key)
        {
            string jsonfile = @"..\..\..\SubmitJobAuto\Setting.json";//JSON文件路径

            using (StreamReader file = File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key].ToString();
                    return value;
                }
            }
        }

        public static string ReadRjson(string key, string key2)
        {
            string jsonfile = @"..\..\..\SubmitJobAuto\SubmitReport.json";//JSON文件路径

            using (StreamReader file = File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key][key2].ToString();
                    return value;
                }
            }
        }

        public static string Readjson(string key1, string key2)
        {
            string jsonfile = @"..\..\..\SubmitJobAuto\Setting.json";//JSON文件路径

            using (StreamReader file = File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key1][key2].ToString();
                    return value;
                }
            }
        }

        public static void Updatejson(string text, string key1, string key2)
        {
            string jsonfile = @"..\..\..\SubmitJobAuto\SubmitReport.json";//JSON文件路径
            string jsonString = File.ReadAllText(jsonfile, Encoding.Default);//读取文件
            JObject jobject = JObject.Parse(jsonString);//解析成json
            jobject[key1][key2] = text;//替换需要的文件
            string convertString = Convert.ToString(jobject);//将json装换为string
            File.WriteAllText(jsonfile, convertString);//将内容写进jon文件中
        }
    }
}

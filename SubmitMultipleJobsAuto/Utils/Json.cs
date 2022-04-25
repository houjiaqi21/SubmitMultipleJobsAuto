using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace SubmitMultipleJobsAuto
{
    public class Json
    {

        /// <summary>
        /// Read a string from a json file
        /// </summary>
        /// <param name="key1">json first-level keyword</param>
        /// <param name="key2">json secondary keyword, can be null</param>
        /// <param name="jsonfile">json filename to read</param>
        /// <returns>read value</returns>
        public static string Readjson(string key1, string key2, string jsonfile)
        {
            jsonfile = @"..\..\..\SubmitMultipleJobsAuto\Json\" + jsonfile + ".json";

            using (StreamReader file = File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    string value;

                    if(key2 == null)
                    {
                        value = o[key1].ToString();
                    }
                    else
                    {
                        value = o[key1][key2].ToString();
                    }

                    return value;
                }
            }
        }

        public static void Updatejson(string text, string key1, string key2, string key3, string jsonfile)
        {
            jsonfile = @"..\..\..\SubmitMultipleJobsAuto\Json\" + jsonfile + ".json";//JSON文件路径
            string jsonString = File.ReadAllText(jsonfile, Encoding.Default);//读取文件
            JObject jobject = JObject.Parse(jsonString);//解析成json
            if(key3 != null)
            {
                jobject[key1][key2][key3] = text;
            }

            if (key2 != null)
            {
                jobject[key1][key2] = text;
            }
            else
            {
                jobject[key1] = text;//替换需要的文件
            }
            
            string convertString = Convert.ToString(jobject);//将json装换为string
            File.WriteAllText(jsonfile, convertString);//将内容写进jon文件中

        }

        public static void WriterjsonEnd(string key1, string key2, string key3, string jsonfile)
        {
            jsonfile = @"..\..\..\SubmitMultipleJobsAuto\Json\" + jsonfile + ".json";
            string jsonString = File.ReadAllText(jsonfile, Encoding.Default);//读取文件
            JObject jobject = JObject.Parse(jsonString);//解析成json

            if(key3 == null)
            {
                jobject.Add(key1, key2);
            }
            else
            {
                JObject relationShip = new JObject();
                relationShip.Add(key2, new JValue(key3));

                jobject.Add(key1, relationShip);
            }

            string convertString = Convert.ToString(jobject);//将json装换为string
            File.WriteAllText(jsonfile, convertString);//将内容写进jon文件中

        }

        public static void Cleanjson(string jsonfile)
        {
            jsonfile = @"..\..\..\SubmitMultipleJobsAuto\Json\" + jsonfile + ".json";
            JObject jobject = new JObject();

            string convertString = Convert.ToString(jobject);//将json装换为string
            File.WriteAllText(jsonfile, convertString);//将内容写进jon文件中
        }

    }
}

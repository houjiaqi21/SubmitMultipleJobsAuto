using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://prod-16.eastus2.logic.azure.com:443/workflows/28eecf48b48d4616a1045475b0857361/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=AMU8o0R4rVQwmfyNyVZqKtNZEsuPWOI18J-DhN-5UX8";

            string bits = SubmitMultipleJobsAuto.Json.Readjson("bits", null, "Setting");
            string installationNotes = MailText("InstallationNotes");
            string screenFolder = SubmitMultipleJobsAuto.Json.Readjson("folderName", null, "screenshotSetting");
            string testRound = SubmitMultipleJobsAuto.Json.Readjson("testRound", null, "screenshotSetting");
            string screenFolderPath = "devtooltelemetrygen23.blob.core.windows.net/synapseautomation/";
            string screenFolderLink = MailText("screenFolderLink_1") + screenFolder + "%2F" + testRound + MailText("screenFolderLink_2");

            string MailHTMLBodyTital = MailText("MailHTMLBodyTital_1") + bits + MailText("MailHTMLBodyTital_2") + MailText("MailHTMLBodyTital_tabletitle");
            string MailHTMLBodyEnd = MailText("MailHTMLBodyEnd_1") + screenFolderLink + "(<font color=RoyalBlue>" + screenFolderPath + screenFolder + "</font>)" + MailText("MailHTMLBodyEnd_2") + installationNotes + MailText("MailHTMLBodyEnd_3");

            string MailHTMLBody = MailHTMLBodyTital;

            int flag = 0;
            int infoNum = Convert.ToInt32(SubmitMultipleJobsAuto.Json.Readjson("flag", null, "submittedJobName")); 
            do
            {
                string info = TableContent(flag);

                MailHTMLBody = MailHTMLBody + info;

                flag++;
            } while (flag < infoNum);

            MailHTMLBody = MailHTMLBody + MailHTMLBodyEnd;

            string user = MailText("users");
            //string user = "v-jiaqihou@microsoft.com";
            string result = PostUrl(url, 
                "{\n \"MailBody\": \""+ MailHTMLBody + "\",\n \"Subject\": \"Scope Automation Submmit Information\",\n \"To\": \"" + user + "\",\n \"CC\": \"v-jiaqihou@microsoft.com\",\n \"Attachments\": \"\",\n \"AttachmentName\": \"\"\n}");

            //CleanUp();

        }

        private static string PostUrl(string url, string postData)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version11;
                // 这里设置了协议类型。
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
                request.KeepAlive = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                ServicePointManager.DefaultConnectionLimit = 100;
                ServicePointManager.Expect100Continue = false;
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(url);
            }

            request.Method = "POST";    //使用get方式发送数据
            request.ContentType = "application/json";
            request.Referer = null;
            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Accept = "*/*";

            byte[] data = Encoding.UTF8.GetBytes(postData);
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            //获取网页响应结果
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string result = string.Empty;
            using (StreamReader sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        private static string MailText(string tag)
        {
            return SubmitMultipleJobsAuto.Json.Readjson(tag, null, "emailconfig");
        }

        private static void CleanUp()
        {
            SubmitMultipleJobsAuto.Json.Cleanjson("submittedJobName");
            SubmitMultipleJobsAuto.Json.Cleanjson("jobSettingInfo");
            SubmitMultipleJobsAuto.Json.WriterjsonEnd("flag", "0", null, "submittedJobName");
            SubmitMultipleJobsAuto.Json.Updatejson("0", "testRoundTag", null, null, "Setting");
        }

        private static string TableContent(int flag)
        {
            string jobNameNow = SubmitMultipleJobsAuto.Json.Readjson(flag.ToString(), null, "submittedJobName");

            string jobName = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "Job Name", "jobSettingInfo");
            string scriptName = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "Script Name", "jobSettingInfo");
            string vSVerson = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "VS Verson", "jobSettingInfo");
            string projectName = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "Project Name", "jobSettingInfo");
            string vCName = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "VC Name", "jobSettingInfo");
            string submmitStatus = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "Submmit status", "jobSettingInfo");
            string jobUrl = SubmitMultipleJobsAuto.Json.Readjson(jobNameNow, "Submit link", "jobSettingInfo");

            string info = "<td>" + jobName + "</td><td>" + scriptName + "</td><td>" + vSVerson + "</td><td>" + projectName +
                "</td><td>" + vCName + "</td><td>" + submmitStatus + "</td><td>" + jobUrl + "</td></tr>";
            return info;
        }
    }

}

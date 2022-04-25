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

            //font-family='verdana,arial,sans-serif' color='#333333' border-width='2px' border-collapse='collapse' border-color='#666666'  background-color='#dedede'
            string bits = SubmitMultipleJobsAuto.Json.Readjson("bits", null, "Setting");
            //string screenFolder = SubmitMultipleJobsAuto.Json.Readjson("bits", null, "screenshotSetting");
            string help = "<a href = 'https://microsoft.sharepoint.com/teams/CosmosBDP/_layouts/OneNote.aspx?id=%2Fteams%2FCosmosBDP%2FShared%20Documents%2FScopeStudio%2FCosmosTest%2FCOSMOS%20Test%20Team%20DOCS&amp;wd=target%28_Scope%2FScope%20Studio%20Automation.one%7CFF3ABE6A-F992-4789-9CC2-13FD820C980B%2FHow%20to%20check%20the%20Screenshot%7C97B40290-C844-4D29-9D2E-C4D9BE55421E%2F%29'> here </a>";
            string screenFolder = SubmitMultipleJobsAuto.Json.Readjson("folderName", null, "screenshotSetting");
            string MailHTMLBodyTital = "<HTML><head><title></title></head> <body style='font-family:Arial,Helvetica,Sans-Serif'>" + 
                "Hello all，<br/> <br/>below is the information for submitting job on bits：<font color=red>" + bits + "</font><br/><br/>" +
                "<p><table border='1' cellpadding='5' cellspacing='0' width='100%' bordercolor='#B3B3B3'><tr bgcolor='#dedede'><th>Job Name</th>" +
                "<th>Script Name</th><th>VS Verson</th><th>Project Name</th><th>VC Name</th><th>Submit Statue</th><th>Submit Link</th></tr><tr>";
            string MailHTMLBodyEnd = "</table></p><br/><br/>Screenshots about test results are stored in https://devtooltelemetrygen23.blob.core.windows.net/synapseautomation/"
                + screenFolder + "<br/>You can refer " + help + " to learn how to view screenshots <br/>"
                //+ "https://microsoft.sharepoint.com/teams/CosmosBDP/_layouts/OneNote.aspx?id=%2Fteams%2FCosmosBDP%2FShared%20Documents%2FScopeStudio%2FCosmosTest%2FCOSMOS%20Test%20Team%20DOCS&wd=target%28_Scope%2FScope%20Studio%20Automation.one%7CFF3ABE6A-F992-4789-9CC2-13FD820C980B%2FHow%20to%20check%20the%20Screenshot%7C97B40290-C844-4D29-9D2E-C4D9BE55421E%2F%29" 
                + "<br/><br/>Thank you !</HTML>";

            string MailHTMLBody = MailHTMLBodyTital;

            int flag = 0;
            
            int infoNum = Convert.ToInt32(SubmitMultipleJobsAuto.Json.Readjson("flag", null, "submittedJobName")); 
            do
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
                    "</td><td>" + vCName + "</td><td>" + submmitStatus + "</td><td>"+ jobUrl + "</td></tr>";

                MailHTMLBody = MailHTMLBody + info;

                flag++;
            } while (flag < infoNum);

            MailHTMLBody = MailHTMLBody + MailHTMLBodyEnd;

            //string user = "v-jiaqihou@microsoft.com;v-shuaitong@microsoft.com;v-meizhang@microsoft.com;v-qinzhao@microsoft.com;v-yanjing@microsoft.com";
            string user = "v-jiaqihou@microsoft.com";
            string result = PostUrl(url, 
                "{\n \"MailBody\": \""+ MailHTMLBody + "\",\n \"Subject\": \"Scope Automation Submmit Information\",\n \"To\": \"" + user + "\",\n \"CC\": \"v-jiaqihou@microsoft.com\",\n \"Attachments\": \"\",\n \"AttachmentName\": \"\"\n}");

            SubmitMultipleJobsAuto.Json.Cleanjson("submittedJobName");
            SubmitMultipleJobsAuto.Json.Cleanjson("jobSettingInfo");
            SubmitMultipleJobsAuto.Json.WriterjsonEnd("flag", "0", null, "submittedJobName");
            SubmitMultipleJobsAuto.Json.Updatejson("0", "testRoundTag", null, null, "Setting");

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
    }

    internal class Mail
    {
    }
}

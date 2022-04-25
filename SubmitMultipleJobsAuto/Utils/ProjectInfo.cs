using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitMultipleJobsAuto
{
    public static class ProjectInfo
    {
        public static string projectNameNow;
        public static WinWindow VsProjectN;
        public static string jobName;
        public static string scriptName;
        public static string vsVerson;
        public static string vcName;
        public static string jobUrl;

        public static int vcFlag;
        public static bool submitExceptionTag = false;

        public static List<string> submitedJobname = new List<string>();
        //public static List<string> jsonPath_now;

        public static string logFinalPath;

        public static string testStartTime;

        public static int jobListEndFlag;
        public static int jobFlag;

    }
}

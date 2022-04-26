using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace SubmitMultipleJobsAuto
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {

        public CodedUITest1()
        {

        }

        [TestMethod]
        public void ScopAll_In_OneTestMethod()
        {
            do
            {
                ProjectInfo.jobFlag = 0;
                Common.InitProjectInfo();
                Common.Openscopeproject(Json.Readjson("scope_project_path", ProjectInfo.jobFlag.ToString(), "Setting"), "2019");
                Playback.Wait(1900);

                Common.Maximized();
                TitleBar.ResetWindowLayout();

                Common.LogText("open successed");

                Common.ProjectSpec(ProjectInfo.jobFlag);

                int subjobnum = 0;
                foreach(string content in ProjectInfo.submitedJobname)
                {
                    Json.WriterjsonEnd(subjobnum.ToString(), content, null, "submittedJobName");
                    subjobnum++;
                }
                Json.WriterjsonEnd("flag", subjobnum.ToString(), null, "submittedJobName");

                Playback.Wait(3000);
                break;

                //ProjectInfo.jobFlag++;
            }
            while (ProjectInfo.jobFlag < ProjectInfo.jobListEndFlag);

            //MessageBox.Show(Json.Readjson("EndFlag", null, "joblist"));
        }

        [TestMethod]
        public void Submmit_0_1_ScopAll_In_One()
        {
            GeneralProcess.OpenInit(0);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_0_2_ScopAll_In_One()
        {
            GeneralProcess.OpenInit(0);
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void Submmit_1_1_DebugFailedVertex()
        {
            GeneralProcess.OpenInit(1);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_1_2_DebugFailedVertex()
        {
            GeneralProcess.OpenInit(1);
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void testMethod3Async()
        {
            //Json.WriterjsonEnd("job2", "name", "1", "test"); //Updatejson
            //Json.Updatejson("2", "job2", "link", null, "test");
            //Json.Cleanjson("test");
            //Json.Updatejson("8", "test", null, null, "submittedJobName");
            //int seconds_to_sleep = 5;
            //var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            //Task<bool> submitExceptionTag = WaitSubmit();
            //Trace.WriteLine("testing...");

            //pathString = Path.Combine(pathString, folderName);
            //Directory.CreateDirectory(pathString);


            //while (true)
            //{
            //    Thread.Sleep(wait_time);
            //    if (submitExceptionTag.Result)
            //    {
            //        break;
            //    }
            //}

            WinWindow mywindow = new WinWindow();
            mywindow.SearchProperties[WinWindow.PropertyNames.Name] = "ScopAll_In_One - Microsoft Visual Studio";
            WinEdit jobResult = Common._winEdit(mywindow, "Job Result");
            //Mouse.Hover(jobResult);
            //Playback.Wait(3000);
            Mouse.MoveScrollWheel(jobResult , - 1);
            int i = 0;
            do {
                Mouse.MoveScrollWheel(-1);
                i++;
            } while (i < 9);
            Playback.Wait(3000);

        }

        private async Task<bool> WaitSubmit()
        {
            return await Task.Run(() =>
            {
                int seconds_to_sleep = 1 * 60;
                var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
                Thread.Sleep(wait_time);
                return true;
            });
        }

        private async Task<bool> WaitSubmit2()
        {
            return await Task.Run(() =>
            {
                int seconds_to_sleep = 1 * 60;
                var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
                Thread.Sleep(wait_time);
                return true;
            });
        }

        [TestMethod]
        public void Submmit_2_1_Parameter()
        {
            GeneralProcess.OpenInit(2);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_2_2_Parameter()
        {
            GeneralProcess.OpenInit(2);
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void Submmit_3_1_FileSetsVertex()
        {
            GeneralProcess.OpenInit(3);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_3_2_FileSetsVertex()
        {
            GeneralProcess.OpenInit(3);
            ProjectInfo.vcFlag = 3;
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void Submmit_4_1_ClusterReference()
        {
            GeneralProcess.OpenInit(4);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_4_2_ClusterReference()
        {
            GeneralProcess.OpenInit(4);
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void Submmit_5_1_DebugStream()
        {
            GeneralProcess.OpenInit(5);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void Submmit_5_2_DebugStream()
        {
            GeneralProcess.OpenInit(5);
            GeneralProcess.CommonSubmitUntilEnd();
        }

        [TestMethod]
        public void Submmit_6_NAatFirstError()
        {
            GeneralProcess.OpenInit(6);
            GeneralProcess.CommonSubmit();
        }

        [TestMethod]
        public void AutoInit()
        {
            string folderName = DateTime.Now.ToString("yyyyMMdd");
            int testRoundTag = Convert.ToInt32(Json.Readjson("testRoundTag", null, "Setting")) + 1;
            string testRound = "testRound" + testRoundTag;
            Json.Updatejson(testRoundTag.ToString(), "testRoundTag", null, null, "Setting");
            Json.Updatejson(folderName, "folderName", null, null, "screenshotSetting");
            Json.Updatejson(testRound, "testRound", null, null, "screenshotSetting");
        }

        [TestMethod]
        public void DebugLocally_0()
        {
            GeneralProcess.OpenInit(0);
            GeneralProcess.CommonDebug();
        }

        [TestMethod]
        public void DebugLocally_1()
        {
            GeneralProcess.OpenInit(1);
            GeneralProcess.CommonDebug();
        }

        [TestMethod]
        public void DebugLocally_2()
        {
            GeneralProcess.OpenInit(2);
            GeneralProcess.CommonDebug();
        }
        #region AutoInit
        //[TestMethod]
        //public void AutoInit2()
        //{
        //    MessageBox.Show("2");
        //}
        //[TestMethod]
        //public void AutoInit3()
        //{
        //    MessageBox.Show("3");
        //}

        //[TestMethod]
        //public void AutoInit4()
        //{
        //    MessageBox.Show("4");
        //}

        //[TestMethod]
        //public void AutoInit5()
        //{
        //    MessageBox.Show("5");
        //}
        #endregion
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //MessageBox.Show("1");
            //string folderName = DateTime.Now.ToString("yyyyMMddhhmmss");
            //Json.Updatejson(folderName, "folderName", null, null, "screenshotSetting");
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        #region instantiate
        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;

        public Common Common
        {
            get
            {
                if (this.common == null)
                {
                    this.common = new Common();
                }

                return this.common;
            }
        }

        private Common common;

        public TitleBar TitleBar
        {
            get
            {
                if (this.titleBar == null)
                {
                    this.titleBar = new TitleBar();
                }

                return this.titleBar;
            }
        }

        private TitleBar titleBar;

        public SubmitJobPage SubmitJobPage
        {
            get
            {
                if (this.submitJobPage == null)
                {
                    this.submitJobPage = new SubmitJobPage();
                }

                return this.submitJobPage;
            }
        }

        private SubmitJobPage submitJobPage;

        public GeneralProcess GeneralProcess
        {
            get
            {
                if (this.generalProcess == null)
                {
                    this.generalProcess = new GeneralProcess();
                }

                return this.generalProcess;
            }
        }

        private GeneralProcess generalProcess;
        #endregion
    }
}

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SubmitMultipleJobsAuto
{
    public class GeneralProcess
    {
        public void OpenInit(int jobflag)
        {
            //string folderName = DateTime.Now.ToString("yyyyMMddhhmmss");
            //Json.Updatejson(folderName, "folderName", null, null, "screenshotSetting");
            ProjectInfo.jobFlag = jobflag;
            Common.InitProjectInfo();

            Common.Openscopeproject(Json.Readjson("scope_project_path", ProjectInfo.jobFlag.ToString(), "Setting"), "2019");
            Playback.Wait(1900);

            Common.Maximized();
            TitleBar.ResetWindowLayout();
        }

        public void CommonSubmit()
        {
            do
            {
                Common.ClickSubmit(Json.Readjson("script_name", ProjectInfo.jobFlag.ToString(), "Setting"));

                Common.EnterJobName();

                Common.SelectCurrentVC(ProjectInfo.vcFlag);
                //Playback.Wait(5000);
                Common.ChooseCosmosRuntime(ProjectInfo.vcFlag);

                SubmitJobPage.ClickSubmit();

                Common.SubmitJudge();
                ProjectInfo.vcFlag++;
            }
            while (ProjectInfo.vcFlag < 4);

            Common.RecordJobName();
        }

        public void CommonSubmitUntilEnd()
        {
            do
            {
                Common.ClickSubmit(Json.Readjson("script_name", ProjectInfo.jobFlag.ToString(), "Setting"));

                Common.EnterJobName();

                Common.SelectCurrentVC(ProjectInfo.vcFlag);
                //Playback.Wait(5000);
                Common.ChooseCosmosRuntime(ProjectInfo.vcFlag);

                SubmitJobPage.ClickSubmit();

                Common.SubmitJudgeUntilEnd();
                Common.RecordJobNameEach();
                ProjectInfo.vcFlag++;
            }
            while (ProjectInfo.vcFlag < 4);

            //Common.RecordJobName();
        }

        public void CommonDebug()
        {
            Common.ClickDebug(Json.Readjson("script_name", ProjectInfo.jobFlag.ToString(), "Setting"));
            Common.DebugJudgeUntilEnd("_1");
            //Playback.Wait(10000);

            WpfPane solution = Common._wpfPane(ProjectInfo.VsProjectN, "Solution Explorer");
            WinTreeItem projectn = Common._winTreeItem(solution, ProjectInfo.scriptName);
            Mouse.DoubleClick(projectn);

            Keyboard.SendKeys("{F5}", ModifierKeys.Control);

            //int seconds_to_sleep = 20;
            //var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            //Thread.Sleep(wait_time);
            Playback.Wait(25000);

            WinWindow cmd = Common._window(@"C:\windows\system32\CMD.exe");
            //cmd.DrawHighlight();
            Mouse.Click(cmd);
            Keyboard.SendKeys("a");

            Common.DebugJudgeUntilEnd("_2");
            //ApplicationUnderTest.Launch(Json.Readjson("automation_project_path", null, "Setting") + @"\UploadScreenshot\bin\Release\UploadScreenshot.exe");

        }

        #region instantiate
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
        #endregion
    }
}

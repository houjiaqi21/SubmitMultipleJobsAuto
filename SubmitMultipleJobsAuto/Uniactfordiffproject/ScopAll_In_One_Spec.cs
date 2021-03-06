using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SubmitMultipleJobsAuto
{
    public class ScopAll_In_One_Spec
    {
        bool submitExceptionTag;
        public void DoAction()
        {
            WpfPane solution = Common._wpfPane(ProjectInfo.VsProjectN, "Solution Explorer");
            WinTreeItem projectn = Common._winTreeItem(solution, "Scope19.script");
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);

            ProjectInfo.scriptName = "Scope19.script";
            //Json.Updatejson(ProjectInfo.scriptName, ProjectInfo.projectNameNow, "Script Name", "jobSettingInfo"); //Updatejson
            ScopeMenu.ClickSubmit();

            WpfPane submitJob = Common._wpfPane(ProjectInfo.VsProjectN, "Submit Job");

            WpfEdit editbox1 = new WpfEdit(submitJob);
            UITestControlCollection editbox = editbox1.FindMatchingControls();
            foreach (UITestControl x in editbox)
            {
                Mouse.Click(x);
                Keyboard.SendKeys("A", ModifierKeys.Control);
                ProjectInfo.jobName = ProjectInfo.projectNameNow + "_houjiaqi" + Common.DateTimeToStamp(DateTime.Now);
                //string sJobname = ProjectInfo.jobName;
                //ProjectInfo.submitedJobname.Add(sJobname);
                Keyboard.SendKeys(ProjectInfo.jobName);
                break;
            }

            Common.SelectCurrentVC(ProjectInfo.vcFlag);

            Common.ChooseCosmosRuntime(ProjectInfo.vcFlag);

            WpfEdit textBoxExtraCmdLine = new WpfEdit(submitJob);
            textBoxExtraCmdLine.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "textBoxExtraCmdLineArguments";

            if (!textBoxExtraCmdLine.Exists)
            {
                WpfButton jobProperties = Common._wpfButton(submitJob, "Job Properties");
                Mouse.Click(jobProperties);
            }

            SubmitJobPage.SubmitP();

            SubmitJobPage.ClickSubmit();

            WpfButton submitYes = Common._wpfButton(ProjectInfo.VsProjectN, "Yes");
            Mouse.Click(submitYes);

            WinPane jobView = Common._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);

            Playback.Wait(10000);

            int seconds_to_sleep = 5;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread submitException_thread = new Thread(new ThreadStart(SubmitException));
            submitException_thread.Start();

            while (true)
            {
                jobView = Common._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);
                if (jobView.Exists || submitExceptionTag)
                {
                    if (jobView.Exists)
                    {
                        WinButton copy = Common._winButton(ProjectInfo.VsProjectN, "Copy URL to clipboard");
                        Mouse.Hover(copy);
                        Mouse.Click();
                        string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text));

                        ProjectInfo.jobUrl = message;

                        Keyboard.SendKeys("{F4}", ModifierKeys.Control);
                        Common.RecordSubmitInfo();
                        submitExceptionTag = false;
                    }
                    else
                    {
                        Common.RecordSubmitInfoFail();
                        submitExceptionTag = false;
                    }
                    ProjectInfo.submitedJobname.Add(ProjectInfo.jobName);
                    break;
                }
                Thread.Sleep(wait_time);
            }
        }

        public void SubmitException()
        {
            int seconds_to_sleep = 3 * 60;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread.Sleep(wait_time);
            submitExceptionTag = true;
        }


        #region instantiate
        public ScopeMenu ScopeMenu
        {
            get
            {
                if (this.menuFun == null)
                {
                    this.menuFun = new ScopeMenu();
                }

                return this.menuFun;
            }
        }

        private ScopeMenu menuFun;

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

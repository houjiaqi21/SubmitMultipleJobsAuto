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
    public class DebugFailedVertex_Spec
    {
        public void DoAction()
        {

            //WpfPane solution = Common._wpfPane(ProjectInfo.VsProjectN, "Solution Explorer");
            //WinTreeItem projectn = Common._winTreeItem(solution, "Scope17.script");
            //Mouse.Click(projectn);

            //ProjectInfo.scriptName = "Scope17.script";
            //ScopeMenu.ClickSubmit();
            string script = "Scope17.script";
            Common.ClickSubmit(script);

            //WpfPane submitJob = Common._wpfPane(ProjectInfo.VsProjectN, "Submit Job");

            //WpfEdit editbox1 = new WpfEdit(submitJob);
            //UITestControlCollection editbox = editbox1.FindMatchingControls();
            //foreach (UITestControl x in editbox)
            //{
            //    Mouse.Click(x);
            //    Keyboard.SendKeys("A", ModifierKeys.Control);
            //    ProjectInfo.jobName = ProjectInfo.projectNameNow + "_houjiaqi" + Common.DateTimeToStamp(DateTime.Now);
            //    Keyboard.SendKeys(ProjectInfo.jobName);
            //    break;
            //}
            Common.EnterJobName();

            Common.SelectCurrentVC(ProjectInfo.vcFlag);
            Common.ChooseCosmosRuntime(ProjectInfo.vcFlag);

            SubmitJobPage.ClickSubmit();

            //WinPane jobView = Common._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);

            //Playback.Wait(10000);

            //int seconds_to_sleep = 5;
            //var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            //Thread submitException_thread = new Thread(new ThreadStart(SubmitException));
            //submitException_thread.Start(submitExceptionTag);

            //while (true)
            //{
            //    jobView = Common._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);
            //    if (jobView.Exists || ProjectInfo.submitExceptionTag)
            //    {
            //        if (jobView.Exists)
            //        {
            //            WinButton copy = Common._winButton(ProjectInfo.VsProjectN, "Copy URL to clipboard");
            //            Mouse.Hover(copy);
            //            Mouse.Click();
            //            string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text));

            //            ProjectInfo.jobUrl = message;

            //            Keyboard.SendKeys("{F4}", ModifierKeys.Control);
            //            Common.RecordSubmitInfo();
            //        }
            //        else
            //        {
            //            Common.RecordSubmitInfoFail();
            //        }
            //        ProjectInfo.submitedJobname.Add(ProjectInfo.jobName);
            //        break;
            //    }
            //    Thread.Sleep(wait_time);
            //}
            Common.SubmitJudge();
        }

        public void SubmitException()
        {
            int seconds_to_sleep = 3 * 60;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread.Sleep(wait_time);
            ProjectInfo.submitExceptionTag = true;
        }

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
    }
}

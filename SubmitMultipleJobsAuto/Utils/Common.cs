using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SubmitMultipleJobsAuto
{
    public class Common
    {
        #region Basic operation
        //GENERAL FUNCTION FOR COMMON CONTROLS

        /// <summary>
        /// open visual studio
        /// </summary>
        /// <param name="verson">visual studio verson</param>
        public void _launchVs(String verson)
        {
            if (verson == "2019")
            {
                string vslocation = Json.Readjson("vs2019_location", null, "Setting");
                ApplicationUnderTest.Launch(vslocation);
            }

            if (verson == "2022")
            {
                string vslocation = Json.Readjson("vs2022_location", null, "Setting");
                ApplicationUnderTest.Launch(vslocation);
            }
        }

        /// <summary>
        /// Find WinWindow by name
        /// </summary>
        /// <param name="WinName">WinWindow's name</param>
        /// <returns>WinWindow</returns>
        public WinWindow _window(string WinName)
        {
            WinWindow mywindow = new WinWindow();
            mywindow.SearchProperties[WinWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        /// <summary>
        /// Find WinWindow by name from Parent Control
        /// </summary>
        /// <param name="ParentWindow">Parent's name</param>
        /// <param name="WinName">WinWindow's name</param>
        /// <returns>WinWindow</returns>
        public WinWindow _window(UITestControl ParentWindow, string WinName)
        {
            WinWindow mywindow = new WinWindow(ParentWindow);
            mywindow.SearchProperties[WinWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        /// <summary>
        /// Find WpfWindow by name
        /// </summary>
        /// <param name="WpfName">WpfWindow's name</param>
        /// <returns></returns>
        public WpfWindow _wpfwindow(string WpfName)
        {
            WpfWindow mywpfdow = new WpfWindow();
            mywpfdow.SearchProperties[WpfWindow.PropertyNames.Name] = WpfName;
            return mywpfdow;
        }

        /// <summary>
        /// Find WpfWindow by name from Parent Control
        /// </summary>
        /// <param name="ParentWindow">Parent's name</param>
        /// <param name="WinName">WpfWindow's name</param>
        /// <returns></returns>
        public WpfWindow _wpfwindow(UITestControl ParentWindow, string WinName)
        {
            WpfWindow mywindow = new WpfWindow(ParentWindow);
            mywindow.SearchProperties[WpfWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        public WinPane _winPane(string PropertyName)
        {
            WinPane mywinPane = new WinPane();
            mywinPane.SearchProperties[WinPane.PropertyNames.Name] = PropertyName;
            return mywinPane;
        }
        public WinPane _winPane(UITestControl ParentWindow, string PropertyName)
        {
            WinPane mywinPane = new WinPane(ParentWindow);
            mywinPane.SearchProperties[WinPane.PropertyNames.Name] = PropertyName;
            return mywinPane;
        }


        public WpfPane _wpfPane(string PropertyName)
        {
            WpfPane mywpfPane = new WpfPane();
            mywpfPane.SearchProperties[WpfPane.PropertyNames.Name] = PropertyName;
            return mywpfPane;
        }
        public WpfPane _wpfPane(UITestControl ParentWindow, string PropertyName)
        {
            WpfPane mywpfPane = new WpfPane(ParentWindow);
            mywpfPane.SearchProperties[WpfPane.PropertyNames.Name] = PropertyName;
            return mywpfPane;
        }

        public WinMenuItem _winMenuItem(UITestControl ParentWindow, string PropertyName)
        {
            WinMenuItem mywinmenuitem = new WinMenuItem(ParentWindow);
            mywinmenuitem.SearchProperties[WinMenuItem.PropertyNames.Name] = PropertyName;
            return mywinmenuitem;
        }

        public WpfMenuItem _wpfMenuItem(UITestControl ParentWindow, string PropertyName)
        {
            WpfMenuItem mywpfmenuitem = new WpfMenuItem(ParentWindow);
            mywpfmenuitem.SearchProperties[WpfMenuItem.PropertyNames.Name] = PropertyName;
            return mywpfmenuitem;
        }

        public WinTreeItem _winTreeItem(UITestControl ParentControl, string PropertyName)
        {
            WinTreeItem selectCluster = new WinTreeItem(ParentControl);
            selectCluster.SearchProperties[WinMenuItem.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }

        public WpfTreeItem _wpfTreeItem(UITestControl ParentControl, string PropertyName)
        {
            WpfTreeItem selectCluster = new WpfTreeItem(ParentControl);
            selectCluster.SearchProperties[WpfMenuItem.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }

        public WinButton _winButton(UITestControl ParentWindow, string PropertyName)
        {
            WinButton mybutton = new WinButton(ParentWindow);
            mybutton.SearchProperties[WinButton.PropertyNames.Name] = PropertyName;

            return mybutton;
        }


        public WpfButton _wpfButton(UITestControl ParentWindow, string PropertyName)
        {
            WpfButton mybutton = new WpfButton(ParentWindow);
            mybutton.SearchProperties[WpfButton.PropertyNames.Name] = PropertyName;

            //if (mybutton.Exists == true)
            //{
            //    Mouse.Click(mybutton);
            //}
            return mybutton;
        }


        public WinEdit _winEdit(UITestControl ParentWindow, string SendingValue, string PropertyName)
        {
            WinEdit mywinedit = new WinEdit(ParentWindow);
            mywinedit.SearchProperties[WinEdit.PropertyNames.Name] = PropertyName;
            Keyboard.SendKeys(mywinedit, SendingValue);
            return mywinedit;
        }

        public WinEdit _winEdit(UITestControl ParentWindow, string PropertyName)
        {
            WinEdit mywinedit = new WinEdit(ParentWindow);
            mywinedit.SearchProperties[WinEdit.PropertyNames.Name] = PropertyName;
            return mywinedit;
        }

        public UITestControl _wpfEdit(UITestControl ParentWindow, string SendingValue, string PropertyName)
        {
            WpfEdit mywpfedit = new WpfEdit(ParentWindow);
            mywpfedit.SearchProperties[WpfEdit.PropertyNames.Name] = PropertyName;
            Keyboard.SendKeys(mywpfedit, SendingValue);
            return mywpfedit;
        }

        public static WinText _MyWinText(UITestControl ParentControl, string PropertyName)
        {
            WinText selectCluster = new WinText(ParentControl);
            selectCluster.SearchProperties[WinText.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }

        public static WpfText _MyWpfText(UITestControl ParentControl, string PropertyName)
        {
            WpfText selectCluster = new WpfText(ParentControl);
            selectCluster.SearchProperties[WpfText.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }
        #endregion

        #region Open scope project
        /// <summary>
        /// Open a existing scope project with vs
        /// </summary>
        /// <param name="path">scope project path</param>
        public void Openscopeproject(string path, string vsVerson)
        {
            WpfWindow OpenProject = _wpfwindow("Open Project/Solution");

            _launchVs(vsVerson);
            ProjectInfo.vsVerson = vsVerson;
            StartPage.ClickOpen();
            Keyboard.SendKeys(path);
            Keyboard.SendKeys("{Enter}");
        }

        public StartPage StartPage
        {
            get
            {
                if (this.startPage == null)
                {
                    this.startPage = new StartPage();
                }

                return this.startPage;
            }
        }

        private StartPage startPage;
        #endregion

        #region Maximized
        /// <summary>
        /// Maximized window
        /// </summary>
        public void Maximized()
        {
            #region Variable Declarations
            WpfWindow uIScopAll_In_OneMicrosWindow = this.ProjectVsWindowNew;
            #endregion

            // Maximize window 'ScopAll_In_One - Microsoft Visual Studio'
            uIScopAll_In_OneMicrosWindow.SetProperty("State", ControlStates.Maximized);
        }

        #region Properties
        ProjectVsWindowNow ProjectVsWindowNew
        {
            get
            {
                string projectName = ProjectInfo.projectNameNow;
                if ((this.mProjectVsWindowNow == null))
                {
                    this.mProjectVsWindowNow = new ProjectVsWindowNow();
                }
                return this.mProjectVsWindowNow;
            }
        }
        #endregion

        #region Fields
        private ProjectVsWindowNow mProjectVsWindowNow;
        #endregion
        #endregion

        #region Choose VC
        public void ChooseVC(string resource, string targetVC)
        {
            WpfPane submitJob = CommonInit._wpfPane(ProjectInfo.VsProjectN, "Submit Job");

            WpfComboBox anaResource = new WpfComboBox(submitJob);
            anaResource.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "analyticsResource";
            Mouse.Click(anaResource);
            Keyboard.SendKeys(resource);
            Keyboard.SendKeys("{Enter}");

            WpfComboBox target = new WpfComboBox(submitJob);
            target.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "targetVCComboBox";
            Mouse.Click(target);
            Keyboard.SendKeys(targetVC);
            Keyboard.SendKeys("{Enter}");
        }

        public void SelectCurrentVC(int vcflag)
        {
            switch (vcflag)
            {
                case 0:
                    CommonInit.ChooseVC("cosmos", "cosmos09.cosmosAdmin");
                    ProjectInfo.vcName = "cosmos: cosmos09.cosmosAdmin";
                    break;
                case 1:
                    //zhblueshiftgen2
                    CommonInit.ChooseVC("ADLA", "zhblueshiftgen2");
                    ProjectInfo.vcName = "ADLA: zhblueshiftgen2";
                    break;
                case 2:
                    CommonInit.ChooseVC("ADLA", "sandbox-c08");
                    ProjectInfo.vcName = "ADLA: sandbox-c08";
                    break;
                case 3:
                    CommonInit.ChooseVC("Synapse", "sandboxwcus");
                    CommonInit.ChooseVC("ADLA", "sandbox-c08");
                    CommonInit.ChooseVC("Synapse", "sandboxwcus");
                    ProjectInfo.vcName = "Synapse: sandboxwcus";
                    //Playback.Wait(1000);
                    break;
            }
        }

        #endregion

        #region Choose Cosmos Runtime
        public void ChooseCosmosRuntime(int vcFlag)
        {
            WpfPane submitJob = CommonInit._wpfPane(ProjectInfo.VsProjectN, "Submit Job");

            WpfEdit customCosmosRuntimeText = new WpfEdit(submitJob);
            customCosmosRuntimeText.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "customCosmosRuntimeText";
            if (!customCosmosRuntimeText.Exists)
            {
                WpfButton jobProperties = CommonInit._wpfButton(submitJob, "Cosmos Runtime Version");
                Mouse.Click(jobProperties);
            }

            WpfRadioButton runtime = new WpfRadioButton(submitJob);

            switch (vcFlag)
            {
                case 0:
                    runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "DefaultRuntimeRadio";
                    Mouse.Click(runtime);
                    break;
                case 1:
                    runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "DefaultRuntimeRadio";
                    //runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "BetaRuntimeRadio";
                    Mouse.Click(runtime);
                    break;
                case 2:
                    runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "DefaultRuntimeRadio";
                    //runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "BetaRuntimeRadio";
                    Mouse.Click(runtime);
                    break;
                case 3:
                    runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "DefaultRuntimeRadio";
                    //runtime.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "BetaRuntimeRadio";
                    Mouse.Click(runtime);
                    break;
            }
        }
        #endregion

        #region SelectCurrentProject
        /// <summary>
        /// select current project use jobflag
        /// </summary>
        /// <param name="jobflag">jobflag</param>
        public void SelectCurrentProject(int jobflag)
        {
            switch (jobflag)
            {
                case 0:
                    ProjectInfo.projectNameNow = Json.Readjson("0", null, "joblist");
                    break;
                case 1:
                    ProjectInfo.projectNameNow = Json.Readjson("1", null, "joblist");
                    break;
                case 2:
                    ProjectInfo.projectNameNow = Json.Readjson("2", null, "joblist");
                    break;
                case 3:
                    ProjectInfo.projectNameNow = Json.Readjson("3", null, "joblist");
                    break;
            }
        }

        public void SelectCurrentProjectNew(int jobflag)
        {
            ProjectInfo.projectNameNow = Json.Readjson(jobflag.ToString(), null, "joblist");
        }
        #endregion

        #region ProjectSpec
        public void ProjectSpec(int jobflag)
        {
            switch (jobflag)
            {
                case 0:
                    do
                    {
                        ScopAll_In_One_Spec.DoAction();
                        ProjectInfo.vcFlag++;
                    }
                    while (ProjectInfo.vcFlag < 4);
                    break;
                case 1:
                    do
                    {
                        DebugFailedVertex_Spec.DoAction();
                        ProjectInfo.vcFlag++;
                    }
                    while (ProjectInfo.vcFlag < 4);
                    break;
                case 2:
                    do
                    {
                        Parameter_Spec.DoAction();
                        ProjectInfo.vcFlag++;
                    }
                    while (ProjectInfo.vcFlag < 4);
                    break;
                case 3:
                    do
                    {
                        FileSetsVertex_Spec.DoAction();
                        ProjectInfo.vcFlag++;
                    }
                    while (ProjectInfo.vcFlag < 4);
                    break;
            }
        }

        public ScopAll_In_One_Spec ScopAll_In_One_Spec
        {
            get
            {
                if (this.scopAll_In_One_Spec == null)
                {
                    this.scopAll_In_One_Spec = new ScopAll_In_One_Spec();
                }

                return this.scopAll_In_One_Spec;
            }
        }

        private ScopAll_In_One_Spec scopAll_In_One_Spec;

        public DebugFailedVertex_Spec DebugFailedVertex_Spec
        {
            get
            {
                if (this.item == null)
                {
                    this.item = new DebugFailedVertex_Spec();
                }

                return this.item;
            }
        }

        private DebugFailedVertex_Spec item;

        public Parameter_Spec Parameter_Spec
        {
            get
            {
                if (this.item1 == null)
                {
                    this.item1 = new Parameter_Spec();
                }

                return this.item1;
            }
        }

        private Parameter_Spec item1;

        public FileSetsVertex_Spec FileSetsVertex_Spec
        {
            get
            {
                if (this.item2 == null)
                {
                    this.item2 = new FileSetsVertex_Spec();
                }

                return this.item2;
            }
        }

        private FileSetsVertex_Spec item2;
        #endregion

        #region InitProjectInfo
        /// <summary>
        /// Initialize project information
        /// </summary>
        public void InitProjectInfo()
        {
            ProjectInfo.testStartTime = DateTime.Now.ToString("_yyyyMMdd_HHmmss");
            SelectCurrentProjectNew(ProjectInfo.jobFlag);
            ProjectInfo.VsProjectN = _window(ProjectInfo.projectNameNow + " - Microsoft Visual Studio");
            ProjectInfo.logFinalPath = @"..\..\..\SubmitMultipleJobsAuto\Logs" + "\\" + ProjectInfo.projectNameNow + ProjectInfo.testStartTime + ".txt";
            ProjectInfo.vcFlag = 0;
        }

        private Common CommonInit
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
        #endregion

        #region record submit information to json
        public void RecordSubmitInfo()
        {
            Json.WriterjsonEnd(ProjectInfo.jobName, "Job Name", ProjectInfo.jobName, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.scriptName, ProjectInfo.jobName, "Script Name",null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.vsVerson, ProjectInfo.jobName, "VS Verson", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.projectNameNow, ProjectInfo.jobName, "Project Name", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.vcName, ProjectInfo.jobName, "VC Name", null, "jobSettingInfo");
            Json.Updatejson("Submitted Successed", ProjectInfo.jobName, "Submmit status", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.jobUrl, ProjectInfo.jobName, "Submit link", null, "jobSettingInfo");
        }

        public void RecordSubmitInfoFail()
        {
            Json.WriterjsonEnd(ProjectInfo.jobName, "Job Name", ProjectInfo.jobName, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.scriptName, ProjectInfo.jobName, "Script Name", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.vsVerson, ProjectInfo.jobName, "VS Verson", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.projectNameNow, ProjectInfo.jobName, "Project Name", null, "jobSettingInfo");
            Json.Updatejson(ProjectInfo.vcName, ProjectInfo.jobName, "VC Name", null, "jobSettingInfo");
            Json.Updatejson("Submitted Failed", ProjectInfo.jobName, "Submmit status", null, "jobSettingInfo");
            Json.Updatejson("", ProjectInfo.jobName, "Submit link", null, "jobSettingInfo");
        }
        #endregion

        #region LogText
        /// <summary>
        /// Record test logs
        /// </summary>
        /// <param name="WritingText">log word</param>
        /// <returns></returns>
        public string LogText(string WritingText)
        {
            string logText = WritingText + "-------------" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (!File.Exists(ProjectInfo.logFinalPath))
            {
                using (StreamWriter sw = File.CreateText(ProjectInfo.logFinalPath))
                {
                }
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(ProjectInfo.logFinalPath, true))
            {
                file.WriteLine(logText);
            }
            return ProjectInfo.logFinalPath;
        }
        #endregion

        #region screen shot
        public void CaptureImage(UITestControl myWindow, string name, string folderName)
        {
            string imagePath = @"..\..\..\SubmitMultipleJobsAuto\ResultImage\";
            name = name + ".png";

            string pathString = Path.Combine(imagePath, Json.Readjson("folderName", null, "screenshotSetting"), folderName);
            Directory.CreateDirectory(pathString);
            //pathString = Path.Combine(pathString, folderName);
            //Directory.CreateDirectory(pathString);

            string shotPath = pathString + "\\" + name;
            string uploadFodler = Json.Readjson("folderName", null, "screenshotSetting") + "\\" + 
                Json.Readjson("testRound", null, "screenshotSetting") + "\\" + folderName;

            Image shot = myWindow.CaptureImage();
            shot.Save(shotPath);

            Json.Updatejson(shotPath, "shotPath", null, null, "screenshotSetting");
            Json.Updatejson(name, "shotName", null, null, "screenshotSetting");
            Json.Updatejson(uploadFodler, "uploadFolder", null, null, "screenshotSetting");
        }
        #endregion

        #region DateTimeTool
        /// <summary>
        /// returns a timestamp
        /// </summary>
        /// <param name="time">DateTime</param>
        /// <returns>timestamp</returns>
        public string DateTimeToStamp(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            int s = (int)(time - startTime).TotalSeconds;
            return s.ToString();
        }
        #endregion

        #region Click Submit
        public void ClickSubmit(string script)
        {
            ProjectInfo.scriptName = script;

            WpfPane solution = CommonInit._wpfPane(ProjectInfo.VsProjectN, "Solution Explorer");
            WinTreeItem projectn = CommonInit._winTreeItem(solution, script);
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);

            for (int i = 0; i <= 1; i++) 
            {
                Keyboard.SendKeys("{Down}");
            }
            Keyboard.SendKeys("{Enter}");

            //ScopeMenu.ClickSubmit();
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
        #endregion

        #region Click Debug
        public void ClickDebug(string script)
        {
            ProjectInfo.scriptName = script;

            WpfPane solution = CommonInit._wpfPane(ProjectInfo.VsProjectN, "Solution Explorer");
            WinTreeItem projectn = CommonInit._winTreeItem(solution, script);
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);

            for (int i = 0; i <= 6; i++)
            {
                Keyboard.SendKeys("{Down}");
            }
            Keyboard.SendKeys("{Enter}");
        }
        #endregion

        #region Enter JobName
        public void EnterJobName()
        {
            WpfPane submitJob = CommonInit._wpfPane(ProjectInfo.VsProjectN, "Submit Job");

            WpfEdit editbox1 = new WpfEdit(submitJob);
            UITestControlCollection editbox = editbox1.FindMatchingControls();
            foreach (UITestControl x in editbox)
            {
                Mouse.Click(x);
                Keyboard.SendKeys("A", ModifierKeys.Control);
                ProjectInfo.jobName = ProjectInfo.projectNameNow + "_houjiaqi" + CommonInit.DateTimeToStamp(DateTime.Now);
                Keyboard.SendKeys(ProjectInfo.jobName);
                break;
            }
        }
        #endregion

        #region Submit Judge
        public void SubmitJudge()
        {
            WinPane jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);

            //Playback.Wait(10000);

            int seconds_to_sleep = 5;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread submitException_thread = new Thread(new ThreadStart(SubmitException));
            submitException_thread.Start();

            while (true)
            {
                jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);
                if (jobView.Exists || ProjectInfo.submitExceptionTag)
                {
                    if (jobView.Exists)
                    {
                        WinButton copy = CommonInit._winButton(ProjectInfo.VsProjectN, "Copy URL to clipboard");
                        Mouse.Hover(copy);
                        Mouse.Click();
                        string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text));

                        ProjectInfo.jobUrl = message;

                        Keyboard.SendKeys("{F4}", ModifierKeys.Control);
                        CommonInit.RecordSubmitInfo();
                        ProjectInfo.submitExceptionTag = false;
                    }
                    else
                    {
                        CommonInit.RecordSubmitInfoFail();
                        ProjectInfo.submitExceptionTag = false;
                    }
                    ProjectInfo.submitedJobname.Add(ProjectInfo.jobName);
                    submitException_thread.Abort();
                    break;
                }
                Thread.Sleep(wait_time);
            }
        }

        public void SubmitJudgeUntilEnd()
        {
            WinPane jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);

            //Playback.Wait(10000);

            int seconds_to_sleep = 8;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread submitException_thread = new Thread(new ThreadStart(SubmitException));
            submitException_thread.Start();

            while (true)
            {
                jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);
                if (jobView.Exists || ProjectInfo.submitExceptionTag)
                {
                    if (jobView.Exists)
                    {
                        WinButton copy = CommonInit._winButton(ProjectInfo.VsProjectN, "Copy URL to clipboard");
                        Mouse.Hover(copy);
                        Mouse.Click();
                        string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text));

                        ProjectInfo.jobUrl = message;

                        WinEdit jobResult = CommonInit._winEdit(ProjectInfo.VsProjectN, "Job Result");
                        while (!jobResult.Exists)
                        {
                            jobResult = CommonInit._winEdit(ProjectInfo.VsProjectN, "Job Result");
                        }
                        if (jobResult.Exists)
                        {
                            while (!(jobResult.Text == "Succeeded"||jobResult.Text == "Failed"))
                            {
                                if (ProjectInfo.submitExceptionTag)
                                {
                                    break;
                                }
                                Thread.Sleep(wait_time);
                                Keyboard.SendKeys("{F5}");
                            }
                            if (jobResult.Text == "Succeeded")
                            {
                                //log
                                CommonInit.CaptureImage(jobView, ShotName(ProjectInfo.vcFlag) + "1", "SubmitSuccess");
                                ApplicationUnderTest.Launch(@"C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release\UploadScreenshot.exe");
                                //upload C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release

                                Mouse.MoveScrollWheel(jobResult, -1);
                                int i = 0;
                                do
                                {
                                    Mouse.MoveScrollWheel(-1);
                                    i++;
                                } while (i < 9);
                                Playback.Wait(3000);

                                CommonInit.CaptureImage(jobView, ShotName(ProjectInfo.vcFlag) + "2", "SubmitSuccess");
                                ApplicationUnderTest.Launch(@"C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release\UploadScreenshot.exe");
                            }
                            else
                            {
                                CommonInit.CaptureImage(jobView, ShotName(ProjectInfo.vcFlag) + "_1", "SubmitFailure");
                                ApplicationUnderTest.Launch(@"C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release\UploadScreenshot.exe");

                                Mouse.MoveScrollWheel(jobResult, -1);
                                int i = 0;
                                do
                                {
                                    Mouse.MoveScrollWheel(-1);
                                    i++;
                                } while (i < 9);
                                Playback.Wait(3000);

                                CommonInit.CaptureImage(jobView, ShotName(ProjectInfo.vcFlag) + "_2", "SubmitFailure");
                                ApplicationUnderTest.Launch(@"C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release\UploadScreenshot.exe");
                            }
                        }

                        Keyboard.SendKeys("{F4}", ModifierKeys.Control);
                        CommonInit.RecordSubmitInfo();
                        ProjectInfo.submitExceptionTag = false;
                    }
                    else
                    {
                        CommonInit.RecordSubmitInfoFail();
                        ProjectInfo.submitExceptionTag = false;
                    }
                    ProjectInfo.submitedJobname.Add(ProjectInfo.jobName);
                    submitException_thread.Abort();
                    break;
                }
                Thread.Sleep(wait_time);
            }
        }
        public void SubmitException()
        {
            int seconds_to_sleep = 5 * 60;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread.Sleep(wait_time);
            ProjectInfo.submitExceptionTag = true;
        }

        public void SubmitJudgeNewAsync()
        {
            WinPane jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);

            int seconds_to_sleep = 5;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Task<bool> x = WaitSubmit();
            //bool submitExceptionTag = false;

            while (true)
            {
                jobView = CommonInit._winPane(ProjectInfo.VsProjectN, "Job view: " + ProjectInfo.jobName);
                if (jobView.Exists || x.Result)
                {
                    if (jobView.Exists)
                    {
                        WinButton copy = CommonInit._winButton(ProjectInfo.VsProjectN, "Copy URL to clipboard");
                        Mouse.Hover(copy);
                        Mouse.Click();
                        string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text));

                        ProjectInfo.jobUrl = message;

                        Keyboard.SendKeys("{F4}", ModifierKeys.Control);
                        CommonInit.RecordSubmitInfo();
                    }
                    else
                    {
                        CommonInit.RecordSubmitInfoFail();
                    }
                    ProjectInfo.submitedJobname.Add(ProjectInfo.jobName);
                    break;
                }
                Thread.Sleep(wait_time);
                //submitExceptionTag = await WaitSubmit();
            }
        }

        private async Task<bool> WaitSubmit()
        {
            return await Task.Run(() =>
            {
                int seconds_to_sleep = 3 * 60;
                var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
                Thread.Sleep(wait_time);
                return true;
            });
        }
        private async Task Wait()
        {
            await WaitSubmit();
        }

        #endregion

        #region Debug Judge Local Run Results - Scope19.script
        public void DebugJudgeUntilEnd(string sceenNum)
        {
            WinPane resultsView = CommonInit._winPane(ProjectInfo.VsProjectN, "Local Run Results - " + ProjectInfo.scriptName);

            int seconds_to_sleep = 8;
            var wait_time = new TimeSpan(0, 0, 0, seconds_to_sleep);
            Thread submitException_thread = new Thread(new ThreadStart(SubmitException));
            submitException_thread.Start();

            while (!resultsView.Exists)
            {
                resultsView = CommonInit._winPane(ProjectInfo.VsProjectN, "Local Run Results - " + ProjectInfo.scriptName);    
            }
            if (resultsView.Exists || ProjectInfo.submitExceptionTag)
            {
                CommonInit.CaptureImage(ProjectInfo.VsProjectN, ShotName(ProjectInfo.vcFlag) + sceenNum, "Debug");
                ApplicationUnderTest.Launch(@"C:\Users\v-jiaqihou\dev\SubmitMultipleJobsAuto\UploadScreenshot\bin\Release\UploadScreenshot.exe");

                ProjectInfo.submitExceptionTag = false;
                submitException_thread.Abort();
            }

        }
        #endregion

        #region shot name
        public string ShotName(int vcFlag)
        {
            switch (vcFlag)
            {
                case 0:
                    return ProjectInfo.projectNameNow + "_cosmos09_cosmosAdmin";
                case 1:
                    return ProjectInfo.projectNameNow + "_ADLA_zhblueshiftgen2";
                case 2:
                    return ProjectInfo.projectNameNow + "_ADLA_sandbox_c08";
                case 3:
                    return ProjectInfo.projectNameNow + "_Synapse_sandboxwcus";
            }
            return "null";
        }
        #endregion

        //record job name to list
        #region Record Job Name
        public void RecordJobName()
        {
            //int infoNum = Convert.ToInt32(Json.Readjson("flag", null, "submittedJobName"));
            int subjobnum = Convert.ToInt32(Json.Readjson("flag", null, "submittedJobName"));
            foreach (string content in ProjectInfo.submitedJobname)
            {
                Json.WriterjsonEnd(subjobnum.ToString(), content, null, "submittedJobName");
                subjobnum++;
            }

            Json.Updatejson(subjobnum.ToString(), "flag", null, null, "submittedJobName");
        }

        public void RecordJobNameEach()
        {
            int subjobnum = Convert.ToInt32(Json.Readjson("flag", null, "submittedJobName"));

            Json.WriterjsonEnd(subjobnum.ToString(), ProjectInfo.jobName, null, "submittedJobName");
            subjobnum++;

            Json.Updatejson(subjobnum.ToString(), "flag", null, null, "submittedJobName");
        }
        #endregion
    }
}

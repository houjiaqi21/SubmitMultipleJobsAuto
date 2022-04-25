using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitMultipleJobsAuto
{
    public class SubmitJobPage
    {
        public void SubmitP()
        {
            #region Variable Declarations
            WpfEdit uITextBoxExtraCmdLineAEdit = this.UISubmitJobWindow.UIUserControl_1Custom.UIJobPropertiesExpander.UITextBoxExtraCmdLineAEdit;
            WpfCheckBox uIDebugModeCheckBoxCheckBox = this.UISubmitJobWindow.UIUserControl_1Custom.UIJobPropertiesExpander.UIDebugModeCheckBoxCheckBox;
            WpfComboBox uIDebugModeComboBoxComboBox = this.UISubmitJobWindow.UIUserControl_1Custom.UIJobPropertiesExpander.UIDebugModeComboBoxComboBox;
            #endregion

            // Type '' in 'textBoxExtraCmdLineArguments' text box
            uITextBoxExtraCmdLineAEdit.Text = this.SubmitJobPageParams.UITextBoxExtraCmdLineAEditText;

            // Select 'debugModeCheckBox' check box
            uIDebugModeCheckBoxCheckBox.Checked = this.SubmitJobPageParams.UIDebugModeCheckBoxCheckBoxChecked;

            // Select '72' in 'debugModeComboBox' combo box
            uIDebugModeComboBoxComboBox.SelectedItem = this.SubmitJobPageParams.UIDebugModeComboBoxComboBoxSelectedItem;
        }

        public void ClickSubmit()
        {
            #region Variable Declarations
            WpfButton uIButtonSubmitButton = this.UISubmitJobWindow.UIUserControl_1Custom.UIButtonSubmitButton;
            //WpfButton uIYesButton = this.UISubmitJobWindow.UIYesButton;
            #endregion

            // Click 'buttonSubmit' button
            Mouse.Click(uIButtonSubmitButton, new Point(44, 8));

            // Click 'Yes' button
            //Mouse.Click(uIYesButton, new Point(49, 4));
        }

        #region Properties
        public virtual SubmitJobPageParams SubmitJobPageParams
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new SubmitJobPageParams();
                }
                return this.mRecordedMethod1Params;
            }
        }

        public UISubmitJobWindow UISubmitJobWindow
        {
            get
            {
                if ((this.mUISubmitJobWindow == null))
                {
                    this.mUISubmitJobWindow = new UISubmitJobWindow();
                }
                return this.mUISubmitJobWindow;
            }
        }
        #endregion

        #region Fields
        private SubmitJobPageParams mRecordedMethod1Params;

        private UISubmitJobWindow mUISubmitJobWindow;
        #endregion
    }

    public class SubmitJobPageParams
    {

        #region Fields
        public string UITextBoxExtraCmdLineAEditText = Json.Readjson("submit_job_information", "Nebula Arguents","Setting");

        /// <summary>
        /// Select 'debugModeCheckBox' check box
        /// </summary>
        public bool UIDebugModeCheckBoxCheckBoxChecked = true;

        /// <summary>
        /// Select '72' in 'debugModeComboBox' combo box
        /// </summary>
        public string UIDebugModeComboBoxComboBoxSelectedItem = "72";
        #endregion
    }

    public class UISubmitJobWindow : WpfWindow
    {

        public UISubmitJobWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Submit Job";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add(ProjectInfo.projectNameNow);
            #endregion
        }

        #region Properties
        public UIUserControl_1Custom_SubmitJob UIUserControl_1Custom
        {
            get
            {
                if ((this.mUIUserControl_1Custom == null))
                {
                    this.mUIUserControl_1Custom = new UIUserControl_1Custom_SubmitJob(this);
                }
                return this.mUIUserControl_1Custom;
            }
        }

        public WpfButton UIYesButton
        {
            get
            {
                if ((this.mUIYesButton == null))
                {
                    this.mUIYesButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIYesButton.SearchProperties[WpfButton.PropertyNames.Name] = "Yes";
                    this.mUIYesButton.WindowTitles.Add("Submit Job");
                    #endregion
                }
                return this.mUIYesButton;
            }
        }
        #endregion

        #region Fields
        private UIUserControl_1Custom_SubmitJob mUIUserControl_1Custom;
        private WpfButton mUIYesButton;
        #endregion
    }

    public class UIUserControl_1Custom_SubmitJob : WpfCustom
    {

        public UIUserControl_1Custom_SubmitJob(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.JobSubmissionDialog";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "UserControl_1";
            this.WindowTitles.Add(ProjectInfo.projectNameNow);
            #endregion
        }

        #region Properties
        public UIJobPropertiesExpander UIJobPropertiesExpander
        {
            get
            {
                if ((this.mUIJobPropertiesExpander == null))
                {
                    this.mUIJobPropertiesExpander = new UIJobPropertiesExpander(this);
                }
                return this.mUIJobPropertiesExpander;
            }
        }

        public WpfButton UIButtonSubmitButton
        {
            get
            {
                if ((this.mUIButtonSubmitButton == null))
                {
                    this.mUIButtonSubmitButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIButtonSubmitButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "buttonSubmit";
                    this.mUIButtonSubmitButton.WindowTitles.Add(ProjectInfo.projectNameNow);
                    #endregion
                }
                return this.mUIButtonSubmitButton;
            }
        }
        #endregion

        #region Fields
        private UIJobPropertiesExpander mUIJobPropertiesExpander;
        private WpfButton mUIButtonSubmitButton;
        #endregion
    }

    public class UIJobPropertiesExpander : WpfExpander
    {

        public UIJobPropertiesExpander(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfExpander.PropertyNames.AutomationId] = "JobPropertiesExpander";
            this.WindowTitles.Add(ProjectInfo.projectNameNow);
            #endregion
        }

        #region Properties
        public WpfEdit UITextBoxExtraCmdLineAEdit
        {
            get
            {
                if ((this.mUITextBoxExtraCmdLineAEdit == null))
                {
                    this.mUITextBoxExtraCmdLineAEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITextBoxExtraCmdLineAEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "textBoxExtraCmdLineArguments";
                    this.mUITextBoxExtraCmdLineAEdit.WindowTitles.Add(ProjectInfo.projectNameNow);
                    #endregion
                }
                return this.mUITextBoxExtraCmdLineAEdit;
            }
        }

        public WpfCheckBox UIDebugModeCheckBoxCheckBox
        {
            get
            {
                if ((this.mUIDebugModeCheckBoxCheckBox == null))
                {
                    this.mUIDebugModeCheckBoxCheckBox = new WpfCheckBox(this);
                    #region Search Criteria
                    this.mUIDebugModeCheckBoxCheckBox.SearchProperties[WpfCheckBox.PropertyNames.AutomationId] = "debugModeCheckBox";
                    this.mUIDebugModeCheckBoxCheckBox.WindowTitles.Add(ProjectInfo.projectNameNow);
                    #endregion
                }
                return this.mUIDebugModeCheckBoxCheckBox;
            }
        }

        public WpfComboBox UIDebugModeComboBoxComboBox
        {
            get
            {
                if ((this.mUIDebugModeComboBoxComboBox == null))
                {
                    this.mUIDebugModeComboBoxComboBox = new WpfComboBox(this);
                    #region Search Criteria
                    this.mUIDebugModeComboBoxComboBox.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "debugModeComboBox";
                    this.mUIDebugModeComboBoxComboBox.WindowTitles.Add(ProjectInfo.projectNameNow);
                    #endregion
                }
                return this.mUIDebugModeComboBoxComboBox;
            }
        }

        public WpfEdit UITextSubmitButton
        {
            get
            {
                if ((this.mUITextBoxExtraCmdLineAEdit == null))
                {
                    this.mUITextBoxExtraCmdLineAEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITextBoxExtraCmdLineAEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "textBoxExtraCmdLineArguments";
                    this.mUITextBoxExtraCmdLineAEdit.WindowTitles.Add(ProjectInfo.projectNameNow);
                    #endregion
                }
                return this.mUITextBoxExtraCmdLineAEdit;
            }
        }
        #endregion

        #region Fields
        private WpfEdit mUITextBoxExtraCmdLineAEdit;

        private WpfCheckBox mUIDebugModeCheckBoxCheckBox;

        private WpfComboBox mUIDebugModeComboBoxComboBox;
        #endregion
    }
}

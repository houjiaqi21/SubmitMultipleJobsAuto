using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace SubmitMultipleJobsAuto
{
    public class ProjectVsWindow
    {
    }
    public class ProjectVsWindowNow : WpfWindow
    {

        public ProjectVsWindowNow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = ProjectInfo.projectNameNow + " - Microsoft Visual Studio";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add(ProjectInfo.projectNameNow + " - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public UIMenuBarMenuBar UIMenuBarMenuBar
        {
            get
            {
                if ((this.mUIMenuBarMenuBar == null))
                {
                    this.mUIMenuBarMenuBar = new UIMenuBarMenuBar(this);
                }
                return this.mUIMenuBarMenuBar;
            }
        }

        public UITabGroupST003ae79031TabList UITabGroupST003ae79031TabList
        {
            get
            {
                if ((this.mUITabGroupST003ae79031TabList == null))
                {
                    this.mUITabGroupST003ae79031TabList = new UITabGroupST003ae79031TabList(this);
                }
                return this.mUITabGroupST003ae79031TabList;
            }
        }

        #endregion

        #region Fields
        private UIMenuBarMenuBar mUIMenuBarMenuBar;
        private UITabGroupST003ae79031TabList mUITabGroupST003ae79031TabList;
        #endregion
    }
}

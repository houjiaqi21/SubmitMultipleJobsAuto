using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubmitMultipleJobsAuto
{
    public partial class ScopeMenu
    {

        public void ClickSubmit()
        {
            #region Variable Declarations
            WpfTreeItem uIScope19scriptTreeItem = this.ProjectVsWindowNow.UITabGroupST003ae79031TabList.UISolutionExplorerTabPage.UIScope17scriptTreeItem;
            WpfMenuItem uISubmitScriptMenuItem = this.UIWpfWindow.UIItemMenu.UISubmitScriptMenuItem;
            #endregion
            //Playback.Wait(1000);
            // Right-Click 'Scope17.script' tree item
            //Mouse.Click(uIScope19scriptTreeItem, MouseButtons.Right);
            //Playback.Wait(1000);
            // Click 'Submit Script' menu item
            Mouse.Click(uISubmitScriptMenuItem);
        }

        public void ClickDebug()
        {
            #region Variable Declarations
            WpfTreeItem uIScope19scriptTreeItem = this.ProjectVsWindowNow.UITabGroupST003ae79031TabList.UISolutionExplorerTabPage.UIScope17scriptTreeItem;
            //WpfMenuItem uIDebugScriptMenuItem = this.UIWpfWindow.UIItemMenu.UIDebugScriptMenuItem;
            #endregion
            //Playback.Wait(1000);
            // Right-Click 'Scope17.script' tree item
            //Mouse.Click(uIScope19scriptTreeItem, MouseButtons.Right);
            //Playback.Wait(1000);
            // Click 'Submit Script' menu item
            //Mouse.Click(uIDebugScriptMenuItem);
        }

        #region Properties
        public ProjectVsWindowNow ProjectVsWindowNow
        {
            get
            {
                if ((this.mProjectVsWindowNow == null))
                {
                    this.mProjectVsWindowNow = new ProjectVsWindowNow();
                }
                return this.mProjectVsWindowNow;
            }
        }

        public UIWpfWindow UIWpfWindow
        {
            get
            {
                if ((this.mUIWpfWindow == null))
                {
                    this.mUIWpfWindow = new UIWpfWindow();
                }
                return this.mUIWpfWindow;
            }
        }
        #endregion

        #region Fields
        private ProjectVsWindowNow mProjectVsWindowNow;

        private UIWpfWindow mUIWpfWindow;
        #endregion
    }

    public class UITabGroupST003ae79031TabList : WpfTabList
    {

        public UITabGroupST003ae79031TabList(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "TabGroup|ST:0:0:{3ae79031-e1bc-11d0-8f78-00a0c9110057}|ST:0:0:{1c64b9c2-e352-428e" +
                "-a56d-0ace190b99a6}";
            this.WindowTitles.Add(ProjectInfo.projectNameNow + " - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public UISolutionExplorerTabPage UISolutionExplorerTabPage
        {
            get
            {
                if ((this.mUISolutionExplorerTabPage == null))
                {
                    this.mUISolutionExplorerTabPage = new UISolutionExplorerTabPage(this);
                }
                return this.mUISolutionExplorerTabPage;
            }
        }
        #endregion

        #region Fields
        private UISolutionExplorerTabPage mUISolutionExplorerTabPage;
        #endregion
    }

    public class UISolutionExplorerTabPage : WpfTabPage
    {

        public UISolutionExplorerTabPage(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabPage.PropertyNames.AutomationId] = "TAB_ST:0:0:{3ae79031-e1bc-11d0-8f78-00a0c9110057}";
            this.WindowTitles.Add(ProjectInfo.projectNameNow + " - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public WpfTreeItem UIScope17scriptTreeItem
        {
            get
            {
                if ((this.mUIScope17scriptTreeItem == null))
                {
                    this.mUIScope17scriptTreeItem = new WpfTreeItem(this);
                    #region Search Criteria
                    this.mUIScope17scriptTreeItem.SearchProperties[WpfTreeItem.PropertyNames.Name] = ProjectInfo.scriptName;
                    this.mUIScope17scriptTreeItem.WindowTitles.Add(ProjectInfo.projectNameNow + " - Microsoft Visual Studio");
                    #endregion
                }
                return this.mUIScope17scriptTreeItem;
            }
        }
        #endregion

        #region Fields
        private WpfTreeItem mUIScope17scriptTreeItem;
        #endregion
    }

    public class UIWpfWindow : WpfWindow
    {

        public UIWpfWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            #endregion
        }

        #region Properties
        public UIItemMenu UIItemMenu
        {
            get
            {
                if ((this.mUIItemMenu == null))
                {
                    this.mUIItemMenu = new UIItemMenu(this);
                }
                return this.mUIItemMenu;
            }
        }
        #endregion

        #region Fields
        private UIItemMenu mUIItemMenu;
        #endregion
    }

    public class UIItemMenu : WpfMenu
    {

        public UIItemMenu(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfMenu.PropertyNames.ClassName] = "Uia.ContextMenu";
            this.SearchProperties[WpfMenu.PropertyNames.Name] = "Item";
            #endregion
        }

        #region Properties
        public WpfMenuItem UISubmitScriptMenuItem
        {
            get
            {
                if ((this.mUISubmitScriptMenuItem == null))
                {
                    this.mUISubmitScriptMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUISubmitScriptMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Submit Script";
                    #endregion
                }
                return this.mUISubmitScriptMenuItem;
            }
        }

        //public WpfMenuItem UIDebugScriptMenuItem
        //{
        //    get
        //    {
        //        if ((this.mUIDebugScriptMenuItem == null))
        //        {
        //            this.mUIDebugScriptMenuItem = new WpfMenuItem(this);
        //            #region Search Criteria
        //            this.mUIDebugScriptMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Debug Locally";
        //            #endregion
        //        }
        //        return this.mUIDebugScriptMenuItem;
        //    }
        //}
        #endregion

        #region Fields
        private WpfMenuItem mUISubmitScriptMenuItem;
        //private WpfMenuItem mUIDebugScriptMenuItem;
        #endregion
    }
}

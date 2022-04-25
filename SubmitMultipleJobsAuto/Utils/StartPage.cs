using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitMultipleJobsAuto
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    public partial class StartPage
    {

        /// <summary>
        /// Click Open Button
        /// </summary>
        public void ClickOpen()
        {
            //#region Variable Declarations
            //WpfButton uIOpenalocal_folderButton = this.UIMicrosoftVisualStudiWindow.UIUserControl_1Custom.UIScrollViewer_1Pane.UIOpenalocal_folderButton;
            //#endregion

            //// Click 'Open a local _folder' button
            //Mouse.Click(uIOpenalocal_folderButton, new Point(143, 43));
            #region Variable Declarations
            WpfButton uIOpena_projectorsolutButton = this.UIMicrosoftVisualStudiWindow.UIUserControl_1Custom.UIScrollViewer_1Pane.UIOpena_projectorsolutButton;
            #endregion

            // Click 'Open a _project or solution' button
            Mouse.Click(uIOpena_projectorsolutButton, new Point(216, 29));
        }
        #region Properties
        public UIMicrosoftVisualStudiWindow UIMicrosoftVisualStudiWindow
        {
            get
            {
                if ((this.mUIMicrosoftVisualStudiWindow == null))
                {
                    this.mUIMicrosoftVisualStudiWindow = new UIMicrosoftVisualStudiWindow();
                }
                return this.mUIMicrosoftVisualStudiWindow;
            }
        }
        #endregion

        #region Fields
        private UIMicrosoftVisualStudiWindow mUIMicrosoftVisualStudiWindow;
        #endregion
        //#region Properties
        //public UIMicrosoftVisualStudiWindow UIMicrosoftVisualStudiWindow
        //{
        //    get
        //    {
        //        if ((this.mUIMicrosoftVisualStudiWindow == null))
        //        {
        //            this.mUIMicrosoftVisualStudiWindow = new UIMicrosoftVisualStudiWindow();
        //        }
        //        return this.mUIMicrosoftVisualStudiWindow;
        //    }
        //}
        //#endregion

        //#region Fields
        //private UIMicrosoftVisualStudiWindow mUIMicrosoftVisualStudiWindow;
        //#endregion
    }

    public class UIMicrosoftVisualStudiWindow : WpfWindow
    {

        public UIMicrosoftVisualStudiWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "File Explorer - Microsoft Visual Studio";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("File Explorer - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public UIUserControl_1Custom UIUserControl_1Custom
        {
            get
            {
                if ((this.mUIUserControl_1Custom == null))
                {
                    this.mUIUserControl_1Custom = new UIUserControl_1Custom(this);
                }
                return this.mUIUserControl_1Custom;
            }
        }
        #endregion

        #region Fields
        private UIUserControl_1Custom mUIUserControl_1Custom;
        #endregion
    }

    public class UIUserControl_1Custom : WpfCustom
    {

        public UIUserControl_1Custom(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.GetToCodeWorkflowView";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "UserControl_1";
            this.WindowTitles.Add("File Explorer - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public UIScrollViewer_1Pane UIScrollViewer_1Pane
        {
            get
            {
                if ((this.mUIScrollViewer_1Pane == null))
                {
                    this.mUIScrollViewer_1Pane = new UIScrollViewer_1Pane(this);
                }
                return this.mUIScrollViewer_1Pane;
            }
        }
        #endregion

        #region Fields
        private UIScrollViewer_1Pane mUIScrollViewer_1Pane;
        #endregion
    }

    public class UIScrollViewer_1Pane : WpfPane
    {

        public UIScrollViewer_1Pane(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.ScrollViewer";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "ScrollViewer_1";
            this.WindowTitles.Add("File Explorer - Microsoft Visual Studio");
            #endregion
        }

        #region Properties
        public WpfButton UIOpena_projectorsolutButton
        {
            get
            {
                if ((this.mUIOpena_projectorsolutButton == null))
                {
                    this.mUIOpena_projectorsolutButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIOpena_projectorsolutButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Button_1";
                    this.mUIOpena_projectorsolutButton.SearchProperties[WpfButton.PropertyNames.Instance] = "2";
                    this.mUIOpena_projectorsolutButton.WindowTitles.Add("File Explorer - Microsoft Visual Studio");
                    #endregion
                }
                return this.mUIOpena_projectorsolutButton;
            }
        }
        #endregion

        #region Fields
        private WpfButton mUIOpena_projectorsolutButton;
        #endregion
    }

    //public class UIMicrosoftVisualStudiWindow : WpfWindow
    //{

    //    public UIMicrosoftVisualStudiWindow()
    //    {
    //        #region Search Criteria
    //        this.SearchProperties[WpfWindow.PropertyNames.Name] = "File Explorer - Microsoft Visual Studio";
    //        this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
    //        this.WindowTitles.Add("Microsoft Visual Studio");
    //        #endregion
    //    }

    //    #region Properties
    //    public UIUserControl_1Custom UIUserControl_1Custom
    //    {
    //        get
    //        {
    //            if ((this.mUIUserControl_1Custom == null))
    //            {
    //                this.mUIUserControl_1Custom = new UIUserControl_1Custom(this);
    //            }
    //            return this.mUIUserControl_1Custom;
    //        }
    //    }
    //    #endregion

    //    #region Fields
    //    private UIUserControl_1Custom mUIUserControl_1Custom;
    //    #endregion
    //}

    //public class UIUserControl_1Custom : WpfCustom
    //{

    //    public UIUserControl_1Custom(UITestControl searchLimitContainer) :
    //            base(searchLimitContainer)
    //    {
    //        #region Search Criteria
    //        this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.GetToCodeWorkflowView";
    //        this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "UserControl_1";
    //        this.WindowTitles.Add("Microsoft Visual Studio");
    //        #endregion
    //    }

    //    #region Properties
    //    public UIScrollViewer_1Pane UIScrollViewer_1Pane
    //    {
    //        get
    //        {
    //            if ((this.mUIScrollViewer_1Pane == null))
    //            {
    //                this.mUIScrollViewer_1Pane = new UIScrollViewer_1Pane(this);
    //            }
    //            return this.mUIScrollViewer_1Pane;
    //        }
    //    }
    //    #endregion

    //    #region Fields
    //    private UIScrollViewer_1Pane mUIScrollViewer_1Pane;
    //    #endregion
    //}

    //public class UIScrollViewer_1Pane : WpfPane
    //{

    //    public UIScrollViewer_1Pane(UITestControl searchLimitContainer) :
    //            base(searchLimitContainer)
    //    {
    //        #region Search Criteria
    //        this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.ScrollViewer";
    //        this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "ScrollViewer_1";
    //        this.WindowTitles.Add("Microsoft Visual Studio");
    //        #endregion
    //    }

    //    #region Properties
    //    public WpfButton UIOpenalocal_folderButton
    //    {
    //        get
    //        {
    //            if ((this.mUIOpenalocal_folderButton == null))
    //            {
    //                this.mUIOpenalocal_folderButton = new WpfButton(this);
    //                #region Search Criteria
    //                this.mUIOpenalocal_folderButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Button_1";
    //                this.mUIOpenalocal_folderButton.SearchProperties[WpfButton.PropertyNames.Instance] = "2";
    //                this.mUIOpenalocal_folderButton.WindowTitles.Add("Microsoft Visual Studio");
    //                #endregion
    //            }
    //            return this.mUIOpenalocal_folderButton;
    //        }
    //    }
    //    #endregion

    //    #region Fields
    //    private WpfButton mUIOpenalocal_folderButton;
    //    #endregion
    //}
}


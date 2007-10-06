using System;
using System.Windows.Forms;
using NStudioInterface;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;

namespace NStudio
{
    public partial class MainMenuContainer : UserControl, IMainMenu
    {
        public MainMenuContainer()
        {
            InitializeComponent();
            Global.MainForm.ToolBarContainer.TopToolStripPanel.Controls.Add(menuStrip1);
        }
        public void RefreshMenuFile()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                saveToolStripMenuItem.Enabled = true;
                //saveAllToolStripMenuItem = ((DocumentBase)Global.MainForm.DockPane.ActiveDocument).Changes;
                //tSaveAll.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveContent).Changes;
                //tSaveFile.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveDocument).Changes;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
            }
            if (Global.MainForm.DockPane.ActiveContent != null)
            {
                closeToolStripMenuItem.Enabled = true;
                closeAllDocumentsToolStripMenuItem.Enabled = true;
                closeAllDocumentsButToolStripMenuItem.Enabled = true;
            }
            else
            {
                closeToolStripMenuItem.Enabled = false;
                closeAllDocumentsToolStripMenuItem.Enabled = false;
                closeAllDocumentsButToolStripMenuItem.Enabled = false;
            }
        }
        public void RefreshMenuEdit()
        {
            mCut.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            mCopy.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            mPaste.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            mDelete.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            mSelectAll.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                mUndo.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveContent).CanUndo;
                mRedo.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveContent).CanRedo;
            }
        }

        #region IMainMenu Members
        public void AddToUnloadPlugin(string aName)
        {
            mLoadedPlugins.DropDownItems.Add(aName);
        }
        public void AddPluginMenu(ToolStripMenuItem aMenu)
        {
            mPlugins.DropDownItems.Add(aMenu);
        }
        public void AddMenu(ToolStripMenuItem aMenu)
        {
            menuStrip1.Items.Add(aMenu);
        }
        public void RemoveMenu(ToolStripMenuItem aMenu)
        {
            menuStrip1.Items.Remove(aMenu);
        }
        public void RefreshMenu()
        {
            RefreshMenuFile();
            RefreshMenuEdit();
            RefreshMenuView();
        }
        public void ChangeLanguage()
        {
            // Main Menu
            mFile.Text = Global.Language.MenuFile;
            mEdit.Text = Global.Language.MenuEdit;
            viewToolStripMenuItem.Text = Global.Language.MenuView;
            mTools.Text = Global.Language.MenuTools;
            mPlugins.Text = Global.Language.MenuPlugins;
            mHelp.Text = Global.Language.MenuHelp;
            // Menu File
            newToolStripMenuItem.Text = Global.Language.MenuNew;
            iCSharpCodeEditorToolStripMenuItem.Text = Global.Language.MenuNewICSharpCode;
            richTextEditorToolStripMenuItem.Text = Global.Language.MenuRichTextEditor;
            scinitllaEditorToolStripMenuItem.Text = Global.Language.MenuScinitllaEditor;
            standardEditorToolStripMenuItem.Text = Global.Language.MenuStandardEditor;
            hTMLEditorToolStripMenuItem.Text = Global.Language.MenuHTMLEditor;
            openToolStripMenuItem.Text = Global.Language.MenuOpen;
            closeToolStripMenuItem.Text = Global.Language.MenuClose;
            closeAllDocumentsToolStripMenuItem.Text = Global.Language.MenuCloseAllDocuments;
            closeAllDocumentsButToolStripMenuItem.Text = Global.Language.MenuCloseAllDocumentsButThis;
            saveToolStripMenuItem.Text = Global.Language.MenuSave;
            saveAllToolStripMenuItem.Text = Global.Language.MenuSaveAll;
            printToolStripMenuItem.Text = Global.Language.MenuPrint;
            printPreviewToolStripMenuItem.Text = Global.Language.MenuPrintPreview;
            exitToolStripMenuItem.Text = Global.Language.MenuExit;
            // Menu Edit
            mUndo.Text = Global.Language.MenuUndo;
            mRedo.Text = Global.Language.MenuRedo;
            mCut.Text = Global.Language.MenuCut;
            mCopy.Text = Global.Language.MenuCopy;
            mPaste.Text = Global.Language.MenuPaste;
            mDelete.Text = Global.Language.MenuDelete;
            mSelectAll.Text = Global.Language.MenuSelectAll;
            mTextCase.Text = Global.Language.MenuTextCase;
            upperCaseToolStripMenuItem.Text = Global.Language.MenuUpperCase;
            lowerCaseToolStripMenuItem.Text = Global.Language.MenuLowerCase;
            capitalizeToolStripMenuItem.Text = Global.Language.MenuCapitalize;
            invertCaseToolStripMenuItem.Text = Global.Language.MenuInvertCase;
            reverseTextToolStripMenuItem.Text = Global.Language.MenuReversText;
            // Menu View
            toolbarsToolStripMenuItem.Text = Global.Language.Toolbars;
            mViewTFile.Text = Global.Language.ToolBarFile;
            mViewTEdit.Text = Global.Language.ToolBarEdit;
            mViewTView.Text = Global.Language.ToolBarView;
            mViewTOthers.Text = Global.Language.ToolBarOthers;
            mViewStatusBar.Text = Global.Language.MenuShowStatusBar;
            visualStyleToolStripMenuItem.Text = Global.Language.MenuVisualStyle;
            renderToolStripMenuItem.Text = Global.Language.MenuRenderer;
            mProgramOpacity.Text = Global.Language.MenuProgramOpacity;
            topMostToolStripMenuItem.Text = Global.Language.MenuTopMost;
            gUILanguageToolStripMenuItem.Text = Global.Language.MenuGUILanguage;
            // Menu Tools
            mOptions.Text = Global.Language.Options;
            mWebBrowser.Text = Global.Language.WebBrowser;
            mClipboardRing.Text = Global.Language.MenuClipboardRing;
            mMathTools.Text = Global.Language.MenuMathTools;
            // Menu Plugins
            mLoadPlugin.Text = Global.Language.MenuLoadPlugin;
            scanPluginFolderForPluginsToolStripMenuItem.Text = Global.Language.MenuScanPluginFolder;
            mLoadedPlugins.Text = Global.Language.MenuLoadedPlugins;
            // Menu Help
            mChangelog.Text = Global.Language.MenuChangelog;
            mReadme.Text = Global.Language.MenuReadme;
            mProgramSite.Text = Global.Language.MenuProgramSite;
            mProgramForum.Text = Global.Language.MenuProgramForum;
            mAuthorSite.Text = Global.Language.MenuAuthorSite;
            mAuthorMail.Text = Global.Language.MenuAuthorMail;
            mAboutProgram.Text = Global.Language.MenuAboutProgram;
            //
            foreach (ToolStripMenuItem item in gUILanguageToolStripMenuItem.DropDownItems)
            {
                if (item.Text == Global.Settings.Settings.Language) item.Checked = true;
                else item.Checked = false;
            }
        }
        #endregion

        private void mEdit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mUndo) Global.MainForm.CurrentDocumentUndo();
            else if (e.ClickedItem == mRedo) Global.MainForm.CurrentDocumentRedo();
            else if (e.ClickedItem == mCut) Global.MainForm.CurrentDocumentCut();
            else if (e.ClickedItem == mCopy) Global.MainForm.CurrentDocumentCopy();
            else if (e.ClickedItem == mPaste) Global.MainForm.CurrentDocumentPaste();
            else if (e.ClickedItem == mDelete) Global.MainForm.CurrentDocumentDelete();
            else if (e.ClickedItem == mSelectAll) Global.MainForm.CurrentDocumentSelectAll();
            else if (e.ClickedItem == reverseTextToolStripMenuItem) EditActions.ReverseText();
            else if (e.ClickedItem == findAndReplaceToolStripMenuItem) Global.MainForm.ShowFindReplaceForm();
        }

        private void mViewTFile_Click(object sender, EventArgs e)
        {
            Global.Settings.Settings.ShowFileToolBar = mViewTFile.Checked;
            Global.MainForm.ToolBarFile.Visible = mViewTFile.Checked;
        }

        private void mViewTEdit_Click(object sender, EventArgs e)
        {
            Global.Settings.Settings.ShowEditToolBar = mViewTEdit.Checked;
            Global.MainForm.ToolBarEdit.Visible = mViewTEdit.Checked;
        }

        private void mViewTView_Click(object sender, EventArgs e)
        {
            Global.Settings.Settings.ShowViewToolBar = mViewTView.Checked;
            Global.MainForm.ToolBarView.Visible = mViewTView.Checked;
        }

        private void mViewTOthers_Click(object sender, EventArgs e)
        {
            Global.Settings.Settings.ShowOthersToolBar = mViewTOthers.Checked;
            Global.MainForm.ToolBarOthers.Visible = mViewTOthers.Checked;
        }
        private void mViewStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            Global.Settings.Settings.ShowStatusBar = mViewStatusBar.Checked;
            Global.MainForm.StatusBar.Visible = mViewStatusBar.Checked;
        }

        private void visualStyleToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mVSclientAndNonClientAreasEnabled)
            {
                mVSclientAndNonClientAreasEnabled.Checked = true;
                mVSclientAreaEnabled.Checked = false;
                mVSnonClientAreaEnabled.Checked = false;
                mVSnoneEnabled.Checked = false;
                Global.MainForm.VisualStyle = VisualStyleState.ClientAndNonClientAreasEnabled;
            }
            else if (e.ClickedItem == mVSclientAreaEnabled)
            {
                mVSclientAndNonClientAreasEnabled.Checked = false;
                mVSclientAreaEnabled.Checked = true;
                mVSnonClientAreaEnabled.Checked = false;
                mVSnoneEnabled.Checked = false;
                Global.MainForm.VisualStyle = VisualStyleState.ClientAreaEnabled;
            }
            else if (e.ClickedItem == mVSnonClientAreaEnabled)
            {
                mVSclientAndNonClientAreasEnabled.Checked = false;
                mVSclientAreaEnabled.Checked = false;
                mVSnonClientAreaEnabled.Checked = true;
                mVSnoneEnabled.Checked = false;
                Global.MainForm.VisualStyle = VisualStyleState.NonClientAreaEnabled;
            }
            else if (e.ClickedItem == mVSnoneEnabled)
            {
                mVSclientAndNonClientAreasEnabled.Checked = false;
                mVSclientAreaEnabled.Checked = false;
                mVSnonClientAreaEnabled.Checked = false;
                mVSnoneEnabled.Checked = true;
                Global.MainForm.VisualStyle = VisualStyleState.NoneEnabled;
            }
        }

        private void mProgramOpacity_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in mProgramOpacity.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem) e.ClickedItem).Checked = true;
            if (e.ClickedItem == mOpacity100) Global.MainForm.FormOpacity = 1.00;
            if (e.ClickedItem == mOpacity90) Global.MainForm.FormOpacity = 0.90;
            if (e.ClickedItem == mOpacity80) Global.MainForm.FormOpacity = 0.80;
            if (e.ClickedItem == mOpacity75) Global.MainForm.FormOpacity = 0.75;
            if (e.ClickedItem == mOpacity70) Global.MainForm.FormOpacity = 0.70;
            if (e.ClickedItem == mOpacity60) Global.MainForm.FormOpacity = 0.60;
            if (e.ClickedItem == mOpacity50) Global.MainForm.FormOpacity = 0.50;
            if (e.ClickedItem == mOpacity40) Global.MainForm.FormOpacity = 0.40;
            if (e.ClickedItem == mOpacity30) Global.MainForm.FormOpacity = 0.30;
            if (e.ClickedItem == mOpacity25) Global.MainForm.FormOpacity = 0.25;
            if (e.ClickedItem == mOpacity20) Global.MainForm.FormOpacity = 0.20;
            if (e.ClickedItem == mOpacity10) Global.MainForm.FormOpacity = 0.10;
        }
        public void RefreshMenuView()
        {
            mViewTFile.Checked = Global.Settings.Settings.ShowFileToolBar;
            mViewTEdit.Checked = Global.Settings.Settings.ShowEditToolBar;
            mViewTView.Checked = Global.Settings.Settings.ShowViewToolBar;
            mViewTOthers.Checked = Global.Settings.Settings.ShowOthersToolBar;
            mViewStatusBar.Checked = Global.Settings.Settings.ShowStatusBar;
            if (Global.MainForm.Renderer == AvailableRenderers.System)
            {
                professionalToolStripMenuItem.Checked = false;
                systemToolStripMenuItem.Checked = true;
                office2007ToolStripMenuItem.Checked = false;
            }
            if (Global.MainForm.Renderer == AvailableRenderers.Professional)
            {
                professionalToolStripMenuItem.Checked = true;
                systemToolStripMenuItem.Checked = false;
                office2007ToolStripMenuItem.Checked = false;
            }
            if (Global.MainForm.Renderer == AvailableRenderers.Office2007)
            {
                professionalToolStripMenuItem.Checked = false;
                systemToolStripMenuItem.Checked = false;
                office2007ToolStripMenuItem.Checked = true;
            }
        }
        private void renderToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == professionalToolStripMenuItem)
            {
                Global.MainForm.Renderer = AvailableRenderers.Professional;
            }
            else if (e.ClickedItem == systemToolStripMenuItem)
            {
                Global.MainForm.Renderer = AvailableRenderers.System;
            }
            else if (e.ClickedItem == office2007ToolStripMenuItem)
            {
                Global.MainForm.Renderer = AvailableRenderers.Office2007;
            }
        }

        private void topMostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Global.MainForm.FormTopMost = topMostToolStripMenuItem.Checked;
        }

        private void newToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == iCSharpCodeEditorToolStripMenuItem) Global.MainForm.AddICSharpEditor(null);
            else if (e.ClickedItem == richTextEditorToolStripMenuItem) Global.MainForm.AddRTE(null);
            else if (e.ClickedItem == scinitllaEditorToolStripMenuItem) Global.MainForm.AddScintilla(null);
            else if (e.ClickedItem == standardEditorToolStripMenuItem) Global.MainForm.AddStandardEditor(null);
            else if (e.ClickedItem == hTMLEditorToolStripMenuItem) Global.MainForm.AddHTMLEditor(null);
        }
        private void mHelp_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mHelp.DropDown.Close();
            if (e.ClickedItem == checkForNewVersionToolStripMenuItem) MessageBox.Show(Global.VersionCheck(true), "Version Checker");
            else if (e.ClickedItem == mChangelog) Global.MainForm.OpenChangelogFile();
            else if (e.ClickedItem == mReadme) Global.MainForm.OpenReadmeFile();
            else if (e.ClickedItem == mProgramSite) Global.MainForm.AddBrowser(Global.ProgramSite);
            else if (e.ClickedItem == mProgramForum) Global.MainForm.AddBrowser(Global.ProgramForum);
            else if (e.ClickedItem == mAuthorSite) Global.MainForm.AddBrowser(Global.AuthorSite);
            else if (e.ClickedItem == mAuthorMail) Process.Start(Global.AuthorMail);
            else if (e.ClickedItem == mAboutProgram) Global.MainForm.ShowAboutForm();
        }
        private void gUILanguageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in gUILanguageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;
            Global.LoadLanguage(e.ClickedItem.Text, Global.MainForm, true);
        }

        private void mFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mFile.DropDown.Close();
            if (e.ClickedItem == openToolStripMenuItem) Global.MainForm.Open();
            else if (e.ClickedItem == closeToolStripMenuItem) Global.MainForm.CloseDocument();
            else if (e.ClickedItem == closeAllDocumentsToolStripMenuItem) Global.MainForm.CloseAllDocuments();
            else if (e.ClickedItem == closeAllDocumentsButToolStripMenuItem) Global.MainForm.CloseAllButThis();
            else if (e.ClickedItem == saveToolStripMenuItem) Global.MainForm.DoSave();
            else if (e.ClickedItem == saveAllToolStripMenuItem) Global.MainForm.DoSaveAll();
            else if (e.ClickedItem == printToolStripMenuItem) Global.MainForm.DoPrint();
            else if (e.ClickedItem == printPreviewToolStripMenuItem) Global.MainForm.DoPrintPreview();
            else if (e.ClickedItem == exitToolStripMenuItem) Global.MainForm.Close();
        }

        private void mTools_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mTools.DropDown.Close();
            if (e.ClickedItem == mOptions) Global.MainForm.ShowOptionsForm();
            else if (e.ClickedItem == mWebBrowser) Global.MainForm.AddBrowser(null);
            else if (e.ClickedItem == mMathTools)
            {
                MathTools mt = new MathTools();
                mt.Show(Global.MainForm.DockPane, DockState.DockLeft);
            }
            else if (e.ClickedItem == mClipboardRing)
            {
                ClipboardRing cr = new ClipboardRing();
                cr.Show(Global.MainForm.DockPane, DockState.DockBottom);
            }
            else if (e.ClickedItem == conZoleToolStripMenuItem)
            {
                ConZole cz = new ConZole();
                cz.Show(Global.MainForm.DockPane, DockState.DockBottom);
            }
            else if (e.ClickedItem == systemInformationToolStripMenuItem)
            {
                SystemInformationTool sy = new SystemInformationTool();
                sy.Show(Global.MainForm.DockPane, DockState.DockBottom);
            }
            else if (e.ClickedItem == directoryWatcherToolStripMenuItem)
            {
                DirectoryWatcher dw = new DirectoryWatcher();
                dw.Show(Global.MainForm.DockPane, DockState.DockLeft);
            }
        }

        private void mTextCase_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == upperCaseToolStripMenuItem) EditActions.ToUpper();
            else if (e.ClickedItem == lowerCaseToolStripMenuItem) EditActions.ToLower();
            else if (e.ClickedItem == capitalizeToolStripMenuItem) EditActions.Capitalize();
            else if (e.ClickedItem == invertCaseToolStripMenuItem) EditActions.InvertCase();
        }

        private void mPlugins_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mPlugins.DropDown.Close();
            if (e.ClickedItem == mLoadPlugin) Global.MainForm.ShowLoadPluginDialog();
            else if (e.ClickedItem == scanPluginFolderForPluginsToolStripMenuItem) Global.MainForm.ScanPluginFolder();
        }
    }
}

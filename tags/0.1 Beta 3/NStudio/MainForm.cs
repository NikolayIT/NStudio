using System;
using System.ComponentModel;
using System.Windows.Forms;
using NStudioInterface;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms.VisualStyles;
using Scintilla.Configuration.SciTE;
using Scintilla.Configuration;

namespace NStudio
{
    public partial class MainForm : Form, IMainForm
    {
        private NewOpenIn NewOpenIn = NewOpenIn.ICSharpEditor;
        private FormWindowState LatestWinState = FormWindowState.Maximized;
        //
        private readonly FileToolBar FileToolBar;
        private readonly EditToolBar EditToolBar;
        private readonly ViewToolBar ViewToolBar;
        private readonly OthersToolBar OthersToolBar;
        private readonly MainMenuContainer Mainmenu;
        private readonly StatusBar Statusbar;
        private readonly SearchReplace searchreplace;
        //

        #region Form Events
        public MainForm()
        {
            Global.MainForm = this;
            InitializeComponent();
            // ToolBars
            OthersToolBar = new OthersToolBar();
            ViewToolBar = new ViewToolBar();
            EditToolBar = new EditToolBar();
            FileToolBar = new FileToolBar();
            // MainMenu
            Mainmenu = new MainMenuContainer();
            // StatusBar
            Statusbar = new StatusBar(this);
            // Search and Replace form
            searchreplace = new SearchReplace();
            //
            Global.Settings = new SettingsManager(this);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            TrayIcon.Text = Global.FullName;
            Global.Settings.LoadSettings();
            Global.Settings.RefreshForm();
            Text = Global.FullName;
            //
            FileInfo info = new FileInfo(Application.ExecutablePath);
            FileInfo globalConfigFile = new FileInfo(info.Directory.FullName + @"\Configuration\global.properties");
            if (globalConfigFile.Exists)
            {
                Global.ScintillaProperties = new SciTEProperties();
                Global.ScintillaProperties.Load(globalConfigFile);
                Global.ScintillaConfig = new ScintillaConfig(Global.ScintillaProperties);
            }
            //
            AddICSharpEditor(null);
            string newv = Global.VersionCheck(false);
            StatusBar.SetStatusBarText(newv);
            if (newv.ToLower().Contains("new")) MessageBox.Show(newv, "Version Checker");
            FormRefresh();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (!Global.Settings.Settings.MinimizeToTray) return;
            if (WindowState == FormWindowState.Minimized)
            {
                TrayIcon.Visible = true;
                Hide();
            }
            else LatestWinState = WindowState;
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = LatestWinState;
            TrayIcon.Visible = false;
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == exitToolStripMenuItem) Close();
            else if (e.ClickedItem == showToolStripMenuItem) TrayIcon_MouseDoubleClick(null, null);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Settings.SaveSettings();
        }
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (Global.Settings.Settings.EnableDragAndDrop && e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (Global.Settings.Settings.EnableDragAndDrop)
            {
                foreach (string fileName in (string[]) e.Data.GetData(DataFormats.FileDrop))
                {
                    AddICSharpEditor(fileName);
                }
            }
        }
        private void FormRefresh()
        {
            //ChangeLanguage();
            FileToolBar.RefreshToolBar();
            EditToolBar.RefreshToolBar();
            ViewToolBar.RefreshToolBar();
            OthersToolBar.RefreshToolBar();
            //
            Mainmenu.RefreshMenu();
        }
        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (DockConatiner.ActiveDocument is DocumentBase)
            {
                ((DocumentBase)DockConatiner.ActiveDocument).SaveFile(SaveFileDialog.FileName);
            }
        }
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (NewOpenIn == NewOpenIn.Unknown)
            {
                OpenInForm openin = new OpenInForm(OpenFileDialog.FileName);
                openin.ShowDialog();
                NewOpenIn = openin.OpenIn;
            }
            switch (NewOpenIn)
            {
                case NewOpenIn.ICSharpEditor:
                    AddICSharpEditor(OpenFileDialog.FileName);
                    break;
                case NewOpenIn.RTFEditor:
                    AddRTE(OpenFileDialog.FileName);
                    break;
                case NewOpenIn.ScintillaEditor:
                    AddScintilla(OpenFileDialog.FileName);
                    break;
                case NewOpenIn.StandardEditor:
                    AddStandardEditor(OpenFileDialog.FileName);
                    break;
                case NewOpenIn.HTMLEditor:
                    AddHTMLEditor(OpenFileDialog.FileName);
                    break;
                default:
                    break;
            }
        }
        void editor_ControlChanged(object aSender, ControlChangedEventArgs aEventArgs)
        {
            FormRefresh();
        }
        void DockFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DockConatiner.ActiveContent is DocumentBase)
            {
                bool res = ((DocumentBase)DockConatiner.ActiveContent).CloseDocument();
                if (res)
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes", "", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes) DoSave();
                    //else if (result == DialogResult.No) ;
                    else if (result == DialogResult.Cancel) e.Cancel = true;
                }
            }
        }
        private void LoadPluginDialog_FileOk(object sender, CancelEventArgs e)
        {
            PluginManager.LoadPlugin(LoadPluginDialog.FileName, this, true);
        }
        private void DockConatiner_ActiveContentChanged(object sender, EventArgs e)
        {
            if (DockConatiner.ActiveContent is DockBase)
                Statusbar.SetStatusBarName(((DockBase)DockConatiner.ActiveContent).StatusBarName);
            else Statusbar.SetStatusBarName("");
            FormRefresh();
        }
        #endregion

        private void ScanForPlugins(string folder)
        {
            try
            {
                string[] subdirs = Directory.GetDirectories(folder);
                foreach (string str in subdirs)
                {
                    ScanForPlugins(str);
                }
                string[] files = Directory.GetFiles(folder);
                foreach (string str in files)
                {
                    FileInfo fi = new FileInfo(str);
                    if (fi.Extension == ".dll") PluginManager.LoadPlugin(str, this, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #region IMainForm Members
        public void Open()
        {
            NewOpenIn = NewOpenIn.Unknown;
            OpenFileDialog.ShowDialog();
        }
        public void ShowFindReplaceForm()
        {
            searchreplace.Show(DockConatiner, DockState.Float);
        }
        public void AddHTMLEditor(string fileName)
        {
            HTML html = new HTML();
            if (fileName != null && fileName != "") html.LoadFile(fileName);
            html.Show(DockConatiner, DockState.Document);
            html.ControlChanged += editor_ControlChanged;
            html.FormClosing += DockFormClosing;
            FormRefresh();
        }
        public void OpenHTML()
        {
            NewOpenIn = NewOpenIn.HTMLEditor;
            OpenFileDialog.ShowDialog();
        }
        public void ScanPluginFolder()
        {
            ScanForPlugins(Global.Path + "\\Plugins\\");

        }
        public void AddStandardEditor(string fileName)
        {
            StandardTextEditor stded = new StandardTextEditor();
            if (fileName != null && fileName != "") stded.LoadFile(fileName);
            stded.Show(DockConatiner, DockState.Document);
            stded.ControlChanged += editor_ControlChanged;
            stded.FormClosing += DockFormClosing;
            FormRefresh();
        }
        public void OpenStandardEditor()
        {
            NewOpenIn = NewOpenIn.StandardEditor;
            OpenFileDialog.ShowDialog();
        }
        public void CloseDocument()
        {
            if (DockConatiner.ActiveContent is DocumentBase)
                ((DocumentBase)DockConatiner.ActiveContent).Close();
        }
        public void CloseAllDocuments()
        {
            for (int i = DockConatiner.Contents.Count - 1; i >= 0; i--)
                if (DockConatiner.Contents[i] is DocumentBase)
                    ((DocumentBase)DockConatiner.Contents[i]).Close();
        }
        public void CloseAllButThis()
        {
            for (int i = DockConatiner.Contents.Count - 1; i >= 0; i-- )
                if (DockConatiner.Contents[i] != DockConatiner.ActiveContent)
                    if (DockConatiner.Contents[i] is DocumentBase)
                        ((DocumentBase)DockConatiner.Contents[i]).Close();
        }
        public void ChangeLanguage()
        {
            Mainmenu.ChangeLanguage();
        }
        public IMainMenu MainMenu
        {
            get { return Mainmenu; }
        }
        public void OpenChangelogFile()
        {
            try { AddScintilla(Global.Path + "\\" + Global.ChangelogFile); }
            catch { MessageBox.Show("Couldn't find changelog file!", "ERROR"); }
        }
        public void OpenReadmeFile()
        {
            try { AddScintilla(Global.Path + "\\" + Global.ReadmeFile); }
            catch { MessageBox.Show("Couldn't find readme file!", "ERROR"); }
        }
        public void ShowLoadPluginDialog()
        {
            LoadPluginDialog.InitialDirectory = Global.Path + "\\" + "Plugins";
            LoadPluginDialog.ShowDialog();
        }
        void IMainForm.Close()
        {
            Close();
        }
        public bool FormTopMost
        {
            get
            {
                return TopMost;
            }
            set
            {
                TopMost = value;
            }
        }
        public double FormOpacity
        {
            get
            {
                return Opacity;
            }
            set
            {
                Opacity = value;
            }
        }
        public VisualStyleState VisualStyle
        {
            get
            {
                return Application.VisualStyleState;
            }
            set
            {
                Application.VisualStyleState = value;
                Invalidate(true);
            }
        }
        public StatusBarBase StatusBar
        {
            get { return Statusbar; }
        }
        public ToolBarBase ToolBarFile
        {
            get { return FileToolBar; }
        }
        public ToolBarBase ToolBarEdit
        {
            get { return EditToolBar; }
        }
        public ToolBarBase ToolBarView
        {
            get { return ViewToolBar; }
        }
        public ToolBarBase ToolBarOthers
        {
            get { return OthersToolBar; }
        }
        public void ShowAboutForm()
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
        public void ShowOptionsForm()
        {
            OptionsForm options = new OptionsForm();
            options.ShowDialog();
        }
        public AvailableRenderers Renderer
        {
            get
            {
                return Global.Settings.Settings.Renderer;
            }
            set
            {
                Global.Settings.Settings.Renderer = value;
                switch (value)
                {
                    case AvailableRenderers.System:
                        ToolStripManager.Renderer = new ToolStripSystemRenderer();
                        break;
                    case AvailableRenderers.Professional:
                        ToolStripManager.Renderer = new ToolStripProfessionalRenderer();
                        break;
                    case AvailableRenderers.Office2007:
                        ToolStripManager.Renderer = new Renderers.Office2007.Office2007Renderer();
                        break;
                    default:
                        break;
                }
                FormRefresh();
            }
        }
        public ToolStripContainer ToolBarContainer
        {
            get { return toolStripContainer1; }
        }
        public void CurrentDocumentUndo()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Undo();
        }
        public void CurrentDocumentRedo()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Redo();
        }
        public void CurrentDocumentCut()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Cut();
        }
        public void CurrentDocumentCopy()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Copy();
        }
        public void CurrentDocumentPaste()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Paste();
        }
        public void CurrentDocumentDelete()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase) DockConatiner.ActiveDocument).Delete();
        }
        public void CurrentDocumentSelectAll()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase) DockConatiner.ActiveDocument).SelectAll();
        }
        public void OpenICSharpEditor()
        {
            NewOpenIn = NewOpenIn.ICSharpEditor;
            OpenFileDialog.ShowDialog();
        }
        public void OpenRTE()
        {
            NewOpenIn = NewOpenIn.RTFEditor;
            OpenFileDialog.ShowDialog();
        }
        public void OpenScintilla()
        {
            NewOpenIn = NewOpenIn.ScintillaEditor;
            OpenFileDialog.ShowDialog();
        }
        public void DoPrint()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).Print();
        }
        public void DoPrintPreview()
        {
            if (DockConatiner.ActiveContent is DocumentBase) ((DocumentBase)DockConatiner.ActiveDocument).PrintPreview();
        }
        public void DoSave()
        {
            if (DockConatiner.ActiveContent is DocumentBase)
            {
                bool res = ((DocumentBase)DockConatiner.ActiveContent).Save();
                if (!res)
                {
                    SaveFileDialog.ShowDialog();
                }
            }
        }
        public void DoSaveAll()
        {
            foreach (IDockContent db in DockConatiner.Contents)
            {
                if (db is DocumentBase)
                {
                    bool res = ((DocumentBase)db).Save();
                    if (!res)
                    {
                        SaveFileDialog.ShowDialog();
                    }
                }
            }
        }
        public void AddICSharpEditor(string fileName)
        {
            ICSharpCodeEditor editor = new ICSharpCodeEditor();
            if (fileName != null && fileName != "") editor.LoadFile(fileName);
            editor.Show(DockConatiner, DockState.Document);
            editor.ControlChanged += editor_ControlChanged;
            editor.FormClosing += DockFormClosing;
            FormRefresh();
        }
        public void AddRTE(string fileName)
        {
            RTE rte = new RTE();
            if (fileName != null && fileName != "") rte.LoadFile(fileName);
            rte.Show(DockConatiner, DockState.Document);
            rte.ControlChanged += editor_ControlChanged;
            rte.FormClosing += DockFormClosing;
            FormRefresh();
        }
        public void AddScintilla(string fileName)
        {
            ScintillaEditor sce = new ScintillaEditor();
            if (fileName != null && fileName != "") sce.LoadFile(fileName);
            sce.Show(DockConatiner, DockState.Document);
            sce.ControlChanged += editor_ControlChanged;
            sce.FormClosing += DockFormClosing;
            FormRefresh();
        }
        public void AddBrowser(string url)
        {
            //Process.Start(url);
            Browser browser;
            if (url != null && url != "") browser = new Browser(this, url);
            else browser = new Browser(this);
            browser.Show(DockConatiner, DockState.Document);
        }
        public DockPanel DockPane
        {
            get { return DockConatiner; }
        }
        public void LoadPlugin(IPlugin Plugin)
        {
            Mainmenu.AddToUnloadPlugin(Plugin.Name);
        }
        public void LoadFileInEditor(string Path)
        {
            AddICSharpEditor(Path);
        }
        public void LoadTextInEditor(string aText)
        {
            ICSharpCodeEditor editor = new ICSharpCodeEditor();
            editor.SetText(aText);
            editor.Show(DockConatiner, DockState.Document);
            editor.ControlChanged += editor_ControlChanged;
            FormRefresh();
        }
        public void AddPluginMenu(ToolStripMenuItem aMenu)
        {
            Mainmenu.AddPluginMenu(aMenu);
        }
        public void AddMenu(ToolStripMenuItem aMenu)
        {
            Mainmenu.AddMenu(aMenu);
        }
        public void RemoveMenu(ToolStripMenuItem aMenu)
        {
            Mainmenu.RemoveMenu(aMenu);
        }
        public string CurrentDocumentText
        {
            get
            {
                if (DockConatiner.ActiveContent != null && DockConatiner.ActiveContent is DocumentBase)
                {
                    return ((DocumentBase)DockConatiner.ActiveContent).DocumentText;
                }
                else return "";
            }
            set
            {
                if (DockConatiner.ActiveContent != null && DockConatiner.ActiveContent is DocumentBase)
                {
                    ((DocumentBase)DockConatiner.ActiveDocument).DocumentText = value;
                }
            }
        }
        public void AddFileToolbarItem(ToolStripItem aItem)
        {
            FileToolBar.Items.Add(aItem);
        }
        public void AddEditToolbarItem(ToolStripItem aItem)
        {
            EditToolBar.Items.Add(aItem);
        }
        public void AddViewToolbarItem(ToolStripItem aItem)
        {
            ViewToolBar.Items.Add(aItem);
        }
        public void AddOthersToolbarItem(ToolStripItem aItem)
        {
            OthersToolBar.Items.Add(aItem);
        }
        #endregion
    }
}
/*
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                //MessageBox.Show(fileName + "\n" + GetFileExtenstion(fileName), "Debug");
                if (GetFileExtenstion(fileName) == ".torrent")
                {
                    if (MessageBox.Show("You have successfuly loaded this torrent file:\n" + fileName + "\nDo you want to load this torrent file in a new tab?", "File loaded!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) Add(fileName);
                    else EditCurrent(fileName);
                }
                else if (GetFileExtenstion(fileName) == ".session")
                {
                    MessageBox.Show("You have successfuly loaded this session file:\n" + fileName, "File loaded!");
                    startthem = false;
                    LoadSession(fileName);
                }
            }
        }
        private DockBase getFirst(string Name)
        {
            foreach (DockBase var in DockConatiner.Contents)
            {
                if (var.Type == Name) return var;
            }
            return null;
        }
*/
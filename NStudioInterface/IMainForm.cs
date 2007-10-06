using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms.VisualStyles;

namespace NStudioInterface
{
    public interface IMainForm
    {
        void DoSave();
        void DoSaveAll();
        void AddICSharpEditor(string fileName);
        void AddRTE(string fileName);
        void AddScintilla(string fileName);
        void AddStandardEditor(string fileName);
        void AddHTMLEditor(string fileName);
        void AddBrowser(string url);
        void DoPrint();
        void DoPrintPreview();
        void Open();
        void OpenICSharpEditor();
        void OpenRTE();
        void OpenScintilla();
        void OpenStandardEditor();
        void OpenHTML();
        void ShowAboutForm();
        void ShowOptionsForm();
        void ShowFindReplaceForm();
        void Close();

        void CurrentDocumentUndo();
        void CurrentDocumentRedo();
        void CurrentDocumentCut();
        void CurrentDocumentCopy();
        void CurrentDocumentPaste();
        void CurrentDocumentDelete();
        void CurrentDocumentSelectAll();

        void CloseDocument();
        void CloseAllDocuments();
        void CloseAllButThis();

        void ChangeLanguage();

        void LoadTextInEditor(string aText);
        void LoadFileInEditor(string path);
        void AddFileToolbarItem(ToolStripItem aItem);
        void AddEditToolbarItem(ToolStripItem aItem);
        void AddViewToolbarItem(ToolStripItem aItem);
        void AddOthersToolbarItem(ToolStripItem aItem);
        void AddPluginMenu(ToolStripMenuItem aMenu);
        void AddMenu(ToolStripMenuItem aMenu);
        void RemoveMenu(ToolStripMenuItem aMenu);
        void LoadPlugin(IPlugin plugin);
        void ScanPluginFolder();
        DockPanel DockPane { get;}
        ToolStripContainer ToolBarContainer { get;}
        AvailableRenderers Renderer { get; set;}
        string CurrentDocumentText { get; set;}
        ToolBarBase ToolBarFile { get;}
        ToolBarBase ToolBarEdit { get;}
        ToolBarBase ToolBarView { get;}
        ToolBarBase ToolBarOthers { get;}
        StatusBarBase StatusBar { get;}
        IMainMenu MainMenu { get;}
        VisualStyleState VisualStyle { get; set;}
        double FormOpacity { get; set;}
        bool FormTopMost { get; set;}

        void ShowLoadPluginDialog();
        void OpenChangelogFile();
        void OpenReadmeFile();
    }
}

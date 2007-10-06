using System.Windows.Forms;
using System.Drawing;
using NStudioInterface;

namespace NStudio
{
    public class FileToolBar : ToolBarBase
    {
        #region Fields
        ToolStripDropDownButton tNewDocument;
        ToolStripMenuItem tNewICSharpCodeEditor;
        ToolStripMenuItem tNewRTEditor;
        ToolStripMenuItem tNewScintilla;
        ToolStripMenuItem tNewStandardEditor;
        ToolStripMenuItem tNewHTMLEditor;
        ToolStripMenuItem tOpenDocument;
        ToolStripButton tSaveFile;
        ToolStripButton tSaveAll;
        ToolStripSeparator toolStripSeparator1;
        ToolStripButton tPrintPreview;
        ToolStripButton tPrint;
        #endregion

        #region Initialization
        private void InitializeComponent()
        {
            tNewDocument = new ToolStripDropDownButton();
            tNewICSharpCodeEditor = new ToolStripMenuItem();
            tNewRTEditor = new ToolStripMenuItem();
            tNewScintilla = new ToolStripMenuItem();
            tNewStandardEditor = new ToolStripMenuItem();
            tNewHTMLEditor = new ToolStripMenuItem();
            tOpenDocument = new ToolStripMenuItem();
            tSaveFile = new ToolStripButton();
            tSaveAll = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tPrint = new ToolStripButton();
            tPrintPreview = new ToolStripButton();

            SuspendLayout();
            Dock = DockStyle.None;
            // 
            // tNewDocument
            // 
            tNewDocument.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tNewDocument.DropDownItems.AddRange(new ToolStripItem[] {
            tNewICSharpCodeEditor,
            tNewRTEditor,
            tNewScintilla,
            tNewStandardEditor,
            tNewHTMLEditor});
            tNewDocument.Image = Global.Resources.NewImage;
            tNewDocument.ImageTransparentColor = Color.Magenta;
            tNewDocument.Name = "tNewDocument";
            tNewDocument.Size = new Size(29, 22);
            tNewDocument.Text = "New document";
            tNewDocument.DropDownItemClicked += tNewDocument_DropDownItemClicked;
            // 
            // tNewICSharpCodeEditor
            // 
            tNewICSharpCodeEditor.Image = Global.Resources.NewImage;
            tNewICSharpCodeEditor.Name = "tNewICSharpCodeEditor";
            tNewICSharpCodeEditor.Size = new Size(215, 22);
            tNewICSharpCodeEditor.Text = "New in ICSharpCode Editor";
            // 
            // tNewRTEditor
            // 
            tNewRTEditor.Image = Global.Resources.FileImage;
            tNewRTEditor.Name = "toolStripMenuItem3";
            tNewRTEditor.Size = new Size(215, 22);
            tNewRTEditor.Text = "New Rich Text Editor";
            // 
            // tNewScintilla
            // 
            tNewScintilla.Name = "tNewScintilla";
            tNewScintilla.Size = new Size(215, 22);
            tNewScintilla.Text = "New Scintilla Editor";
            // 
            // tNewStandardEditor
            // 
            tNewStandardEditor.Name = "tNewStandardEditor";
            tNewStandardEditor.Size = new Size(215, 22);
            tNewStandardEditor.Text = "New Standard Editor";
            // 
            // tNewStandardEditor
            // 
            tNewHTMLEditor.Name = "tNewHTMLEditor";
            tNewHTMLEditor.Size = new Size(215, 22);
            tNewHTMLEditor.Text = "New HTML Editor";
            // 
            // tOpenDocument
            // 
            tOpenDocument.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tOpenDocument.Image = Global.Resources.OpenImage;
            tOpenDocument.ImageTransparentColor = Color.Magenta;
            tOpenDocument.Name = "tOpenDocument";
            tOpenDocument.Size = new Size(23, 22);
            tOpenDocument.Text = "Open in...";
            // 
            // tSaveFile
            // 
            tSaveFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tSaveFile.Image = Global.Resources.SaveImage;
            tSaveFile.ImageTransparentColor = Color.Magenta;
            tSaveFile.Name = "tSaveFile";
            tSaveFile.Size = new Size(23, 22);
            tSaveFile.Text = "Save As...";
            // 
            // tSaveAll
            // 
            tSaveAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tSaveAll.Enabled = true;
            tSaveAll.Image = Global.Resources.SaveAllImage;
            tSaveAll.ImageTransparentColor = Color.Magenta;
            tSaveAll.Name = "tSaveAll";
            tSaveAll.Size = new Size(23, 22);
            tSaveAll.Text = "Save all";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tPrint
            // 
            tPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            //tPrint.Enabled = false;
            tPrint.Image = Global.Resources.PrintImage;
            tPrint.ImageTransparentColor = Color.Magenta;
            tPrint.Name = "tPrint";
            tPrint.Size = new Size(23, 22);
            tPrint.Text = "Print";
            // 
            // tPrintPreview
            // 
            tPrintPreview.DisplayStyle = ToolStripItemDisplayStyle.Image;
            //tPrintPreview.Enabled = false;
            tPrintPreview.Image = Global.Resources.PrintPreviewImage;
            tPrintPreview.ImageTransparentColor = Color.Magenta;
            tPrintPreview.Name = "tPrintPreview";
            tPrintPreview.Size = new Size(23, 22);
            tPrintPreview.Text = "Print preview";

            Items.AddRange(new ToolStripItem[] {
            tNewDocument,
            tOpenDocument,
            tSaveFile,
            tSaveAll,
            toolStripSeparator1,
            tPrint,
            tPrintPreview
            });
            //this.Location = new System.Drawing.Point(3, 24);
            Name = "ToolBarFile";
            AutoSize = true;
            ItemClicked += FileToolBar_ItemClicked;
            //this.Size = new System.Drawing.Size(168, 25);
            //this.TabIndex = 1;
            ResumeLayout(true);
        }
        #endregion

        #region Events
        void FileToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tOpenDocument) Global.MainForm.Open();
            else if (e.ClickedItem == tSaveFile) Global.MainForm.DoSave();
            else if (e.ClickedItem == tSaveAll) Global.MainForm.DoSaveAll();
            else if (e.ClickedItem == tPrint) Global.MainForm.DoPrint();
            else if (e.ClickedItem == tPrintPreview) Global.MainForm.DoPrintPreview();
        }
        void tNewDocument_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tNewICSharpCodeEditor) Global.MainForm.AddICSharpEditor(null);
            else if (e.ClickedItem == tNewRTEditor) Global.MainForm.AddRTE(null);
            else if (e.ClickedItem == tNewScintilla) Global.MainForm.AddScintilla(null);
            else if (e.ClickedItem == tNewStandardEditor) Global.MainForm.AddStandardEditor(null);
            else if (e.ClickedItem == tNewHTMLEditor) Global.MainForm.AddHTMLEditor(null);
        }
        public override void RefreshToolBar()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                tSaveFile.Enabled = true;
                tSaveAll.Enabled = true;
                //tSaveFile.Enabled = ((DocumentBase)parent.DockPane.ActiveDocument).Changes;
                //tSaveAll.Enabled = ((DocumentBase)parent.DockPane.ActiveContent).Changes;
            }
            else
            {
                tSaveFile.Enabled = false;
            }
        }
        #endregion  
      
        #region Constructors
        public FileToolBar()
        {
            Global.MainForm.ToolBarContainer.TopToolStripPanel.Controls.Add(this);
            InitializeComponent();
        }
        #endregion
    }
}

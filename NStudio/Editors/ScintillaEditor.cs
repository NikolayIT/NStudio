using System;
using System.IO;
using NStudioInterface;
using System.Windows.Forms;
using Scintilla.Printing;

namespace NStudio
{
    public partial class ScintillaEditor : DocumentBase
    {
        FileInfo fi = null;
        public ScintillaEditor()
        {
            InitializeComponent();
            //this.fileName = string.Empty;
            //this.scideMDI = scideMDI;
            //this.scintillaEditor.AddShortcuts(this.menuStripEditor.Items);
            //this.scintillaEditor.SmartIndentingEnabled = true;
            editor.Configuration = Global.ScintillaConfig;
            editor.ConfigurationLanguage = "cs";
            printDocument = new PrintDocument(editor);
            printDocument.DefaultPageSettings = pageSettings = new PageSettings();
            //this.CreateLanguageMenuOptions("cs");
        }
        public override string StatusBarName
        {
            get
            {
                if (fi == null) return "Scintilla Editor";
                else return "Scintilla Editor (" + fi.Name + ")";
            }
        }
        public override void SetText(string aText)
        {
            editor.Text = aText;
        }
        public override void LoadFile(string aFile)
        {
            using (StreamReader sr = new StreamReader(aFile))
            {
                editor.Text = sr.ReadToEnd();
            }
            FileName = aFile;
            fi = new FileInfo(FileName);
            Changes = false;
            TabText = fi.Name;
            string language  = Global.ScintillaProperties.GetLanguageFromExtension(new FileInfo(aFile).Extension.TrimStart('.'));
            if (language != null) editor.ConfigurationLanguage = language;
        }
        public override void SaveFile(string File)
        {
            using (StreamWriter sw = new StreamWriter(File))
            {
                sw.Write(editor.Text);
            }
            Changes = false;
            TabText = new FileInfo(File).Name;
        }
        public override void Clear()
        {
            editor.Clear();
        }
        public override void Copy()
        {
            editor.Copy();
        }
        public override void Cut()
        {
            editor.Cut();
        }
        public override void Delete()
        {
            int ind = editor.SelectionStart;
            editor.Text = editor.Text.Remove(editor.SelectionStart, editor.SelectionEnd - editor.SelectionStart);
            editor.SetSelection(ind, ind);
        }
        public override void Paste()
        {
            editor.Paste();
        }
        public override void Redo()
        {
            editor.Redo();
        }
        public override void SelectAll()
        {
            editor.SelectAll();
        }
        public override void Undo()
        {
            editor.Undo();
        }
        public override string SelectedText
        {
            get
            {
                return editor.Text.Substring(editor.SelectionStart, editor.SelectionEnd - editor.SelectionStart);
            }
            set
            {
                int ind = editor.SelectionStart;
                editor.Text = editor.Text.Remove(editor.SelectionStart, editor.SelectionEnd - editor.SelectionStart);
                editor.InsertText(ind, value);
            }
        }
        private void editor_TextChanged(object sender, EventArgs e)
        {
            CanRedo = editor.CanRedo;
            CanUndo = editor.CanUndo;
            Changes = true;
            TabText = new FileInfo(FileName).Name + "*";
            OnControlChanged(ChangedControl.TextChanged);
        }
        public override bool Save()
        {
            if ((FileName != null) && FileName != "")
            {
                SaveFile(FileName);
                return true;
            }
            else return false;
        }
        public override bool CloseDocument()
        {
            return Changes;
        }
        public override string DocumentText
        {
            get
            {
                try { return editor.Text.Substring(editor.SelectionStart, editor.SelectionEnd - editor.SelectionStart); }
                catch { return ""; }
            }
            set { editor.Text.Replace(editor.Text.Substring(editor.SelectionStart, editor.SelectionEnd - editor.SelectionStart), value); }
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == undoToolStripMenuItem) Undo();
            else if (e.ClickedItem == redoToolStripMenuItem) Redo();
            else if (e.ClickedItem == cutToolStripMenuItem) Cut();
            else if (e.ClickedItem == copyToolStripMenuItem) Copy();
            else if (e.ClickedItem == pasteToolStripMenuItem) Paste();
            else if (e.ClickedItem == deleteToolStripMenuItem) Delete();
            else if (e.ClickedItem == selectAllToolStripMenuItem) SelectAll();
        }
        private void ScintillaEditor_Load(object sender, EventArgs e)
        {
            CanRedo = true;
            CanUndo = true;
        }
        private PrintDocument printDocument;
        private PageSettings pageSettings;
        public override void Print()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.Document = printDocument;
            dialog.PrinterSettings = pageSettings.PrinterSettings;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        public override void PrintPreview()
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = printDocument;
            dialog.ShowDialog();
        }
    }
}
using System;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.Document;
using System.IO;
using NStudioInterface;
using ICSharpCode.TextEditor.Util;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using System.Text;
namespace NStudio
{
    public partial class ICSharpCodeEditor : DocumentBase
    {
        FileInfo fi = null;
        public ICSharpCodeEditor()
        {
            InitializeComponent();
            textedit.TextChanged += new EventHandler(textedit_TextChanged);
            textedit.ActiveTextAreaControl.TextChanged += new EventHandler(textedit_TextChanged);
            textedit.ActiveTextAreaControl.TextArea.TextChanged += new EventHandler(textedit_TextChanged);
        }
        public override string StatusBarName
        {
            get
            {
                if (fi == null) return "ICSharpCode Editor";
                else return "ICSharpCode Editor (" + fi.Name + ")";
            }
        }
        public override void SetText(string aText)
        {
            textedit.Text = aText;
        }
        public override void Cut()
        {
            Cut cut = new Cut();
            cut.Execute(textedit.ActiveTextAreaControl.TextArea);
            cut = null;
        }
        public override void Copy()
        {
            Copy copy = new Copy();
            copy.Execute(textedit.ActiveTextAreaControl.TextArea);
            copy = null;
        }
        public override void Paste()
        {
            Paste paste = new Paste();
            paste.Execute(textedit.ActiveTextAreaControl.TextArea);
            paste = null;
        }
        public override void Delete()
        {
            Delete del = new Delete();
            del.Execute(textedit.ActiveTextAreaControl.TextArea);
            del = null;
        }
        public override void LoadFile(string File)
        {
            textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(File);
            textedit.LoadFile(File);
            FileName = File;
            fi = new FileInfo(FileName);
            Changes = false;
            TabText = fi.Name;
        }
        public override void SaveFile(string File)
        {
            textedit.SaveFile(File);
            Changes = false;
            TabText = new FileInfo(File).Name;
        }
        private void Editor_Load(object sender, EventArgs e)
        {
            textedit.ShowEOLMarkers = false;
            textedit.ShowHRuler = false;
            textedit.ShowInvalidLines = false;
            textedit.ShowLineNumbers = true;
            textedit.ShowMatchingBracket = true;
            textedit.ShowSpaces = false;
            textedit.ShowTabs = false;
            textedit.ShowVRuler = true;
            textedit.TabIndent = 3;
            textedit.ConvertTabsToSpaces = true;
        }
        public override void Undo()
        {
            textedit.Undo();
        }
        public override void Redo()
        {
            textedit.Redo();
        }
        public override void Clear()
        {
            textedit.Text = "";
        }
        public override void SelectAll()
        {
            textedit.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(null, null);
        }
        private void textedit_TextChanged(object sender, EventArgs e)
        {
            CanRedo = textedit.EnableRedo;
            CanUndo = textedit.EnableUndo;
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
                try { return textedit.Text; }
                catch { return ""; }
            }
            set { textedit.Text = value; }
        }
        public override string SpecialText
        {
            get
            {
                return RtfWriter.GenerateRtf(textedit.ActiveTextAreaControl.TextArea);
            }
            set
            {
                //textedit.Rtf = value;
            }
        }
        public override string SelectedText
        {
            get
            {
                return textedit.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
            }
            set
            {
                TextArea textArea = textedit.ActiveTextAreaControl.TextArea;
                if (!textArea.SelectionManager.HasSomethingSelected) return;
                // get the selected text:
                string text = textArea.SelectionManager.SelectedText;
                // reverse the text:
                //StringBuilder b = new StringBuilder(text.Length);
                //for (int i = text.Length - 1; i >= 0; i--)
                //    b.Append(text[i]);
                //string newText = b.ToString();
                // ensure caret is at start of selection
                textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
                // deselect text
                textArea.SelectionManager.ClearSelection();
                // replace the selected text with the new text:
                // Replace() takes the arguments: start offset to replace, length of the text to remove, new text
                textArea.Document.Replace(textArea.Caret.Offset,
                                          text.Length,
                                          value);
                // Redraw:
                textArea.Refresh();
                //int ind = textedit.ActiveTextAreaControl.TextArea.SelectionManager.
                //textedit.ActiveTextAreaControl.TextArea.SelectionManager.RemoveSelectedText();
                //textedit.ActiveTextAreaControl.TextArea.Text.Insert(1, value);
                //textedit.ActiveTextAreaControl.TextArea.SelectionManager.
            }
        }
        private void languageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == cToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
            else if (e.ClickedItem == cToolStripMenuItem1) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            else if (e.ClickedItem == vBNETToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("VBNET");
            else if (e.ClickedItem == aSPNETToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("ASP/XHTML");
            else if (e.ClickedItem == hTMLToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("HTML");
            else if (e.ClickedItem == pHPToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("PHP");
            else if (e.ClickedItem == javaToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Java");
            else if (e.ClickedItem == bATToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("BAT");
            else if (e.ClickedItem == booToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Boo");
            else if (e.ClickedItem == coCoToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Coco");
            else if (e.ClickedItem == javaScriptToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("JavaScript");
            else if (e.ClickedItem == patchToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Patch");
            else if (e.ClickedItem == teXToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TeX");
            else if (e.ClickedItem == xMLToolStripMenuItem) textedit.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
            foreach (ToolStripItem item in languageToolStripMenuItem.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == cutToolStripMenuItem) Cut();
            else if (e.ClickedItem == copyToolStripMenuItem) Copy();
            else if (e.ClickedItem == pasteToolStripMenuItem) Paste();
            else if (e.ClickedItem == undoToolStripMenuItem) Undo();
            else if (e.ClickedItem == redoToolStripMenuItem) Redo();
        }
        public override void Print()
        {
            textedit.PrintDocument.Print();
        }
        public override void PrintPreview()
        {
            //textedit.PrintDocument.
        }
    }
}
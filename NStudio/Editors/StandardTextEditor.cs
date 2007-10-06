using System;
using NStudioInterface;
using System.IO;

namespace NStudio
{
    public partial class StandardTextEditor : DocumentBase
    {
        FileInfo fi = null;
        public StandardTextEditor()
        {
            InitializeComponent();
        }
        public override string StatusBarName
        {
            get
            {
                if (fi == null) return "Standard Editor";
                else return "Standard Editor (" + fi.Name + ")";
            }
        }
        public override void SetText(string aText)
        {
            textedit.Text = aText;
        }
        public override void Cut()
        {
            textedit.Cut();
        }
        public override void Copy()
        {
            textedit.Copy();
        }
        public override void Paste()
        {
            textedit.Paste();
        }
        public override void Delete()
        {
            int ind = textedit.SelectionStart;
            textedit.Text = textedit.Text.Remove(textedit.SelectionStart, textedit.SelectionLength);
            textedit.Select(ind, 0);
        }
        public override void Undo()
        {
            textedit.Undo();
        }
        public override void Redo()
        {
            //textedit.Redo();
        }
        public override void Clear()
        {
            textedit.Clear();
        }
        public override void SelectAll()
        {
            textedit.SelectAll();
        }
        public override void LoadFile(string File)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                textedit.Text = sr.ReadToEnd();
            }
            fi = new FileInfo(FileName);
            FileName = File;
            Changes = false;
            TabText = fi.Name;
        }
        public override void SaveFile(string File)
        {
            using (StreamWriter sw = new StreamWriter(File))
            {
                sw.Write(textedit.Text);
            }
            Changes = false;
            TabText = new FileInfo(File).Name;
        }
        private void textedit_TextChanged(object sender, EventArgs e)
        {
            //CanRedo = textedit.CanRedo;
            CanRedo = false;
            CanUndo = textedit.CanUndo;
            Changes = true;
            try { TabText = new FileInfo(FileName).Name + "*"; }
            catch { TabText = "Untitled*"; }
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
                try { return textedit.Text.Substring(textedit.SelectionStart, textedit.SelectionLength); }
                catch { return ""; }
            }
            set { textedit.Text.Replace(textedit.Text.Substring(textedit.SelectionStart, textedit.SelectionLength), value); }
        }
        public override string SelectedText
        {
            get
            {
                return textedit.SelectedText;
            }
            set
            {
                textedit.SelectedText = value;
            }
        }
        public override void Print()
        {
            //editor.Print();
        }
        public override void PrintPreview()
        {
            //editor.PrintPreview();
        }
    }
}
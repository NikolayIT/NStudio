using System;
using NStudioInterface;
using System.IO;

namespace NStudio
{
    public partial class HTML : DocumentBase
    {
        FileInfo fi = null;
        public HTML()
        {
            InitializeComponent();
            CanRedo = true;
            CanUndo = true;
        }
        public override string StatusBarName
        {
            get
            {
                if (fi == null) return "HTML Editor";
                else return "HTML Editor (" + fi.Name + ")";
            }
        }
        public override void Cut()
        {
            if (editor.CanCut) editor.Cut();
        }
        public override void Copy()
        {
            if (editor.CanCopy) editor.Copy();
        }
        public override void Paste()
        {
            if (editor.CanPaste) editor.Paste();
        }
        public override void Delete()
        {
            if (editor.CanDelete) editor.Delete();
        }
        public override void Undo()
        {
            if (editor.CanUndo) editor.Undo();
        }
        public override void Redo()
        {
            if (editor.CanRedo) editor.Redo();
        }
        public override void Clear()
        {
            if (editor.CanSelectAll && editor.CanDelete)
            {
                editor.SelectAll();
                editor.Delete();
            }
        }
        public override void SelectAll()
        {
            if (editor.CanSelectAll) editor.SelectAll();
        }
        public override void LoadFile(string File)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                editor.LoadHtml(sr.ReadToEnd());
            }
            FileName = File;
            fi = new FileInfo(FileName);
            Changes = false;
            TabText = fi.Name;
        }
        public override void SaveFile(string File)
        {
            using (StreamWriter sw = new StreamWriter(File))
            {
                sw.Write(editor.SaveHtml());
            }
            Changes = false;
            TabText = new FileInfo(File).Name;
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
        public override string SpecialText
        {
            get
            {
                return editor.SaveHtml();
            }
            set
            {
                editor.LoadHtml(value);
            }
        }
        public override void Print()
        {
            editor.Print();
        }
        public override void PrintPreview()
        {
            editor.PrintPreview();
        }
    }
}
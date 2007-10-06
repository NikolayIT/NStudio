using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NStudioInterface
{
    public partial class DocumentBase : DockBase
    {
        //
        public bool CanUndo = false;
        public bool CanRedo = false;
        //
        public bool Changes = false;
        public string FileName = "";
        //
        public virtual void SetText(string aText) { }
        public virtual void LoadFile(string aFile) { }
        public virtual void SaveFile(string aFile) { }
        public virtual bool Save() { return false; }
        public virtual bool CloseDocument() { return true; }
        // Edit Functions
        public virtual void Undo() { }
        public virtual void Redo() { }
        public virtual void Cut() { }
        public virtual void Copy() { }
        public virtual void Paste() { }
        public virtual void Delete() { }
        public virtual void SelectAll() { }
        public virtual void Clear() { }
        //
        public virtual void Print() { }
        public virtual void PrintPreview() { }
        //
        public virtual string DocumentText
        {
            get { return ""; }
            set { ;}
        }
        public virtual string SpecialText
        {
            get { return ""; }
            set { ;}
        }
        public virtual string SelectedText
        {
            get { return ""; }
            set { ;}
        }
        //
    }
}
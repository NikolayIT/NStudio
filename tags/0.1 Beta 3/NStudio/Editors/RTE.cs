using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NStudioInterface;

namespace NStudio
{
    public partial class RTE : DocumentBase
    {
        FileInfo fi = null;
        public RTE()
        {
            InitializeComponent();
            Changes = false;
        }
        public override string StatusBarName
        {
            get
            {
                if (fi == null) return "Rich Text Editor";
                else return "Rich Text Editor (" + fi.Name + ")";
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
            textedit.Redo();
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
                string inp = sr.ReadToEnd();
                try { textedit.Rtf = inp; }
                catch (ArgumentException) { textedit.Text = inp; }
            }
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
        private void textedit_TextChanged(object sender, EventArgs e)
        {
            CanRedo = textedit.CanRedo;
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
        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tbrFont)
            {
                fontDialog1.Font = textedit.SelectionFont;
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    textedit.SelectionFont = fontDialog1.Font;
                }
            }
            if (e.ClickedItem == tbrColor)
            {
                colorDialog1.Color = textedit.SelectionColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    textedit.SelectionColor = colorDialog1.Color;
                }
            }
            else if (e.ClickedItem == tbrLeft) textedit.SelectionAlignment = HorizontalAlignment.Left;
            else if (e.ClickedItem == tbrCenter) textedit.SelectionAlignment = HorizontalAlignment.Center;
            else if (e.ClickedItem == tbrRight) textedit.SelectionAlignment = HorizontalAlignment.Right;
            else if (e.ClickedItem == tbrBold) textedit.SelectionFont = new Font(textedit.SelectionFont, textedit.SelectionFont.Style ^ FontStyle.Bold);
            else if (e.ClickedItem == tbrItalic) textedit.SelectionFont = new Font(textedit.SelectionFont, textedit.SelectionFont.Style ^ FontStyle.Italic);
            else if (e.ClickedItem == tbrUnderline) textedit.SelectionFont = new Font(textedit.SelectionFont, textedit.SelectionFont.Style ^ FontStyle.Underline);
            else if (e.ClickedItem == tbrStrikeout) textedit.SelectionFont = new Font(textedit.SelectionFont, textedit.SelectionFont.Style ^ FontStyle.Strikeout);
            else if (e.ClickedItem == tbrNormal) textedit.SelectionFont = new Font(textedit.SelectionFont, FontStyle.Regular);
            else if (e.ClickedItem == tbrInsertImage) openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            object curr = Clipboard.GetDataObject();
            string strImagePath = openFileDialog1.FileName;
            Image img;
            img = Image.FromFile(strImagePath);
            Clipboard.SetDataObject(img);
            DataFormats.Format df;
            df = DataFormats.GetFormat(DataFormats.Bitmap);
            if (textedit.CanPaste(df))
            {
                textedit.Paste(df);
            }
            Clipboard.SetDataObject(curr);
        }

        private void textedit_SelectionChanged(object sender, EventArgs e)
        {
            tbrBold.Checked = textedit.SelectionFont.Bold;
            tbrItalic.Checked = textedit.SelectionFont.Italic;
            tbrUnderline.Checked = textedit.SelectionFont.Underline;
            tbrStrikeout.Checked = textedit.SelectionFont.Strikeout;
        }

        private void IndentToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mnuIndent0) textedit.SelectionIndent = 0;
            else if (e.ClickedItem == mnuIndent5) textedit.SelectionIndent = 5;
            else if (e.ClickedItem == mnuIndent10) textedit.SelectionIndent = 10;
            else if (e.ClickedItem == mnuIndent15) textedit.SelectionIndent = 15;
            else if (e.ClickedItem == mnuIndent20) textedit.SelectionIndent = 20;
            else if (e.ClickedItem == mnuIndent25) textedit.SelectionIndent = 25;
            else if (e.ClickedItem == mnuIndent30) textedit.SelectionIndent = 30;
            else if (e.ClickedItem == mnuIndent40) textedit.SelectionIndent = 40;
            else if (e.ClickedItem == mnuIndent50) textedit.SelectionIndent = 50;
        }

        private void PageColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textedit.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textedit.BackColor = colorDialog1.Color;
            }
        }
        private void AddBulletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textedit.BulletIndent = 10;
            textedit.SelectionBullet = true;
        }
        private void RemoveBulletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textedit.SelectionBullet = false;
        }
        public override string SpecialText
        {
            get
            {
                return textedit.Rtf;
            }
            set
            {
                textedit.Rtf = value;
            }
        }
        public override void Print()
        {
            //textedit.Print();
        }
        public override void PrintPreview()
        {
            //textedit.PrintPreview();
        }
    }
}
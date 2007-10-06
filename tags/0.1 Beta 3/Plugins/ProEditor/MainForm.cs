using System;
using NStudioInterface;

namespace ProEditor
{
    public partial class MainForm : DocumentBase, IPluginForm
    {
        IMainForm parent;
        public MainForm()
        {
            InitializeComponent();
        }

        #region IPluginForm Members
        public IMainForm ParentMainForm
        {
            set
            {
                parent = value;
            }
            get
            {
                return parent;
            }
        }
        #endregion

        #region Character
        private void convertQuotesToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("'", "\"");
            parent.CurrentDocumentText = text;
        }
        private void convertQuotesToToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\"", "'");
            parent.CurrentDocumentText = text;
        }
        private void removeQuotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\"", "");
            text = text.Replace("'", "");
            parent.CurrentDocumentText = text;
        }
        private void convertToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\"", "\\\"");
            parent.CurrentDocumentText = text;
        }
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("'", "\\'");
            parent.CurrentDocumentText = text;
        }
        private void convertToToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("'", "\\\"");
            parent.CurrentDocumentText = text;
        }
        private void convertToToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\\\"", "\"");
            parent.CurrentDocumentText = text;
        }
        private void convertToToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\\'", "'");
            parent.CurrentDocumentText = text;
        }
        private void convertToToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.Replace("\\\"", "'");
            parent.CurrentDocumentText = text;
        }
        #endregion

        private void uPPERCASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.ToUpper();
            parent.CurrentDocumentText = text;
        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.ToLower();
            parent.CurrentDocumentText = text;
        }

        private void properCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.ToLowerInvariant();
            parent.CurrentDocumentText = text;
        }

        private void iNVERTCASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = parent.CurrentDocumentText;
            text = text.ToUpperInvariant();
            parent.CurrentDocumentText = text;
        }
        /*
        private void convertRTFToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (parent.DockPane.ActiveContent is DocumentBase)
            {
                string convert = ((DocumentBase) parent.DockPane.ActiveContent).SpecialText;
                MessageBox.Show(convert);
            }
        }
         */
    }
}
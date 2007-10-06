using System;
using System.Windows.Forms;
using NStudioInterface;
using System.IO;
using System.Drawing;

namespace NStudio
{
    public partial class OpenInForm : Form
    {
        public NewOpenIn OpenIn = NewOpenIn.ScintillaEditor;
        public OpenInForm(string fileName)
        {
            InitializeComponent();
            Font boldFont = new Font(Scintilla.Font, FontStyle.Bold);
            label2.Text = fileName;
            FileInfo fi = new FileInfo(fileName);
            if (fi.Extension == ".rtf")
            {
                label3.Text = "We recommend you Rich Text Editor";
                RTE.Font = boldFont;
            }
            else if (fi.Extension == ".html" || fi.Extension == ".htm")
            {
                label3.Text = "We recommend you HTML, Scintilla or ICSharpCode editor";
                HTML.Font = boldFont;
                Scintilla.Font = boldFont;
                ICSharpCode.Font = boldFont;
            }
            else
            {
                label3.Text = "We recommend you Scintilla or ICSharpCode editor";
                Scintilla.Font = boldFont;
                ICSharpCode.Font = boldFont;
            }
        }

        private void Scintilla_Click(object sender, EventArgs e)
        {
            OpenIn = NewOpenIn.ScintillaEditor;
            Close();
        }

        private void ICSharpCode_Click(object sender, EventArgs e)
        {
            OpenIn = NewOpenIn.ICSharpEditor;
            Close();
        }

        private void RTE_Click(object sender, EventArgs e)
        {
            OpenIn = NewOpenIn.RTFEditor;
            Close();
        }

        private void HTML_Click(object sender, EventArgs e)
        {
            OpenIn = NewOpenIn.HTMLEditor;
            Close();
        }

        private void Standart_Click(object sender, EventArgs e)
        {
            OpenIn = NewOpenIn.StandardEditor;
            Close();
        }
    }
}
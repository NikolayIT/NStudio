using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using NStudioInterface;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace CodeSnippet
{
    public partial class CodeSnippet : DockBase, IPluginForm
    {
        IMainForm parent;
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
        private ZipFile file;
        public CodeSnippet()
        {
            InitializeComponent();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            treeView.Nodes.Clear();
            textBox1.Text = openFileDialog1.FileName;
            file = new ZipFile(openFileDialog1.FileName);
            foreach (ZipEntry entr in file)
            {
                if (entr.IsFile)
                {
                    treeView.Nodes.Add(entr.Name);
                }
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Stream str = file.GetInputStream(file.FindEntry(e.Node.Text, true));
                byte[] data = new byte[4096];
                int size = str.Read(data, 0, data.Length);
                StringBuilder sb = new StringBuilder((int) str.Length + 16);
                while (size > 0)
                {
                    sb.Append(Encoding.Default.GetString(data, 0, size));
                    size = str.Read(data, 0, data.Length);
                }
                Clipboard.SetText(sb.ToString());
            }
            catch
            {
            }
        }
    }
}

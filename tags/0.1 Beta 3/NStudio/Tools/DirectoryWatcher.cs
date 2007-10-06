using System;
using NStudioInterface;

namespace NStudio
{
    public partial class DirectoryWatcher : DockBase
    {
        private bool started = false;
        public DirectoryWatcher()
        {
            InitializeComponent();
        }
        public override string StatusBarName
        {
            get
            {
                return "Directory Watcher 0.1";
            }
        }
        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            richTextBox1.AppendText(e.Name + " " + e.ChangeType + Environment.NewLine);
        }
        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            richTextBox1.AppendText(e.Name + " " + e.ChangeType + Environment.NewLine);
        }
        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            richTextBox1.AppendText(e.Name + " " + e.ChangeType + Environment.NewLine);
        }
        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            richTextBox1.AppendText(e.Name + " " + e.ChangeType + Environment.NewLine);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (started)
            {
                button2.Text = "Start";
                fileSystemWatcher1.EnableRaisingEvents = false;
                started = false;
            }
            else
            {
                fileSystemWatcher1.Path = textBox1.Text;
                button2.Text = "Stop";
                fileSystemWatcher1.EnableRaisingEvents = true;
                started = true;
            }
        }
    }
}
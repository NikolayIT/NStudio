using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NStudioInterface;

namespace WindowsMediaPlayer
{
    public partial class MainForm : DocumentBase, IPluginForm
    {
        private IMainForm parent;
        public IMainForm ParentMainForm
        {
            set { parent = value; }
            get
            {
                return parent;
            }
        }
        public override string StatusBarName
        {
            get
            {
                return "WindowsMediaPlayer 0.1 (" + axWindowsMediaPlayer1.versionInfo  + ")";
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            //parent.StatusBar.SetStatusBarText(axWindowsMediaPlayer1.status);
        }
        void openStream_Click(object sender, System.EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"mms://87.120.130.6/btv_live_q2.wmv";
        }
    }
}
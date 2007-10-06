using System;
using System.Windows.Forms;
using System.Diagnostics;
using NStudioInterface;

namespace NStudio
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            groupBox1.Text = Global.FullName;
            lblName.Text = Global.FullName;
            linkLabel1.Text = Global.ProgramSite;
            linkLabel2.Text = Global.AuthorSite;
            foreach (string comp in Global.Components)
            {
                listBox1.Items.Add(comp);
            }
            foreach (PluginType plug in PluginManager.Plugins)
            {
                listBox1.Items.Add(plug.ToString());
            }
            //linkLabel3.Text = Global.AuthorMail;
            //linkLabel4.Text = Global.ProgramForum;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Global.HasWebBrowser) Global.MainForm.AddBrowser(Global.ProgramSite);
            else Process.Start(Global.ProgramSite);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Global.HasWebBrowser) Global.MainForm.AddBrowser(Global.AuthorSite);
            else Process.Start(Global.AuthorSite);
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Global.HasWebBrowser) Global.MainForm.AddBrowser(Global.AuthorMail);
            else Process.Start(Global.AuthorMail);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Global.HasWebBrowser) Global.MainForm.AddBrowser(Global.ProgramForum);
            else Process.Start(Global.ProgramForum);
        }
    }
}
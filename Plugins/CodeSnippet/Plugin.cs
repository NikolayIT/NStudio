using System;
using NStudioInterface;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CodeSnippet
{
    public class Plugin : IPlugin
    {
        CodeSnippet frm;
        IMainForm parent;
        ToolStripMenuItem menu;

        #region IPlugin Members
        public string Name
        {
            get { return "CodeSnippet"; }
        }
        public string Description
        {
            get { return "Code Snippets For NStudio"; }
        }
        public string Author
        {
            get { return "NRPG"; }
        }
        public string Version
        {
            get { return "0.1"; }
        }
        public string FullName
        {
            get { return Name + " " + Version; }
        }
        public void Initialize(IMainForm Parent)
        {
            parent = Parent;
            //
            frm = new CodeSnippet();
            frm.ParentMainForm = parent;
            frm.Name = FullName;
            frm.HideOnClose = true;
            //
            menu = new ToolStripMenuItem();
            menu.Text = Name;
            menu.Click += new EventHandler(menu_Click);
            //
            parent.AddPluginMenu(menu);
            frm.Show(parent.DockPane, DockState.DockLeft);
        }
        void menu_Click(object sender, EventArgs e)
        {
            frm.Show(parent.DockPane, DockState.DockLeft);
        }
        public void Dispose()
        {
            parent.RemoveMenu(menu);
            frm.Dispose();
        }
        #endregion
    }
}

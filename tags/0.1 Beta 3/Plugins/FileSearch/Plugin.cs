using System;
using NStudioInterface;
using System.Windows.Forms;
using FileSearch.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FileSearch
{
    public class Plugin : IPlugin
    {
        frmMain frm;
        IMainForm parent;
        //ToolStripMenuItem glmenu;
        ToolStripMenuItem menu;

        #region IPlugin Members
        public string Name
        {
            get { return "FileSearch"; }
        }
        public string Description
        {
            get { return "Search into your files"; }
        }
        public string Author
        {
            get { return "NRPG"; }
        }
        public string Version
        {
            get { return "4.1.3"; }
        }
        public string FullName
        {
            get { return Name + " " + Version; }
        }
        public void Initialize(IMainForm Parent)
        {
            parent = Parent;
            //
            frm = new frmMain();
            frm.ParentMainForm = parent;
            frm.Name = FullName;
            frm.HideOnClose = false;
            //
            //glmenu = new ToolStripMenuItem();
            //glmenu.Text = this.FullName;
            //glmenu.DropDownItems.Add(frm.mnuFile);
            //glmenu.DropDownItems.Add(frm.mnuEdit);
            //glmenu.DropDownItems.Add(frm.mnuTools);
            //glmenu.DropDownItems.Add(frm.mnuHelp);
            //parent.AddMenu(glmenu);
            //
            menu = new ToolStripMenuItem();
            menu.Text = Name;
            menu.Click += menu_Click;
            parent.AddPluginMenu(menu);
            //
            frm.Show(parent.DockPane, DockState.Document);
        }

        void menu_Click(object sender, EventArgs e)
        {
            frmMain frm2 = new frmMain();
            frm2.ParentMainForm = parent;
            frm2.Name = FullName;
            frm2.HideOnClose = false;
            frm2.Show(parent.DockPane, DockState.Document);
        }
        public void Dispose()
        {
            parent.RemoveMenu(menu);
            frm.Dispose();
        }
        #endregion
    }
}
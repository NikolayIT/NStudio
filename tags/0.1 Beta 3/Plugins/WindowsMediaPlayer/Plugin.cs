using System;
using NStudioInterface;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WindowsMediaPlayer
{
    public class Plugin : IPlugin
    {
        MainForm frm;
        IMainForm parent;
        ToolStripMenuItem menu;

        #region IPlugin Members
        public string Name
        {
            get { return "WindowsMediaPlayer"; }
        }
        public string Description
        {
            get { return "Play all your media files"; }
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
            frm = new MainForm();
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
            menu.Click += new EventHandler(menu_Click);
            parent.AddPluginMenu(menu);
            //
            frm.Show(parent.DockPane, DockState.Document);
        }

        void menu_Click(object sender, EventArgs e)
        {
            MainForm frm2 = new MainForm();
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
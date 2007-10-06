using System;
using System.Collections.Generic;
using System.Text;
using NStudioInterface;
using System.Windows.Forms;

namespace ProEditor
{
    public class Plugin : IPlugin
    {
        IMainForm parent;
        MainForm frm;
        ToolStripMenuItem menu;

        #region IPlugin Members
        public string Name
        {
            get { return "ProEditor"; }
        }
        public string Description
        {
            get { return "Enchances editor features. Proffessional text editing. Useful funcitons."; }
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
            frm = new MainForm();
            frm.ParentMainForm = parent;
            menu = new ToolStripMenuItem();
            menu.Text = this.Name;
            menu.DropDownItems.Add(frm.mnuCharacters);
            menu.DropDownItems.Add(frm.mnuQuick);
            menu.DropDownItems.Add(frm.mnuEdit);
            menu.DropDownItems.Add(frm.mnuConvert);
            menu.DropDownItems.Add(frm.mnuInsert);
            menu.DropDownItems.Add(frm.mnuTools);
            menu.DropDownItems.Add(frm.mnuViz);
            menu.Image = global::ProEditor.Properties.Resources.icon;
            parent.AddMenu(menu);
        }
        public void Dispose()
        {
            
        }
        #endregion
    }
}

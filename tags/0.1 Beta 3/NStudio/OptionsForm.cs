using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NStudio
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void UpdateSettings()
        {
            // general
            Global.Settings.Settings.MinimizeToTray = chkMinimizeToTray.Checked;
            Global.Settings.Settings.EnableDragAndDrop = chkDragAndDrop.Checked;
            Global.Settings.Settings.ShowStatusBar = chkShowStatusBar.Checked;
            Global.Settings.Settings.ShowFileToolBar = chkShowFileToolBar.Checked;
            Global.Settings.Settings.ShowEditToolBar = chkShowEditToolBar.Checked;
            Global.Settings.Settings.ShowViewToolBar = chkShowViewToolBar.Checked;
            Global.Settings.Settings.ShowOthersToolBar = chkShowOthersToolBar.Checked;
            // browser settings
            Global.Settings.Settings.BrowserContextMenu = chkBrowserContextMenu.Checked;
            Global.Settings.Settings.BrowserDrop = chkBrowserDrop.Checked;
            Global.Settings.Settings.BrowserScriptErrors = chkBrowserScriptErrors.Checked;
            Global.Settings.Settings.BrowserScrollBar = chkBrowserScrollbar.Checked;
            Global.Settings.Settings.BrowserShortcuts = chkBrowserShortcuts.Checked;
        }
        private void LoadSettings()
        {
            // general
            chkMinimizeToTray.Checked = Global.Settings.Settings.MinimizeToTray;
            chkDragAndDrop.Checked = Global.Settings.Settings.EnableDragAndDrop;
            chkShowStatusBar.Checked = Global.Settings.Settings.ShowStatusBar;
            chkShowFileToolBar.Checked = Global.Settings.Settings.ShowFileToolBar;
            chkShowEditToolBar.Checked = Global.Settings.Settings.ShowEditToolBar;
            chkShowViewToolBar.Checked = Global.Settings.Settings.ShowViewToolBar;
            chkShowOthersToolBar.Checked = Global.Settings.Settings.ShowOthersToolBar;
            // browser settings
            chkBrowserContextMenu.Checked = Global.Settings.Settings.BrowserContextMenu;
            chkBrowserDrop.Checked = Global.Settings.Settings.BrowserDrop;
            chkBrowserScriptErrors.Checked = Global.Settings.Settings.BrowserScriptErrors;
            chkBrowserScrollbar.Checked = Global.Settings.Settings.BrowserScrollBar;
            chkBrowserShortcuts.Checked = Global.Settings.Settings.BrowserShortcuts;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UpdateSettings();
            Global.Settings.RefreshForm();
            Global.Settings.UpdateMenues();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
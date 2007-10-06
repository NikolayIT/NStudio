using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NStudioInterface;
using System.Drawing;

namespace NStudio
{
    public class StatusBar : StatusBarBase
    {
        ToolStripStatusLabel InfoPanel;
        ToolStripStatusLabel ContentName;
        ToolStripStatusLabel VersionPanel;
        ToolStripSeparator separator;
        ToolStripSeparator separator2;

        private void Initialize()
        {
            InfoPanel = new ToolStripStatusLabel();
            ContentName = new ToolStripStatusLabel();
            VersionPanel = new ToolStripStatusLabel();
            separator = new ToolStripSeparator();
            separator2 = new ToolStripSeparator();
            SuspendLayout();
            RenderMode = ToolStripRenderMode.ManagerRenderMode;
            //
            InfoPanel.AutoSize = true;
            InfoPanel.TextAlign = ContentAlignment.MiddleLeft;
            InfoPanel.Spring = true;
            InfoPanel.Text = "Program loaded...";
            //
            ContentName.AutoSize = true;
            ContentName.Text = "";
            //
            VersionPanel.AutoSize = true;
            VersionPanel.Text = Global.FullName;
            //
            Items.Add(InfoPanel);
            Items.Add(separator);
            Items.Add(ContentName);
            Items.Add(separator2);
            Items.Add(VersionPanel);
            ResumeLayout(true);
        }

        public StatusBar(IMainForm aParent)
        {
            parent = aParent;
            Initialize();
            parent.ToolBarContainer.BottomToolStripPanel.Controls.Add(this);
        }

        public override void SetStatusBarText(string aText)
        {
            InfoPanel.Text = aText;
        }
        public override void SetStatusBarName(string aName)
        {
            ContentName.Text = aName;
        }
    }
}

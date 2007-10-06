using System.Windows.Forms;
using System.Drawing;
using NStudioInterface;

namespace NStudio
{
    public class ViewToolBar : ToolBarBase
    {
        #region Fields
        private ToolStripDropDownButton tSkin;
        private ToolStripMenuItem tProfessionalSkin;
        private ToolStripMenuItem tOffice2007Skin;
        private ToolStripMenuItem tSystemSkin;
        private ToolStripButton tWebBrowser;
        #endregion

        #region Initialization
        private void InitializeComponent()
        {
            SuspendLayout();
            Dock = DockStyle.None;

            tSkin = new ToolStripDropDownButton();
            tProfessionalSkin = new ToolStripMenuItem();
            tSystemSkin = new ToolStripMenuItem();
            tOffice2007Skin = new ToolStripMenuItem();
            tWebBrowser = new ToolStripButton();

            // 
            // tSkin
            // 
            tSkin.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tSkin.DropDownItems.AddRange(new ToolStripItem[] {
            tProfessionalSkin,
            tSystemSkin,
            tOffice2007Skin});
            tSkin.Image = Global.Resources.ViewImage;
            tSkin.ImageTransparentColor = Color.Magenta;
            tSkin.Name = "tSkin";
            tSkin.Size = new Size(29, 22);
            tSkin.Text = "Renderer";
            tSkin.DropDownItemClicked += tSkin_DropDownItemClicked;
            // 
            // tProfessionalSkin
            // 
            tProfessionalSkin.Checked = true;
            tProfessionalSkin.CheckState = CheckState.Checked;
            tProfessionalSkin.Name = "tProfessionalSkin";
            tProfessionalSkin.Size = new Size(143, 22);
            tProfessionalSkin.Text = "Professional";
            // 
            // tSystemSkin
            // 
            tSystemSkin.Name = "tSystemSkin";
            tSystemSkin.Size = new Size(143, 22);
            tSystemSkin.Text = "System";
            // 
            // tOffice2007Skin
            // 
            tOffice2007Skin.Name = "tOffice2007Skin";
            tOffice2007Skin.Size = new Size(143, 22);
            tOffice2007Skin.Text = "Office 2007";
            // 
            // tWebBrowser
            // 
            tWebBrowser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tWebBrowser.Image = Global.Resources.WebImage;
            tWebBrowser.ImageTransparentColor = Color.Magenta;
            tWebBrowser.Name = "tWebBrowser";
            tWebBrowser.Size = new Size(23, 22);
            tWebBrowser.Text = "Web browser";

            Items.AddRange(new ToolStripItem[] {
            tSkin,
            tWebBrowser});
            //this.Location = new System.Drawing.Point(3, 24);
            Name = "ToolBarEdit";
            AutoSize = true;
            ItemClicked += ViewToolBar_ItemClicked;
            //this.Size = new System.Drawing.Size(168, 25);
            //this.TabIndex = 1;
            ResumeLayout(true);
        }
        #endregion

        #region Events
        public override void RefreshToolBar()
        {
            if (Global.MainForm.Renderer == AvailableRenderers.System)
            {
                tSystemSkin.Checked = true;
                tProfessionalSkin.Checked = false;
                tOffice2007Skin.Checked = false;
            }
            if (Global.MainForm.Renderer == AvailableRenderers.Professional)
            {
                tSystemSkin.Checked = false;
                tProfessionalSkin.Checked = true;
                tOffice2007Skin.Checked = false;
            }
            if (Global.MainForm.Renderer == AvailableRenderers.Office2007)
            {
                tSystemSkin.Checked = false;
                tProfessionalSkin.Checked = false;
                tOffice2007Skin.Checked = true;
            }
        }
        void ViewToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tWebBrowser) Global.MainForm.AddBrowser(Global.DefaultWebBrowserAddress);
            //else if (e.ClickedItem == tWebBrowser) Global.MainForm.AddBrowser(Global.DefaultWebBrowserAddress);
        }
        void tSkin_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tSystemSkin)
            {
                Global.MainForm.Renderer = AvailableRenderers.System;
            }
            else if (e.ClickedItem == tProfessionalSkin)
            {
                Global.MainForm.Renderer = AvailableRenderers.Professional;
            }
            else if (e.ClickedItem == tOffice2007Skin)
            {
                Global.MainForm.Renderer = AvailableRenderers.Office2007;
            }
        }

        #endregion

        #region Constructors
        public ViewToolBar()
        {
            Global.MainForm.ToolBarContainer.TopToolStripPanel.Controls.Add(this);
            InitializeComponent();
        }
        #endregion
    }
}

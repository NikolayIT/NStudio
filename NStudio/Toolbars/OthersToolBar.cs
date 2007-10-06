using System.Windows.Forms;
using System.Drawing;
using NStudioInterface;

namespace NStudio
{
    public class OthersToolBar : ToolBarBase
    {
        #region Fields
        private ToolStripButton tOptions;
        private ToolStripButton tAbout;
        #endregion

        #region Initialization
        private void InitializeComponent()
        {
            SuspendLayout();
            Dock = DockStyle.None;

            tOptions = new ToolStripButton();
            tAbout = new ToolStripButton();

            // 
            // tOptions
            // 
            tOptions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tOptions.Image = Global.Resources.PropertiesImage;
            tOptions.ImageTransparentColor = Color.Magenta;
            tOptions.Name = "tOptions";
            tOptions.Size = new Size(23, 22);
            tOptions.Text = "Options";
            // 
            // tAbout
            // 
            tAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tAbout.Image = Global.Resources.HelpImage;
            tAbout.ImageTransparentColor = Color.Magenta;
            tAbout.Name = "tAbout";
            tAbout.Size = new Size(23, 22);
            tAbout.Text = "Help";


            Items.AddRange(new ToolStripItem[] {
            tOptions,
            tAbout});
            //this.Location = new System.Drawing.Point(3, 24);
            Name = "ToolBarEdit";
            AutoSize = true;
            ItemClicked += OthersToolBar_ItemClicked;
            //this.Size = new System.Drawing.Size(168, 25);
            //this.TabIndex = 1;
            ResumeLayout(true);
        }
        #endregion

        #region Events
        public override void RefreshToolBar()
        {
            //
        }
        void OthersToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tOptions) Global.MainForm.ShowOptionsForm();
            else if (e.ClickedItem == tAbout) Global.MainForm.ShowAboutForm();
        }
        #endregion

        #region Constructors
        public OthersToolBar()
        {
            Global.MainForm.ToolBarContainer.TopToolStripPanel.Controls.Add(this);
            InitializeComponent();
        }
        #endregion
    }
}

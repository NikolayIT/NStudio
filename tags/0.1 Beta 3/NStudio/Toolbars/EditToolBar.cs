using System.Windows.Forms;
using System.Drawing;
using NStudioInterface;

namespace NStudio
{
    public class EditToolBar : ToolBarBase
    {
        #region Fields
        private ToolStripButton tCut;
        private ToolStripButton tCopy;
        private ToolStripButton tPaste;
        private ToolStripButton tDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tUndo;
        private ToolStripButton tRedo;
        #endregion

        #region Initialization
        private void InitializeComponent()
        {
            SuspendLayout();
            Dock = DockStyle.None;

            tCut = new ToolStripButton();
            tCopy = new ToolStripButton();
            tPaste = new ToolStripButton();
            tDelete = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tUndo = new ToolStripButton();
            tRedo = new ToolStripButton();

            // 
            // tCut
            // 
            tCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tCut.Image = Global.Resources.CutImage;
            tCut.ImageTransparentColor = Color.Magenta;
            tCut.Name = "tCut";
            tCut.Size = new Size(23, 22);
            tCut.Text = "Cut";
            // 
            // tCopy
            // 
            tCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tCopy.Image = Global.Resources.CopyImage;
            tCopy.ImageTransparentColor = Color.Magenta;
            tCopy.Name = "tCopy";
            tCopy.Size = new Size(23, 22);
            tCopy.Text = "Copy";
            // 
            // tPaste
            // 
            tPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tPaste.Image = Global.Resources.PasteImage;
            tPaste.ImageTransparentColor = Color.Magenta;
            tPaste.Name = "tPaste";
            tPaste.Size = new Size(23, 22);
            tPaste.Text = "Paste";
            // 
            // tDelete
            // 
            tDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tDelete.Image = Global.Resources.DeleteImage;
            tDelete.ImageTransparentColor = Color.Magenta;
            tDelete.Name = "tDelete";
            tDelete.Size = new Size(23, 22);
            tDelete.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tUndo
            // 
            tUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tUndo.Image = Global.Resources.UndoImage;
            tUndo.ImageTransparentColor = Color.Magenta;
            tUndo.Name = "tUndo";
            tUndo.Size = new Size(23, 22);
            tUndo.Text = "Undo";
            // 
            // tRedo
            // 
            tRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tRedo.Image = Global.Resources.RedoImage;
            tRedo.ImageTransparentColor = Color.Magenta;
            tRedo.Name = "tRedo";
            tRedo.Size = new Size(23, 22);
            tRedo.Text = "Redo";

            Items.AddRange(new ToolStripItem[] {
            tCut,
            tCopy,
            tPaste,
            tDelete,
            toolStripSeparator1,
            tUndo,
            tRedo});
            //this.Location = new System.Drawing.Point(3, 24);
            Name = "ToolBarEdit";
            AutoSize = true;
            ItemClicked += EditToolBar_ItemClicked;
            //this.Size = new System.Drawing.Size(168, 25);
            //this.TabIndex = 1;
            ResumeLayout(true);
        }


        #endregion

        #region Events
        public override void RefreshToolBar()
        {
            tCut.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            tCopy.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            tPaste.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            tDelete.Enabled = (Global.MainForm.DockPane.ActiveContent is DocumentBase);
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                tUndo.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveContent).CanUndo;
                tRedo.Enabled = ((DocumentBase)Global.MainForm.DockPane.ActiveContent).CanRedo;
            }
        }
        void EditToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tUndo) Global.MainForm.CurrentDocumentUndo();
            else if (e.ClickedItem == tRedo) Global.MainForm.CurrentDocumentRedo();
            else if (e.ClickedItem == tCut) Global.MainForm.CurrentDocumentCut();
            else if (e.ClickedItem == tCopy) Global.MainForm.CurrentDocumentCopy();
            else if (e.ClickedItem == tPaste) Global.MainForm.CurrentDocumentPaste();
            else if (e.ClickedItem == tDelete) Global.MainForm.CurrentDocumentDelete();
        }
        #endregion

        #region Constructors
        public EditToolBar()
        {
            Location = new Point(3, 24);
            Global.MainForm.ToolBarContainer.TopToolStripPanel.Controls.Add(this);
            TabIndex = 1;
            InitializeComponent();
        }
        #endregion
    }
}

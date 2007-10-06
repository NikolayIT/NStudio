namespace NStudio
{
    partial class RTE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTE));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbrBold = new System.Windows.Forms.ToolStripButton();
            this.tbrItalic = new System.Windows.Forms.ToolStripButton();
            this.tbrUnderline = new System.Windows.Forms.ToolStripButton();
            this.tbrStrikeout = new System.Windows.Forms.ToolStripButton();
            this.tbrNormal = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrFont = new System.Windows.Forms.ToolStripButton();
            this.tbrColor = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrLeft = new System.Windows.Forms.ToolStripButton();
            this.tbrCenter = new System.Windows.Forms.ToolStripButton();
            this.tbrRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrInsertImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.IndentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent10 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent15 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent20 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent25 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent40 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.AddBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.PageColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textedit = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbrBold,
            this.tbrItalic,
            this.tbrUnderline,
            this.tbrStrikeout,
            this.tbrNormal,
            this.ToolStripSeparator4,
            this.tbrFont,
            this.tbrColor,
            this.ToolStripSeparator2,
            this.tbrLeft,
            this.tbrCenter,
            this.tbrRight,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.tbrInsertImage,
            this.toolStripSeparator1,
            this.toolStripDropDownButton2});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(414, 25);
            this.ToolStrip1.TabIndex = 0;
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // tbrBold
            // 
            this.tbrBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrBold.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tbrBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrBold.Name = "tbrBold";
            this.tbrBold.Size = new System.Drawing.Size(23, 22);
            this.tbrBold.Text = "B";
            this.tbrBold.ToolTipText = "Bold";
            // 
            // tbrItalic
            // 
            this.tbrItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrItalic.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbrItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrItalic.Name = "tbrItalic";
            this.tbrItalic.Size = new System.Drawing.Size(23, 22);
            this.tbrItalic.Text = "I";
            this.tbrItalic.ToolTipText = "Italic";
            // 
            // tbrUnderline
            // 
            this.tbrUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrUnderline.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tbrUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrUnderline.Name = "tbrUnderline";
            this.tbrUnderline.Size = new System.Drawing.Size(23, 22);
            this.tbrUnderline.Text = "U";
            this.tbrUnderline.ToolTipText = "Underline";
            // 
            // tbrStrikeout
            // 
            this.tbrStrikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrStrikeout.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.tbrStrikeout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrStrikeout.Name = "tbrStrikeout";
            this.tbrStrikeout.Size = new System.Drawing.Size(23, 22);
            this.tbrStrikeout.Text = "S";
            this.tbrStrikeout.ToolTipText = "Strikeout";
            // 
            // tbrNormal
            // 
            this.tbrNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrNormal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbrNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrNormal.Name = "tbrNormal";
            this.tbrNormal.Size = new System.Drawing.Size(23, 22);
            this.tbrNormal.Text = "N";
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrFont
            // 
            this.tbrFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrFont.Image = ((System.Drawing.Image)(resources.GetObject("tbrFont.Image")));
            this.tbrFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrFont.Name = "tbrFont";
            this.tbrFont.Size = new System.Drawing.Size(23, 22);
            this.tbrFont.Text = "Font";
            // 
            // tbrColor
            // 
            this.tbrColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrColor.Image = ((System.Drawing.Image)(resources.GetObject("tbrColor.Image")));
            this.tbrColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrColor.Name = "tbrColor";
            this.tbrColor.Size = new System.Drawing.Size(23, 22);
            this.tbrColor.Text = "toolStripButton1";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrLeft
            // 
            this.tbrLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrLeft.Image = ((System.Drawing.Image)(resources.GetObject("tbrLeft.Image")));
            this.tbrLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrLeft.Name = "tbrLeft";
            this.tbrLeft.Size = new System.Drawing.Size(23, 22);
            this.tbrLeft.Text = "Left";
            // 
            // tbrCenter
            // 
            this.tbrCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrCenter.Image = ((System.Drawing.Image)(resources.GetObject("tbrCenter.Image")));
            this.tbrCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrCenter.Name = "tbrCenter";
            this.tbrCenter.Size = new System.Drawing.Size(23, 22);
            this.tbrCenter.Text = "Center";
            // 
            // tbrRight
            // 
            this.tbrRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrRight.Image = ((System.Drawing.Image)(resources.GetObject("tbrRight.Image")));
            this.tbrRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrRight.Name = "tbrRight";
            this.tbrRight.Size = new System.Drawing.Size(23, 22);
            this.tbrRight.Text = "Right";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "v0.21";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrInsertImage
            // 
            this.tbrInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrInsertImage.Image = ((System.Drawing.Image)(resources.GetObject("tbrInsertImage.Image")));
            this.tbrInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrInsertImage.Name = "tbrInsertImage";
            this.tbrInsertImage.Size = new System.Drawing.Size(23, 22);
            this.tbrInsertImage.Text = "Insert image";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IndentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.AddBulletsToolStripMenuItem,
            this.RemoveBulletsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.PageColorToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "Tools";
            // 
            // IndentToolStripMenuItem
            // 
            this.IndentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIndent0,
            this.mnuIndent5,
            this.mnuIndent10,
            this.mnuIndent15,
            this.mnuIndent20,
            this.mnuIndent25,
            this.mnuIndent30,
            this.mnuIndent40,
            this.mnuIndent50});
            this.IndentToolStripMenuItem.Name = "IndentToolStripMenuItem";
            this.IndentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.IndentToolStripMenuItem.Text = "&Indent";
            this.IndentToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.IndentToolStripMenuItem_DropDownItemClicked);
            // 
            // mnuIndent0
            // 
            this.mnuIndent0.Name = "mnuIndent0";
            this.mnuIndent0.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent0.Text = "None";
            // 
            // mnuIndent5
            // 
            this.mnuIndent5.Name = "mnuIndent5";
            this.mnuIndent5.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent5.Text = "5 pts";
            // 
            // mnuIndent10
            // 
            this.mnuIndent10.Name = "mnuIndent10";
            this.mnuIndent10.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent10.Text = "10 pts";
            // 
            // mnuIndent15
            // 
            this.mnuIndent15.Name = "mnuIndent15";
            this.mnuIndent15.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent15.Text = "15 pts";
            // 
            // mnuIndent20
            // 
            this.mnuIndent20.Name = "mnuIndent20";
            this.mnuIndent20.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent20.Text = "20 pts";
            // 
            // mnuIndent25
            // 
            this.mnuIndent25.Name = "mnuIndent25";
            this.mnuIndent25.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent25.Text = "25 pts";
            // 
            // mnuIndent30
            // 
            this.mnuIndent30.Name = "mnuIndent30";
            this.mnuIndent30.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent30.Text = "30 pts";
            // 
            // mnuIndent40
            // 
            this.mnuIndent40.Name = "mnuIndent40";
            this.mnuIndent40.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent40.Text = "40 pts";
            // 
            // mnuIndent50
            // 
            this.mnuIndent50.Name = "mnuIndent50";
            this.mnuIndent50.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent50.Text = "50 pts";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // AddBulletsToolStripMenuItem
            // 
            this.AddBulletsToolStripMenuItem.Name = "AddBulletsToolStripMenuItem";
            this.AddBulletsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AddBulletsToolStripMenuItem.Text = "A&dd Bullets";
            this.AddBulletsToolStripMenuItem.Click += new System.EventHandler(this.AddBulletsToolStripMenuItem_Click);
            // 
            // RemoveBulletsToolStripMenuItem
            // 
            this.RemoveBulletsToolStripMenuItem.Name = "RemoveBulletsToolStripMenuItem";
            this.RemoveBulletsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.RemoveBulletsToolStripMenuItem.Text = "&Remove Bullets";
            this.RemoveBulletsToolStripMenuItem.Click += new System.EventHandler(this.RemoveBulletsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // PageColorToolStripMenuItem
            // 
            this.PageColorToolStripMenuItem.Name = "PageColorToolStripMenuItem";
            this.PageColorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.PageColorToolStripMenuItem.Text = "&Page Color...";
            this.PageColorToolStripMenuItem.Click += new System.EventHandler(this.PageColorToolStripMenuItem_Click);
            // 
            // textedit
            // 
            this.textedit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textedit.Location = new System.Drawing.Point(0, 25);
            this.textedit.Name = "textedit";
            this.textedit.Size = new System.Drawing.Size(414, 265);
            this.textedit.TabIndex = 1;
            this.textedit.Text = "";
            this.textedit.SelectionChanged += new System.EventHandler(this.textedit_SelectionChanged);
            this.textedit.TextChanged += new System.EventHandler(this.textedit_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*|Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|PNG Files|*.png" +
                "";
            this.openFileDialog1.Title = "Insert Image File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // RTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 290);
            this.Controls.Add(this.textedit);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "RTE";
            this.TabText = "Untitled";
            this.Text = "Untitled";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tbrFont;
        private System.Windows.Forms.ToolStripButton tbrColor;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton tbrLeft;
        internal System.Windows.Forms.ToolStripButton tbrCenter;
        internal System.Windows.Forms.ToolStripButton tbrRight;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton tbrBold;
        internal System.Windows.Forms.ToolStripButton tbrItalic;
        internal System.Windows.Forms.ToolStripButton tbrUnderline;
        private System.Windows.Forms.RichTextBox textedit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        internal System.Windows.Forms.ToolStripMenuItem IndentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuIndent0;
        internal System.Windows.Forms.ToolStripMenuItem mnuIndent5;
        internal System.Windows.Forms.ToolStripMenuItem mnuIndent10;
        internal System.Windows.Forms.ToolStripMenuItem mnuIndent15;
        internal System.Windows.Forms.ToolStripMenuItem mnuIndent20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbrInsertImage;
        private System.Windows.Forms.ToolStripButton tbrStrikeout;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuIndent25;
        private System.Windows.Forms.ToolStripMenuItem mnuIndent30;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem AddBulletsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RemoveBulletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem PageColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbrNormal;
        private System.Windows.Forms.ToolStripMenuItem mnuIndent40;
        private System.Windows.Forms.ToolStripMenuItem mnuIndent50;

    }
}
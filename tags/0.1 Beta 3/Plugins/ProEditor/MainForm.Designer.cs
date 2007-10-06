namespace ProEditor
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCharacters = new System.Windows.Forms.ToolStripMenuItem();
            this.convertQuotesToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertQuotesToToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeQuotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.convertToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.convertToToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.uPPERCASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowerCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.properCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNVERTCASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuick = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViz = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCharacters,
            this.mnuQuick,
            this.mnuEdit,
            this.mnuConvert,
            this.mnuInsert,
            this.mnuTools,
            this.mnuViz});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCharacters
            // 
            this.mnuCharacters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertQuotesToToolStripMenuItem,
            this.convertQuotesToToolStripMenuItem1,
            this.removeQuotesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.convertToToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.convertToToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.convertToToolStripMenuItem2,
            this.convertToToolStripMenuItem3,
            this.convertToToolStripMenuItem4,
            this.toolStripMenuItem3,
            this.uPPERCASEToolStripMenuItem,
            this.lowerCaseToolStripMenuItem,
            this.properCaseToolStripMenuItem,
            this.iNVERTCASEToolStripMenuItem});
            this.mnuCharacters.Name = "mnuCharacters";
            this.mnuCharacters.Size = new System.Drawing.Size(72, 20);
            this.mnuCharacters.Text = "Characters";
            // 
            // convertQuotesToToolStripMenuItem
            // 
            this.convertQuotesToToolStripMenuItem.Name = "convertQuotesToToolStripMenuItem";
            this.convertQuotesToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertQuotesToToolStripMenuItem.Text = "Convert quotes to \"";
            this.convertQuotesToToolStripMenuItem.Click += new System.EventHandler(this.convertQuotesToToolStripMenuItem_Click);
            // 
            // convertQuotesToToolStripMenuItem1
            // 
            this.convertQuotesToToolStripMenuItem1.Name = "convertQuotesToToolStripMenuItem1";
            this.convertQuotesToToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.convertQuotesToToolStripMenuItem1.Text = "Convert quotes to \'";
            this.convertQuotesToToolStripMenuItem1.Click += new System.EventHandler(this.convertQuotesToToolStripMenuItem1_Click);
            // 
            // removeQuotesToolStripMenuItem
            // 
            this.removeQuotesToolStripMenuItem.Name = "removeQuotesToolStripMenuItem";
            this.removeQuotesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeQuotesToolStripMenuItem.Text = "Remove quotes";
            this.removeQuotesToolStripMenuItem.Click += new System.EventHandler(this.removeQuotesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // convertToToolStripMenuItem
            // 
            this.convertToToolStripMenuItem.Name = "convertToToolStripMenuItem";
            this.convertToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertToToolStripMenuItem.Text = "Convert \" to \\\"";
            this.convertToToolStripMenuItem.Click += new System.EventHandler(this.convertToToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertToolStripMenuItem.Text = "Convert \' to \\\'";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // convertToToolStripMenuItem1
            // 
            this.convertToToolStripMenuItem1.Name = "convertToToolStripMenuItem1";
            this.convertToToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.convertToToolStripMenuItem1.Text = "Convert \' to \\\"";
            this.convertToToolStripMenuItem1.Click += new System.EventHandler(this.convertToToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // convertToToolStripMenuItem2
            // 
            this.convertToToolStripMenuItem2.Name = "convertToToolStripMenuItem2";
            this.convertToToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.convertToToolStripMenuItem2.Text = "Convert \\\" to \"";
            this.convertToToolStripMenuItem2.Click += new System.EventHandler(this.convertToToolStripMenuItem2_Click);
            // 
            // convertToToolStripMenuItem3
            // 
            this.convertToToolStripMenuItem3.Name = "convertToToolStripMenuItem3";
            this.convertToToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.convertToToolStripMenuItem3.Text = "Convert \\\' to \'";
            this.convertToToolStripMenuItem3.Click += new System.EventHandler(this.convertToToolStripMenuItem3_Click);
            // 
            // convertToToolStripMenuItem4
            // 
            this.convertToToolStripMenuItem4.Name = "convertToToolStripMenuItem4";
            this.convertToToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.convertToToolStripMenuItem4.Text = "Convert \\\" to \'";
            this.convertToToolStripMenuItem4.Click += new System.EventHandler(this.convertToToolStripMenuItem4_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // uPPERCASEToolStripMenuItem
            // 
            this.uPPERCASEToolStripMenuItem.Name = "uPPERCASEToolStripMenuItem";
            this.uPPERCASEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uPPERCASEToolStripMenuItem.Text = "UPPER CASE";
            this.uPPERCASEToolStripMenuItem.Click += new System.EventHandler(this.uPPERCASEToolStripMenuItem_Click);
            // 
            // lowerCaseToolStripMenuItem
            // 
            this.lowerCaseToolStripMenuItem.Name = "lowerCaseToolStripMenuItem";
            this.lowerCaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lowerCaseToolStripMenuItem.Text = "lower case";
            this.lowerCaseToolStripMenuItem.Click += new System.EventHandler(this.lowerCaseToolStripMenuItem_Click);
            // 
            // properCaseToolStripMenuItem
            // 
            this.properCaseToolStripMenuItem.Name = "properCaseToolStripMenuItem";
            this.properCaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.properCaseToolStripMenuItem.Text = "Proper Case";
            this.properCaseToolStripMenuItem.Click += new System.EventHandler(this.properCaseToolStripMenuItem_Click);
            // 
            // iNVERTCASEToolStripMenuItem
            // 
            this.iNVERTCASEToolStripMenuItem.Name = "iNVERTCASEToolStripMenuItem";
            this.iNVERTCASEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iNVERTCASEToolStripMenuItem.Text = "iNVERT cASE";
            this.iNVERTCASEToolStripMenuItem.Click += new System.EventHandler(this.iNVERTCASEToolStripMenuItem_Click);
            // 
            // mnuQuick
            // 
            this.mnuQuick.Name = "mnuQuick";
            this.mnuQuick.Size = new System.Drawing.Size(45, 20);
            this.mnuQuick.Text = "Quick";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(37, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuConvert
            // 
            this.mnuConvert.Name = "mnuConvert";
            this.mnuConvert.Size = new System.Drawing.Size(58, 20);
            this.mnuConvert.Text = "Convert";
            // 
            // mnuInsert
            // 
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(48, 20);
            this.mnuInsert.Text = "Insert";
            // 
            // mnuTools
            // 
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuViz
            // 
            this.mnuViz.Name = "mnuViz";
            this.mnuViz.Size = new System.Drawing.Size(32, 20);
            this.mnuViz.Text = "Viz";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 101);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.TabText = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem convertQuotesToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertQuotesToToolStripMenuItem1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem mnuCharacters;
        public System.Windows.Forms.ToolStripMenuItem mnuQuick;
        public System.Windows.Forms.ToolStripMenuItem mnuEdit;
        public System.Windows.Forms.ToolStripMenuItem mnuConvert;
        public System.Windows.Forms.ToolStripMenuItem mnuInsert;
        public System.Windows.Forms.ToolStripMenuItem mnuTools;
        public System.Windows.Forms.ToolStripMenuItem mnuViz;
        private System.Windows.Forms.ToolStripMenuItem removeQuotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem uPPERCASEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowerCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem properCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNVERTCASEToolStripMenuItem;

    }
}
namespace NStudio
{
    partial class Browser
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Back = new System.Windows.Forms.ToolStripButton();
            this.Forward = new System.Windows.Forms.ToolStripButton();
            this.Refr = new System.Windows.Forms.ToolStripButton();
            this.Stop = new System.Windows.Forms.ToolStripButton();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Search = new System.Windows.Forms.ToolStripButton();
            this.Address = new System.Windows.Forms.ToolStripTextBox();
            this.Go = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Back,
            this.Forward,
            this.Refr,
            this.Stop,
            this.Home,
            this.Search,
            this.Address,
            this.Go});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(342, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Back
            // 
            this.Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(23, 22);
            this.Back.Text = "Back";
            this.Back.ToolTipText = "Back";
            // 
            // Forward
            // 
            this.Forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(23, 22);
            this.Forward.Text = "Forward";
            // 
            // Refr
            // 
            this.Refr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refr.Name = "Refr";
            this.Refr.Size = new System.Drawing.Size(23, 22);
            this.Refr.Text = "Refresh";
            this.Refr.ToolTipText = "Refresh";
            // 
            // Stop
            // 
            this.Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(23, 22);
            this.Stop.Text = "Stop";
            // 
            // Home
            // 
            this.Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(23, 22);
            this.Home.Text = "Home";
            // 
            // Search
            // 
            this.Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(23, 22);
            this.Search.Text = "Search";
            // 
            // Address
            // 
            this.Address.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Address.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(100, 25);
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address_KeyDown);
            // 
            // Go
            // 
            this.Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(23, 22);
            this.Go.Text = "Go";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(342, 275);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 300);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Browser";
            this.TabText = "Browser";
            this.Text = "Browser";
            this.Resize += new System.EventHandler(this.Browser_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Back;
        private System.Windows.Forms.ToolStripButton Forward;
        private System.Windows.Forms.ToolStripButton Refr;
        private System.Windows.Forms.ToolStripTextBox Address;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton Search;
        private System.Windows.Forms.ToolStripButton Go;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripButton Stop;
    }
}
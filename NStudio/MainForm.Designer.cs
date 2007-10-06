using WeifenLuo.WinFormsUI.Docking;

namespace NStudio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.DockConatiner = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadPluginDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.DockConatiner);
            this.toolStripContainer1.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(579, 365);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(579, 390);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // DockConatiner
            // 
            this.DockConatiner.ActiveAutoHideContent = null;
            this.DockConatiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockConatiner.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.DockConatiner.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.DockConatiner.Location = new System.Drawing.Point(0, 0);
            this.DockConatiner.Name = "DockConatiner";
            this.DockConatiner.Size = new System.Drawing.Size(579, 365);
            this.DockConatiner.TabIndex = 0;
            this.DockConatiner.ActiveContentChanged += new System.EventHandler(this.DockConatiner_ActiveContentChanged);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Text files|*.txt|HTML Files|*.html;*.htm|Documents|*.rtf|All files|*.*";
            this.OpenFileDialog.FilterIndex = 4;
            this.OpenFileDialog.Title = "Open File";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // LoadPluginDialog
            // 
            this.LoadPluginDialog.Filter = "Plugins|*.dll|Executable files|*.exe|All Files|*.*";
            this.LoadPluginDialog.Title = "Load plugin...";
            this.LoadPluginDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadPluginDialog_FileOk);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "All Files|*.*";
            this.SaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Tag = "NStudio";
            this.TrayIcon.Text = "NStudio";
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 390);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NStudio";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.OpenFileDialog LoadPluginDialog;
        public DockPanel DockConatiner;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}


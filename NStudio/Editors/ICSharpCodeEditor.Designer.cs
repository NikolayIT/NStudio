namespace NStudio
{
    partial class ICSharpCodeEditor
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
            this.textedit = new ICSharpCode.TextEditor.TextEditorControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vBNETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSPNETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coCoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textedit
            // 
            this.textedit.ContextMenuStrip = this.contextMenuStrip1;
            this.textedit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textedit.Location = new System.Drawing.Point(0, 0);
            this.textedit.Name = "textedit";
            this.textedit.ShowEOLMarkers = true;
            this.textedit.ShowSpaces = true;
            this.textedit.ShowTabs = true;
            this.textedit.ShowVRuler = true;
            this.textedit.Size = new System.Drawing.Size(450, 344);
            this.textedit.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.languageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 148);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.cToolStripMenuItem1,
            this.vBNETToolStripMenuItem,
            this.aSPNETToolStripMenuItem,
            this.hTMLToolStripMenuItem,
            this.pHPToolStripMenuItem,
            this.javaToolStripMenuItem,
            this.bATToolStripMenuItem,
            this.booToolStripMenuItem,
            this.coCoToolStripMenuItem,
            this.javaScriptToolStripMenuItem,
            this.patchToolStripMenuItem,
            this.teXToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.languageToolStripMenuItem.Text = "Language";
            this.languageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.languageToolStripMenuItem_DropDownItemClicked);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cToolStripMenuItem.Text = "C++";
            // 
            // cToolStripMenuItem1
            // 
            this.cToolStripMenuItem1.Name = "cToolStripMenuItem1";
            this.cToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.cToolStripMenuItem1.Text = "C#";
            // 
            // vBNETToolStripMenuItem
            // 
            this.vBNETToolStripMenuItem.Name = "vBNETToolStripMenuItem";
            this.vBNETToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.vBNETToolStripMenuItem.Text = "VB.NET";
            // 
            // aSPNETToolStripMenuItem
            // 
            this.aSPNETToolStripMenuItem.Name = "aSPNETToolStripMenuItem";
            this.aSPNETToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aSPNETToolStripMenuItem.Text = "ASP.NET";
            // 
            // hTMLToolStripMenuItem
            // 
            this.hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            this.hTMLToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.hTMLToolStripMenuItem.Text = "HTML";
            // 
            // pHPToolStripMenuItem
            // 
            this.pHPToolStripMenuItem.Name = "pHPToolStripMenuItem";
            this.pHPToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.pHPToolStripMenuItem.Text = "PHP";
            // 
            // javaToolStripMenuItem
            // 
            this.javaToolStripMenuItem.Name = "javaToolStripMenuItem";
            this.javaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.javaToolStripMenuItem.Text = "Java";
            // 
            // bATToolStripMenuItem
            // 
            this.bATToolStripMenuItem.Name = "bATToolStripMenuItem";
            this.bATToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.bATToolStripMenuItem.Text = "BAT";
            // 
            // booToolStripMenuItem
            // 
            this.booToolStripMenuItem.Name = "booToolStripMenuItem";
            this.booToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.booToolStripMenuItem.Text = "Boo";
            // 
            // coCoToolStripMenuItem
            // 
            this.coCoToolStripMenuItem.Name = "coCoToolStripMenuItem";
            this.coCoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.coCoToolStripMenuItem.Text = "Coco";
            // 
            // javaScriptToolStripMenuItem
            // 
            this.javaScriptToolStripMenuItem.Name = "javaScriptToolStripMenuItem";
            this.javaScriptToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.javaScriptToolStripMenuItem.Text = "Java Script";
            // 
            // patchToolStripMenuItem
            // 
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.patchToolStripMenuItem.Text = "Patch";
            // 
            // teXToolStripMenuItem
            // 
            this.teXToolStripMenuItem.Name = "teXToolStripMenuItem";
            this.teXToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.teXToolStripMenuItem.Text = "TeX";
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            // 
            // ICSharpCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 344);
            this.Controls.Add(this.textedit);
            this.Name = "ICSharpCodeEditor";
            this.TabText = "Untitled";
            this.Text = "Untitled";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textedit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vBNETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSPNETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pHPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem javaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coCoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem javaScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}
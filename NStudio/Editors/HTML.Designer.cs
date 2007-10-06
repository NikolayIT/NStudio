namespace NStudio
{
    partial class HTML
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
            this.editor = new HTMLEditor.HtmlControl();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AbsolutePositioningEnabled = false;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsDesignMode = true;
            this.editor.IsDirty = false;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.MultipleSelectionEnabled = false;
            this.editor.Name = "editor";
            this.editor.ScriptEnabled = false;
            this.editor.ScriptObject = null;
            this.editor.Size = new System.Drawing.Size(372, 376);
            this.editor.TabIndex = 0;
            // 
            // HTML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 376);
            this.Controls.Add(this.editor);
            this.Name = "HTML";
            this.TabText = "Untitled";
            this.Text = "Untitled";
            this.ResumeLayout(false);

        }

        #endregion

        private HTMLEditor.HtmlControl editor;

    }
}
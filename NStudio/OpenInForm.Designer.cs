namespace NStudio
{
    partial class OpenInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenInForm));
            this.Scintilla = new System.Windows.Forms.Button();
            this.ICSharpCode = new System.Windows.Forms.Button();
            this.RTE = new System.Windows.Forms.Button();
            this.HTML = new System.Windows.Forms.Button();
            this.Standart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Scintilla
            // 
            resources.ApplyResources(this.Scintilla, "Scintilla");
            this.Scintilla.Name = "Scintilla";
            this.Scintilla.UseVisualStyleBackColor = true;
            this.Scintilla.Click += new System.EventHandler(this.Scintilla_Click);
            // 
            // ICSharpCode
            // 
            resources.ApplyResources(this.ICSharpCode, "ICSharpCode");
            this.ICSharpCode.Name = "ICSharpCode";
            this.ICSharpCode.UseVisualStyleBackColor = true;
            this.ICSharpCode.Click += new System.EventHandler(this.ICSharpCode_Click);
            // 
            // RTE
            // 
            resources.ApplyResources(this.RTE, "RTE");
            this.RTE.Name = "RTE";
            this.RTE.UseVisualStyleBackColor = true;
            this.RTE.Click += new System.EventHandler(this.RTE_Click);
            // 
            // HTML
            // 
            resources.ApplyResources(this.HTML, "HTML");
            this.HTML.Name = "HTML";
            this.HTML.UseVisualStyleBackColor = true;
            this.HTML.Click += new System.EventHandler(this.HTML_Click);
            // 
            // Standart
            // 
            resources.ApplyResources(this.Standart, "Standart");
            this.Standart.Name = "Standart";
            this.Standart.UseVisualStyleBackColor = true;
            this.Standart.Click += new System.EventHandler(this.Standart_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // OpenInForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Standart);
            this.Controls.Add(this.HTML);
            this.Controls.Add(this.RTE);
            this.Controls.Add(this.ICSharpCode);
            this.Controls.Add(this.Scintilla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenInForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scintilla;
        private System.Windows.Forms.Button ICSharpCode;
        private System.Windows.Forms.Button RTE;
        private System.Windows.Forms.Button HTML;
        private System.Windows.Forms.Button Standart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
namespace NStudio
{
    partial class ConZole
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
            this.commandPrompt1 = new NStudio.CommandPrompt();
            this.SuspendLayout();
            // 
            // commandPrompt1
            // 
            this.commandPrompt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandPrompt1.Location = new System.Drawing.Point(0, 0);
            this.commandPrompt1.Name = "commandPrompt1";
            this.commandPrompt1.Size = new System.Drawing.Size(483, 266);
            this.commandPrompt1.TabIndex = 0;
            this.commandPrompt1.Command += new NStudio.CommandEventHandler(this.commandPrompt1_Command);
            // 
            // ConZole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 266);
            this.Controls.Add(this.commandPrompt1);
            this.Name = "ConZole";
            this.TabText = "ConZole";
            this.Text = "ConZole";
            this.ResumeLayout(false);

        }
        #endregion

        private CommandPrompt commandPrompt1;
    }
}
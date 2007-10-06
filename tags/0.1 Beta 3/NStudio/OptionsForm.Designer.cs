namespace NStudio
{
    partial class OptionsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.chkDragAndDrop = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkShowOthersToolBar = new System.Windows.Forms.CheckBox();
            this.chkShowViewToolBar = new System.Windows.Forms.CheckBox();
            this.chkShowFileToolBar = new System.Windows.Forms.CheckBox();
            this.chkShowEditToolBar = new System.Windows.Forms.CheckBox();
            this.chkShowStatusBar = new System.Windows.Forms.CheckBox();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.chkBrowserShortcuts = new System.Windows.Forms.CheckBox();
            this.chkBrowserContextMenu = new System.Windows.Forms.CheckBox();
            this.chkBrowserScrollbar = new System.Windows.Forms.CheckBox();
            this.chkBrowserScriptErrors = new System.Windows.Forms.CheckBox();
            this.chkBrowserDrop = new System.Windows.Forms.CheckBox();
            this.tabEditors = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.ICSharpCodeEditor = new System.Windows.Forms.TabPage();
            this.ScintillaEditor = new System.Windows.Forms.TabPage();
            this.RTEditor = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tabBrowser.SuspendLayout();
            this.tabEditors.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirm, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 265);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(165, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(156, 27);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabEditors);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 265);
            this.tabControl1.TabIndex = 2;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tabControl3);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(316, 239);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabDisplay);
            this.tabControl3.Controls.Add(this.tabBrowser);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(310, 233);
            this.tabControl3.TabIndex = 0;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.chkDragAndDrop);
            this.tabDisplay.Controls.Add(this.label1);
            this.tabDisplay.Controls.Add(this.comboBox1);
            this.tabDisplay.Controls.Add(this.chkShowOthersToolBar);
            this.tabDisplay.Controls.Add(this.chkShowViewToolBar);
            this.tabDisplay.Controls.Add(this.chkShowFileToolBar);
            this.tabDisplay.Controls.Add(this.chkShowEditToolBar);
            this.tabDisplay.Controls.Add(this.chkShowStatusBar);
            this.tabDisplay.Controls.Add(this.chkMinimizeToTray);
            this.tabDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(302, 207);
            this.tabDisplay.TabIndex = 0;
            this.tabDisplay.Text = "Display";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // chkDragAndDrop
            // 
            this.chkDragAndDrop.AutoSize = true;
            this.chkDragAndDrop.Location = new System.Drawing.Point(6, 125);
            this.chkDragAndDrop.Name = "chkDragAndDrop";
            this.chkDragAndDrop.Size = new System.Drawing.Size(132, 17);
            this.chkDragAndDrop.TabIndex = 8;
            this.chkDragAndDrop.Text = "Enable Drag and Drop";
            this.chkDragAndDrop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Visual style:";
            this.label1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Client And Non Client Areas Enabled",
            "Client Area Enabled",
            "Non Client Area Enabled",
            "None Enabled"});
            this.comboBox1.Location = new System.Drawing.Point(74, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // chkShowOthersToolBar
            // 
            this.chkShowOthersToolBar.AutoSize = true;
            this.chkShowOthersToolBar.Location = new System.Drawing.Point(157, 75);
            this.chkShowOthersToolBar.Name = "chkShowOthersToolBar";
            this.chkShowOthersToolBar.Size = new System.Drawing.Size(127, 17);
            this.chkShowOthersToolBar.TabIndex = 5;
            this.chkShowOthersToolBar.Text = "Show Others ToolBar";
            this.chkShowOthersToolBar.UseVisualStyleBackColor = true;
            // 
            // chkShowViewToolBar
            // 
            this.chkShowViewToolBar.AutoSize = true;
            this.chkShowViewToolBar.Location = new System.Drawing.Point(6, 75);
            this.chkShowViewToolBar.Name = "chkShowViewToolBar";
            this.chkShowViewToolBar.Size = new System.Drawing.Size(119, 17);
            this.chkShowViewToolBar.TabIndex = 4;
            this.chkShowViewToolBar.Text = "Show View ToolBar";
            this.chkShowViewToolBar.UseVisualStyleBackColor = true;
            // 
            // chkShowFileToolBar
            // 
            this.chkShowFileToolBar.AutoSize = true;
            this.chkShowFileToolBar.Location = new System.Drawing.Point(6, 52);
            this.chkShowFileToolBar.Name = "chkShowFileToolBar";
            this.chkShowFileToolBar.Size = new System.Drawing.Size(112, 17);
            this.chkShowFileToolBar.TabIndex = 3;
            this.chkShowFileToolBar.Text = "Show File ToolBar";
            this.chkShowFileToolBar.UseVisualStyleBackColor = true;
            // 
            // chkShowEditToolBar
            // 
            this.chkShowEditToolBar.AutoSize = true;
            this.chkShowEditToolBar.Location = new System.Drawing.Point(157, 52);
            this.chkShowEditToolBar.Name = "chkShowEditToolBar";
            this.chkShowEditToolBar.Size = new System.Drawing.Size(114, 17);
            this.chkShowEditToolBar.TabIndex = 2;
            this.chkShowEditToolBar.Text = "Show Edit ToolBar";
            this.chkShowEditToolBar.UseVisualStyleBackColor = true;
            // 
            // chkShowStatusBar
            // 
            this.chkShowStatusBar.AutoSize = true;
            this.chkShowStatusBar.Location = new System.Drawing.Point(6, 29);
            this.chkShowStatusBar.Name = "chkShowStatusBar";
            this.chkShowStatusBar.Size = new System.Drawing.Size(102, 17);
            this.chkShowStatusBar.TabIndex = 1;
            this.chkShowStatusBar.Text = "Show StatusBar";
            this.chkShowStatusBar.UseVisualStyleBackColor = true;
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(6, 6);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(202, 17);
            this.chkMinimizeToTray.TabIndex = 0;
            this.chkMinimizeToTray.Text = "Place program in tray when minimized";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.chkBrowserShortcuts);
            this.tabBrowser.Controls.Add(this.chkBrowserContextMenu);
            this.tabBrowser.Controls.Add(this.chkBrowserScrollbar);
            this.tabBrowser.Controls.Add(this.chkBrowserScriptErrors);
            this.tabBrowser.Controls.Add(this.chkBrowserDrop);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(302, 207);
            this.tabBrowser.TabIndex = 2;
            this.tabBrowser.Text = "Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // chkBrowserShortcuts
            // 
            this.chkBrowserShortcuts.AutoSize = true;
            this.chkBrowserShortcuts.Checked = true;
            this.chkBrowserShortcuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrowserShortcuts.Location = new System.Drawing.Point(6, 98);
            this.chkBrowserShortcuts.Name = "chkBrowserShortcuts";
            this.chkBrowserShortcuts.Size = new System.Drawing.Size(169, 17);
            this.chkBrowserShortcuts.TabIndex = 5;
            this.chkBrowserShortcuts.Text = "Enable WebBrowser shortcuts";
            this.chkBrowserShortcuts.UseVisualStyleBackColor = true;
            // 
            // chkBrowserContextMenu
            // 
            this.chkBrowserContextMenu.AutoSize = true;
            this.chkBrowserContextMenu.Checked = true;
            this.chkBrowserContextMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrowserContextMenu.Location = new System.Drawing.Point(6, 29);
            this.chkBrowserContextMenu.Name = "chkBrowserContextMenu";
            this.chkBrowserContextMenu.Size = new System.Drawing.Size(190, 17);
            this.chkBrowserContextMenu.TabIndex = 4;
            this.chkBrowserContextMenu.Text = "Enable WebBrowser context menu";
            this.chkBrowserContextMenu.UseVisualStyleBackColor = true;
            // 
            // chkBrowserScrollbar
            // 
            this.chkBrowserScrollbar.AutoSize = true;
            this.chkBrowserScrollbar.Checked = true;
            this.chkBrowserScrollbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrowserScrollbar.Location = new System.Drawing.Point(6, 75);
            this.chkBrowserScrollbar.Name = "chkBrowserScrollbar";
            this.chkBrowserScrollbar.Size = new System.Drawing.Size(101, 17);
            this.chkBrowserScrollbar.TabIndex = 3;
            this.chkBrowserScrollbar.Text = "Enable scrollbar";
            this.chkBrowserScrollbar.UseVisualStyleBackColor = true;
            // 
            // chkBrowserScriptErrors
            // 
            this.chkBrowserScriptErrors.AutoSize = true;
            this.chkBrowserScriptErrors.Location = new System.Drawing.Point(6, 52);
            this.chkBrowserScriptErrors.Name = "chkBrowserScriptErrors";
            this.chkBrowserScriptErrors.Size = new System.Drawing.Size(110, 17);
            this.chkBrowserScriptErrors.TabIndex = 1;
            this.chkBrowserScriptErrors.Text = "Show script errors";
            this.chkBrowserScriptErrors.UseVisualStyleBackColor = true;
            // 
            // chkBrowserDrop
            // 
            this.chkBrowserDrop.AutoSize = true;
            this.chkBrowserDrop.Checked = true;
            this.chkBrowserDrop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrowserDrop.Location = new System.Drawing.Point(6, 6);
            this.chkBrowserDrop.Name = "chkBrowserDrop";
            this.chkBrowserDrop.Size = new System.Drawing.Size(139, 17);
            this.chkBrowserDrop.TabIndex = 0;
            this.chkBrowserDrop.Tag = "";
            this.chkBrowserDrop.Text = "Allow WebBrowser drop";
            this.chkBrowserDrop.UseVisualStyleBackColor = true;
            // 
            // tabEditors
            // 
            this.tabEditors.Controls.Add(this.tabControl2);
            this.tabEditors.Location = new System.Drawing.Point(4, 22);
            this.tabEditors.Name = "tabEditors";
            this.tabEditors.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditors.Size = new System.Drawing.Size(316, 239);
            this.tabEditors.TabIndex = 1;
            this.tabEditors.Text = "Text Editors";
            this.tabEditors.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.ICSharpCodeEditor);
            this.tabControl2.Controls.Add(this.ScintillaEditor);
            this.tabControl2.Controls.Add(this.RTEditor);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(310, 233);
            this.tabControl2.TabIndex = 0;
            // 
            // ICSharpCodeEditor
            // 
            this.ICSharpCodeEditor.Location = new System.Drawing.Point(4, 22);
            this.ICSharpCodeEditor.Name = "ICSharpCodeEditor";
            this.ICSharpCodeEditor.Padding = new System.Windows.Forms.Padding(3);
            this.ICSharpCodeEditor.Size = new System.Drawing.Size(302, 207);
            this.ICSharpCodeEditor.TabIndex = 0;
            this.ICSharpCodeEditor.Text = "ICSharpCode Editor";
            this.ICSharpCodeEditor.UseVisualStyleBackColor = true;
            // 
            // ScintillaEditor
            // 
            this.ScintillaEditor.Location = new System.Drawing.Point(4, 22);
            this.ScintillaEditor.Name = "ScintillaEditor";
            this.ScintillaEditor.Padding = new System.Windows.Forms.Padding(3);
            this.ScintillaEditor.Size = new System.Drawing.Size(302, 207);
            this.ScintillaEditor.TabIndex = 1;
            this.ScintillaEditor.Text = "Scintilla Editor";
            this.ScintillaEditor.UseVisualStyleBackColor = true;
            // 
            // RTEditor
            // 
            this.RTEditor.Location = new System.Drawing.Point(4, 22);
            this.RTEditor.Name = "RTEditor";
            this.RTEditor.Padding = new System.Windows.Forms.Padding(3);
            this.RTEditor.Size = new System.Drawing.Size(302, 207);
            this.RTEditor.TabIndex = 2;
            this.RTEditor.Text = "Rich Text Editor";
            this.RTEditor.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 298);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.tabDisplay.PerformLayout();
            this.tabBrowser.ResumeLayout(false);
            this.tabBrowser.PerformLayout();
            this.tabEditors.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabEditors;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage ICSharpCodeEditor;
        private System.Windows.Forms.TabPage ScintillaEditor;
        private System.Windows.Forms.TabPage RTEditor;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.CheckBox chkShowEditToolBar;
        private System.Windows.Forms.CheckBox chkShowStatusBar;
        private System.Windows.Forms.CheckBox chkShowOthersToolBar;
        private System.Windows.Forms.CheckBox chkShowViewToolBar;
        private System.Windows.Forms.CheckBox chkShowFileToolBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.CheckBox chkBrowserShortcuts;
        private System.Windows.Forms.CheckBox chkBrowserContextMenu;
        private System.Windows.Forms.CheckBox chkBrowserScrollbar;
        private System.Windows.Forms.CheckBox chkBrowserScriptErrors;
        private System.Windows.Forms.CheckBox chkBrowserDrop;
        private System.Windows.Forms.CheckBox chkDragAndDrop;
    }
}
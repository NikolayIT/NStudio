using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileSearch.Windows.Forms
{
   /// <summary>
   /// Used to Add/Edit a Text Editor for a specified file type.
   /// </summary>
   /// <remarks>
   ///   FileSearch File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002 AstroComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General Public License
   ///   as published by the Free Software Foundation; either version 2
   ///   of the License, or (at your option) any later version.
   ///   
   ///   This program is distributed in the hope that it will be useful,
   ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
   ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   ///   GNU General Public License for more details.
   ///   
   ///   You should have received a copy of the GNU General Public License
   ///   along with this program; if not, write to the Free Software
   ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
   ///   
   ///   The author may be contacted at:
   ///   ted@astrocomma.com or curtismbeard@gmail.com
   /// </remarks>
   /// <history>
   /// [Curtis_Beard]		07/21/2006	Created
   /// </history>
	public class frmAddEditTextEditor : System.Windows.Forms.Form
	{
      #region Declarations
      private bool __Add = true;
      private bool __AllTypesDefined = false;
      private string __FileType;
      private string __OriginalFileType = string.Empty;
      private string __Location;
      private string __CmdArgs;
      private string __PreviewText = "Preview {0}";
      private string[] __ExistingFileTypes = null;
      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private FileSearch.Windows.Controls.PictureButton btnBrowse;
      private System.Windows.Forms.TextBox txtFileType;
      private System.Windows.Forms.TextBox txtTextEditorLocation;
      private System.Windows.Forms.TextBox txtCmdLineArgs;
      private System.Windows.Forms.Label lblFileType;
      private System.Windows.Forms.Label lblAllTypesMessage;
      private System.Windows.Forms.Label lblCmdLineArgs;
      private System.Windows.Forms.Label lblCmdOptionsView;
      private System.Windows.Forms.Label lblTextEditorLocation;
      private System.Windows.Forms.Label lblCmdOptions;
      private System.Windows.Forms.ToolTip HoverTips;
      private System.ComponentModel.IContainer components;

      /// <summary>
      /// Creates an instance of the frmAddEditTextEditor class.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
		public frmAddEditTextEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.components = new System.ComponentModel.Container();
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddEditTextEditor));
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnBrowse = new FileSearch.Windows.Controls.PictureButton();
         this.txtFileType = new System.Windows.Forms.TextBox();
         this.txtTextEditorLocation = new System.Windows.Forms.TextBox();
         this.txtCmdLineArgs = new System.Windows.Forms.TextBox();
         this.lblFileType = new System.Windows.Forms.Label();
         this.lblAllTypesMessage = new System.Windows.Forms.Label();
         this.lblCmdLineArgs = new System.Windows.Forms.Label();
         this.lblCmdOptionsView = new System.Windows.Forms.Label();
         this.lblTextEditorLocation = new System.Windows.Forms.Label();
         this.lblCmdOptions = new System.Windows.Forms.Label();
         this.HoverTips = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.btnOK.Location = new System.Drawing.Point(290, 225);
         this.btnOK.Name = "btnOK";
         this.btnOK.TabIndex = 5;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.btnCancel.Location = new System.Drawing.Point(370, 225);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnBrowse
         // 
         this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
         this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
         this.btnBrowse.Location = new System.Drawing.Point(424, 66);
         this.btnBrowse.Name = "btnBrowse";
         this.btnBrowse.Size = new System.Drawing.Size(16, 16);
         this.btnBrowse.TabIndex = 3;
         this.btnBrowse.TabStop = false;
         this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
         // 
         // txtFileType
         // 
         this.txtFileType.Location = new System.Drawing.Point(120, 8);
         this.txtFileType.Name = "txtFileType";
         this.txtFileType.Size = new System.Drawing.Size(88, 20);
         this.txtFileType.TabIndex = 1;
         this.txtFileType.Text = "";
         this.txtFileType.TextChanged += new System.EventHandler(this.txtFileType_TextChanged);
         // 
         // txtTextEditorLocation
         // 
         this.txtTextEditorLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtTextEditorLocation.Location = new System.Drawing.Point(120, 64);
         this.txtTextEditorLocation.Name = "txtTextEditorLocation";
         this.txtTextEditorLocation.Size = new System.Drawing.Size(296, 20);
         this.txtTextEditorLocation.TabIndex = 2;
         this.txtTextEditorLocation.Text = "";
         // 
         // txtCmdLineArgs
         // 
         this.txtCmdLineArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtCmdLineArgs.Location = new System.Drawing.Point(120, 168);
         this.txtCmdLineArgs.Name = "txtCmdLineArgs";
         this.txtCmdLineArgs.Size = new System.Drawing.Size(320, 20);
         this.txtCmdLineArgs.TabIndex = 4;
         this.txtCmdLineArgs.Text = "";
         this.txtCmdLineArgs.TextChanged += new System.EventHandler(this.txtCmdLineArgs_TextChanged);
         // 
         // lblFileType
         // 
         this.lblFileType.Location = new System.Drawing.Point(8, 8);
         this.lblFileType.Name = "lblFileType";
         this.lblFileType.TabIndex = 1;
         this.lblFileType.Text = "File Type";
         this.lblFileType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblAllTypesMessage
         // 
         this.lblAllTypesMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblAllTypesMessage.Location = new System.Drawing.Point(216, 8);
         this.lblAllTypesMessage.Name = "lblAllTypesMessage";
         this.lblAllTypesMessage.Size = new System.Drawing.Size(224, 48);
         this.lblAllTypesMessage.TabIndex = 22;
         this.lblAllTypesMessage.Text = "A Text Editor can be used for all unknown types by using a * for the file type.";
         // 
         // lblCmdLineArgs
         // 
         this.lblCmdLineArgs.Location = new System.Drawing.Point(8, 168);
         this.lblCmdLineArgs.Name = "lblCmdLineArgs";
         this.lblCmdLineArgs.TabIndex = 4;
         this.lblCmdLineArgs.Text = "Command Line";
         this.lblCmdLineArgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblCmdOptionsView
         // 
         this.lblCmdOptionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblCmdOptionsView.Location = new System.Drawing.Point(8, 225);
         this.lblCmdOptionsView.Name = "lblCmdOptionsView";
         this.lblCmdOptionsView.Size = new System.Drawing.Size(280, 23);
         this.lblCmdOptionsView.TabIndex = 20;
         this.lblCmdOptionsView.Text = "Preview:";
         this.lblCmdOptionsView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblTextEditorLocation
         // 
         this.lblTextEditorLocation.Location = new System.Drawing.Point(8, 64);
         this.lblTextEditorLocation.Name = "lblTextEditorLocation";
         this.lblTextEditorLocation.Size = new System.Drawing.Size(112, 23);
         this.lblTextEditorLocation.TabIndex = 3;
         this.lblTextEditorLocation.Text = "Text Editor Location";
         this.lblTextEditorLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblCmdOptions
         // 
         this.lblCmdOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblCmdOptions.Location = new System.Drawing.Point(120, 96);
         this.lblCmdOptions.Name = "lblCmdOptions";
         this.lblCmdOptions.Size = new System.Drawing.Size(320, 64);
         this.lblCmdOptions.TabIndex = 21;
         this.lblCmdOptions.Text = "Command Line Options:";
         // 
         // frmAddEditTextEditor
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(450, 255);
         this.Controls.Add(this.lblCmdOptions);
         this.Controls.Add(this.lblTextEditorLocation);
         this.Controls.Add(this.lblCmdOptionsView);
         this.Controls.Add(this.lblCmdLineArgs);
         this.Controls.Add(this.lblAllTypesMessage);
         this.Controls.Add(this.lblFileType);
         this.Controls.Add(this.txtCmdLineArgs);
         this.Controls.Add(this.txtTextEditorLocation);
         this.Controls.Add(this.txtFileType);
         this.Controls.Add(this.btnBrowse);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmAddEditTextEditor";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Text Editors";
         this.Load += new System.EventHandler(this.frmAddEditTextEditor_Load);
         this.ResumeLayout(false);

      }
		#endregion

      #region Properties
      /// <summary>
      /// Determines whether the control is in Addition mode.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public bool IsAdd
      {
         set { __Add = value; }
      }

      /// <summary>
      /// Determines whether the All File Types has already been used.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public bool IsAllTypesDefined
      {
         set
         {
            __AllTypesDefined = value;
            if (__AllTypesDefined)
               // one is defined so don't display
               lblAllTypesMessage.Visible = false;
            else
               // not defined so display message
               lblAllTypesMessage.Visible = true;
         }
      }

      /// <summary>
      /// Contains the file type.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string TextEditorFileType
      {
         get { return __FileType; }
         set
         {
            __OriginalFileType = value;
            __FileType = value;
         }
      }

      /// <summary>
      /// Contains the location.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string TextEditorLocation
      {
         get { return __Location; }
         set { __Location = value; }
      }

      /// <summary>
      /// Contains the command line arguments.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string TextEditorCommandLine
      {
         get { return __CmdArgs; }
         set { __CmdArgs = value; }
      }

      /// <summary>
      /// Contains the current file types defined.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		04/20/2007	Created
      /// </history>
      public string[] ExistingFileTypes
      {
         get { return __ExistingFileTypes; }
         set { __ExistingFileTypes = value; }
      }
      #endregion

      #region Events
      /// <summary>
      /// Setup the form for display.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void frmAddEditTextEditor_Load(object sender, System.EventArgs e)
      {
         if (!__Add)
         {
            // load values into text boxes
            txtFileType.Text = __FileType;
            txtTextEditorLocation.Text = __Location;
            txtCmdLineArgs.Text = __CmdArgs;
         }

         lblCmdOptions.Text = "Command Line Optons:\r\n" +
                              "  %1 - File\r\n" +
                              "  %2 - Line Number\r\n" +
                              "  %3 - Column";

         //Language.GenerateXml(this, Application.StartupPath + "\\" + this.Name + ".xml");
         Language.ProcessForm(this, HoverTips);

         if (lblCmdOptionsView.Text.Equals(string.Empty))
            lblCmdOptionsView.Text = __PreviewText;
         else
            __PreviewText = lblCmdOptionsView.Text;

         lblCmdOptionsView.Text = RetrieveCmdLineViewText();
      }

      /// <summary>
      /// Save the user selected items and close the form.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// [Curtis_Beard]		05/22/2007	FIX: 1646328, check when adding a new extension
      /// </history>
      private void btnOK_Click(object sender, System.EventArgs e)
      {
         // validate not an existing file type
         bool exists = false;
         if (ExistingFileTypes != null)
         {
            foreach (string fileType in ExistingFileTypes)
            {
               if (fileType.Equals(txtFileType.Text))
               {
                  exists = true;
                  break;
               }
            }
            if (exists)
            {
               this.DialogResult = DialogResult.None;
               MessageBox.Show(this, Language.GetGenericText("TextEditorsErrorFileTypeExists"), 
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
            }
         }

         // validate that an editor exists
         if (txtTextEditorLocation.Text.Length < 1)
         {
            this.DialogResult = DialogResult.None;
            MessageBox.Show(this, Language.GetGenericText("TextEditorsErrorNoEditor"), 
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         // validate cmdline has at least %1
         if (txtCmdLineArgs.Text.IndexOf("%1") == -1)
         {
            txtCmdLineArgs.Text = "%1";
         }

         // load values from text boxes
         __FileType = txtFileType.Text;
         __Location = txtTextEditorLocation.Text;
         __CmdArgs = txtCmdLineArgs.Text;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      /// <summary>
      /// Close the form.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void btnCancel_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      /// <summary>
      /// Allow selection of an executable file.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void btnBrowse_Click(object sender, System.EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = "Executables (*.exe)|*.exe|All Files (*.*)|*.*";
         dlg.Title = Language.GetGenericText("TextEditorsBrowseTitle");
         dlg.Multiselect = false;

         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            txtTextEditorLocation.Text = dlg.FileName;
            lblCmdOptionsView.Text = RetrieveCmdLineViewText();
         }

         dlg.Dispose();
      }

      /// <summary>
      /// Update the preview display.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void txtCmdLineArgs_TextChanged(object sender, System.EventArgs e)
      {
         lblCmdOptionsView.Text = RetrieveCmdLineViewText();
      }

      /// <summary>
      /// Checks to make sure the all file types (*) is used only once
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void txtFileType_TextChanged(object sender, System.EventArgs e)
      {
         if (__AllTypesDefined && !__OriginalFileType.Equals(Constants.ALL_FILE_TYPES))
         {
            if (txtFileType.Text.Equals(Constants.ALL_FILE_TYPES))
            {
               MessageBox.Show(Language.GetGenericText("TextEditorsAllTypesDefined"), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
               txtFileType.Text = string.Empty;
            }
         }
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Returns a preview of what the command line will look like to open a file
      /// </summary>
      /// <returns>Preview of command line</returns>
      /// <history>
      /// [Curtis_Beard]      06/13/2005	ADD: Better cmd line arg support
      /// [Curtis_Beard]      07/26/2006	ADD: 1512026, column
      /// </history>
      private string RetrieveCmdLineViewText()
      {
         string _text = txtCmdLineArgs.Text;

         _text = _text.Replace("%1", "file.txt");
         _text = _text.Replace("%2", "450");
         _text = _text.Replace("%3", "11");

         return string.Format(__PreviewText, "editor.exe " + _text);
      }
      #endregion
	}
}

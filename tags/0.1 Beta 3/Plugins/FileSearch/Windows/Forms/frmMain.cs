using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NStudioInterface;
using libFileSearch;

namespace FileSearch.Windows.Forms
{
   /// <summary>
   /// Main Form
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
   /// [Theodore_Ward]     ??/??/????  Initial
   /// [Curtis_Beard]      01/11/2005  .Net Conversion/Comments/Option Strict
   /// [Curtis_Beard]      10/15/2005	CHG: Replace search procedures
   /// </history>
    public class frmMain : DocumentBase, IPluginForm
	{
        private IMainForm parent;

        public IMainForm ParentMainForm
        {
            set { parent = value; }
            get
            {
                return parent;
            }
        }

        public override string StatusBarName
        {
            get
            {
                return "FileSearch 4.1.3";
            }
        }

      #region Declarations
      private bool __OptionsShow = true;
      private int __SortColumn = -1;
      private Grep __Grep = null;
      private string __SearchOptionsText = "Search Options {0}";
      private int __FileListHeight = Core.GeneralSettings.DEFAULT_FILE_PANEL_HEIGHT;
      private System.Collections.Specialized.StringCollection __ErrorCollection = new System.Collections.Specialized.StringCollection();
      #endregion

      #region Delegate Declarations
      private delegate void UpdateHitCountCallBack(HitObject hit);
      private delegate void SetSearchStateCallBack(bool enable);
      private delegate void UpdateStatusMessageCallBack(string message);
      private delegate void ClearItemsCallBack();
      private delegate void AddToListCallBack(System.IO.FileInfo file, int index);
      private delegate void DisplaySearchErrorsCallBack();
      #endregion

      private System.Windows.Forms.ListView lstFileNames;
      private System.Windows.Forms.RichTextBox txtHits;
      private System.Windows.Forms.Panel pnlSearch;
      private System.Windows.Forms.ComboBox cboSearchForText;
      private System.Windows.Forms.ComboBox cboFileName;
      private System.Windows.Forms.ComboBox cboFilePath;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnSearch;
      private System.Windows.Forms.Panel pnlSearchOptions;
      private System.Windows.Forms.Panel pnlMainSearch;
      private System.Windows.Forms.Label lblSearchText;
      private System.Windows.Forms.Label lblFileTypes;
      private System.Windows.Forms.Label lblSearchPath;
      private System.Windows.Forms.Label lblSearchHeading;
      private System.Windows.Forms.Splitter splitUpDown;
      private System.Windows.Forms.Splitter splitLeftRight;
      private System.Windows.Forms.Panel pnlRightSide;
      private System.Windows.Forms.StatusBar stbStatus;
      private System.Windows.Forms.LinkLabel lnkSearchOptions;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Panel PanelOptionsContainer;
      private System.Windows.Forms.CheckBox chkNegation;
      private System.Windows.Forms.CheckBox chkCaseSensitive;
      private System.Windows.Forms.CheckBox chkRecurse;
      private System.Windows.Forms.CheckBox chkFileNamesOnly;
      private System.Windows.Forms.CheckBox chkLineNumbers;
      private System.Windows.Forms.CheckBox chkRegularExpressions;
      private System.Windows.Forms.CheckBox chkWholeWordOnly;
      private System.Windows.Forms.NumericUpDown txtContextLines;
      private System.Windows.Forms.Label lblContextLines;
      private System.Windows.Forms.MenuItem mnuFile;
      private System.Windows.Forms.MenuItem mnuSaveResults;
      private System.Windows.Forms.MenuItem mnuPrintResults;
      private System.Windows.Forms.MenuItem mnuExit;
      private System.Windows.Forms.MenuItem mnuEdit;
      private System.Windows.Forms.MenuItem mnuTools;
      private System.Windows.Forms.MenuItem mnuOptions;
      private System.Windows.Forms.MenuItem mnuHelp;
      private System.Windows.Forms.MenuItem mnuAbout;
      private System.Windows.Forms.MenuItem mnuSelectAll;
      private System.Windows.Forms.MenuItem mnuOpenSelected;
      private System.Windows.Forms.MenuItem mnuClearMRU;
      private System.Windows.Forms.MainMenu mnuAll;
      private System.Windows.Forms.MenuItem mnuFileSep;
      private System.Windows.Forms.MenuItem mnuToolsSep;
      private System.Windows.Forms.MenuItem mnuSaveSearchSettings;
      private System.Windows.Forms.ImageList ListViewImageList;
      private FileSearch.Windows.Controls.PictureButton picBrowse;
      private System.Windows.Forms.MenuItem mnuBrowse;
      private System.Windows.Forms.MenuItem mnuFileSep2;
      private System.ComponentModel.IContainer components;

      /// <summary>
      /// Creates an instance of the frmMain class.
      /// </summary>
      /// /// <history>
      /// [Theodore_Ward]     ??/??/????  Created
      /// [Curtis_Beard]      11/02/2006	CHG: Conversion to C#, setup event handlers
      /// </history>
		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

         // Attach event handlers
         this.Resize += new EventHandler(frmMain_Resize);
         this.Closed += new EventHandler(frmMain_Closed);
			pnlMainSearch.Paint += new PaintEventHandler(pnlMainSearch_Paint);
         pnlSearch.SizeChanged += new EventHandler(pnlSearch_SizeChanged);
         PanelOptionsContainer.Paint += new PaintEventHandler(PanelOptionsContainer_Paint);
         splitLeftRight.Paint += new PaintEventHandler(splitLeftRight_Paint);
         splitUpDown.Paint += new PaintEventHandler(splitUpDown_Paint);
         mnuFile.Select += new EventHandler(mnuFile_Select);
         mnuEdit.Select += new EventHandler(mnuEdit_Select);
         cboFilePath.DropDown += new EventHandler(cboFilePath_DropDown);
         cboFileName.DropDown += new EventHandler(cboFileName_DropDown);
         cboSearchForText.DropDown += new EventHandler(cboSearchForText_DropDown);
         chkNegation.CheckedChanged += new EventHandler(chkNegation_CheckedChanged);
         chkFileNamesOnly.CheckedChanged += new EventHandler(chkFileNamesOnly_CheckedChanged);
         txtHits.MouseDown += new MouseEventHandler(txtHits_MouseDown);
         lstFileNames.MouseDown += new MouseEventHandler(lstFileNames_MouseDown);
         lstFileNames.ColumnClick += new ColumnClickEventHandler(lstFileNames_ColumnClick);
         lstFileNames.HandleCreated += new EventHandler(lstFileNames_HandleCreated);
         lstFileNames.ItemDrag += new ItemDragEventHandler(lstFileNames_ItemDrag);
         
         try
         {
            // set font for printing and default display
            txtHits.Font = new Font("Courier New", 9.75F, FontStyle.Regular);
         }
         catch {}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if disposing, false otherwise</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
         this.pnlSearch = new System.Windows.Forms.Panel();
         this.pnlSearchOptions = new System.Windows.Forms.Panel();
         this.PanelOptionsContainer = new System.Windows.Forms.Panel();
         this.lblContextLines = new System.Windows.Forms.Label();
         this.txtContextLines = new System.Windows.Forms.NumericUpDown();
         this.chkWholeWordOnly = new System.Windows.Forms.CheckBox();
         this.chkRegularExpressions = new System.Windows.Forms.CheckBox();
         this.chkNegation = new System.Windows.Forms.CheckBox();
         this.chkLineNumbers = new System.Windows.Forms.CheckBox();
         this.chkFileNamesOnly = new System.Windows.Forms.CheckBox();
         this.chkRecurse = new System.Windows.Forms.CheckBox();
         this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
         this.lnkSearchOptions = new System.Windows.Forms.LinkLabel();
         this.pnlMainSearch = new System.Windows.Forms.Panel();
         this.picBrowse = new FileSearch.Windows.Controls.PictureButton();
         this.btnSearch = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.cboFilePath = new System.Windows.Forms.ComboBox();
         this.cboFileName = new System.Windows.Forms.ComboBox();
         this.cboSearchForText = new System.Windows.Forms.ComboBox();
         this.lblSearchText = new System.Windows.Forms.Label();
         this.lblFileTypes = new System.Windows.Forms.Label();
         this.lblSearchPath = new System.Windows.Forms.Label();
         this.lblSearchHeading = new System.Windows.Forms.Label();
         this.pnlRightSide = new System.Windows.Forms.Panel();
         this.txtHits = new System.Windows.Forms.RichTextBox();
         this.splitUpDown = new System.Windows.Forms.Splitter();
         this.lstFileNames = new System.Windows.Forms.ListView();
         this.splitLeftRight = new System.Windows.Forms.Splitter();
         this.mnuAll = new System.Windows.Forms.MainMenu();
         this.mnuFile = new System.Windows.Forms.MenuItem();
         this.mnuBrowse = new System.Windows.Forms.MenuItem();
         this.mnuFileSep2 = new System.Windows.Forms.MenuItem();
         this.mnuSaveResults = new System.Windows.Forms.MenuItem();
         this.mnuPrintResults = new System.Windows.Forms.MenuItem();
         this.mnuFileSep = new System.Windows.Forms.MenuItem();
         this.mnuExit = new System.Windows.Forms.MenuItem();
         this.mnuEdit = new System.Windows.Forms.MenuItem();
         this.mnuSelectAll = new System.Windows.Forms.MenuItem();
         this.mnuOpenSelected = new System.Windows.Forms.MenuItem();
         this.mnuTools = new System.Windows.Forms.MenuItem();
         this.mnuClearMRU = new System.Windows.Forms.MenuItem();
         this.mnuToolsSep = new System.Windows.Forms.MenuItem();
         this.mnuSaveSearchSettings = new System.Windows.Forms.MenuItem();
         this.mnuOptions = new System.Windows.Forms.MenuItem();
         this.mnuHelp = new System.Windows.Forms.MenuItem();
         this.mnuAbout = new System.Windows.Forms.MenuItem();
         this.stbStatus = new System.Windows.Forms.StatusBar();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.ListViewImageList = new System.Windows.Forms.ImageList(this.components);
         this.pnlSearch.SuspendLayout();
         this.pnlSearchOptions.SuspendLayout();
         this.PanelOptionsContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtContextLines)).BeginInit();
         this.pnlMainSearch.SuspendLayout();
         this.pnlRightSide.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlSearch
         // 
         this.pnlSearch.AutoScroll = true;
         this.pnlSearch.BackColor = System.Drawing.SystemColors.Window;
         this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.pnlSearch.Controls.Add(this.pnlSearchOptions);
         this.pnlSearch.Controls.Add(this.pnlMainSearch);
         this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Left;
         this.pnlSearch.Location = new System.Drawing.Point(0, 0);
         this.pnlSearch.Name = "pnlSearch";
         this.pnlSearch.Size = new System.Drawing.Size(240, 484);
         this.pnlSearch.TabIndex = 0;
         // 
         // pnlSearchOptions
         // 
         this.pnlSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.pnlSearchOptions.Controls.Add(this.PanelOptionsContainer);
         this.pnlSearchOptions.Controls.Add(this.lnkSearchOptions);
         this.pnlSearchOptions.Location = new System.Drawing.Point(16, 208);
         this.pnlSearchOptions.Name = "pnlSearchOptions";
         this.pnlSearchOptions.Size = new System.Drawing.Size(200, 224);
         this.pnlSearchOptions.TabIndex = 1;
         // 
         // PanelOptionsContainer
         // 
         this.PanelOptionsContainer.Controls.Add(this.lblContextLines);
         this.PanelOptionsContainer.Controls.Add(this.txtContextLines);
         this.PanelOptionsContainer.Controls.Add(this.chkWholeWordOnly);
         this.PanelOptionsContainer.Controls.Add(this.chkRegularExpressions);
         this.PanelOptionsContainer.Controls.Add(this.chkNegation);
         this.PanelOptionsContainer.Controls.Add(this.chkLineNumbers);
         this.PanelOptionsContainer.Controls.Add(this.chkFileNamesOnly);
         this.PanelOptionsContainer.Controls.Add(this.chkRecurse);
         this.PanelOptionsContainer.Controls.Add(this.chkCaseSensitive);
         this.PanelOptionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelOptionsContainer.Location = new System.Drawing.Point(0, 16);
         this.PanelOptionsContainer.Name = "PanelOptionsContainer";
         this.PanelOptionsContainer.Size = new System.Drawing.Size(200, 208);
         this.PanelOptionsContainer.TabIndex = 1;
         // 
         // lblContextLines
         // 
         this.lblContextLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblContextLines.Location = new System.Drawing.Point(56, 175);
         this.lblContextLines.Name = "lblContextLines";
         this.lblContextLines.Size = new System.Drawing.Size(127, 20);
         this.lblContextLines.TabIndex = 8;
         this.lblContextLines.Text = "Context Lines";
         this.lblContextLines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.toolTip1.SetToolTip(this.lblContextLines, "Show lines above and below the word matched");
         // 
         // txtContextLines
         // 
         this.txtContextLines.Location = new System.Drawing.Point(7, 175);
         this.txtContextLines.Name = "txtContextLines";
         this.txtContextLines.Size = new System.Drawing.Size(41, 20);
         this.txtContextLines.TabIndex = 13;
         this.toolTip1.SetToolTip(this.txtContextLines, "Show lines above and below the word matched");
         // 
         // chkWholeWordOnly
         // 
         this.chkWholeWordOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkWholeWordOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkWholeWordOnly.Location = new System.Drawing.Point(7, 56);
         this.chkWholeWordOnly.Name = "chkWholeWordOnly";
         this.chkWholeWordOnly.Size = new System.Drawing.Size(178, 16);
         this.chkWholeWordOnly.TabIndex = 8;
         this.chkWholeWordOnly.Text = "&Whole Word";
         this.toolTip1.SetToolTip(this.chkWholeWordOnly, "Only match entire words (not parts of words)");
         // 
         // chkRegularExpressions
         // 
         this.chkRegularExpressions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkRegularExpressions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkRegularExpressions.Location = new System.Drawing.Point(7, 8);
         this.chkRegularExpressions.Name = "chkRegularExpressions";
         this.chkRegularExpressions.Size = new System.Drawing.Size(178, 16);
         this.chkRegularExpressions.TabIndex = 6;
         this.chkRegularExpressions.Text = "Regular &Expressions";
         this.toolTip1.SetToolTip(this.chkRegularExpressions, "Use \"regular expression\" matching");
         // 
         // chkNegation
         // 
         this.chkNegation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkNegation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkNegation.Location = new System.Drawing.Point(7, 128);
         this.chkNegation.Name = "chkNegation";
         this.chkNegation.Size = new System.Drawing.Size(178, 16);
         this.chkNegation.TabIndex = 11;
         this.chkNegation.Text = "&Negation";
         this.toolTip1.SetToolTip(this.chkNegation, "Find the files without the Search Text in them");
         // 
         // chkLineNumbers
         // 
         this.chkLineNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkLineNumbers.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkLineNumbers.Location = new System.Drawing.Point(7, 152);
         this.chkLineNumbers.Name = "chkLineNumbers";
         this.chkLineNumbers.Size = new System.Drawing.Size(178, 16);
         this.chkLineNumbers.TabIndex = 12;
         this.chkLineNumbers.Text = "&Line Numbers";
         this.toolTip1.SetToolTip(this.chkLineNumbers, "Include line numbers before each match");
         // 
         // chkFileNamesOnly
         // 
         this.chkFileNamesOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkFileNamesOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkFileNamesOnly.Location = new System.Drawing.Point(7, 104);
         this.chkFileNamesOnly.Name = "chkFileNamesOnly";
         this.chkFileNamesOnly.Size = new System.Drawing.Size(178, 16);
         this.chkFileNamesOnly.TabIndex = 10;
         this.chkFileNamesOnly.Text = "Show File Names &Only";
         this.toolTip1.SetToolTip(this.chkFileNamesOnly, "Show names but not contents of files that have matches (may be faster on large fi" +
            "les)");
         // 
         // chkRecurse
         // 
         this.chkRecurse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkRecurse.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkRecurse.Location = new System.Drawing.Point(7, 80);
         this.chkRecurse.Name = "chkRecurse";
         this.chkRecurse.Size = new System.Drawing.Size(178, 16);
         this.chkRecurse.TabIndex = 9;
         this.chkRecurse.Text = "&Recurse";
         this.toolTip1.SetToolTip(this.chkRecurse, "Search in subdirectories");
         // 
         // chkCaseSensitive
         // 
         this.chkCaseSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkCaseSensitive.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.chkCaseSensitive.Location = new System.Drawing.Point(7, 32);
         this.chkCaseSensitive.Name = "chkCaseSensitive";
         this.chkCaseSensitive.Size = new System.Drawing.Size(178, 16);
         this.chkCaseSensitive.TabIndex = 7;
         this.chkCaseSensitive.Text = "&Case Sensitive";
         this.toolTip1.SetToolTip(this.chkCaseSensitive, "Match upper and lower case letters exactly");
         // 
         // lnkSearchOptions
         // 
         this.lnkSearchOptions.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
         this.lnkSearchOptions.Dock = System.Windows.Forms.DockStyle.Top;
         this.lnkSearchOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lnkSearchOptions.LinkColor = System.Drawing.SystemColors.ActiveCaption;
         this.lnkSearchOptions.Location = new System.Drawing.Point(0, 0);
         this.lnkSearchOptions.Name = "lnkSearchOptions";
         this.lnkSearchOptions.Size = new System.Drawing.Size(200, 16);
         this.lnkSearchOptions.TabIndex = 5;
         this.lnkSearchOptions.TabStop = true;
         this.lnkSearchOptions.Text = "Search Options >>";
         this.lnkSearchOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lnkSearchOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSearchOptions_LinkClicked);
         // 
         // pnlMainSearch
         // 
         this.pnlMainSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.pnlMainSearch.Controls.Add(this.picBrowse);
         this.pnlMainSearch.Controls.Add(this.btnSearch);
         this.pnlMainSearch.Controls.Add(this.btnCancel);
         this.pnlMainSearch.Controls.Add(this.cboFilePath);
         this.pnlMainSearch.Controls.Add(this.cboFileName);
         this.pnlMainSearch.Controls.Add(this.cboSearchForText);
         this.pnlMainSearch.Controls.Add(this.lblSearchText);
         this.pnlMainSearch.Controls.Add(this.lblFileTypes);
         this.pnlMainSearch.Controls.Add(this.lblSearchPath);
         this.pnlMainSearch.Controls.Add(this.lblSearchHeading);
         this.pnlMainSearch.Location = new System.Drawing.Point(16, 8);
         this.pnlMainSearch.Name = "pnlMainSearch";
         this.pnlMainSearch.Size = new System.Drawing.Size(200, 192);
         this.pnlMainSearch.TabIndex = 0;
         // 
         // picBrowse
         // 
         this.picBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
         this.picBrowse.Image = ((System.Drawing.Image)(resources.GetObject("picBrowse.Image")));
         this.picBrowse.Location = new System.Drawing.Point(176, 42);
         this.picBrowse.Name = "picBrowse";
         this.picBrowse.Size = new System.Drawing.Size(16, 16);
         this.picBrowse.TabIndex = 6;
         this.picBrowse.TabStop = false;
         this.picBrowse.Click += new System.EventHandler(this.picBrowse_Click);
         // 
         // btnSearch
         // 
         this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
         this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.btnSearch.Location = new System.Drawing.Point(8, 160);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.TabIndex = 0;
         this.btnSearch.Text = "&Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Enabled = false;
         this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.btnCancel.Location = new System.Drawing.Point(115, 160);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // cboFilePath
         // 
         this.cboFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboFilePath.Location = new System.Drawing.Point(8, 40);
         this.cboFilePath.Name = "cboFilePath";
         this.cboFilePath.Size = new System.Drawing.Size(160, 21);
         this.cboFilePath.TabIndex = 1;
         // 
         // cboFileName
         // 
         this.cboFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboFileName.Location = new System.Drawing.Point(8, 80);
         this.cboFileName.Name = "cboFileName";
         this.cboFileName.Size = new System.Drawing.Size(184, 21);
         this.cboFileName.TabIndex = 2;
         // 
         // cboSearchForText
         // 
         this.cboSearchForText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboSearchForText.Location = new System.Drawing.Point(8, 120);
         this.cboSearchForText.Name = "cboSearchForText";
         this.cboSearchForText.Size = new System.Drawing.Size(184, 21);
         this.cboSearchForText.TabIndex = 3;
         // 
         // lblSearchText
         // 
         this.lblSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblSearchText.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblSearchText.Location = new System.Drawing.Point(8, 104);
         this.lblSearchText.Name = "lblSearchText";
         this.lblSearchText.Size = new System.Drawing.Size(180, 16);
         this.lblSearchText.TabIndex = 3;
         this.lblSearchText.Text = "Search Text";
         // 
         // lblFileTypes
         // 
         this.lblFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblFileTypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblFileTypes.Location = new System.Drawing.Point(8, 64);
         this.lblFileTypes.Name = "lblFileTypes";
         this.lblFileTypes.Size = new System.Drawing.Size(180, 16);
         this.lblFileTypes.TabIndex = 2;
         this.lblFileTypes.Text = "File Types";
         // 
         // lblSearchPath
         // 
         this.lblSearchPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblSearchPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblSearchPath.Location = new System.Drawing.Point(8, 24);
         this.lblSearchPath.Name = "lblSearchPath";
         this.lblSearchPath.Size = new System.Drawing.Size(180, 16);
         this.lblSearchPath.TabIndex = 1;
         this.lblSearchPath.Text = "Search Path";
         // 
         // lblSearchHeading
         // 
         this.lblSearchHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblSearchHeading.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.lblSearchHeading.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.lblSearchHeading.Location = new System.Drawing.Point(0, 0);
         this.lblSearchHeading.Name = "lblSearchHeading";
         this.lblSearchHeading.Size = new System.Drawing.Size(202, 16);
         this.lblSearchHeading.TabIndex = 0;
         this.lblSearchHeading.Text = "FileSearch Search";
         this.lblSearchHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // pnlRightSide
         // 
         this.pnlRightSide.Controls.Add(this.txtHits);
         this.pnlRightSide.Controls.Add(this.splitUpDown);
         this.pnlRightSide.Controls.Add(this.lstFileNames);
         this.pnlRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlRightSide.DockPadding.Left = 8;
         this.pnlRightSide.Location = new System.Drawing.Point(240, 0);
         this.pnlRightSide.Name = "pnlRightSide";
         this.pnlRightSide.Size = new System.Drawing.Size(544, 484);
         this.pnlRightSide.TabIndex = 1;
         // 
         // txtHits
         // 
         this.txtHits.DetectUrls = false;
         this.txtHits.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtHits.Location = new System.Drawing.Point(8, 200);
         this.txtHits.Name = "txtHits";
         this.txtHits.ReadOnly = true;
         this.txtHits.Size = new System.Drawing.Size(536, 284);
         this.txtHits.TabIndex = 1;
         this.txtHits.Text = "";
         this.txtHits.WordWrap = false;
         // 
         // splitUpDown
         // 
         this.splitUpDown.Dock = System.Windows.Forms.DockStyle.Top;
         this.splitUpDown.Location = new System.Drawing.Point(8, 192);
         this.splitUpDown.Name = "splitUpDown";
         this.splitUpDown.Size = new System.Drawing.Size(536, 8);
         this.splitUpDown.TabIndex = 2;
         this.splitUpDown.TabStop = false;
         // 
         // lstFileNames
         // 
         this.lstFileNames.Dock = System.Windows.Forms.DockStyle.Top;
         this.lstFileNames.FullRowSelect = true;
         this.lstFileNames.HideSelection = false;
         this.lstFileNames.Location = new System.Drawing.Point(8, 0);
         this.lstFileNames.Name = "lstFileNames";
         this.lstFileNames.Size = new System.Drawing.Size(536, 192);
         this.lstFileNames.TabIndex = 0;
         this.lstFileNames.View = System.Windows.Forms.View.Details;
         this.lstFileNames.SelectedIndexChanged += new System.EventHandler(this.lstFileNames_SelectedIndexChanged);
         // 
         // splitLeftRight
         // 
         this.splitLeftRight.Location = new System.Drawing.Point(240, 0);
         this.splitLeftRight.MinExtra = 100;
         this.splitLeftRight.MinSize = 240;
         this.splitLeftRight.Name = "splitLeftRight";
         this.splitLeftRight.Size = new System.Drawing.Size(8, 484);
         this.splitLeftRight.TabIndex = 2;
         this.splitLeftRight.TabStop = false;
         // 
         // mnuAll
         // 
         this.mnuAll.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                               this.mnuFile,
                                                                               this.mnuEdit,
                                                                               this.mnuTools,
                                                                               this.mnuHelp});
         // 
         // mnuFile
         // 
         this.mnuFile.Index = 0;
         this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.mnuBrowse,
                                                                                this.mnuFileSep2,
                                                                                this.mnuSaveResults,
                                                                                this.mnuPrintResults,
                                                                                this.mnuFileSep,
                                                                                this.mnuExit});
         this.mnuFile.Text = "&File";
         // 
         // mnuBrowse
         // 
         this.mnuBrowse.Index = 0;
         this.mnuBrowse.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this.mnuBrowse.Text = "Select Sea&rch Path...";
         this.mnuBrowse.Click += new System.EventHandler(this.mnuBrowse_Click);
         // 
         // mnuFileSep2
         // 
         this.mnuFileSep2.Index = 1;
         this.mnuFileSep2.Text = "-";
         // 
         // mnuSaveResults
         // 
         this.mnuSaveResults.Index = 2;
         this.mnuSaveResults.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this.mnuSaveResults.Text = "&Save Results";
         this.mnuSaveResults.Click += new System.EventHandler(this.mnuSaveResults_Click);
         // 
         // mnuPrintResults
         // 
         this.mnuPrintResults.Index = 3;
         this.mnuPrintResults.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
         this.mnuPrintResults.Text = "&Print Results";
         this.mnuPrintResults.Click += new System.EventHandler(this.mnuPrintResults_Click);
         // 
         // mnuFileSep
         // 
         this.mnuFileSep.Index = 4;
         this.mnuFileSep.Text = "-";
         // 
         // mnuExit
         // 
         this.mnuExit.Index = 5;
         this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
         this.mnuExit.Text = "E&xit";
         this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
         // 
         // mnuEdit
         // 
         this.mnuEdit.Index = 1;
         this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.mnuSelectAll,
                                                                                this.mnuOpenSelected});
         this.mnuEdit.Text = "&Edit";
         // 
         // mnuSelectAll
         // 
         this.mnuSelectAll.Index = 0;
         this.mnuSelectAll.Text = "&Select All Files";
         this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
         // 
         // mnuOpenSelected
         // 
         this.mnuOpenSelected.Index = 1;
         this.mnuOpenSelected.Text = "&Open Selected Files";
         this.mnuOpenSelected.Click += new System.EventHandler(this.mnuOpenSelected_Click);
         // 
         // mnuTools
         // 
         this.mnuTools.Index = 2;
         this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.mnuClearMRU,
                                                                                 this.mnuToolsSep,
                                                                                 this.mnuSaveSearchSettings,
                                                                                 this.mnuOptions});
         this.mnuTools.Text = "&Tools";
         // 
         // mnuClearMRU
         // 
         this.mnuClearMRU.Index = 0;
         this.mnuClearMRU.Text = "&Clear Most Recently Used Lists";
         this.mnuClearMRU.Click += new System.EventHandler(this.mnuClearMRU_Click);
         // 
         // mnuToolsSep
         // 
         this.mnuToolsSep.Index = 1;
         this.mnuToolsSep.Text = "-";
         // 
         // mnuSaveSearchSettings
         // 
         this.mnuSaveSearchSettings.Index = 2;
         this.mnuSaveSearchSettings.Text = "&Save Search Options";
         this.mnuSaveSearchSettings.Click += new System.EventHandler(this.mnuSaveSearchSettings_Click);
         // 
         // mnuOptions
         // 
         this.mnuOptions.Index = 3;
         this.mnuOptions.Shortcut = System.Windows.Forms.Shortcut.F9;
         this.mnuOptions.Text = "&Options...";
         this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
         // 
         // mnuHelp
         // 
         this.mnuHelp.Index = 3;
         this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.mnuAbout});
         this.mnuHelp.Text = "&Help";
         // 
         // mnuAbout
         // 
         this.mnuAbout.Index = 0;
         this.mnuAbout.Text = "&About...";
         this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
         // 
         // stbStatus
         // 
         this.stbStatus.Location = new System.Drawing.Point(0, 484);
         this.stbStatus.Name = "stbStatus";
         this.stbStatus.Size = new System.Drawing.Size(784, 22);
         this.stbStatus.TabIndex = 3;
         // 
         // ListViewImageList
         // 
         this.ListViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
         this.ListViewImageList.ImageSize = new System.Drawing.Size(16, 16);
         this.ListViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListViewImageList.ImageStream")));
         this.ListViewImageList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnSearch;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(784, 506);
         this.Controls.Add(this.splitLeftRight);
         this.Controls.Add(this.pnlRightSide);
         this.Controls.Add(this.pnlSearch);
         this.Controls.Add(this.stbStatus);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this.mnuAll;
         this.Name = "frmMain";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "FileSearch";
         this.Load += new System.EventHandler(this.frmMain_Load);
         this.pnlSearch.ResumeLayout(false);
         this.pnlSearchOptions.ResumeLayout(false);
         this.PanelOptionsContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.txtContextLines)).EndInit();
         this.pnlMainSearch.ResumeLayout(false);
         this.pnlRightSide.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

      #region Form Events
      /// <summary>
      /// Form Load Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   04/12/2005	ADD: Command line additions
      /// [Son_Le]            08/08/2005  CHG: save listview header widths
      /// [Curtis_Beard]	   10/15/2005	CHG: validate command line parameter as valid dir
      /// [Curtis_Beard]	   07/12/2006	CHG: allow drives for a valid command line parameter
      /// [Curtis_Beard]	   07/25/2006	CHG: Moved cmd line processing to ProcessCommandLine routine
      /// [Curtis_Beard]	   10/10/2006	CHG: Remove call to load search settings, perform check only.
      /// </history>
      private void frmMain_Load(object sender, System.EventArgs e)
      {
         // Parse command line, must be before any use of config files
         CommandLineProcessing.CommandLineArguments args = CommandLineProcessing.Process(Environment.GetCommandLineArgs());

         // set defaults
         txtContextLines.Maximum = Constants.MAX_CONTEXT_LINES;
         lnkSearchOptions.Text = __SearchOptionsText;

         // Load language
         //Language.GenerateXml(this, Application.StartupPath + "\\" + this.Name + ".xml");
         Language.Load(FileSearch.Core.GeneralSettings.Language);
         Language.ProcessForm(this, this.toolTip1);
         
         // set member to hold language specified text
         __SearchOptionsText = lnkSearchOptions.Text;

         // Hide the Search Options
         ShowSearchOptions();

         // Load the general settings
         Legacy.ConvertGeneralSettings();
         LoadSettings();

         // Load the search settings
         Legacy.ConvertSearchSettings();
         LoadSearchSettings();

         // Delete registry entry (if exist)
         Legacy.DeleteRegistry();

         // Load plugins
         Core.PluginManager.Load();

         // set view state of controls
         LoadViewStates();

         // Handle any command line arguments
         ProcessCommandLine(args);
      }

      /// <summary>
      /// Handles form resize event.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void frmMain_Resize(object sender, EventArgs e)
      {
         splitLeftRight.Invalidate();
         splitUpDown.Invalidate();
      }

      /// <summary>
      /// Closed Event - Save settings and exit
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   10/11/2006	CHG: Use common function to remove Browse..., call SaveSettings
      /// [Curtis_Beard]	   11/22/2006	CHG: Remove use of browse in combobox
      /// </history>
      private void frmMain_Closed(object sender, EventArgs e)
      {
         SaveSettings();
         Application.Exit();
      }
      #endregion

      #region Control Events
      /// <summary>
      /// Paint the border for the panel.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]      11/02/2006  Created
      /// </history>
      private void pnlMainSearch_Paint(object sender, PaintEventArgs e)
      {
         Rectangle rect = pnlMainSearch.ClientRectangle;
         rect.Width -= 1;
         rect.Height -= 1;

         e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveCaption), rect);
      }

      /// <summary>
      /// Paint the border for the panel
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]      11/02/2006  Created
      /// </history>
      private void PanelOptionsContainer_Paint(object sender, PaintEventArgs e)
      {
         Rectangle rect = PanelOptionsContainer.ClientRectangle;
         rect.Width -= 1;
         rect.Height -= 1;

         e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveCaption), rect);
      }

      /// <summary>
      /// Resize the comboboxes when the main search panel is resized.
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <remarks>
      ///   This is a workaround for a bug in the .NET 2003 combobox control
      ///   when it is set to ComboBoxStyle.DropDown that will select the text
      ///   in the control when it is resized.
      ///   By temporarily changing the style to ComboBoxStyle.Simple and manually
      ///   setting the width, we can avoid this annoying feature.
      /// </remarks>
      /// <history>
      /// [Son_Le]            08/08/2005  FIX:1180742, remove highlight of combobox
      /// [Curtis_Beard]      11/03/2006  CHG: don't resize just change style
      /// </history>
      private void pnlSearch_SizeChanged(object sender, EventArgs e)
      {
         //int _width = btnSearch.Width + btnCancel.Width + 
         //             (btnCancel.Left - (btnSearch.Left + btnSearch.Width));

         cboFilePath.DropDownStyle = ComboBoxStyle.DropDownList;
         //cboFilePath.Width = _width;
         cboFilePath.DropDownStyle = ComboBoxStyle.DropDown;

         cboFileName.DropDownStyle = ComboBoxStyle.Simple;
         //cboFileName.Width = _width;
         cboFileName.DropDownStyle = ComboBoxStyle.DropDown;

         cboSearchForText.DropDownStyle = ComboBoxStyle.Simple;
         //cboSearchForText.Width = _width;
         cboSearchForText.DropDownStyle = ComboBoxStyle.DropDown;

         pnlMainSearch.Invalidate();
         PanelOptionsContainer.Invalidate();
      }

      /// <summary>
      /// Handles drawing a splitter gripper on the control.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void splitLeftRight_Paint(object sender, PaintEventArgs e)
      {
         const int RECT_SIZE = 2;
         const int MAX = 9;

         Graphics g = e.Graphics;
         int x1 = Convert.ToInt32(splitLeftRight.Width / 2) - 1;
         int x2 = x1 + 1;
         int y1 = Convert.ToInt32(((splitLeftRight.Height - (MAX * 2 * RECT_SIZE)) / 2) + 1);
         int y2 = y1 + 1;
         int index = 0;

         do
         {
            g.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(x2, y2, RECT_SIZE, RECT_SIZE));
            g.FillRectangle(SystemBrushes.ControlDark, new Rectangle(x1, y1, RECT_SIZE, RECT_SIZE));

            y1 = y1 + (2 * RECT_SIZE);
            y2 = y1 + 1;

            index += 1;
         }while (index < MAX);
      }

      /// <summary>
      /// Handles drawing a splitter gripper on the control.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      private void splitUpDown_Paint(object sender, PaintEventArgs e)
      {
         const int RECT_SIZE = 2;
         const int MAX = 9;

         Graphics g = e.Graphics;
         int x1 = Convert.ToInt32(((splitUpDown.Width - (MAX * 2 * RECT_SIZE)) / 2) + 1);
         int x2 = x1 + 1;
         int y1 = Convert.ToInt32(splitUpDown.Height / 2) - 1;
         int y2 = y1 + 1;
         int index = 0;

         do
         {
            g.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(x2, y2, RECT_SIZE, RECT_SIZE));
            g.FillRectangle(SystemBrushes.ControlDark, new Rectangle(x1, y1, RECT_SIZE, RECT_SIZE));

            x1 = x1 + (2 * RECT_SIZE);
            x2 = x1 + 1;

            index += 1;
         }while (index < MAX);
      }

      /// <summary>
      /// Hide/Show the Search Options
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]	   02/04/2005	Created
      /// </history>
      private void lnkSearchOptions_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         ShowSearchOptions();
      }

      /// <summary>
      /// Resize drop down list if necessary
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]    11/21/2005	Created
      /// </history>
      private void cboSearchForText_DropDown(object sender, EventArgs e)
      {
         cboSearchForText.DropDownWidth = CalculateDropDownWidth(cboSearchForText);
      }

      /// <summary>
      /// Resize drop down list if necessary
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]    11/21/2005	Created
      /// </history>
      private void cboFilePath_DropDown(object sender, EventArgs e)
      {
         cboFilePath.DropDownWidth = CalculateDropDownWidth(cboFilePath);
      }

      /// <summary>
      /// Resize drop down list if necessary
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]    11/21/2005	Created
      /// </history>
      private void cboFileName_DropDown(object sender, EventArgs e)
      {
         cboFileName.DropDownWidth = CalculateDropDownWidth(cboFileName);
      }

      /// <summary>
      /// Negation check event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/28/2005	Created
      /// [Curtis_Beard]	   06/13/2005	CHG: Gray out file names only when checked
      /// </history>
      private void chkNegation_CheckedChanged(object sender, EventArgs e)
      {
         chkFileNamesOnly.Checked = chkNegation.Checked;
         chkFileNamesOnly.Enabled = !chkNegation.Checked;         
      }

      /// <summary>
      /// File Names Only Check Box Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]   ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   06/13/2005	CHG: Gray out context lines label
      /// </history>
      private void chkFileNamesOnly_CheckedChanged(object sender, EventArgs e)
      {
         if (chkFileNamesOnly.Checked)
         {
            chkLineNumbers.Enabled = false;
            txtContextLines.Enabled = false;
            lblContextLines.Enabled = false;
         }
         else
         {
            chkLineNumbers.Enabled = true;
            txtContextLines.Enabled = true;
            lblContextLines.Enabled = true;
         }
      }

      /// <summary>
      /// Cancel Button Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void btnCancel_Click(object sender, System.EventArgs e)
      {
         if (__Grep != null)
            __Grep.Abort();
      }

      /// <summary>
      /// Search Button Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void btnSearch_Click(object sender, System.EventArgs e)
      {
         if (!VerifyInterface())
            return;

         StartSearch();
      }

      /// <summary>
      /// txtHits Mouse Down Event - Used to detect a double click
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion/Replaced with mouse down
      /// [Curtis_Beard]	   12/07/2005	CHG: Use column constant
      /// [Curtis_Beard]	   07/03/2006	FIX: 1516777, stop right click to open text editor
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      private void txtHits_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left && e.Clicks == 2)
         {
            int lineNumber;
            int hitLineNumber;
            int hitColumn;

            // Make sure there is something to click on.
            if (lstFileNames.SelectedItems.Count == 0)
               return;

            // retrieve the hit object
            HitObject hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.SelectedItems[0].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

            // Find out the line number the cursor is on.
            lineNumber = txtHits.GetLineFromCharIndex(txtHits.SelectionStart);

            // Use the cursor's linenumber to get the hit's line number.
            hitLineNumber = hit.RetrieveLineNumber(lineNumber);

            hitColumn = hit.RetrieveColumn(lineNumber);

            // Retrieve the filename
            string path = hit.FilePath;
            parent.LoadFileInEditor(path);
            // Open the default editor.
            //Common.EditFile(path, hitLineNumber, hitColumn);
         }
      }

      /// <summary>
      /// File Name List Double Click Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   12/07/2005	CHG: Use column constant
      /// [Curtis_Beard]	   07/03/2006	FIX: 1516777, stop right click to open text editor,
      ///                                 changed from DoubleClick event to MouseDown
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      private void lstFileNames_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left && e.Clicks == 2)
         {
            // Make sure there is something to click on
            if (lstFileNames.SelectedItems.Count == 0)
               return;

            // retrieve the hit object
            HitObject hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.SelectedItems[0].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

            // Retrieve the filename
            string path = hit.FilePath;
            parent.LoadFileInEditor(path);
            // Open the default editor.
            //Common.EditFile(path, 1, 1);
         }
      }

      /// <summary>
      /// File Name List Select Index Change Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   12/07/2005	CHG: Use column constant
      /// </history>
      private void lstFileNames_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (lstFileNames.SelectedItems.Count > 0)
         {
            // retrieve hit object
            HitObject hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.SelectedItems[0].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));
            
            HighlightText(hit);
            
            hit = null;
         }
      }

      /// <summary>
      /// Allow sorting of list view columns
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]	   02/06/2005	Created
      /// [Curtis_Beard]	   07/07/2006	CHG: add support for count column sorting
      /// [Curtis_Beard]	   10/06/2006	FIX: clear sort indicator propertly
      /// </history>
      private void lstFileNames_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         // Determine whether the column is the same as the last column clicked.
         if (e.Column != __SortColumn)
         {
            // Remove sort indicator
            if (__SortColumn != -1)
               Windows.API.SetHeaderImage(lstFileNames, __SortColumn, SortOrder.Ascending, false);

            // Set the sort column to the new column.
            __SortColumn = e.Column;

            // Set the sort order to ascending by default.
            lstFileNames.Sorting = SortOrder.Ascending;            
         }
         else
         {
            // Determine what the last sort order was and change it.
            if (lstFileNames.Sorting == SortOrder.Ascending)
               lstFileNames.Sorting = SortOrder.Descending;
            else
               lstFileNames.Sorting = SortOrder.Ascending;
         }

         // set column sort image
         Windows.API.SetHeaderImage(lstFileNames, e.Column, lstFileNames.Sorting, true);

         // Set the ListViewItemSorter property to a new ListViewItemComparer object.
         ListViewItemComparer comparer;

         // set comparer for integer types if the count column, otherwise try date/string
         if (e.Column == Constants.COLUMN_INDEX_COUNT)
            comparer = new ListViewItemComparer(e.Column, lstFileNames.Sorting, true);
         else
            comparer = new ListViewItemComparer(e.Column, lstFileNames.Sorting);

         lstFileNames.ListViewItemSorter = comparer;

         // Call the sort method to manually sort.
         lstFileNames.Sort();
      }

      /// <summary>
      /// Handles setting the ImageList for the ListView control.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		09/08/2006	Created
      /// </history>
      private void lstFileNames_HandleCreated(object sender, EventArgs e)
      {
         Windows.API.SetHeaderImageList(lstFileNames.Handle, ListViewImageList.Handle);
      }

      /// <summary>
      /// Handles setting up the drag event for a selected file.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]		07/25/2006	ADD: 1512028, Drag support
      /// </history>
      private void lstFileNames_ItemDrag(object sender, ItemDragEventArgs e)
      {
         ListViewItem item = (ListViewItem)e.Item;
         string path = item.SubItems[Constants.COLUMN_INDEX_DIRECTORY].Text + 
				System.IO.Path.DirectorySeparatorChar.ToString() + 
				item.SubItems[Constants.COLUMN_INDEX_FILE].Text;

         if (System.IO.File.Exists(path))
         {
            string[] paths = new string[1];
            paths[0] = path;
            DataObject data = new DataObject(DataFormats.FileDrop, paths);

            lstFileNames.DoDragDrop(data, DragDropEffects.Copy);
         }
      }

      /// <summary>
      /// Allows selection of the search path.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]	   11/22/2006	Created
      /// </history>
      private void picBrowse_Click(object sender, System.EventArgs e)
      {
         BrowseForFolder();
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Load the general settings values.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   10/11/2006	Created
      /// [Curtis_Beard]	   11/22/2006	CHG: Remove use of browse in combobox
      /// </history>
      private void LoadSettings()
      {
         //  Only load up to the desired number of paths.
         if (FileSearch.Core.GeneralSettings.MaximumMRUPaths < 0 || FileSearch.Core.GeneralSettings.MaximumMRUPaths > Constants.MAX_STORED_PATHS)
            FileSearch.Core.GeneralSettings.MaximumMRUPaths = Constants.MAX_STORED_PATHS;

         LoadComboBoxEntry(cboFilePath, FileSearch.Core.GeneralSettings.SearchStarts);
         LoadComboBoxEntry(cboFileName, FileSearch.Core.GeneralSettings.SearchFilters);
         LoadComboBoxEntry(cboSearchForText, FileSearch.Core.GeneralSettings.SearchTexts);

         // Path
         if (cboFilePath.Items.Count > 0 && cboFilePath.Items.Count != 1)
            cboFilePath.SelectedIndex = 0;
         
         // Filter
         if (cboFileName.Items.Count == 0)
         {
            // no entries so create defaults
            cboFileName.Items.AddRange(new object[] {"*.*", "*.txt", "*.java", "*.htm, *.html", "*.jsp, *.asp", "*.js, *.inc", "*.htm, *.html, *.jsp, *.asp", "*.sql", "*.bas, *.cls, *.vb", "*.cs", "*.cpp, *.c, *.h", "*.asm"});
         }
         cboFileName.SelectedIndex = 0;

         // Search
         if (cboSearchForText.Items.Count > 0)
            cboSearchForText.SelectedIndex = 0;

         // Result Window Colors
         txtHits.ForeColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
         txtHits.BackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);

         // File list columns
         SetColumnsText();

         LoadWindowSettings();

         // Load the text editors
         Common.LoadTextEditors();
      }

      /// <summary>
      /// Load the window settings.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   06/28/2007	Created
      /// </history>
      private void LoadWindowSettings()
      {
         int _state = FileSearch.Core.GeneralSettings.WindowState;

         // set the top/left
         if (FileSearch.Core.GeneralSettings.WindowTop != -1)
            this.Top = FileSearch.Core.GeneralSettings.WindowTop;
         if (FileSearch.Core.GeneralSettings.WindowLeft != -1)
            this.Left = FileSearch.Core.GeneralSettings.WindowLeft;

         // set the width/height
         if (FileSearch.Core.GeneralSettings.WindowWidth != -1)
            this.Width = FileSearch.Core.GeneralSettings.WindowWidth;
         if (FileSearch.Core.GeneralSettings.WindowHeight != -1)
            this.Height = FileSearch.Core.GeneralSettings.WindowHeight;

         if (_state != -1 && _state == (int)FormWindowState.Maximized)
         {
            this.WindowState = FormWindowState.Maximized;
         }

         // set the splitter positions
         if (FileSearch.Core.GeneralSettings.WindowSearchPanelWidth != -1)
            this.pnlSearch.Width = FileSearch.Core.GeneralSettings.WindowSearchPanelWidth;
         if (FileSearch.Core.GeneralSettings.WindowFilePanelHeight != -1)
            this.lstFileNames.Height = FileSearch.Core.GeneralSettings.WindowFilePanelHeight;
      }

      /// <summary>
      /// Save the general settings values.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   10/11/2006	Created
      /// </history>
      private void SaveSettings()
      {
         SaveWindowSettings();

         //save column widths
         FileSearch.Core.GeneralSettings.WindowFileColumnNameWidth = lstFileNames.Columns[Constants.COLUMN_INDEX_FILE].Width;
         FileSearch.Core.GeneralSettings.WindowFileColumnLocationWidth = lstFileNames.Columns[Constants.COLUMN_INDEX_DIRECTORY].Width;
         FileSearch.Core.GeneralSettings.WindowFileColumnDateWidth = lstFileNames.Columns[Constants.COLUMN_INDEX_DATE].Width;
         FileSearch.Core.GeneralSettings.WindowFileColumnCountWidth = lstFileNames.Columns[Constants.COLUMN_INDEX_COUNT].Width;

         //save divider panel positions
         FileSearch.Core.GeneralSettings.WindowSearchPanelWidth = pnlSearch.Width;
         FileSearch.Core.GeneralSettings.WindowFilePanelHeight = lstFileNames.Height;

         //save search comboboxes
         FileSearch.Core.GeneralSettings.SearchStarts = Common.GetComboBoxEntriesAsString(cboFilePath);
         FileSearch.Core.GeneralSettings.SearchFilters = Common.GetComboBoxEntriesAsString(cboFileName);
         FileSearch.Core.GeneralSettings.SearchTexts = Common.GetComboBoxEntriesAsString(cboSearchForText);

         FileSearch.Core.GeneralSettings.Save();
      }

      /// <summary>
      /// Save the window settings in the config.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   06/28/2007	Created
      /// </history>
      private void SaveWindowSettings()
      {
         if (this.WindowState == FormWindowState.Normal)
         {
            FileSearch.Core.GeneralSettings.WindowLeft = this.Left;
            FileSearch.Core.GeneralSettings.WindowTop = this.Top;
            FileSearch.Core.GeneralSettings.WindowWidth = this.Width;
            FileSearch.Core.GeneralSettings.WindowHeight = this.Height;
            FileSearch.Core.GeneralSettings.WindowState = (int)this.WindowState;
         }
         else
         {
            // just save the state, so that previous normal dimensions are valid
            FileSearch.Core.GeneralSettings.WindowState = (int)this.WindowState;
         }
      }

      /// <summary>
      /// Loads the given System.Windows.Forms.ComboBox with the values.
      /// </summary>
      /// <param name="combo">System.Windows.Forms.ComboBoxy</param>
      /// <param name="values">string of the values to load</param>
      /// <history>
      /// [Curtis_Beard]	   10/11/2006	Created
      /// [Curtis_Beard]	   11/22/2006	CHG: Remove use of browse in combobox
      /// </history>
      private void LoadComboBoxEntry(System.Windows.Forms.ComboBox combo, string values)
      {
         if (!values.Equals(string.Empty))
         {
            string[] items = Common.GetComboBoxEntriesFromString(values);
         
            if (items.Length > 0)
            {
               int start = items.Length;
               if (start > FileSearch.Core.GeneralSettings.MaximumMRUPaths)
                  start = FileSearch.Core.GeneralSettings.MaximumMRUPaths;

               combo.BeginUpdate();
               for (int i = start - 1; i > -1; i--)
               {
                  AddComboSelection(combo, items[i]);
               }
               combo.EndUpdate();
            }
         }
      }

      /// <summary>
      /// Set the Common Search Settings on the form
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   01/28/2005	Created
      /// [Curtis_Beard]	   10/10/2006	CHG: Use search settings implementation.
      /// </history>
      private void LoadSearchSettings()
      {
         chkRegularExpressions.Checked = FileSearch.Core.SearchSettings.UseRegularExpressions;
         chkCaseSensitive.Checked = FileSearch.Core.SearchSettings.UseCaseSensitivity;
         chkWholeWordOnly.Checked = FileSearch.Core.SearchSettings.UseWholeWordMatching;
         chkLineNumbers.Checked = FileSearch.Core.SearchSettings.IncludeLineNumbers;
         chkRecurse.Checked = FileSearch.Core.SearchSettings.UseRecursion;
         chkFileNamesOnly.Checked = FileSearch.Core.SearchSettings.ReturnOnlyFileNames;
         txtContextLines.Text = FileSearch.Core.SearchSettings.ContextLines.ToString();
         chkNegation.Checked = FileSearch.Core.SearchSettings.UseNegation;
      }

      /// <summary>
      /// Save the search options.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   10/11/2006	Created
      /// </history>
      private void SaveSearchSettings()
      {
         FileSearch.Core.SearchSettings.UseRegularExpressions = chkRegularExpressions.Checked;
         FileSearch.Core.SearchSettings.UseCaseSensitivity = chkCaseSensitive.Checked;
         FileSearch.Core.SearchSettings.UseWholeWordMatching = chkWholeWordOnly.Checked;
         FileSearch.Core.SearchSettings.IncludeLineNumbers = chkLineNumbers.Checked;
         FileSearch.Core.SearchSettings.UseRecursion = chkRecurse.Checked;
         FileSearch.Core.SearchSettings.ReturnOnlyFileNames = chkFileNamesOnly.Checked;
         FileSearch.Core.SearchSettings.ContextLines = int.Parse(txtContextLines.Text);
         FileSearch.Core.SearchSettings.UseNegation = chkNegation.Checked;

         FileSearch.Core.SearchSettings.Save();
      }

      /// <summary>
      /// Show/Hide the Search Options Panel
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   02/05/2005	Created
      /// </history>
      private void ShowSearchOptions()
      {
         if (__OptionsShow)
         {
            // hide and set text
            lnkSearchOptions.Text = String.Format(__SearchOptionsText, ">>");
            lnkSearchOptions.LinkBehavior = LinkBehavior.AlwaysUnderline;
            lnkSearchOptions.BackColor = SystemColors.Window;
            lnkSearchOptions.LinkColor = SystemColors.HotTrack;
            lnkSearchOptions.ActiveLinkColor = SystemColors.HotTrack;

            pnlSearchOptions.BackColor = SystemColors.Window;
            pnlSearchOptions.BorderStyle = BorderStyle.None;
            PanelOptionsContainer.Visible = false;
            pnlSearch.AutoScroll = false;

            __OptionsShow = false;
         }
         else
         {
            // set text
            lnkSearchOptions.Text = String.Format(__SearchOptionsText, "<<");
            lnkSearchOptions.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSearchOptions.BackColor = SystemColors.ActiveCaption;
            lnkSearchOptions.LinkColor = SystemColors.ActiveCaptionText;
            lnkSearchOptions.ActiveLinkColor = SystemColors.ActiveCaptionText;

            pnlSearchOptions.BackColor = SystemColors.Window;
            PanelOptionsContainer.Visible = true;
            pnlSearch.AutoScroll = true;
            pnlSearchOptions.BringToFront();

            __OptionsShow = true;
         }
      }

      /// <summary>
      /// Sets the file list's columns' text to the correct language.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/25/2006	Created
      /// </history>
      private void SetColumnsText()
      {
         if (lstFileNames.Columns.Count == 0)
         {
            lstFileNames.Columns.Add(Language.GetGenericText("ResultsColumnFile"), FileSearch.Core.GeneralSettings.WindowFileColumnNameWidth, HorizontalAlignment.Left);
            lstFileNames.Columns.Add(Language.GetGenericText("ResultsColumnLocation"), FileSearch.Core.GeneralSettings.WindowFileColumnLocationWidth, HorizontalAlignment.Left);
            lstFileNames.Columns.Add(Language.GetGenericText("ResultsColumnDate"), FileSearch.Core.GeneralSettings.WindowFileColumnDateWidth, HorizontalAlignment.Left);
            lstFileNames.Columns.Add(Language.GetGenericText("ResultsColumnCount"), FileSearch.Core.GeneralSettings.WindowFileColumnCountWidth, HorizontalAlignment.Left);
         }
         else
         {
            lstFileNames.Columns[Constants.COLUMN_INDEX_FILE].Text = Language.GetGenericText("ResultsColumnFile");
            lstFileNames.Columns[Constants.COLUMN_INDEX_DIRECTORY].Text = Language.GetGenericText("ResultsColumnLocation");
            lstFileNames.Columns[Constants.COLUMN_INDEX_DATE].Text = Language.GetGenericText("ResultsColumnDate");
            lstFileNames.Columns[Constants.COLUMN_INDEX_COUNT].Text = Language.GetGenericText("ResultsColumnCount");
         }
      }

      /// <summary>
      /// Verify user selected options
      /// </summary>
      /// <returns>True - Verified, False - Otherwise</returns>
      /// <history>
      /// [Theodore_Ward]   ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   10/14/2005	CHG: Use max context lines constant in message
      /// </history>
      private bool VerifyInterface()
      {
         try
         {
            try
            {
               int _lines = int.Parse(txtContextLines.Text);
               if (_lines < 0 || _lines > Constants.MAX_CONTEXT_LINES)
               {
                  MessageBox.Show(String.Format(Language.GetGenericText("VerifyErrorContextLines"), 0, Constants.MAX_CONTEXT_LINES.ToString()),
                     Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return false;
               }
            }
            catch
            {
               MessageBox.Show(String.Format(Language.GetGenericText("VerifyErrorContextLines"), 0, Constants.MAX_CONTEXT_LINES.ToString()),
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }

            if (cboFileName.Text.Trim().Equals(string.Empty))
            {
               MessageBox.Show(Language.GetGenericText("VerifyErrorFileType"), 
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }

            if (cboFilePath.Text.Trim().Equals(string.Empty))
            {
               MessageBox.Show(Language.GetGenericText("VerifyErrorNoStartPath"),
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }

            if (!System.IO.Directory.Exists(cboFilePath.Text.Trim()))
            {
               MessageBox.Show(String.Format(Language.GetGenericText("VerifyErrorInvalidStartPath"), cboFilePath.Text),
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }

            if (cboSearchForText.Text.Trim().Equals(string.Empty))
            {
               MessageBox.Show(Language.GetGenericText("VerifyErrorNoSearchText"),
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }
         }
         catch
         {
            MessageBox.Show(Language.GetGenericText("VerifyErrorGeneric"),
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
         }

         return true;
      }

      /// <summary>
      /// Add an item to a combo box
      /// </summary>
      /// <param name="combo">Combo Box</param>
      /// <param name="item">Item to add</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   05/09/2007	CHG: check for a valid item
      /// </history>
      private void AddComboSelection(System.Windows.Forms.ComboBox combo, string item)
      {
         if (item.Length > 0)
         {
            // If this path is already in the dropdown, remove it.
            combo.Items.Remove(item);

            // Add this path as the first item in the dropdown.
            combo.Items.Insert(0, item);

            // The combo text gets cleared by the AddItem.
            combo.Text = item;

            // Only store as many paths as has been set in options.
            //if (combo.Items.Count > Common.NUM_STORED_PATHS)
            if (combo.Items.Count > FileSearch.Core.GeneralSettings.MaximumMRUPaths)
            {
               // Remove the last item in the list.
               combo.Items.RemoveAt(combo.Items.Count - 1);
            }
         }
      }      

      /// <summary>
      /// Highlight the searched text in the results
      /// </summary>
      /// <param name="hit">Hit Object containing results</param>
      /// <history>
      /// [Curtis_Beard]	   01/27/2005	Created
      /// [Curtis_Beard]	   04/12/2005	FIX: 1180741, Don't capitalize hit line
      /// [Curtis_Beard]	   11/18/2005	ADD: custom highlight colors
      /// [Curtis_Beard] 	   12/06/2005	CHG: call WholeWordOnly from Grep class
      /// [Curtis_Beard] 	   04/21/2006	CHG: highlight regular expression searches
      /// [Curtis_Beard] 	   09/28/2006	FIX: use grep object for settings instead of gui items
      /// </history>
      private void HighlightText(HitObject hit)
      {
         string _textToSearch = string.Empty;
         string _searchText = __Grep.SearchText;
         int _index = 0;
         string _tempLine = string.Empty;

         string _begin = string.Empty;
         string _text = string.Empty;
         string _end = string.Empty;
         int _pos = 0;
         bool _highlight = false;

         // Clear the contents
         txtHits.Text = string.Empty;
         txtHits.ForeColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
         txtHits.BackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);

         if (__Grep.UseRegularExpressions)
            HighlightTextRegEx(hit);
         else
         {
            // Loop through hits and highlight search for text
            for (_index = 0; _index < hit.LineCount; _index++)
            {
               // Retrieve hit text
               _textToSearch = hit.RetrieveLine(_index);

               // Set default font
               txtHits.SelectionFont = new Font("Courier New", 9.75F, FontStyle.Regular);

               _tempLine = _textToSearch;

               // attempt to locate the text in the line
               if (__Grep.UseCaseSensitivity)
                  _pos = _tempLine.IndexOf(_searchText);
               else
                  _pos = _tempLine.ToLower().IndexOf(_searchText.ToLower());

               if (_pos > -1)
               {
                  do
                  {
                     _highlight = false;

                     //
                     // retrieve parts of text
                     _begin = _tempLine.Substring(0, _pos);
                     _text = _tempLine.Substring(_pos, _searchText.Length);
                     _end = _tempLine.Substring(_pos + _searchText.Length);

                     // set default color for starting text
                     txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
                     // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
                     txtHits.SelectedText = _begin;

                     // do a check to see if begin and end are valid for wholeword searches
                     if (__Grep.UseWholeWordMatching)
                        _highlight = Grep.WholeWordOnly(_begin, _end);
                     else
                        _highlight = true;

                     // set highlight color for searched text
                     if (_highlight)
                     {
                        txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.HighlightForeColor);
                        // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.HighlightBackColor);
                     }
                     txtHits.SelectedText = _text;

                     // Check remaining string for other hits in same line
                     if (__Grep.UseCaseSensitivity)
                        _pos = _end.IndexOf(_searchText);
                     else
                        _pos = _end.ToLower().IndexOf(_searchText.ToLower());

                     // set default color for end, if no more hits in line
                     _tempLine = _end;
                     if (_pos < 0)
                     {
                        txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
                        // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
                        txtHits.SelectedText = _end;
                     }

                  }while (_pos > -1);
               }
               else
               {
                  // set default color, no search text found
                  txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
                  // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
                  txtHits.SelectedText = _textToSearch;
               }
            }
         }
      }

      /// <summary>
      /// Highlight the searched text in the results when using regular expressions
      /// </summary>
      /// <param name="hit">Hit Object containing results</param>
      /// <history>
      /// [Curtis_Beard]	   04/21/2006	Created
      /// [Curtis_Beard]	   05/11/2006	FIX: Include context lines if present and prevent system beep
      /// [Curtis_Beard]	   07/07/2006	FIX: 1512029, highlight whole word and case sensitive matches
      /// [Curtis_Beard] 	   09/28/2006	FIX: use grep object for settings instead of gui items, remove searchText parameter
      /// [Curtis_Beard]	   05/18/2006	FIX: 1723815, use correct whole word matching regex
      /// </history>
      private void HighlightTextRegEx(HitObject hit)
      {
         string _textToSearch = string.Empty;
         string _tempString = string.Empty;
         int _index = 0;
         int _lastPos = 0;
         int _counter = 0;
         Regex _regEx = new Regex(__Grep.SearchText);
         MatchCollection _col;
         Match _item;

         // Loop through hits and highlight search for text
         for (_index = 0; _index < hit.LineCount; _index++)
         {
            // Retrieve hit text
            _textToSearch = hit.RetrieveLine(_index);

            // Set default font
            txtHits.SelectionFont = new Font("Courier New", 9.75F, FontStyle.Regular);

            // find all reg ex matches in line
            if (__Grep.UseCaseSensitivity && __Grep.UseWholeWordMatching)
            {
               _regEx = new Regex("\\b" + __Grep.SearchText + "\\b");
               _col = _regEx.Matches(_textToSearch);
            }
            else if (__Grep.UseCaseSensitivity)
            {
               _regEx = new Regex(__Grep.SearchText);
               _col = _regEx.Matches(_textToSearch);
            }
            else if (__Grep.UseWholeWordMatching)
            {
               _regEx = new Regex("\\b" + __Grep.SearchText + "\\b", RegexOptions.IgnoreCase);
               _col = _regEx.Matches(_textToSearch);
            }
            else
            {
               _regEx = new Regex(__Grep.SearchText, RegexOptions.IgnoreCase);
               _col = _regEx.Matches(_textToSearch);
            }

            // loop through the matches
            _lastPos = 0;
            for (_counter = 0; _counter < _col.Count; _counter++)
            {
               _item = _col[_counter];

               // set the start text
               txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
               // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);

               // check for empty string to prevent assigning nothing to selection text preventing
               //  a system beep
               _tempString = _textToSearch.Substring(_lastPos, _item.Index - _lastPos);
               if (!_tempString.Equals(string.Empty))
                  txtHits.SelectedText = _tempString;

               // set the hit text
               txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.HighlightForeColor);
               // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.HighlightBackColor);
               txtHits.SelectedText = _textToSearch.Substring(_item.Index, _item.Length);

               // set the end text
               txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
               // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
               if (_counter + 1 >= _col.Count)
               {
                  //  no more hits so just set the rest
                  txtHits.SelectedText = _textToSearch.Substring(_item.Index + _item.Length);
                  _lastPos = _item.Index + _item.Length;
               }
               else
               {
                  // another hit so just set inbetween
                  txtHits.SelectedText = _textToSearch.Substring(_item.Index + _item.Length, _col[_counter + 1].Index - (_item.Index + _item.Length));
                  _lastPos = _col[_counter + 1].Index;
               }
            }

            if (_col.Count == 0)
            {
               //  no match, just a context line
               txtHits.SelectionColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
               // txtHits.SelectionBackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
               txtHits.SelectedText = _textToSearch;
            }
         }
      }

      /// <summary>
      /// Enable/Disable menu items (Thread safe)
      /// </summary>
      /// <param name="enable">True - enable menu items, False - disable</param>
      /// <history>
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   07/10/2006	CHG: Disable combo boxes during search
      /// [Curtis_Beard]	   07/12/2006	CHG: make thread safe
      /// [Curtis_Beard]	   07/25/2006	ADD: enable/disable context lines label
      /// </history>
      private void SetSearchState(bool enable)
      {
         if (this.InvokeRequired)
         {
            SetSearchStateCallBack _delegate = new SetSearchStateCallBack(SetSearchState);
            this.Invoke(_delegate, new Object[1] {enable});
            return;
         }

         mnuFile.Enabled = enable;
         mnuEdit.Enabled = enable;
         mnuTools.Enabled = enable;
         mnuHelp.Enabled = enable;

         btnSearch.Enabled = enable;
         btnCancel.Enabled = !enable;
         picBrowse.Enabled = enable;
         pnlSearchOptions.Enabled = enable;
         lblContextLines.Enabled = enable;

         cboFileName.Enabled = enable;
         cboFilePath.Enabled = enable;
         cboSearchForText.Enabled = enable;

         if (enable)
            btnSearch.Focus();
         else
            btnCancel.Focus();

      }

      /// <summary>
      /// Open Browser for Folder dialog
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/13/2005	ADD: Initial
      /// [Curtis_Beard]		10/02/2006	FIX: Clear ComboBox when only Browse... is present
      /// [Curtis_Beard]		11/22/2006	CHG: Remove use of browse in combobox
      /// [Justin_Dearing]		05/06/2007	CHG: Dialog defaults to the folder selected in the combobox.
      /// [Curtis_Beard]		05/23/2007	CHG: Remove cancel highlight
      /// </history>
      private void BrowseForFolder()
      {
         FolderBrowserDialog dlg = new FolderBrowserDialog();
         dlg.Description = Language.GetGenericText("OpenFolderDescription");
         dlg.ShowNewFolderButton = false;

         // set initial directory if valid
         if (System.IO.Directory.Exists(cboFilePath.Text)) 
         {
            dlg.SelectedPath = cboFilePath.Text;
         }
         
         // display dialog and setup path if selected
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            AddComboSelection(cboFilePath, dlg.SelectedPath);
         }
      }

      /// <summary>
      /// Calculates the width of the drop down list of the given combo box
      /// </summary>
      /// <param name="combo">Combo box to base calculate from</param>
      /// <returns>Width of longest string in combo box items</returns>
      /// <history>
      /// [Curtis_Beard]    11/21/2005	Created
      /// </history>
      private int CalculateDropDownWidth(ComboBox combo)
      {
         const int EXTRA = 10;

         Graphics g = combo.CreateGraphics();
         int _max = combo.Width;
         string _itemValue = string.Empty;
         SizeF _size;

         foreach (object _item in combo.Items)
         {
            _itemValue = _item.ToString();
            _size = g.MeasureString(_itemValue, combo.Font);

            if (_size.Width > _max)
               _max = Convert.ToInt32(_size.Width);
         }

         // keep original width if no item longer
         if (_max != combo.Width)
            _max += EXTRA;

         return _max;
      }

      /// <summary>
      /// Truncate the given file's name if it is to long to fit in the given status bar
      /// </summary>
      /// <param name="file">FileInfo object to measure</param>
      /// <param name="status">StatusBar to measure against</param>
      /// <returns>file name or truncated file name if to long</returns>
      /// <history>
      /// [Curtis_Beard]	   04/21/2006	Created, fixes bug 1367852
      /// </history>
      private string TruncateFileName(System.IO.FileInfo file, StatusBar status)
      {
         const int EXTRA = 20;     //used for spacing of the sizer
         Graphics g = status.CreateGraphics();
         int _strLen = 0;
         string _name = file.FullName;

         _strLen = Convert.ToInt32(g.MeasureString(_name, status.Font).Width);
         if (_strLen >= (status.Width - EXTRA))
         {
            // truncate to just the root name and the file name (for now)
            _name = file.Directory.Root.Name + @"...\" + file.Name;
         }

         g.Dispose();

         return _name;
      }

      /// <summary>
      /// Processes any command line arguments
      /// </summary>
      /// <param name="args">CommandLineProcessing.CommandLineArguments</param>
      /// <history>
      /// [Curtis_Beard]		07/25/2006	ADD: 1492221, command line parameters
      /// [Curtis_Beard]		05/18/2007	CHG: adapt to new processing
      /// </history>
      private void ProcessCommandLine(CommandLineProcessing.CommandLineArguments args)
      {
         if (args.AnyArguments)
         {
            //if (args.IsProjectFile)
               //LoadProjectFile(args.ProjectFile);

            if (args.IsValidStartPath)
               AddComboSelection(cboFilePath, args.StartPath);

            if (args.IsValidFileTypes)
               AddComboSelection(cboFileName, args.FileTypes);

            if (args.IsValidSearchText)
               AddComboSelection(cboSearchForText, args.SearchText);

            // turn on option if specified (options default to last saved otherwise)
            if (args.UseRegularExpressions)
               chkRegularExpressions.Checked = true;
            if (args.IsCaseSensitive)
               chkCaseSensitive.Checked = true;
            if (args.IsWholeWord)
               chkWholeWordOnly.Checked = true;
            if (args.UseRecursion)
               chkRecurse.Checked = true;
            if (args.IsFileNamesOnly)
               chkFileNamesOnly.Checked = true;
            if (args.IsNegation)
               chkNegation.Checked = true;
            if (args.UseLineNumbers)
               chkLineNumbers.Checked = true;
            if (args.ContextLines > -1)
               txtContextLines.Value = args.ContextLines;
            //if (args.SkipHidden)
            //   chkSkipHidden.Checked = true;
            //if (args.SkipSystem)
            //   chkSkipSystem.Checked = true;

            // keep last to ensure all options are set before a search begins
            if (args.StartSearch)
            {
               btnSearch_Click(null, null);
               this.Show();
               this.Refresh();
            }
         }
      }

      /// <summary>
      /// Save results to a text file
      /// </summary>
      /// <param name="path">Fully qualified file path</param>
      /// <history>
      /// [Curtis_Beard]		09/06/2006	Created
      /// </history>
      private void SaveResultsAsText(string path)
      {
         System.IO.StreamWriter writer = null;

         try
         {
            // Open the file
            writer = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);

            SetStatusBarMessage(String.Format(Language.GetGenericText("SaveSaving"), path));

            // loop through File Names list
            for (int _index = 0; _index < lstFileNames.Items.Count; _index++)
            {
               HitObject _hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.Items[_index].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

               // write info to a file
               writer.WriteLine("-------------------------------------------------------------------------------");
               writer.WriteLine(_hit.FilePath);
               writer.WriteLine("-------------------------------------------------------------------------------");
               writer.Write(_hit.Lines);
               writer.WriteLine("");

               // clear hit object
               _hit = null;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(String.Format(Language.GetGenericText("SaveError"), ex.ToString()), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // Close file
            if (writer != null)
            {
               writer.Flush();
               writer.Close();
            }

            SetStatusBarMessage(Language.GetGenericText("SaveSaved"));
         }
      }

      /// <summary>
      /// Save results to a html file
      /// </summary>
      /// <param name="path">Fully qualified file path</param>
      /// <history>
      /// [Curtis_Beard]		09/06/2006	Created
      /// </history>
      private void SaveResultsAsHTML(string path)
      {
         System.IO.StreamWriter writer = null;

         try
         {
            SetStatusBarMessage(string.Format(Language.GetGenericText("SaveSaving"), path));

            // Open the file
            writer = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);

            string repeat = string.Empty;
            string repeatSection;
            System.Text.StringBuilder allSections = new System.Text.StringBuilder();
            string repeater;
            System.Text.StringBuilder lines = new System.Text.StringBuilder();
            string template = HTMLHelper.GetContents("Output.html");
            string css = HTMLHelper.GetContents("Output.css");
            int totalHits = 0;

            if (__Grep.ReturnOnlyFileNames)
               template = HTMLHelper.GetContents("Output-fileNameOnly.html");

            css = HTMLHelper.ReplaceCssHolders(css);
            template = template.Replace("%%style%%", css);
            template = template.Replace("%%title%%", "FileSearch Results");

            int rStart = template.IndexOf("[repeat]");
            int rStop = template.IndexOf("[/repeat]") + "[/repeat]".Length;
            repeat = template.Substring(rStart, rStop - rStart);

            repeatSection = repeat;
            repeatSection = repeatSection.Replace("[repeat]", string.Empty);
            repeatSection = repeatSection.Replace("[/repeat]", string.Empty);

            // loop through File Names list
            for (int _index = 0; _index < lstFileNames.Items.Count; _index++)
            {
               HitObject _hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.Items[_index].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

               lines = new System.Text.StringBuilder();
               repeater = repeatSection;
               repeater = repeater.Replace("%%file%%", _hit.FilePath);
               totalHits += _hit.HitCount;

               for (int _jIndex = 0; _jIndex < _hit.LineCount; _jIndex++)
                  lines.Append(HTMLHelper.GetHighlightLine(_hit.RetrieveLine(_jIndex), __Grep));

               repeater = repeater.Replace("%%lines%%", lines.ToString());

               // clear hit object
               _hit = null;

               allSections.Append(repeater);
            }

            template = template.Replace(repeat, allSections.ToString());
            template = template.Replace("%%totalhits%%", totalHits.ToString());
            template = HTMLHelper.ReplaceSearchOptions(template, __Grep);

            // write out template to the file
            writer.WriteLine(template);
         }
         catch (Exception ex)
         {
            MessageBox.Show(string.Format(Language.GetGenericText("SaveError"), ex.ToString()), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // Close file
            if (writer != null)
            {
               writer.Flush();
               writer.Close();
            }

            SetStatusBarMessage(Language.GetGenericText("SaveSaved"));
         }
      }

      /// <summary>
      /// Save results to a xml file
      /// </summary>
      /// <param name="path">Fully qualified file path</param>
      /// <history>
      /// [Curtis_Beard]		09/06/2006	Created
      /// </history>
      private void SaveResultsAsXML(string path)
      {
         System.Xml.XmlTextWriter writer = null;

         try
         {
            SetStatusBarMessage(string.Format(Language.GetGenericText("SaveSaving"), path));

            // Open the file
            writer = new System.Xml.XmlTextWriter(path, System.Text.Encoding.UTF8);
            writer.Formatting = System.Xml.Formatting.Indented;

            writer.WriteStartDocument(true);
            writer.WriteStartElement("astrogrep");
            writer.WriteAttributeString("version", "1.0");

            // write out search options
            writer.WriteStartElement("options");
            writer.WriteElementString("searchPath", __Grep.StartDirectory);
            writer.WriteElementString("fileTypes", __Grep.FileFilter);
            writer.WriteElementString("searchText", __Grep.SearchText);
            writer.WriteElementString("regularExpressions", __Grep.UseRegularExpressions.ToString());
            writer.WriteElementString("caseSensitive", __Grep.UseCaseSensitivity.ToString());
            writer.WriteElementString("wholeWord", __Grep.UseWholeWordMatching.ToString());
            writer.WriteElementString("recurse", __Grep.UseRecursion.ToString());
            writer.WriteElementString("showFileNamesOnly", __Grep.ReturnOnlyFileNames.ToString());
            writer.WriteElementString("negation", __Grep.UseNegation.ToString());
            writer.WriteElementString("lineNumbers", __Grep.IncludeLineNumbers.ToString());
            writer.WriteElementString("contextLines", __Grep.ContextLines.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("search");
            writer.WriteAttributeString("totalfiles", __Grep.Greps.Count.ToString());

            // get total hits
            int totalHits = 0;
            for (int _index = 0; _index < lstFileNames.Items.Count; _index++)
            {
               HitObject _hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.Items[_index].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

               // add to total
               totalHits += _hit.HitCount;

               // clear hit object
               _hit = null;
            }
            writer.WriteAttributeString("totalfound", totalHits.ToString());

            for (int _index = 0; _index < lstFileNames.Items.Count; _index++)
            {
               writer.WriteStartElement("item");
               HitObject _hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.Items[_index].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

               writer.WriteAttributeString("file", _hit.FilePath);
               writer.WriteAttributeString("total", _hit.HitCount.ToString());

               // write out lines
               for (int _jIndex = 0; _jIndex < _hit.LineCount; _jIndex++)
                  writer.WriteElementString("line", _hit.RetrieveLine(_jIndex));

               // clear hit object
               _hit = null;

               writer.WriteEndElement();
            }

            writer.WriteEndElement();   //search
            writer.WriteEndElement();   //astrogrep
         }
         catch (Exception ex)
         {
            MessageBox.Show(string.Format(Language.GetGenericText("SaveError"), ex.ToString()), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // Close file
            if (writer != null)
            {
               writer.Flush();
               writer.Close();
            }

            SetStatusBarMessage(Language.GetGenericText("SaveSaved"));
         }
      }

      /// <summary>
      /// Set the view states of the controls.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]      05/16/2007  ADD: created
      /// </history>
      private void LoadViewStates()
      {
         // set view state of results preview
         //if (Core.GeneralSettings.ShowResultsPreview)
         //{
            __FileListHeight = Core.GeneralSettings.WindowFilePanelHeight;
         //}
         //txtHits.Visible = !Core.GeneralSettings.ShowResultsPreview;
         //mnuViewPreview_Click(null, null);
         //if (!Core.GeneralSettings.ShowResultsPreview)
         //{
         //  __FileListHeight = Core.GeneralSettings.DEFAULT_FILE_PANEL_HEIGHT;
         //}

         // Set view state of status bar
         //mnuViewStatusBar.Checked = Core.GeneralSettings.ShowStatusBar;
         //stbStatus.Visible = Core.GeneralSettings.ShowStatusBar;
      }

      #endregion

      #region Menu Events
      /// <summary>
      /// Enable/Disable menu items if listview contains items
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]      11/03/2005	Created
      /// </history>
      private void mnuFile_Select(object sender, EventArgs e)
      {
         if (lstFileNames.Items.Count == 0)
         {
            mnuSaveResults.Enabled = false;
            mnuPrintResults.Enabled = false;
         }
         else
         {
            mnuSaveResults.Enabled = true;
            mnuPrintResults.Enabled = true;
         }
      }

      /// <summary>
      /// Select a folder for the search path.
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]	   11/22/2006	Created
      /// </history>
      private void mnuBrowse_Click(object sender, System.EventArgs e)
      {
         BrowseForFolder();
      }

      /// <summary>
      /// Save the results to a file
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/11/2005	Initial
      /// [Curtis_Beard]	   10/14/2005	CHG: use No Results for message box title 
      /// [Curtis_Beard]	   12/07/2005	CHG: Use column constant
      /// [Curtis_Beard]	   09/06/2006	CHG: Update to support html and xml output
      /// </history>
      private void mnuSaveResults_Click(object sender, System.EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.CheckPathExists = true;
         dlg.AddExtension = true;
         dlg.Title = Language.GetGenericText("SaveDialogTitle");
         dlg.Filter = "Text (*.txt)|*.txt|HTML (*.html)|*.html|XML (*.xml)|*.xml";

         // only show dialog if information to save
         if (lstFileNames.Items.Count > 0)
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               switch (dlg.FilterIndex)
               {
                  case 1:
                     // Save to text
                     SaveResultsAsText(dlg.FileName);
                     break;
                  case 2:
                     // Save to html
                     SaveResultsAsHTML(dlg.FileName);
                     break;
                  case 3:
                     // Save to xml
                     SaveResultsAsXML(dlg.FileName);
                     break;
               }
            }
         }
         else
            MessageBox.Show(Language.GetGenericText("SaveNoResults"), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      /// <summary>
      /// Show Print Dialog
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   09/10/2005	CHG: pass in listView and grep hashtable
      /// [Curtis_Beard]	   10/14/2005	CHG: use No Results for message box title
      /// [Curtis_Beard]	   12/07/2005	CHG: Pass in font name and size to print dialog
      /// [Curtis_Beard]	   10/11/2006	CHG: Pass in font and icon
      /// </history>
      private void mnuPrintResults_Click(object sender, System.EventArgs e)
      {
         if (lstFileNames.Items.Count > 0)
         {
            frmPrint _form = new frmPrint(lstFileNames, __Grep.Greps, txtHits.Font, this.Icon);
            _form.ShowDialog(this);
            _form = null;
         }
         else
            MessageBox.Show(Language.GetGenericText("PrintNoResults"), Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      /// <summary>
      /// Menu Exit
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void mnuExit_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      /// <summary>
      /// Enable/Disable menu items if listview contains items
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]      11/03/2005	Created
      /// </history>
      private void mnuEdit_Select(object sender, EventArgs e)
      {
         if (lstFileNames.Items.Count == 0)
         {
            mnuSelectAll.Enabled = false;
            mnuOpenSelected.Enabled = false;
         }
         else
         {
            mnuSelectAll.Enabled = true;
            mnuOpenSelected.Enabled = true;
         }
      }

      /// <summary>
      /// Menu Select All Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void mnuSelectAll_Click(object sender, System.EventArgs e)
      {
         for (int i = 0; i < lstFileNames.Items.Count; i++)
            lstFileNames.Items[i].Selected = true;
      }

      /// <summary>
      /// Open Selected Files Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   12/07/2005	CHG: Use column constant
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      private void mnuOpenSelected_Click(object sender, System.EventArgs e)
      {
         string path;
         HitObject hit;

         for (int i = 0; i < lstFileNames.SelectedItems.Count; i++)
         {
            // retrieve hit object
            hit = __Grep.RetrieveHitObject(int.Parse(lstFileNames.SelectedItems[i].SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text));

            // retrieve the filename
            path = hit.FilePath;
            parent.LoadFileInEditor(path);
            // open the default editor
            //Common.EditFile(path, 1, 1);
         }
      }

      /// <summary>
      /// Clear MRU Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   11/22/2006	CHG: Remove use of browse in combobox
      /// </history>
      private void mnuClearMRU_Click(object sender, System.EventArgs e)
      {
         cboFilePath.Items.Clear();
         cboFileName.Items.Clear();
         cboSearchForText.Items.Clear();

         FileSearch.Core.GeneralSettings.SearchStarts = string.Empty;
         FileSearch.Core.GeneralSettings.SearchFilters = string.Empty;
         FileSearch.Core.GeneralSettings.SearchTexts = string.Empty;
         FileSearch.Core.GeneralSettings.Save();
      }

      /// <summary>
      /// Save Search Settings Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/28/2005	Created
      /// </history>
      private void mnuSaveSearchSettings_Click(object sender, System.EventArgs e)
      {
         if (VerifyInterface())
         {
            SaveSearchSettings();
         }
      }      

      /// <summary>
      /// Menu Options Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]		??/??/????  Initial
      /// [Curtis_Beard]		01/11/2005	.Net Conversion
      /// [Curtis_Beard]		11/10/2006	ADD: Update combo boxes and language changes
      /// [Curtis_Beard]		11/22/2006	CHG: Remove use of browse in combobox
      /// [Curtis_Beard]		05/22/2007	FIX: 1723814, rehighlight the selected result
      /// </history>
      private void mnuOptions_Click(object sender, System.EventArgs e)
      {
         frmOptions _form = new frmOptions();

         if (_form.ShowDialog(this) == DialogResult.OK)
         {
            //update combobox lengths
            while (cboFilePath.Items.Count > FileSearch.Core.GeneralSettings.MaximumMRUPaths)
               cboFilePath.Items.RemoveAt(cboFilePath.Items.Count - 1);
            while (cboFileName.Items.Count > FileSearch.Core.GeneralSettings.MaximumMRUPaths)
               cboFileName.Items.RemoveAt(cboFileName.Items.Count - 1);
            while (cboSearchForText.Items.Count > FileSearch.Core.GeneralSettings.MaximumMRUPaths)
               cboSearchForText.Items.RemoveAt(cboSearchForText.Items.Count - 1);

            // load new language if necessary
            if (_form.IsLanguageChange)
            {
               Language.Load(Core.GeneralSettings.Language);
               Language.ProcessForm(this, this.toolTip1);

               SetColumnsText();

               // reload label
               __SearchOptionsText = lnkSearchOptions.Text;
               if (!__OptionsShow)
                  lnkSearchOptions.Text = String.Format(__SearchOptionsText, ">>");
               else
                  lnkSearchOptions.Text = String.Format(__SearchOptionsText, "<<");

               // clear statusbar text
               stbStatus.Text = string.Empty;
            }

            // change results display and rehighlight
            txtHits.ForeColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsForeColor);
            txtHits.BackColor = Common.ConvertStringToColor(FileSearch.Core.GeneralSettings.ResultsBackColor);
            lstFileNames_SelectedIndexChanged(null, null);
         }
         _form = null;
      }

      /// <summary>
      /// Menu About Event
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]		??/??/????  Initial
      /// [Curtis_Beard]		01/11/2005	.Net Conversion
      /// </history>
      private void mnuAbout_Click(object sender, System.EventArgs e)
      {
         frmAbout _form = new frmAbout();

         _form.ShowDialog(this);
         _form = null;
      }
      #endregion

      #region Grep Events
      /// <summary>
      /// Handles the Grep object's SearchingFile event
      /// </summary>
      /// <param name="file">FileInfo object containg currently being search file</param>
      /// <history>
      /// [Curtis_Beard]		10/17/2005	Created
      /// [Curtis_Beard]		12/02/2005	CHG: handle SearchingFile event instead of StatusMessage
      /// [Curtis_Beard]		04/21/2006	CHG: truncate the file name if necessary
      /// </history>
      private void ReceiveSearchingFile(System.IO.FileInfo file)
      {
         string message = string.Format(Language.GetGenericText("SearchSearching"), TruncateFileName(file, stbStatus));

         SetStatusBarMessage(message);
      }

      /// <summary>
      /// A file has been detected to contain the searching text
      /// </summary>
      /// <param name="file">File detected to contain searching text</param>
      /// <param name="index">Position in GrepCollection</param>
      /// <history>
      /// [Curtis_Beard]		10/17/2005	Created
      /// </history>
      private void ReceiveFileHit(System.IO.FileInfo file, int index)
      {
         AddHitToList(file, index);
      }

      /// <summary>
      /// A line has been detected to contain the searching text
      /// </summary>
      /// <param name="hit">The HitObject that contains the line</param>
      /// <param name="index">The position in the HitObject's line collection</param>
      /// <history>
      /// [Curtis_Beard]		11/04/2005   Created
      /// </history>
      private void ReceiveLineHit(HitObject hit, int index)
      {
         UpdateHitCount(hit);
      }

      /// <summary>
      /// Receives the search error event when a file search causes an uncatchable error
      /// </summary>
      /// <param name="file">FileInfo object of error file</param>
      /// <param name="ex">Exception message</param>
      /// <history>
      /// [Curtis_Beard]		03/14/2006	Created
      /// [Curtis_Beard]		05/28/2007  CHG: use Exception and display error
      /// [Curtis_Beard]		08/07/2007  ADD: 1741735, better search error handling
      /// </history>
      private void ReceiveSearchError(System.IO.FileInfo file, Exception ex)
      {
         string message = string.Empty;
         if (file == null)
            message = string.Format(Language.GetGenericText("SearchGenericError"), ex.Message);
         else
            message = string.Format(Language.GetGenericText("SearchFileError"), file.FullName, ex.Message);

         __ErrorCollection.Add(message);
      }

      /// <summary>
      /// Receives the search cancel event when the grep has been cancelled.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/12/2006	Created
      /// [Curtis_Beard]		08/07/2007  ADD: 1741735, display any search errors
      /// </history>
      private void ReceiveSearchCancel()
      {
         string message = Language.GetGenericText("SearchCancelled");

         SetStatusBarMessage(message);
         SetSearchState(true);

         DisplaySearchErrors();
      }

      /// <summary>
      /// Receives the search complete event when the grep has completed.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/12/2006	Created
      /// [Curtis_Beard]		06/27/2007  CHG: removed message parameter
      /// [Curtis_Beard]		08/07/2007  ADD: 1741735, display any search errors
      /// </history>
      private void ReceiveSearchComplete()
      {
         string message = Language.GetGenericText("SearchFinished");
         
         SetStatusBarMessage(message);
         SetSearchState(true);

         DisplaySearchErrors();
      }

      /// <summary>
      /// Display any search errors that were logged.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		08/07/2007  ADD: 1741735, better search error handling
      /// </history>
      private void DisplaySearchErrors()
      {
         if (this.InvokeRequired)
         {
            DisplaySearchErrorsCallBack del = new DisplaySearchErrorsCallBack(DisplaySearchErrors);
            this.Invoke(del);
            return;
         }

         string[] msgs = new string[__ErrorCollection.Count];
         __ErrorCollection.CopyTo(msgs, 0);

         if (msgs.Length > 0)
         {
            // create a simple form to display the errors
            Form frmError = new Form();
            frmError.Name = "frmError";
            frmError.StartPosition =  FormStartPosition.CenterParent;
            frmError.Size = new Size(this.Width - 50, this.Height / 2);
            frmError.Text = Constants.ProductName;
            frmError.ShowInTaskbar = false;
            frmError.MinimizeBox = false;
            frmError.Icon = null;
            frmError.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            TextBox txtMsg = new TextBox();
            txtMsg.Dock = DockStyle.Fill;
            txtMsg.ReadOnly = true;
            txtMsg.BackColor = System.Drawing.SystemColors.Window;
            txtMsg.Lines = msgs;
            txtMsg.Name = "txtMsg";
            txtMsg.Multiline = true;
            txtMsg.ScrollBars = ScrollBars.Both;
            txtMsg.Select(0,0);
            txtMsg.WordWrap = false;

            frmError.Controls.Add(txtMsg);
            frmError.ShowDialog(this);
            frmError.Dispose();
         }
      }

      /// <summary>
      /// Updates the count column (Thread safe)
      /// </summary>
      /// <param name="hit">HitObject that contains updated information</param>
      /// <history>
      /// [Curtis_Beard]		11/21/2005  Created
      /// </history>
      private void UpdateHitCount(HitObject hit)
      {
         // Makes this a thread safe operation
         if (lstFileNames.InvokeRequired)
         {
            UpdateHitCountCallBack _delegate = new UpdateHitCountCallBack(UpdateHitCount);
            lstFileNames.Invoke(_delegate, new object[1] {hit});
            return;
         }

         // find correct item to update
         foreach (ListViewItem _item in lstFileNames.Items)
         {
            if (int.Parse(_item.SubItems[Constants.COLUMN_INDEX_GREP_INDEX].Text) == hit.Index)
            {
               _item.SubItems[Constants.COLUMN_INDEX_COUNT].Text = hit.HitCount.ToString();
               break;
            }
         }
      }

      /// <summary>
      /// Set the status bar message text. (Thread Safe)
      /// </summary>
      /// <param name="message">Text to display</param>
      /// <history>
      /// [Curtis_Beard]		01/27/2007	Created
      /// </history>
      private void SetStatusBarMessage(string message)
      {
         if (stbStatus.InvokeRequired)
         {
            UpdateStatusMessageCallBack _delegate = new UpdateStatusMessageCallBack(SetStatusBarMessage);
            stbStatus.Invoke(_delegate, new object[1] {message});
            return;
         }

         stbStatus.Text = message;
      }


      /// <summary>
      /// Start the searching
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/17/2005	Created
      /// [Curtis_Beard]		07/03/2006	FIX: 1516775, Remove trim on the search expression
      /// [Curtis_Beard]		07/12/2006	CHG: moved thread actions to grep class
      /// [Curtis_Beard]		11/22/2006	CHG: Remove use of browse in combobox
      /// [Curtis_Beard]		08/07/2007  ADD: 1741735, better search error handling
      /// [Curtis_Beard]		08/21/2007  FIX: 1778467, make sure file pattern is correct if a '\' is present
      /// </history>
      private void StartSearch()
      {
         string _path;
         string _fileName;
         int _index;
         string _expression;

         try
         {
            _fileName = cboFileName.Text;
            _path = cboFilePath.Text.Trim();
            _expression = cboSearchForText.Text;

            // update combo selections
            AddComboSelection(cboSearchForText, _expression);
            AddComboSelection(cboFileName, _fileName);
            AddComboSelection(cboFilePath, _path);

            // Ensure that there is a backslash.
            if (!_path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
               _path += System.IO.Path.DirectorySeparatorChar.ToString();

            // update path and fileName if fileName has a path in it
            int slashPos = _fileName.LastIndexOf(System.IO.Path.DirectorySeparatorChar.ToString());
				if (slashPos > -1)
				{
					// fileName has a slash, so append the directory and get the file filter
					_path += _fileName.Substring(0, slashPos);
					_fileName = _fileName.Substring(slashPos + 1);
				}

            // disable gui
            SetSearchState(false);

            // reset display
            SetStatusBarMessage(string.Empty);
            ClearItems();
            txtHits.Clear();

            // Clear search errors
            __ErrorCollection.Clear();

            // begin searching
            __Grep = new Grep();
            SetGrepOptions();
            __Grep.StartDirectory = _path;
            __Grep.FileFilter = _fileName;
            __Grep.SearchText = _expression;

            // attach events
            __Grep.FileHit += new libFileSearch.Grep.FileHitHandler(ReceiveFileHit);
            __Grep.LineHit += new libFileSearch.Grep.LineHitHandler(ReceiveLineHit);
            __Grep.SearchCancel += new libFileSearch.Grep.SearchCancelHandler(ReceiveSearchCancel);
            __Grep.SearchComplete += new libFileSearch.Grep.SearchCompleteHandler(ReceiveSearchComplete);
            __Grep.SearchError += new libFileSearch.Grep.SearchErrorHandler(ReceiveSearchError);
            __Grep.SearchingFile += new libFileSearch.Grep.SearchingFileHandler(ReceiveSearchingFile);

            __Grep.BeginExecute();
         }
         catch (Exception ex)
         {
            __ErrorCollection.Add(ex.Message);
            DisplaySearchErrors();
         }
      }

      /// <summary>
      /// Clears the file list (Thread safe).
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/10/2006	Created
      /// </history>
      private void ClearItems()
      {
         if (lstFileNames.InvokeRequired)
         {
            ClearItemsCallBack _delegate = new ClearItemsCallBack(ClearItems);
            lstFileNames.Invoke(_delegate);
            return;
         }

         lstFileNames.Items.Clear();
      }

      /// <summary>
      /// Sets the grep options
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/17/2005	Created
      /// [Curtis_Beard]		07/28/2006  ADD: extension exclusion list
      /// </history>
      private void SetGrepOptions()
      {
         if (__Grep != null)
         {
            // set values from user selected search options
            __Grep.UseCaseSensitivity = chkCaseSensitive.Checked;
            __Grep.ContextLines = Convert.ToInt32(txtContextLines.Value);
            __Grep.IncludeLineNumbers = chkLineNumbers.Checked;
            __Grep.UseNegation = chkNegation.Checked;
            __Grep.ReturnOnlyFileNames = chkFileNamesOnly.Checked;
            __Grep.UseRecursion = chkRecurse.Checked;
            __Grep.UseRegularExpressions = chkRegularExpressions.Checked;
            __Grep.UseWholeWordMatching = chkWholeWordOnly.Checked;

            string[] extensions = FileSearch.Core.GeneralSettings.ExtensionExcludeList.Split(';');
            foreach (string ext in extensions)
               __Grep.AddExclusionExtension(ext.ToLower());

            __Grep.Plugins = Core.PluginManager.Items;
         }
      }

      /// <summary>
      /// Add a file hit to the listview (Thread safe).
      /// </summary>
      /// <param name="file">File to add</param>
      /// <param name="index">Position in GrepCollection</param>
      /// <history>
      /// [Curtis_Beard]		10/17/2005	Created
      /// [Curtis_Beard]		12/02/2005	CHG: Add the count column
      /// [Curtis_Beard]		07/07/2006	CHG: Make thread safe
      /// [Curtis_Beard]		09/14/2006	CHG: Update to use date's ToString method
      /// </history>
      private void AddHitToList(System.IO.FileInfo file, int index)
      {
         if (lstFileNames.InvokeRequired)
         {
            AddToListCallBack _delegate = new AddToListCallBack(AddHitToList);
            lstFileNames.Invoke(_delegate, new object[2] {file, index});
            return;
         }

         ListViewItem _listItem;

         // Create the list item
         _listItem = new ListViewItem(file.Name);
         _listItem.SubItems.Add(file.DirectoryName);
         _listItem.SubItems.Add(file.LastWriteTime.ToString());
         _listItem.SubItems.Add("0");
         // must be last
         _listItem.SubItems.Add(index.ToString());

         // Add list item to listview
         lstFileNames.Items.Add(_listItem);

         // clear it out
         _listItem = null;
      }
      #endregion
   }
}
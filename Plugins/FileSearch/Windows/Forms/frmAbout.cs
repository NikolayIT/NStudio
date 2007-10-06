using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileSearch.Windows.Forms
{
   /// <summary>
   /// About Dialog
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
   /// [Curtis_Beard]	   01/11/2005	.Net Conversion/Cleanup
   /// [Curtis_Beard]	   11/03/2005	CHG: set hover text to link
   /// </history>
	public class frmAbout : System.Windows.Forms.Form
	{
      private System.Windows.Forms.PictureBox picIcon;
      private System.Windows.Forms.Button cmdOK;
      private System.Windows.Forms.Panel HeaderPanel;
      private System.Windows.Forms.LinkLabel lnkHomePage;
      private System.Windows.Forms.LinkLabel LicenseLinkLabel;
      private System.Windows.Forms.Label lblTitle;
      private System.Windows.Forms.Label lblVersion;
      private System.Windows.Forms.Label lblDescription;
      private System.Windows.Forms.Label lblDisclaimer;
      private System.Windows.Forms.Label CopyrightLabel;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.ComponentModel.IContainer components;

      /// <summary>
      /// Creates an instance of the frmAbout class.
      /// </summary>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]      01/11/2005	.Net Conversion/Cleanup
      /// </history>
		public frmAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			HeaderPanel.Paint += new PaintEventHandler(HeaderPanel_Paint);
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAbout));
         this.lnkHomePage = new System.Windows.Forms.LinkLabel();
         this.LicenseLinkLabel = new System.Windows.Forms.LinkLabel();
         this.cmdOK = new System.Windows.Forms.Button();
         this.HeaderPanel = new System.Windows.Forms.Panel();
         this.picIcon = new System.Windows.Forms.PictureBox();
         this.lblTitle = new System.Windows.Forms.Label();
         this.lblVersion = new System.Windows.Forms.Label();
         this.lblDescription = new System.Windows.Forms.Label();
         this.lblDisclaimer = new System.Windows.Forms.Label();
         this.CopyrightLabel = new System.Windows.Forms.Label();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // lnkHomePage
         // 
         this.lnkHomePage.AutoSize = true;
         this.lnkHomePage.Location = new System.Drawing.Point(8, 312);
         this.lnkHomePage.Name = "lnkHomePage";
         this.lnkHomePage.Size = new System.Drawing.Size(119, 16);
         this.lnkHomePage.TabIndex = 2;
         this.lnkHomePage.TabStop = true;
         this.lnkHomePage.Text = "FileSearch Home Page";
         this.toolTip1.SetToolTip(this.lnkHomePage, "http://astrogrep.sourceforge.net");
         this.lnkHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHomePage_LinkClicked);
         // 
         // LicenseLinkLabel
         // 
         this.LicenseLinkLabel.AutoSize = true;
         this.LicenseLinkLabel.Location = new System.Drawing.Point(8, 223);
         this.LicenseLinkLabel.Name = "LicenseLinkLabel";
         this.LicenseLinkLabel.Size = new System.Drawing.Size(72, 16);
         this.LicenseLinkLabel.TabIndex = 1;
         this.LicenseLinkLabel.TabStop = true;
         this.LicenseLinkLabel.Text = "GNU License";
         this.toolTip1.SetToolTip(this.LicenseLinkLabel, "http://www.gnu.org/copyleft/gpl.html");
         this.LicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseLinkLabel_LinkClicked);
         // 
         // cmdOK
         // 
         this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.cmdOK.Location = new System.Drawing.Point(344, 312);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(84, 23);
         this.cmdOK.TabIndex = 0;
         this.cmdOK.Text = "&OK";
         this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
         // 
         // HeaderPanel
         // 
         this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this.HeaderPanel.Font = new System.Drawing.Font("Sylfaen", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
         this.HeaderPanel.Name = "HeaderPanel";
         this.HeaderPanel.Size = new System.Drawing.Size(434, 100);
         this.HeaderPanel.TabIndex = 3;
         // 
         // picIcon
         // 
         this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
         this.picIcon.Location = new System.Drawing.Point(384, 112);
         this.picIcon.Name = "picIcon";
         this.picIcon.Size = new System.Drawing.Size(32, 32);
         this.picIcon.TabIndex = 4;
         this.picIcon.TabStop = false;
         this.picIcon.Visible = false;
         // 
         // lblTitle
         // 
         this.lblTitle.AutoSize = true;
         this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblTitle.Location = new System.Drawing.Point(8, 102);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Size = new System.Drawing.Size(84, 16);
         this.lblTitle.TabIndex = 5;
         this.lblTitle.Text = "Application Title";
         // 
         // lblVersion
         // 
         this.lblVersion.AutoSize = true;
         this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblVersion.Location = new System.Drawing.Point(8, 117);
         this.lblVersion.Name = "lblVersion";
         this.lblVersion.Size = new System.Drawing.Size(43, 16);
         this.lblVersion.TabIndex = 6;
         this.lblVersion.Text = "Version";
         // 
         // lblDescription
         // 
         this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblDescription.Location = new System.Drawing.Point(8, 161);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(416, 62);
         this.lblDescription.TabIndex = 7;
         this.lblDescription.Text = "label1";
         // 
         // lblDisclaimer
         // 
         this.lblDisclaimer.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblDisclaimer.Location = new System.Drawing.Point(8, 281);
         this.lblDisclaimer.Name = "lblDisclaimer";
         this.lblDisclaimer.Size = new System.Drawing.Size(416, 20);
         this.lblDisclaimer.TabIndex = 8;
         this.lblDisclaimer.Text = "Created by Theodore Ward and converted to .Net by Curtis Beard";
         // 
         // CopyrightLabel
         // 
         this.CopyrightLabel.AutoSize = true;
         this.CopyrightLabel.Location = new System.Drawing.Point(7, 132);
         this.CopyrightLabel.Name = "CopyrightLabel";
         this.CopyrightLabel.Size = new System.Drawing.Size(219, 16);
         this.CopyrightLabel.TabIndex = 10;
         this.CopyrightLabel.Text = "Copyright (C) 2002-2007 AstroComma Inc.";
         // 
         // frmAbout
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.cmdOK;
         this.ClientSize = new System.Drawing.Size(434, 348);
         this.Controls.Add(this.CopyrightLabel);
         this.Controls.Add(this.lblVersion);
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.LicenseLinkLabel);
         this.Controls.Add(this.lnkHomePage);
         this.Controls.Add(this.lblDisclaimer);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.picIcon);
         this.Controls.Add(this.HeaderPanel);
         this.Controls.Add(this.cmdOK);
         this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmAbout";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "About MyApp";
         this.Load += new System.EventHandler(this.frmAbout_Load);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// Used to draw custom header
      /// </summary>
      /// <param name="sender">system parameter</param>
      /// <param name="e">system parameter</param>
      /// <history>
      /// [Curtis_Beard]   11/03/2005   Created
      /// [Curtis_Beard]   09/12/2006   CHG: Implement panel paint instead of form
      /// </history>
      private void HeaderPanel_Paint(object sender, PaintEventArgs e)
      {
         LinearGradientBrush _gradientBrush = new LinearGradientBrush(new RectangleF(0, 0, HeaderPanel.Width, HeaderPanel.Height), Common.ASTROGREP_ORANGE, Color.White, LinearGradientMode.ForwardDiagonal);
         Graphics _graphics = e.Graphics;
         const int _borderBuffer = 10;

         _graphics.SmoothingMode = SmoothingMode.HighQuality;
         _graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

         // Gradient the panel
         _graphics.FillRectangle(_gradientBrush, new RectangleF(0, 0, HeaderPanel.Width, HeaderPanel.Height));

         // Draw picture
         int _yCorner = HeaderPanel.Height - _borderBuffer - picIcon.Height;
         _graphics.DrawImage(picIcon.Image, _borderBuffer, _yCorner);

         // Draw text
         int _xCorner = picIcon.Width + (2 * _borderBuffer);
         _graphics.DrawString(lblTitle.Text, HeaderPanel.Font, Brushes.Black, _xCorner, _yCorner);

         // Draw a bottom border line
         _graphics.DrawLine(SystemPens.ControlDark, 0, HeaderPanel.Height - 2, HeaderPanel.Width, HeaderPanel.Height - 2);
         _graphics.DrawLine(SystemPens.ControlLightLight, 0, HeaderPanel.Height - 1, HeaderPanel.Width, HeaderPanel.Height - 1);

         // Cleanup
         _gradientBrush.Dispose();
         _graphics.Dispose();
      }

      /// <summary>
      /// Opens the systems default browser and displays the web link
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard] 	11/03/2005	Created
      /// </history>
      private void LicenseLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
      }

      /// <summary>
      /// Opens the systems default browser and displays the web link
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void lnkHomePage_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
      }

      /// <summary>
      /// Closes form
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void cmdOK_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      /// <summary>
      /// Load values for form
      /// </summary>
      /// <param name="sender">System parm</param>
      /// <param name="e">System parm</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   11/03/2005	CHG: make link always blue, new license link
      /// [Curtis_Beard]	   07/07/2006	CHG: call reflection and fileversion info once
      /// [Curtis_Beard]	   05/18/2007	CHG: always use current year for copyright
      /// </history>
      private void frmAbout_Load(object sender, System.EventArgs e)
      {
         System.Reflection.Assembly _assembly = System.Reflection.Assembly.GetExecutingAssembly();
         string _appName = _assembly.GetName().Name;
         System.Diagnostics.FileVersionInfo _info = System.Diagnostics.FileVersionInfo.GetVersionInfo(_assembly.Location);

         this.Text = "About {0}";

         lblVersion.Text = string.Format("Version {0}.{1}.{2}", _info.FileMajorPart, _info.FileMinorPart, _info.FileBuildPart);
         lblTitle.Text = _appName;
         lblDescription.Text = "Additional Copyright (C) 2002 to Theodore L. Ward. FileSearch comes with ABSOLUTELY NO WARRANTY; for details visit http://www.gnu.org/copyleft/gpl.html This is free software, and you are welcome to redistribute it under certain conditions; http://www.gnu.org/copyleft/gpl.html#SEC3";
         lblDisclaimer.Text = "Created by Theodore Ward and converted to .Net by Curtis Beard";

         // Setup the hyperlinks
         LicenseLinkLabel.Links.Add(0, LicenseLinkLabel.Text.Length, "http://www.gnu.org/copyleft/gpl.html");
         LicenseLinkLabel.LinkColor = Color.Blue;
         lnkHomePage.Text = "{0} Home Page";
         lnkHomePage.LinkColor = Color.Blue;

         //Language.GenerateXml(Me, Application.StartupPath & "\" & Me.Name & ".xml")
         Language.ProcessForm(this);

         this.Text = string.Format(this.Text, _appName);
         lnkHomePage.Text = string.Format(lnkHomePage.Text, _appName);
         lnkHomePage.Links.Add(0, lnkHomePage.Text.Length, "http://astrogrep.sourceforge.net/");
         CopyrightLabel.Text = string.Format("Copyright (C) 2002-{0} AstroComma Inc.", DateTime.Now.Year.ToString());
      }
   }
}

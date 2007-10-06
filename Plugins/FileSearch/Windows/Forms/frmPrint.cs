using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileSearch.Windows.Forms
{
   /// <summary>
   /// Print type selection form
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
   /// [Curtis_Beard]	   02/02/2005	Created
   /// [Curtis_Beard]      11/02/2005	CHG: cleanup, pass in font info, comment headers changed
   /// </history>
   public class frmPrint : System.Windows.Forms.Form
   {
      #region Declarations
      private PrintDocument pdoc = new PrintDocument();
      private string __document = string.Empty;
      private ListView __listView;
      private Hashtable __grepTable;
      private Font __Font;
      private int __CurrentChar = 0;
      private Icon __Icon;
      #endregion

      private System.Windows.Forms.Button cmdPrint;
      private System.Windows.Forms.Button cmdPreview;
      private System.Windows.Forms.Button cmdPageSetup;
      private System.Windows.Forms.Button cmdCancel;
      private System.Windows.Forms.Label lblSelect;
      private System.Windows.Forms.ListBox lstPrintTypes;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      /// <summary>
      /// Creates an instance of this class setting its private objects
      /// </summary>
      /// <param name="fileList">Results ListView object</param>
      /// <param name="greps">Grep Collection as a HashTable</param>
      /// <param name="font">Font to use during printing</param>
      /// <param name="icon">The icon to use for print preview dialog</param>
      /// <history>
      /// [Curtis_Beard]      11/02/2005	Created
      /// [Curtis_Beard]      10/11/2006	CHG: Added Font object and a Icon
      /// </history>
      public frmPrint(ListView fileList, Hashtable greps, Font font, Icon icon)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         __listView = fileList;
         __grepTable = greps;
         __Font = font;
         __Icon = icon;

         pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
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
         this.cmdPrint = new System.Windows.Forms.Button();
         this.cmdPreview = new System.Windows.Forms.Button();
         this.cmdPageSetup = new System.Windows.Forms.Button();
         this.cmdCancel = new System.Windows.Forms.Button();
         this.lblSelect = new System.Windows.Forms.Label();
         this.lstPrintTypes = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // cmdPrint
         // 
         this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.cmdPrint.Location = new System.Drawing.Point(8, 160);
         this.cmdPrint.Name = "cmdPrint";
         this.cmdPrint.Size = new System.Drawing.Size(96, 23);
         this.cmdPrint.TabIndex = 1;
         this.cmdPrint.Text = "&Print";
         this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
         // 
         // cmdPreview
         // 
         this.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.cmdPreview.Location = new System.Drawing.Point(120, 160);
         this.cmdPreview.Name = "cmdPreview";
         this.cmdPreview.Size = new System.Drawing.Size(96, 23);
         this.cmdPreview.TabIndex = 2;
         this.cmdPreview.Text = "Pre&view";
         this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
         // 
         // cmdPageSetup
         // 
         this.cmdPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.cmdPageSetup.Location = new System.Drawing.Point(232, 160);
         this.cmdPageSetup.Name = "cmdPageSetup";
         this.cmdPageSetup.Size = new System.Drawing.Size(96, 23);
         this.cmdPageSetup.TabIndex = 3;
         this.cmdPageSetup.Text = "Page &Setup";
         this.cmdPageSetup.Click += new System.EventHandler(this.cmdPageSetup_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.cmdCancel.Location = new System.Drawing.Point(344, 160);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(96, 23);
         this.cmdCancel.TabIndex = 4;
         this.cmdCancel.Text = "&Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // lblSelect
         // 
         this.lblSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.lblSelect.Location = new System.Drawing.Point(8, 8);
         this.lblSelect.Name = "lblSelect";
         this.lblSelect.Size = new System.Drawing.Size(432, 16);
         this.lblSelect.TabIndex = 4;
         this.lblSelect.Text = "Please select the output type:";
         // 
         // lstPrintTypes
         // 
         this.lstPrintTypes.Location = new System.Drawing.Point(8, 32);
         this.lstPrintTypes.Name = "lstPrintTypes";
         this.lstPrintTypes.Size = new System.Drawing.Size(432, 121);
         this.lstPrintTypes.TabIndex = 0;
         // 
         // frmPrint
         // 
         this.AcceptButton = this.cmdPrint;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(450, 191);
         this.Controls.Add(this.lstPrintTypes);
         this.Controls.Add(this.lblSelect);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdPageSetup);
         this.Controls.Add(this.cmdPreview);
         this.Controls.Add(this.cmdPrint);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmPrint";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Print";
         this.Load += new System.EventHandler(this.frmPrint_Load);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// Form Load Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]      02/02/2005	Created
      /// </history>
      private void frmPrint_Load(object sender, System.EventArgs e)
      {
         //Language.GenerateXml(this, Application.StartupPath + "\\" + this.Name + ".xml");
         Language.ProcessForm(this);

         // load the list of types to print
         lstPrintTypes.Items.Add(Language.GetGenericText("PrintTypeSelected"));
         lstPrintTypes.Items.Add(Language.GetGenericText("PrintTypeCurrent"));
         lstPrintTypes.Items.Add(Language.GetGenericText("PrintTypeAll"));
         lstPrintTypes.Items.Add(Language.GetGenericText("PrintTypeFile"));

         // Set the first item as selected
         lstPrintTypes.SelectedIndex = 0;

         // Set the default document settings
         pdoc.DefaultPageSettings.Margins.Left = 25;
         pdoc.DefaultPageSettings.Margins.Top = 25;
         pdoc.DefaultPageSettings.Margins.Bottom = 25;
         pdoc.DefaultPageSettings.Margins.Right = 25;
      }

      #region Control Events
      /// <summary>
      /// Print Button Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]      02/02/2005	Created
      /// </history>
      private void cmdPrint_Click(object sender, System.EventArgs e)
      {
         try
         {
            PrintDialog dialog = new PrintDialog();
            SetDocument();
            dialog.Document = pdoc;

            if (dialog.ShowDialog(this) == DialogResult.OK)
               pdoc.Print();
         }
         catch
         {
            MessageBox.Show(Language.GetGenericText("PrintErrorPrint"),
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Print Preview Button Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]      02/02/2005	Created
      /// [Curtis_Beard]      10/06/2006	CHG: Set icon and make resizable
      /// [Curtis_Beard]      11/02/2006	CHG: translate form text
      /// </history>
      private void cmdPreview_Click(object sender, System.EventArgs e)
      {
         try
         {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            SetDocument();
            ppd.Document = pdoc;

            // Set properties of preview dialog
            ppd.StartPosition = FormStartPosition.CenterScreen;
            ppd.Size = new Size(640, 480);
            ppd.FormBorderStyle = FormBorderStyle.Sizable;
            ppd.Icon = __Icon;
            ppd.Text = Language.GetControlText(cmdPreview).Replace("&", string.Empty);

            // set initial zoom level to 100%
            ppd.PrintPreviewControl.Zoom = 1.0;

            ppd.ShowDialog(this);
         }
         catch
         {
            MessageBox.Show(Language.GetGenericText("PrintErrorPreview"),
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Page Setup Button Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]      02/02/2005	Created
      /// [Curtis_Beard]      11/02/2005	CHG: remove setting the default margins
      /// </history>
      private void cmdPageSetup_Click(object sender, System.EventArgs e)
      {
         PageSetupDialog psd = new PageSetupDialog();

         try
         {
            psd.Document = pdoc;
            psd.PageSettings = pdoc.DefaultPageSettings;

            if (psd.ShowDialog(this) == DialogResult.OK)
               pdoc.DefaultPageSettings = psd.PageSettings;
         }
         catch
         {
            MessageBox.Show(Language.GetGenericText("PrintErrorPageSettings"),
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Cancel Button Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <history>
      /// [Curtis_Beard]      02/02/2005	Created
      /// </history>
      private void cmdCancel_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }
      #endregion

      #region PrintDocument Events
      /// <summary>
      /// PrintPage Event
      /// </summary>
      /// <param name="sender">system parm</param>
      /// <param name="e">system parm</param>
      /// <remarks>
      ///   PrintPage is the foundational printing event. This event gets fired for every 
      ///   page that will be printed. You could also handle the BeginPrint and EndPrint
      ///   events for more control.
      ///   
      ///   The following is very 
      ///   fast and useful for plain text as MeasureString calculates the text that
      ///   can be fitted on an entire page. This is not that useful, however, for 
      ///   formatted text. In that case you would want to have word-level (vs page-level)
      ///   control, which is more complicated.
      /// </remarks>
      /// <history>
      /// [Curtis_Beard]	   02/02/2005	Created
      /// [Curtis_Beard]      11/02/2005	CHG: Use class' font name and size
      /// </history>
      private void pdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         int intPrintAreaHeight;
         int intPrintAreaWidth;
         int marginLeft;
         int marginTop;

         // Initialize local variables that contain the bounds of the printing 
         // area rectangle.
         intPrintAreaHeight = pdoc.DefaultPageSettings.PaperSize.Height - pdoc.DefaultPageSettings.Margins.Top - pdoc.DefaultPageSettings.Margins.Bottom;
         intPrintAreaWidth = pdoc.DefaultPageSettings.PaperSize.Width - pdoc.DefaultPageSettings.Margins.Left - pdoc.DefaultPageSettings.Margins.Right;

         // Initialize local variables to hold margin values that will serve
         // as the X and Y coordinates for the upper left corner of the printing 
         // area rectangle.
         marginLeft = pdoc.DefaultPageSettings.Margins.Left; // X coordinate
         marginTop = pdoc.DefaultPageSettings.Margins.Top; // Y coordinate

         // If the user selected Landscape mode, swap the printing area height 
         // and width.
         if (pdoc.DefaultPageSettings.Landscape)
         {
            int intTemp;
            intTemp = intPrintAreaHeight;
            intPrintAreaHeight = intPrintAreaWidth;
            intPrintAreaWidth = intTemp;
         }

         // Calculate the total number of lines in the document based on the height of
         // the printing area and the height of the font.
         int intLineCount = Convert.ToInt32(intPrintAreaHeight / __Font.Height);

         // Initialize the rectangle structure that defines the printing area.
         RectangleF rectPrintingArea = new RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight);

         // Instantiate the StringFormat class, which encapsulates text layout 
         // information (such as alignment and line spacing), display manipulations 
         // (such as ellipsis insertion and national digit substitution) and OpenType 
         // features. Use of StringFormat causes MeasureString and DrawString to use
         // only an integer number of lines when printing each page, ignoring partial
         // lines that would otherwise likely be printed if the number of lines per 
         // page do not divide up cleanly for each page (which is usually the case).
         // See further discussion in the SDK documentation about StringFormatFlags.
         StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);

         // Call MeasureString to determine the number of characters that will fit in
         // the printing area rectangle. The CharFitted Int32 is passed ByRef and used
         // later when calculating intCurrentChar and thus HasMorePages. LinesFilled 
         // is not needed for this sample but must be passed when passing CharsFitted.
         // Mid is used to pass the segment of remaining text left off from the 
         // previous page of printing (recall that intCurrentChar was declared as 
         // static.
         int intLinesFilled;
         int intCharsFitted;
         e.Graphics.MeasureString(__document.Substring(__CurrentChar), __Font,
            new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt,
            out intCharsFitted, out intLinesFilled);

         // Print the text to the page.
         e.Graphics.DrawString(__document.Substring(__CurrentChar), __Font, 
            Brushes.Black, rectPrintingArea, fmt);

         // Advance the current char to the last char printed on this page. As 
         // intCurrentChar is a static variable, its value can be used for the next
         // page to be printed. It is advanced by 1 and passed to Mid() to print the
         // next page (see above in MeasureString()).
         __CurrentChar += intCharsFitted;

         // HasMorePages tells the printing module whether another PrintPage event
         // should be fired.
         if (__CurrentChar < __document.Length)
            e.HasMorePages = true;
         else
         {
            e.HasMorePages = false;
            // You must explicitly reset intCurrentChar as it is static.
            __CurrentChar = 0;
         }
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Set the document to print
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   02/02/2005	Created
      /// [Curtis_Beard]	   09/10/2005	CHG: create grepPrint object to generate document
      /// [Curtis_Beard]      11/02/2005	CHG: Use try/catch and set doc to error message in catch
      /// </history>
      private void SetDocument()
      {
         try
         {
            GrepPrint _printDoc = new GrepPrint(__listView, __grepTable);

            switch (lstPrintTypes.SelectedIndex)
            {
               case 0:
                  __document = _printDoc.PrintSelectedItems();
                  break;
               case 1:
                  __document = _printDoc.PrintSingleItem();
                  break;
               case 2:
                  __document = _printDoc.PrintAllHits();
                  break;
               case 3:
                  __document = _printDoc.PrintFileList();
                  break;
               default:
                  __document = string.Empty;
                  break;
            }
         }
         catch (Exception ex)
         {
            // display error to user in document if an error occurred trying to generate
            // the document for printing
            __document = string.Format(Language.GetGenericText("PrintErrorDocument"), ex.Message);
         }
      }
      #endregion
   }
}
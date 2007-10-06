using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FileSearch.Windows.Controls
{
   /// <summary>
   /// 
   /// </summary>
   /// <remarks>
   ///  FileSearch File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002troComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General public License
   ///   published by the Free Software Foundation; either version 2
   ///   of the License, or (at your option) any later version.
   ///   
   ///   This program is distributed in the hope that it will be useful,
   ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
   ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   ///   GNU General public License for more details.
   ///   
   ///   You should have received a copy of the GNU General public License
   ///   along with this program; if not, write to the Free Software
   ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
   /// 
   ///   The author may be contacted at:
   ///   ted@astrocomma.com or curtismbeard@gmail.com
   /// </remarks>
   /// <history>
   /// 	[Curtis_Beard]	   11/18/2005	Created
   /// </history>
   [DefaultEvent("ColorChange")]
   public class ColorButton : System.Windows.Forms.Button
   {
      #region Declarations
      ///<summary>Raised when a color has been selected</summary>
      public delegate void ColorChangeHandler(Color newColor);
      /// <summary>Raised when a color has been selected</summary>
      public event ColorChangeHandler ColorChange;

      private Color __selectedColor = Color.Black;
      #endregion

      /// <summary>
      /// 
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      public ColorButton()
      {
         this.MouseEnter += new System.EventHandler(OnMouseEnter);
         this.MouseLeave += new System.EventHandler(OnMouseLeave);
         this.MouseUp += new MouseEventHandler(OnMouseUp);
         this.Paint += new PaintEventHandler(ButtonPaint);
         this.Click += new System.EventHandler(ColorButton_Click);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      [Category("Appearance"),
      DefaultValue(true),
      Description("The currently selected color.")]
      public Color SelectedColor
      {
         get { return __selectedColor; }
         set
         {
            // fixes some wierdness when using designer selected colors
            __selectedColor = Color.FromArgb(value.ToArgb());
            this.Invalidate();
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private void OnMouseEnter(object sender, System.EventArgs e)
      {
         this.Invalidate();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private void OnMouseLeave(object sender, System.EventArgs e)
      {
         this.Invalidate();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private void OnMouseUp(object sender, MouseEventArgs e)
      {
         this.Invalidate();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// 	[Curtis_Beard]	   07/20/2006	CHG: Resize drawing sections so that focus rectangle looks better
      /// </history>
      private void ButtonPaint(object sender, PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         Rectangle r = this.ClientRectangle;
         byte border = 5;
         byte right_border = 15;
         Rectangle rc = new Rectangle(r.Left + border, r.Top + border, r.Width - border - right_border - 2, r.Height - border * 2 - 1);
         Pen pen = new Pen(Color.Black);
         SolidBrush centerColorBrush = new SolidBrush(this.SelectedColor);
         int _halfHeight = Convert.ToInt32(r.Height / 2);

         g.FillRectangle(centerColorBrush, rc);
         g.DrawRectangle(pen, rc);

         // draw the arrow
         Point p1 = new Point(r.Width - 10, _halfHeight - 1);
         Point p2 = new Point(r.Width - 6, _halfHeight - 1);
         g.DrawLine(pen, p1, p2);

         p1 = new Point(r.Width - 9, _halfHeight);
         p2 = new Point(r.Width - 7, _halfHeight);
         g.DrawLine(pen, p1, p2);

         p1 = new Point(r.Width - 8, _halfHeight);
         p2 = new Point(r.Width - 8, _halfHeight + 1);
         g.DrawLine(pen, p1, p2);

         // draw the divider line
         pen = new Pen(SystemColors.ControlDark);
         p1 = new Point(r.Width - 13, 4);
         p2 = new Point(r.Width - 13, r.Height - 5);
         g.DrawLine(pen, p1, p2);

         pen = new Pen(SystemColors.ControlLightLight);
         p1 = new Point(r.Width - 12, 4);
         p2 = new Point(r.Width - 12, r.Height - 5);
         g.DrawLine(pen, p1, p2);

         pen.Dispose();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private void ColorButton_Click(object sender, System.EventArgs e)
      {
         Point p = new Point(this.Left, this.Top + this.Height);
         p = this.Parent.PointToScreen(p);

         ColorPaletteDialog clDlg = new ColorPaletteDialog(p, this.SelectedColor);
         clDlg.ColorChosen += new FileSearch.Windows.Controls.ColorButton.ColorPaletteDialog.ColorChosenHandler(ColorChosen);
         clDlg.Show();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="chosen"></param>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private void ColorChosen(Color chosen)
      {
         this.SelectedColor = chosen;
         if (ColorChange != null)
            ColorChange(chosen);
      }

      #region Class ColorPaletteDialog"
      /// <summary>
      /// 
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]	   11/18/2005	Created
      /// </history>
      private class ColorPaletteDialog : System.Windows.Forms.Form
      {
         public delegate void ColorChosenHandler(Color chosen);
         public event ColorChosenHandler ColorChosen;

         private const int MAX_COLORS = 40;
         private bool __showingCustom = false;
         private Color __selectedColor;

         private Color[] __colors = new Color[] {Color.FromArgb(0, 0, 0), Color.FromArgb(153, 51, 0), Color.FromArgb(51, 51, 0), Color.FromArgb(0, 51, 0), Color.FromArgb(0, 51, 102), Color.FromArgb(0, 0, 128), Color.FromArgb(51, 51, 153), Color.FromArgb(51, 51, 51), Color.FromArgb(128, 0, 0), Color.FromArgb(255, 102, 0), Color.FromArgb(128, 128, 0), Color.FromArgb(0, 128, 0), Color.FromArgb(0, 128, 128), Color.FromArgb(0, 0, 255), Color.FromArgb(102, 102, 153), Color.FromArgb(128, 128, 128), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 153, 0), Color.FromArgb(153, 204, 0), Color.FromArgb(51, 153, 102), Color.FromArgb(51, 204, 204), Color.FromArgb(51, 102, 255), Color.FromArgb(128, 0, 128), Color.FromArgb(153, 153, 153), Color.FromArgb(255, 0, 255), Color.FromArgb(255, 204, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 204, 255), Color.FromArgb(153, 51, 102), Color.FromArgb(192, 192, 192), Color.FromArgb(255, 153, 204), Color.FromArgb(255, 204, 153), Color.FromArgb(255, 255, 153), Color.FromArgb(204, 255, 204), Color.FromArgb(204, 255, 255), Color.FromArgb(153, 204, 255), Color.FromArgb(204, 153, 255), Color.FromArgb(255, 255, 255)};
         private string[] __colorNames = new string[] {"Black", "Brown", "Olive Green", "Dark Green", "Dark Teal", "Dark Blue", "Indigo", "Gray-80%", "Dark Red", "Orange", "Dark Yellow", "Green", "Teal", "Blue", "Blue-Gray", "Gray-50%", "Red", "Light Orange", "Lime", "Sea Green", "Aqua", "Light Blue", "Violet", "Gray-40%", "Pink", "Gold", "Yellow", "Bright Green", "Turquoise", "Sky Blue", "Plum", "Gray-25%", "Rose", "Tan", "Light Yellow", "Light Green", "Light Turquoise", "Pale Blue", "Lavender", "White"};

         // Controls
         private Button __otherButton = new Button();
         private Panel __otherPanel = new Panel();
         private Button __cancelButton = new Button();
         private Panel[] __panels = new Panel[MAX_COLORS];

         /// <summary>
         /// 
         /// </summary>
         /// <param name="startingPoint"></param>
         /// <param name="selectedColor"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         public ColorPaletteDialog(Point startingPoint, Color selectedColor)
         {
            // form properties
            this.Size = new Size(158, 132);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Location = startingPoint;
            this.Deactivate += new EventHandler(ColorPaletteDialog_Deactivate);

            // Set the selected color passed in
            this.SelectedColor = selectedColor;

            // build the display
            BuildPalette();

            // Other button
            __otherButton.Text = Windows.Language.GetGenericText("ColorOtherText");
            __otherButton.Size = new Size(121, 22);
            __otherButton.Location = new Point(5, 99);
            __otherButton.Click += new System.EventHandler(moreColorsButton_Click);
            __otherButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Controls.Add(__otherButton);

            // Other Color Panel
            __otherPanel.Height = 16;
            __otherPanel.Width = 16;
            __otherPanel.Location = new Point(131, 99);
            this.Controls.Add(__otherPanel);

            // "invisible" button to cancel at Escape
            __cancelButton.Size = new Size(5, 5);
            __cancelButton.Location = new Point(-10, -10);
            __cancelButton.Click += new System.EventHandler(cancelButton_Click);
            this.Controls.Add(__cancelButton);
            __cancelButton.TabIndex = 0;
            __cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton = __cancelButton;
         }

         /// <summary>
         /// 
         /// </summary>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         public Color SelectedColor
         {
            get { return __selectedColor; }
            set 
            {
               __selectedColor = value;
               if (ColorChosen != null)
                  ColorChosen(value);
            }
         }

         /// <summary>
         /// 
         /// </summary>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void BuildPalette()
         {
            byte pwidth = 16;
            byte pheight = 16;
            byte pdistance = 2;
            byte border = 5;
            int x = border;
            int y = border;
            ToolTip toolTip = new ToolTip();
            bool _selected = false;

            for (int i = 0; i < MAX_COLORS; i++)
            {
               __panels[i] = new Panel();
               __panels[i].Height = pwidth;
               __panels[i].Width = pheight;
               __panels[i].Location = new Point(x, y);
               toolTip.SetToolTip(__panels[i], __colorNames[i]);

               this.Controls.Add(__panels[i]);

               if (x < 7 * (pwidth + pdistance))
                  x += pwidth + pdistance;
               else
               {
                  x = border;
                  y += pheight + pdistance;
               }

               __panels[i].BackColor = __colors[i];

               // Check if current panel is the currently selected color
               if (__panels[i].BackColor.Equals(this.SelectedColor))
               {
                  __panels[i].BorderStyle = BorderStyle.Fixed3D;
                  _selected = true;
               }

               __panels[i].MouseEnter += new System.EventHandler(OnMouseEnterPanel);
               __panels[i].MouseLeave += new System.EventHandler(OnMouseLeavePanel);
               __panels[i].MouseDown += new MouseEventHandler(OnMouseDownPanel);
               __panels[i].MouseUp += new MouseEventHandler(OnMouseUpPanel);
               __panels[i].Paint += new PaintEventHandler(OnPanelPaint);
            }

            // used to set other color panel if not a default color
            if (!_selected)
            {
               __otherPanel.BackColor = this.SelectedColor;
               __otherPanel.BorderStyle = BorderStyle.Fixed3D;
            }
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void moreColorsButton_Click(object sender, System.EventArgs e)
         {
            ColorDialog colDialog = new ColorDialog();
            colDialog.FullOpen = true;
            __showingCustom = true;
            colDialog.Color = SelectedColor;

            if (colDialog.ShowDialog(this) == DialogResult.OK)
               SelectedColor = colDialog.Color;

            colDialog.Dispose();

            __showingCustom = false;

            this.Close();
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void cancelButton_Click(object sender, System.EventArgs e)
         {
            this.Close();
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void OnMouseEnterPanel(object sender, System.EventArgs e)
         {
            DrawPanel(sender, 1);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void OnMouseLeavePanel(object sender, System.EventArgs e)
         {
            DrawPanel(sender, 0);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void OnMouseDownPanel(object sender, MouseEventArgs e)
         {
            DrawPanel(sender, 2);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void OnMouseUpPanel(object sender, MouseEventArgs e)
         {
            Panel panel = (Panel)sender;
            SelectedColor = panel.BackColor;

            this.Close();
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="state"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void DrawPanel(object sender, byte state)
         {
            Panel panel = (Panel)sender;
            Graphics g = panel.CreateGraphics();
            Pen pen1;
            Pen pen2;

            if (state == 1) //mouse over
            {
               pen1 = new Pen(SystemColors.ControlLightLight);
               pen2 = new Pen(SystemColors.ControlDarkDark);
            }
            else
            {
               if (state == 2) //clicked
               {
                  //neutral
                  pen1 = new Pen(SystemColors.ControlDarkDark);
                  pen2 = new Pen(SystemColors.ControlLightLight);                  
               }
               else
               {
                  pen1 = new Pen(SystemColors.ControlDark);
                  pen2 = new Pen(SystemColors.ControlDark);
               }
            }

            Rectangle r  = panel.ClientRectangle;
            Point p1 = new Point(r.Left, r.Top); //top left
            Point p2 = new Point(r.Right - 1, r.Top); //top right
            Point p3 = new Point(r.Left, r.Bottom - 1); //bottom left
            Point p4 = new Point(r.Right - 1, r.Bottom - 1); //bottom right
            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p1, p3);
            g.DrawLine(pen2, p2, p4);
            g.DrawLine(pen2, p3, p4);

            pen1.Dispose();
            pen2.Dispose();
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void OnPanelPaint(object sender, PaintEventArgs e)
         {
            DrawPanel(sender, 0);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         /// <history>
         /// 	[Curtis_Beard]	   11/18/2005	Created
         /// </history>
         private void ColorPaletteDialog_Deactivate(object sender, System.EventArgs e)
         {
            if (!__showingCustom)
               this.Close();
         }
      }
      #endregion
   }
}

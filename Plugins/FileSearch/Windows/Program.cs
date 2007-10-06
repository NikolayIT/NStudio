using System;
using System.Windows.Forms;

namespace FileSearch.Windows
{
	/// <summary>
	/// Startup for application
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
	/// [Curtis_Beard]	   01/27/2005	.Net Conversion/Support for xp themes
	/// [Curtis_Beard]	   10/14/2005	CHG: Made a class instead of module
	/// </history>
	public class Program
	{
		/// <summary>
		/// Starts the application
		/// </summary>
		/// <remarks>
		/// Enables visual styles for the controls if available.
		/// </remarks>
		/// <history>
		/// [Curtis_Beard]	   10/14/2005	Created
		/// [Curtis_Beard]	   07/21/2006	CHG: Use a try/catch block for any erroneous errors
		/// [Curtis_Beard]	   10/11/2006	CHG: Remove setting reference to frmMain in Common class
		/// </history>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.DoEvents();
				Application.Run(new Windows.Forms.frmMain());
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("A critical error occurred and FileSearch must be shutdown.  Please restart FileSearch.\n({0})", ex.Message), 
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}
	}
}
using System;
using System.Windows.Forms;

namespace FileSearch.Windows
{
   /// <summary>
   /// Common Routines and Variables
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
   /// [Curtis_Beard]	   01/11/2005	Initial - Moved common routines into this module
   /// [Curtis_Beard]	   10/15/2005	CHG: Remove End of Line settings
   /// [Curtis_Beard]	   11/04/2005	CHG: made into a class
   /// [Curtis_Beard]	   11/21/2005	ADD: lines in count column
   /// [Curtis_Beard] 	   12/06/2005	CHG: Move WholeWordOnly to Grep class
   /// [Curtis_Beard]	   07/20/2006	ADD: Load/Save TextEditor array, 
   ///                                 Created legacy,registry,and constants classes
   /// [Curtis_Beard] 	   05/29/2007	ADD: property for help file location
   /// </history>
	public class Common
	{
      private Common()
      {}

      /// <summary>FileSearch Color</summary>
      public static System.Drawing.Color ASTROGREP_ORANGE = System.Drawing.Color.FromArgb(251, 127, 6);
      private static TextEditor[] TextEditors;

      /// <summary>
      /// Gets the full path to the FileSearch help file.
      /// </summary>
      static public string HelpFileLocation
      {
         get { return System.IO.Path.Combine(Constants.ProductLocation, "FileSearch-Help.chm"); }
      }

      #region Public Methods
      /// <summary>
      /// Edit a file that the user has double clicked on
      /// </summary>
      /// <param name="path">Fully qualified file path</param>
      /// <param name="line">Line number</param>
      /// <param name="column">Column position</param>
      /// <history>
      /// [Theodore_Ward]     ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion, Try/Catch
      /// [Curtis_Beard]	   06/13/2005	CHG: Used new cmd line arg specification
      /// [Curtis_Beard]	   07/20/2006	CHG: Run the text editor associated with the file's extension
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      public static void EditFile(string path, int line, int column)
      {
         try
         {  
            // pick the correct editor to use
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            TextEditor editorToUse = null;

            // find extension match
            if (TextEditors != null)
            {
               foreach (TextEditor editor in TextEditors)
               {
                  if (editor.FileType.IndexOf(file.Extension) > -1)
                  {
                     // use this editor
                     editorToUse = editor;
                     break;
                  }
               }

               // try finding default for all types (*)
               if (editorToUse == null)
               {
                  foreach (TextEditor editor in TextEditors)
                  {
                     if (editor.FileType.Equals(Constants.ALL_FILE_TYPES))
                     {
                        // use this editor
                        editorToUse = editor;
                        break;
                     }
                  }
               }

               if (editorToUse == null)
               {
                  MessageBox.Show(Language.GetGenericText("TextEditorsErrorNotDefined"),
                     Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               else
                  EditFile(editorToUse, path, line, column);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(String.Format(Language.GetGenericText("TextEditorsErrorGeneric"), path, ex.Message),
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }      

      /// <summary>
      /// Load the specified text editors from the registry.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]	   07/10/2006  Created
      /// </history>
      public static void LoadTextEditors()
      {
         string editorsString = FileSearch.Core.GeneralSettings.TextEditors;
         
         if (editorsString.Length > 0)
         {
            //parse string for each editor
            string[] editors = Core.Common.SplitByString(editorsString, Constants.TEXT_EDITOR_SEPARATOR);
            if (editors.Length > 0)
            {
               TextEditors = new TextEditor[editors.Length];

               for (int i = 0; i < editors.Length; i++)
               {
                  //parse each editor for class properties
                  string[] values = Core.Common.SplitByString(editors[i], Constants.TEXT_EDITOR_ARGS_SEPARATOR);
                  if (values.Length > 0)
                  {
                     TextEditor txtEditor = new TextEditor();
                     txtEditor.Editor = values[0];
                     txtEditor.Arguments = values[1];
                     txtEditor.FileType = values[2];

                     TextEditors[i] = txtEditor;
                  }
               }               
            }
         }
         else
         {
            TextEditors = Windows.Legacy.ConvertTextEditors();
            SaveTextEditors(TextEditors);
         }
      }

      /// <summary>
      /// Get the text editors that were loaded.
      /// </summary>
      /// <returns>Array of TextEditor objects</returns>
      /// <history>
      /// [Curtis_Beard]	   07/10/2006	Created
      /// </history>
      public static TextEditor[] GetTextEditors()
      {
         return TextEditors;
      }

      /// <summary>
      /// Saves the given Array of TextEditor objects to the registry and updates the
      /// TextEditors array.
      /// </summary>
      /// <param name="editors">Array of TextEditor objects</param>
      /// <history>
      /// [Curtis_Beard]	   07/10/2006	Created
      /// </history>
      public static void SaveTextEditors(TextEditor[] editors)
      {
         if (editors != null)
         {
            System.Text.StringBuilder builder = new System.Text.StringBuilder(editors.Length);
            TextEditors = new TextEditor[editors.Length];
            TextEditors = editors;

            foreach (TextEditor editor in editors)
            {
               if (builder.Length > 0)
                  builder.Append(Constants.TEXT_EDITOR_SEPARATOR);

               builder.AppendFormat("{1}{0}{2}{0}{3}", Constants.TEXT_EDITOR_ARGS_SEPARATOR, 
                  editor.Editor, editor.Arguments, editor.FileType);
            }

            FileSearch.Core.GeneralSettings.TextEditors = builder.ToString();
         }
         else
         {
            TextEditors = null;
            FileSearch.Core.GeneralSettings.TextEditors = string.Empty;
         }

         FileSearch.Core.GeneralSettings.Save();
      }

      /// <summary>
      /// Create or delete an application shortcut on the user's desktop.
      /// </summary>
      /// <param name="create">True to create shortcut, False to delete it</param>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      public static void SetDesktopShortcut(bool create)
      {
         CreateApplicationShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), create);
      }

      /// <summary>
      /// Create or delete an application shortcut on the user's start menu.
      /// </summary>
      /// <param name="create">True to create shortcut, False to delete it</param>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      public static void SetStartMenuShortcut(bool create)
      {
         CreateApplicationShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Programs), create);
      }

      /// <summary>
      /// Checks to see if the desktop shortcut exists.
      /// </summary>
      /// <returns>Returns true if the shortcut exists, false otherwise</returns>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      public static bool IsDesktopShortcut()
      {
         return IsShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
      }

      /// <summary>
      /// Checks to see if the start menu shortcut exists.
      /// </summary>
      /// <returns>Returns true if the shortcut exists, false otherwise</returns>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      public static bool IsStartMenuShortcut()
      {
         return IsShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
      }

      /// <summary>
      /// Converts a Color to a string.
      /// </summary>
      /// <param name="color">Color</param>
      /// <returns>color values as a string</returns>
      /// <history>
      /// [Curtis_Beard]		11/03/2006	Created
      /// </history>
      public static string ConvertColorToString(System.Drawing.Color color)
      {
         return string.Format("{0}{4}{1}{4}{2}{4}{3}", color.R.ToString(), color.G.ToString(), color.B.ToString(), color.A.ToString(), Constants.COLOR_SEPARATOR);
      }

      /// <summary>
      /// Converts a string to a Color.
      /// </summary>
      /// <param name="color">color values as a string</param>
      /// <returns>Color</returns>
      /// <history>
      /// [Curtis_Beard]		11/03/2006	Created
      /// </history>
      public static System.Drawing.Color ConvertStringToColor(string color)
      {
         string[] rgba = color.Split(char.Parse(Constants.COLOR_SEPARATOR));

         return System.Drawing.Color.FromArgb(byte.Parse(rgba[3]), byte.Parse(rgba[0]), byte.Parse(rgba[1]), byte.Parse(rgba[2]));
      }

      /// <summary>
      /// Retrieves all the ComboBox entries as a string.
      /// </summary>
      /// <param name="combo">ComboBox</param>
      /// <returns>string of entries</returns>
      /// <history>
      /// [Curtis_Beard]		11/03/2006	Created
      /// </history>
      public static string GetComboBoxEntriesAsString(System.Windows.Forms.ComboBox combo)
      {
         string[] entries = new string[combo.Items.Count];

         for (int i = 0; i < combo.Items.Count; i++)
         {
            entries[i] = combo.Items[i].ToString();
         }

         return string.Join(Constants.SEARCH_ENTRIES_SEPARATOR, entries);
      }

      /// <summary>
      /// Retrieves the values as an array of strings.
      /// </summary>
      /// <param name="values">ComboBox values as a string</param>
      /// <returns>Array of strings</returns>
      /// <history>
      /// [Curtis_Beard]		11/03/2006	Created
      /// </history>
      public static string[] GetComboBoxEntriesFromString(string values)
      {
         string[] entries = Core.Common.SplitByString(values, Constants.SEARCH_ENTRIES_SEPARATOR);

         return entries;
      }

      /// <summary>
      /// Set registry entry to make application a right-click option on a foler
      /// </summary>
      /// <param name="setOption">True - Set registry value, False - remove registry value</param>
      /// <history>
      /// [Curtis_Beard]	   10/14/2005	Created
      /// [Curtis_Beard]	   07/11/2006	CHG: use drive/directory instead of folder
      /// [Curtis_Beard]	   11/13/2006	CHG: use try/catch to prevent no access to registry
      /// </history>
      public static void SetAsSearchOption(bool setOption)
      {
         try
         {
            Microsoft.Win32.RegistryKey _key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true);
            Microsoft.Win32.RegistryKey _driveKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Drive\shell", true);
            Microsoft.Win32.RegistryKey _astroGrepKey;
            Microsoft.Win32.RegistryKey _astroGrepDriveKey;

            Legacy.RemoveOldSearchOption();

            if (_key != null && _driveKey != null)
            {
               if (setOption)
               {
                  // create keys
                  _astroGrepKey = _key.CreateSubKey("astrogrep");
                  _astroGrepDriveKey = _driveKey.CreateSubKey("astrogrep");

                  if (_astroGrepKey != null && _astroGrepDriveKey != null)
                  {
                     _astroGrepKey.SetValue("", String.Format(Language.GetGenericText("SearchExplorerItem"), "&FileSearch"));
                     _astroGrepDriveKey.SetValue("", String.Format(Language.GetGenericText("SearchExplorerItem"), "&FileSearch"));

                     Microsoft.Win32.RegistryKey _commandKey = _astroGrepKey.CreateSubKey("command");
                     Microsoft.Win32.RegistryKey _commandDriveKey = _astroGrepDriveKey.CreateSubKey("command");
                     if (_commandKey != null && _commandDriveKey != null)
                     {
                        _commandKey.SetValue("", "\"" + Application.StartupPath + "\\FileSearch.exe\" \"%L\"");
                        _commandDriveKey.SetValue("", "\"" + Application.StartupPath + "\\FileSearch.exe\" \"%L\"");
                     }
                  }
               }
               else
               {
                  // remove keys
                  try
                  {
                     _key.DeleteSubKeyTree("astrogrep");
                     _driveKey.DeleteSubKeyTree("astrogrep");
                  }
                  catch {}
               }
            }
         }
         catch {}
      }

      /// <summary>
      /// Checks to see if FileSearch is a search option on right-click of folders
      /// </summary>
      /// <returns>True - set, False - not set</returns>
      /// <history>
      /// [Curtis_Beard]	   10/15/2005	Created
      /// [Curtis_Beard]	   07/11/2006	CHG: remove Folder based if exists
      /// [Curtis_Beard]	   11/13/2006	CHG: renamed from CheckIfSearchOption
      /// </history>
      public static bool IsSearchOption()
      {
         if (Legacy.CheckIfOldSearchOption())
         {
            Legacy.RemoveOldSearchOption();
            SetAsSearchOption(true);
         }

         Microsoft.Win32.RegistryKey _key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Directory\shell\astrogrep", false);

         // key exists
         if (_key != null)
         {
            _key.Close();
            return true;
         }

         // key doesn't
         return false;
      }

      /// <summary>
      /// Checks to see if a user has rights to access the registry key to set the search option.
      /// </summary>
      /// <returns>True - has rights, False - otherwise</returns>
      /// <history>
      /// [Curtis_Beard]	   11/13/2006	Created
      /// </history>
      public static bool IsSearchOptionEnabled()
      {
         try
         {
            Microsoft.Win32.RegistryKey _key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true);

            if (_key != null)
            {
               _key.Close();
               return true;
            }
         }
         catch {}

         return false;
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Edit a file that the user has double clicked on
      /// </summary>
      /// <param name="textEditor">Text editor object reference</param>
      /// <param name="path">Fully qualified file path</param>
      /// <param name="line">Line number</param>
      /// <param name="column">Column position</param>
      /// <history>
      /// [Curtis_Beard]	   07/10/2006	ADD: Initial
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      private static void EditFile(TextEditor textEditor, string path, int line, int column)
      {
         EditFile(textEditor.Editor, textEditor.Arguments, path, line, column);
      }

      /// <summary>
      /// Edit a file that the user has double clicked on
      /// </summary>
      /// <param name="editor">Text editor to use</param>
      /// <param name="args">Text editor arguments to use (contains at least %1)</param>
      /// <param name="path">Fully qualified file path</param>
      /// <param name="line">Line number</param>
      /// <param name="column">Column position</param>
      /// <history>
      /// [Curtis_Beard]	   07/10/2006	ADD: Initial
      /// [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
      /// </history>
      private static void EditFile(string editor, string args, string path, int line, int column)
      {
         try
         {
            if (editor.Equals(string.Empty) || args.IndexOf("%1") == -1)
            {
               // no file argument specified
               MessageBox.Show(Language.GetGenericText("TextEditorsErrorNoCmdLineForFile"), 
                  Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               // replace
               //  %1 with filename 
               //  %2 with line number
               //  %3 with column
               string _text = args;
               _text = _text.Replace("%1", "\"" + path + "\"");
               _text = _text.Replace("%2", line.ToString());
               _text = _text.Replace("%3", column.ToString());

               // Check to see if editor needs quotes around it
               string _editor = editor;
               if (_editor.IndexOf(".exe") > 0)
                  _editor = "\"" + _editor + "\"";

               System.Diagnostics.Process.Start(_editor, _text);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(String.Format(Language.GetGenericText("TextEditorsErrorGeneric"), path, ex.Message),
               Constants.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      /// <summary>
      /// Creates an URL shortcut using for the application.
      /// </summary>
      /// <param name="location">Directory where the shortcut should be created.</param>
      /// <param name="create">True to create shortcut, False to delete it</param>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      private static void CreateApplicationShortcut(string location, bool create)
      {
         string path = location + "\\" + Constants.ProductName + ".url";

         if (create)
         {
            //
            // Create shortcut, if not there
            //
            System.IO.StreamWriter writer = null;
            string app;
            //string icon;

            try
            {
               if (!System.IO.File.Exists(path))
               {
                  writer = new System.IO.StreamWriter(path);

                  app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                  writer.WriteLine("[InternetShortcut]");
                  writer.WriteLine("URL=" + app);
                  writer.WriteLine("IconIndex=0");
                  writer.WriteLine("IconFile=" + app);

                  //original code
                  //writer.WriteLine("URL=file:///" + app);
                  //writer.WriteLine("IconIndex=0");
                  //icon = app.Replace("\\", "/");
                  //writer.WriteLine("IconFile=" + icon);

                  writer.Flush();
               }
            }
            catch (Exception ex)
            {
               System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
               if (writer != null)
                  writer.Close();
            }
         }
         else
         {
            //
            // Delete shortcut, if exists
            //
            try
            {
               if (System.IO.File.Exists(path))
                  System.IO.File.Delete(path);
            }
            catch (Exception ex)
            {
               System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
         }
      }

      /// <summary>
      /// Checks to see if a shortcut exists.
      /// </summary>
      /// <param name="location">Directory where the shortcut could be</param>
      /// <returns>Returns true if the shortcut exists, false otherwise</returns>
      /// <history>
      /// [Curtis_Beard]		09/05/2006	Created
      /// </history>
      private static bool IsShortcut(string location)
      {
         string path = location + "\\" + Constants.ProductName + ".url";

         if (System.IO.File.Exists(path))
            return true;

         return false;
      }
      #endregion
	}
}

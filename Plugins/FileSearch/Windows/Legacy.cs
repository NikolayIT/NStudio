using System;

namespace FileSearch.Windows
{
   /// <summary>
   /// Used to access legacy methods for conversion or removal.
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
   /// [Curtis_Beard]		07/20/2006	Created
   /// </history>
   public class Legacy
   {
      /// <summary>
      /// Delete the registry settings for the legacy DEFAULT_EDITOR and EDITOR_ARG
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/20/2006	Created
      /// </history>
      public static void DeleteSingleTextEditor()
      {
         try
         {
            Registry.DeleteStartupSetting("DEFAULT_EDITOR");
            Registry.DeleteStartupSetting("EDITOR_ARG");
         }
         catch {}
      }

      /// <summary>
      /// Checks for the Folder based Search option.
      /// </summary>
      /// <returns>True if found, False otherwise</returns>
      /// <history>
      /// 	[Curtis_Beard]		07/11/2006	Created
      /// </history>
      public static bool CheckIfOldSearchOption()
      {
         Microsoft.Win32.RegistryKey _key;
         _key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Folder\shell\astrogrep", false);

         if (_key != null)
            return true;

         return false;
      }

      /// <summary>
      /// Removes the Folder based search option.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/11/2006	Created
      /// </history>
      public static void RemoveOldSearchOption()
      {
         Microsoft.Win32.RegistryKey _key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Folder\shell", true);

         if (_key != null)
         {
            try
            {
               _key.DeleteSubKeyTree("astrogrep");
            }
            catch {}
         }
      }

      /// <summary>
      /// Attempt to convert search options in registry to most recent style.
      /// </summary>
      /// <remarks>
      /// Removes any registry settings for search options if found and successfully converted.
      /// </remarks>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      public static void ConvertSearchSettings()
      {
         if (Registry.CheckStartupSetting("USE_REG_EXPRESSIONS"))
         {
            FileSearch.Core.SearchSettings.UseRegularExpressions = Registry.GetStartupSetting("USE_REG_EXPRESSIONS", false);
            Registry.DeleteStartupSetting("USE_REG_EXPRESSIONS");
         }

         if (Registry.CheckStartupSetting("USE_CASE_SENSITIVE"))
         {
            FileSearch.Core.SearchSettings.UseCaseSensitivity = Registry.GetStartupSetting("USE_CASE_SENSITIVE", false);
            Registry.DeleteStartupSetting("USE_CASE_SENSITIVE");
         }

         if (Registry.CheckStartupSetting("USE_WHOLE_WORD"))
         {
            FileSearch.Core.SearchSettings.UseWholeWordMatching = Registry.GetStartupSetting("USE_WHOLE_WORD", false);
            Registry.DeleteStartupSetting("USE_WHOLE_WORD");
         }

         if (Registry.CheckStartupSetting("USE_LINE_NUMBERS"))
         {
            FileSearch.Core.SearchSettings.IncludeLineNumbers = Registry.GetStartupSetting("USE_LINE_NUMBERS", true);
            Registry.DeleteStartupSetting("USE_LINE_NUMBERS");
         }

         if (Registry.CheckStartupSetting("USE_RECURSION"))
         {
            FileSearch.Core.SearchSettings.UseRecursion = Registry.GetStartupSetting("USE_RECURSION", true);
            Registry.DeleteStartupSetting("USE_RECURSION");
         }

         if (Registry.CheckStartupSetting("SHOW_FILE_NAMES_ONLY"))
         {
            FileSearch.Core.SearchSettings.ReturnOnlyFileNames = Registry.GetStartupSetting("SHOW_FILE_NAMES_ONLY", false);
            Registry.DeleteStartupSetting("SHOW_FILE_NAMES_ONLY");
         }

         if (Registry.CheckStartupSetting("USE_NEGATION"))
         {
            FileSearch.Core.SearchSettings.UseNegation = Registry.GetStartupSetting("USE_NEGATION", false);
            Registry.DeleteStartupSetting("USE_NEGATION");
         }

         if (Registry.CheckStartupSetting("NUM_CONTEXT_LINES"))
         {
            int lines = Registry.GetStartupSetting("NUM_CONTEXT_LINES", 0);
            if (lines < 0 || lines > Constants.MAX_CONTEXT_LINES)
               lines = 0;
            FileSearch.Core.SearchSettings.ContextLines = lines;
            Registry.DeleteStartupSetting("NUM_CONTEXT_LINES");
         }

         FileSearch.Core.SearchSettings.Save();
      }

      /// <summary>
      /// Attempt to convert general settings in registry to most recent style.
      /// </summary>
      /// <remarks>
      /// Removes any registry settings for general settings if found and successfully converted.
      /// </remarks>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      public static void ConvertGeneralSettings()
      {
         // max mru
         if (Registry.CheckStartupSetting("MAX_STORED_PATHS"))
         {
            FileSearch.Core.GeneralSettings.MaximumMRUPaths = Registry.GetStartupSetting("MAX_STORED_PATHS", 10);

            if (FileSearch.Core.GeneralSettings.MaximumMRUPaths < 0 || FileSearch.Core.GeneralSettings.MaximumMRUPaths > Constants.MAX_STORED_PATHS)
               FileSearch.Core.GeneralSettings.MaximumMRUPaths = Constants.MAX_STORED_PATHS;

            Registry.DeleteStartupSetting("MAX_STORED_PATHS");
         }

         // mru values
         ConvertMRUSettings();

         // window settings
         // column widths
         // splitter positions
         ConvertWindowSettings();

         // colors
         ConvertResultColors();

         // exclude list
         if (Registry.CheckStartupSetting("ExtensionExcludeList"))
         {
            FileSearch.Core.GeneralSettings.ExtensionExcludeList = Registry.GetStartupSetting("ExtensionExcludeList", Constants.DEFAULT_EXTENSION_EXCLUDE_LIST);
            Registry.DeleteStartupSetting("ExtensionExcludeList");
         }

         // language
         if (Registry.CheckStartupSetting("Language"))
         {
            FileSearch.Core.GeneralSettings.Language = Registry.GetStartupSetting("Language", Constants.DEFAULT_LANGUAGE);
            Registry.DeleteStartupSetting("Language");
         }

         FileSearch.Core.GeneralSettings.Save();
      }

      /// <summary>
      /// Retrieve the registry values for the text editors and return a Text
      /// </summary>
      /// <returns>TextEditor array, null if values don't exist</returns>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      public static TextEditor[] ConvertTextEditors()
      {
         TextEditor[] editors = null;

         string mruValue = Registry.GetRegistrySetting("TextEditors", "MRUList", string.Empty);

         if (mruValue.Length > 0)
         {
            string display = string.Empty;
            string path = string.Empty;
            string args = string.Empty;
            int max = int.Parse(mruValue);

            editors = new TextEditor[max];

            for (int i = 1; i <= max; i++)
            {
               path = Registry.GetRegistrySetting("TextEditors", i.ToString(), "-1");
               args = Registry.GetRegistrySetting("TextEditors", i.ToString() + "_args", "-1");
               display = Registry.GetRegistrySetting("TextEditors", i.ToString() + "_fileType", string.Empty);

               if (!path.Equals("-1") && !args.Equals("-1"))
                  editors[i - 1] = new TextEditor(display, path, args);
            }

            Registry.DeleteRegistrySetting("TextEditors");
         }
         else
         {
            // try legacy, if exist, update and remove
            string editorPath = Registry.GetStartupSetting("DEFAULT_EDITOR");
            string editorArgs = Registry.GetStartupSetting("EDITOR_ARG");

            if (editorPath.Length > 0)
            {
               TextEditor editor = new TextEditor();
               editor.FileType = "*";
               editor.Editor = editorPath;
               editor.Arguments = editorArgs;

               editors = new TextEditor[1];
               editors[0] = editor;

               // remove legacy from registry
               DeleteSingleTextEditor();
            }
         }

         return editors;
      }

      /// <summary>
      /// Deletes all registry entries for this application.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      public static void DeleteRegistry()
      {
         Registry.DeleteAllRegistry();
      }

      /// <summary>
      /// Convert the old language value to the new culture based values.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		05/22/2007  Created
      /// </history>
      public static void ConvertLanguageValue()
      {
         switch (Core.GeneralSettings.Language)
         {
            case "English":
               Core.GeneralSettings.Language = "en-us";
               break;
            case "Español":
               Core.GeneralSettings.Language = "es-mx";
               break;
            case "Deutsch":
               Core.GeneralSettings.Language = "de-de";
               break;
            case "Italiano":
               Core.GeneralSettings.Language = "it-it";
               break;
         }
      }

      #region Private Methods
      /// <summary>
      /// Convert and remove registry entries pertaining to MRU lists.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      private static void ConvertMRUSettings()
      {
         string _registryValue;
         string _indexNum;
         System.Text.StringBuilder sbPaths = new System.Text.StringBuilder(FileSearch.Core.GeneralSettings.MaximumMRUPaths);
         System.Text.StringBuilder sbFilters = new System.Text.StringBuilder(FileSearch.Core.GeneralSettings.MaximumMRUPaths);
         System.Text.StringBuilder sbSearches = new System.Text.StringBuilder(FileSearch.Core.GeneralSettings.MaximumMRUPaths);

         //  Get the MRU Paths and add them to the path combobox.
         for (int i = 0; i < FileSearch.Core.GeneralSettings.MaximumMRUPaths; i++)
         {
            _indexNum = i.ToString();

            //  Get the most recent start pathes
            _registryValue = Registry.GetStartupSetting("MRUPath" + _indexNum);

            //  Add the path to the path combobox.
            if (!_registryValue.Equals(string.Empty))
            {
               if (sbPaths.Length > 0)
                  sbPaths.Append(Constants.SEARCH_ENTRIES_SEPARATOR);

               sbPaths.Append(_registryValue);

               Registry.DeleteStartupSetting("MRUPath" + _indexNum);
            }

            //  Get the most recent File filters
            _registryValue = Registry.GetStartupSetting("MRUFileName" + _indexNum);

            //  Add the file name to the path combobox.
            if (!_registryValue.Equals(string.Empty))
            {
               if (sbFilters.Length > 0)
                  sbFilters.Append(Constants.SEARCH_ENTRIES_SEPARATOR);

               sbFilters.Append(_registryValue);

               Registry.DeleteStartupSetting("MRUFileName" + _indexNum);
            }

            //  Get the most recent search expressions
            _registryValue = Registry.GetStartupSetting("MRUExpression" + _indexNum);

            //  Add the search expression to the path combobox.
            if (!_registryValue.Equals(string.Empty))
            {
               if (sbSearches.Length > 0)
                  sbSearches.Append(Constants.SEARCH_ENTRIES_SEPARATOR);

               sbSearches.Append(_registryValue);

               Registry.DeleteStartupSetting("MRUExpression" + _indexNum);
            }            
         }

         if (sbPaths.Length > 0)
            FileSearch.Core.GeneralSettings.SearchStarts = sbPaths.ToString();

         if (sbFilters.Length > 0)
            FileSearch.Core.GeneralSettings.SearchFilters = sbFilters.ToString();

         if (sbSearches.Length > 0)
            FileSearch.Core.GeneralSettings.SearchTexts = sbSearches.ToString();
      }

      /// <summary>
      /// Convert and remove registry entries pertaining to window settings.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      private static void ConvertWindowSettings()
      {
         if (Registry.CheckStartupSetting("POS_TOP"))
         {
            FileSearch.Core.GeneralSettings.WindowTop = Registry.GetStartupSetting("POS_TOP", -1);
            Registry.DeleteStartupSetting("POS_TOP");
         }
         if (Registry.CheckStartupSetting("POS_LEFT"))
         {
            FileSearch.Core.GeneralSettings.WindowLeft = Registry.GetStartupSetting("POS_LEFT", -1);
            Registry.DeleteStartupSetting("POS_LEFT");
         }
         if (Registry.CheckStartupSetting("POS_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowWidth = Registry.GetStartupSetting("POS_WIDTH", -1);
            Registry.DeleteStartupSetting("POS_WIDTH");
         }
         if (Registry.CheckStartupSetting("POS_HEIGHT"))
         {
            FileSearch.Core.GeneralSettings.WindowHeight = Registry.GetStartupSetting("POS_HEIGHT", -1);
            Registry.DeleteStartupSetting("POS_HEIGHT");
         }
         if (Registry.CheckStartupSetting("POS_STATE"))
         {
            FileSearch.Core.GeneralSettings.WindowState = Registry.GetStartupSetting("POS_STATE", -1);
            Registry.DeleteStartupSetting("POS_STATE");
         }

         if (Registry.CheckStartupSetting("SEARCH_PANEL_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowSearchPanelWidth = Registry.GetStartupSetting("SEARCH_PANEL_WIDTH", -1);
            Registry.DeleteStartupSetting("SEARCH_PANEL_WIDTH");
         }
         if (Registry.CheckStartupSetting("FILE_PANEL_HEIGHT"))
         {
            FileSearch.Core.GeneralSettings.WindowFilePanelHeight = Registry.GetStartupSetting("FILE_PANEL_HEIGHT", -1);
            Registry.DeleteStartupSetting("FILE_PANEL_HEIGHT");
         }

         if (Registry.CheckStartupSetting("FILELIST_FILENAME_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowFileColumnNameWidth = Registry.GetStartupSetting("FILELIST_FILENAME_WIDTH", 100);
            Registry.DeleteStartupSetting("FILELIST_FILENAME_WIDTH");
         }
         if (Registry.CheckStartupSetting("FILELIST_LOCATED_IN_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowFileColumnLocationWidth = Registry.GetStartupSetting("FILELIST_LOCATED_IN_WIDTH", 200);
            Registry.DeleteStartupSetting("FILELIST_LOCATED_IN_WIDTH");
         }
         if (Registry.CheckStartupSetting("FILELIST_DATE_MODIFIED_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowFileColumnDateWidth = Registry.GetStartupSetting("FILELIST_DATE_MODIFIED_WIDTH", 150);
            Registry.DeleteStartupSetting("FILELIST_DATE_MODIFIED_WIDTH");
         }
         if (Registry.CheckStartupSetting("FILELIST_COUNT_WIDTH"))
         {
            FileSearch.Core.GeneralSettings.WindowFileColumnCountWidth = Registry.GetStartupSetting("FILELIST_COUNT_WIDTH", 60);
            Registry.DeleteStartupSetting("FILELIST_COUNT_WIDTH");
         }
      }

      /// <summary>
      /// Convert and remove registry entries pertaining to result colors.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/10/2006	Created
      /// </history>
      private static void ConvertResultColors()
      {
         if (Registry.CheckStartupSetting("HighlightForeColor"))
         {
            FileSearch.Core.GeneralSettings.HighlightForeColor = Common.ConvertColorToString(Registry.GetStartupSetting("HighlightForeColor", Common.ASTROGREP_ORANGE));
            Registry.DeleteStartupSetting("HighlightForeColor");
         }
         if (Registry.CheckStartupSetting("HighlightBackColor"))
         {
            FileSearch.Core.GeneralSettings.HighlightBackColor = Common.ConvertColorToString(Registry.GetStartupSetting("HighlightBackColor", System.Drawing.SystemColors.Window));
            Registry.DeleteStartupSetting("HighlightBackColor");
         }
         if (Registry.CheckStartupSetting("ResultsForeColor"))
         {
            FileSearch.Core.GeneralSettings.ResultsForeColor = Common.ConvertColorToString(Registry.GetStartupSetting("ResultsForeColor", System.Drawing.SystemColors.WindowText));
            Registry.DeleteStartupSetting("ResultsForeColor");
         }
         if (Registry.CheckStartupSetting("ResultsBackColor"))
         {
            FileSearch.Core.GeneralSettings.ResultsBackColor = Common.ConvertColorToString(Registry.GetStartupSetting("ResultsBackColor", System.Drawing.SystemColors.Window));
            Registry.DeleteStartupSetting("ResultsBackColor");
         }
      }
      #endregion
   }
}
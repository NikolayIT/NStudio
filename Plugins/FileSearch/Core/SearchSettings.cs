using System;
using System.IO;

namespace FileSearch.Core
{
   /// <summary>
   /// Used to access the search option settings.
   /// </summary>
   /// <remarks>
   ///   FileSearch File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002 AstroComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General public License
   ///   as published by the Free Software Foundation; either version 2
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
   /// [Curtis_Beard]      11/02/2006  Created
   /// [Curtis_Beard]      01/27/2007  ADD: 1561584, skip hidden/system files and directories
   /// [Curtis_Beard]      04/25/2007  FIX: 1700029, always get correct config path
   /// </history>
   public sealed class SearchSettings
   {
      // This class is fully static.
      private SearchSettings()  {}

      #region Declarations
      private static SearchSettings __MySettings = null;

      private const string VERSION = "1.0";

      private bool regularExpressions = false;
      private bool caseSensitive = false;
      private bool wholeWord = false;
      private bool recurse = true;
      private bool fileNamesOnly = false;
      private bool negation = false;
      private bool lineNumbers = true;
      private int contextLines = 0;
      private bool skipHidden = false;
      private bool skipSystem = false;
      #endregion

      /// <summary>
      /// Contains the static reference of this class.
      /// </summary>
      private static SearchSettings MySettings
      {
         get
         {
            if (__MySettings == null)
            {
               __MySettings = new SearchSettings();
               SettingsIO.Load(__MySettings, Location, VERSION);
            }
            return __MySettings;
         }
      }

      /// <summary>
      /// Gets the full location to the config file.
      /// </summary>
      static public string Location
      {
         get
         {
            if (Core.Common.StoreDataLocal)
            {
               return Path.Combine(Constants.ProductLocation, "FileSearch.search.config");
            }
            else
            {
               string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.ProductName);

               return Path.Combine(path, "FileSearch.search.config");
            }
         }
      }

      /// <summary>
      /// Save the search options.
      /// </summary>
      /// <returns>Returns true on success, false otherwise</returns>
      public static bool Save()
      {
         return SettingsIO.Save(MySettings, Location, VERSION);
      }

      /// <summary>
      /// Use regular expressions.
      /// </summary>
      static public bool UseRegularExpressions
      {
         get { return MySettings.regularExpressions; }
         set { MySettings.regularExpressions = value; }
      }

      /// <summary>
      /// Use case sensitivity.
      /// </summary>
      static public bool UseCaseSensitivity
      {
         get { return MySettings.caseSensitive; }
         set { MySettings.caseSensitive = value; }
      }

      /// <summary>
      /// Use whole word matching.
      /// </summary>
      static public bool UseWholeWordMatching
      {
         get { return MySettings.wholeWord; }
         set { MySettings.wholeWord = value; }
      }

      /// <summary>
      /// Use recursion to search sub directories.
      /// </summary>
      static public bool UseRecursion
      {
         get { return MySettings.recurse; }
         set { MySettings.recurse = value; }
      }

      /// <summary>
      /// Retrieve only file names.
      /// </summary>
      static public bool ReturnOnlyFileNames
      {
         get { return MySettings.fileNamesOnly; }
         set { MySettings.fileNamesOnly = value; }
      }

      /// <summary>
      /// Retrieve all files not containing search text.
      /// </summary>
      static public bool UseNegation
      {
         get { return MySettings.negation; }
         set { MySettings.negation = value; }
      }

      /// <summary>
      /// Include line numbers.
      /// </summary>
      static public bool IncludeLineNumbers
      {
         get { return MySettings.lineNumbers; }
         set { MySettings.lineNumbers = value; }
      }

      /// <summary>
      /// Number of context lines to display.
      /// </summary>
      static public int ContextLines
      {
         get { return MySettings.contextLines; }
         set { MySettings.contextLines = value; }
      }

      /// <summary>
      /// Skip hidden files and directories.
      /// </summary>
      static public bool SkipHidden
      {
         get { return MySettings.skipHidden; }
         set { MySettings.skipHidden = value; }
      }

      /// <summary>
      /// Skip system files and directories.
      /// </summary>
      static public bool SkipSystem
      {
         get { return MySettings.skipSystem; }
         set { MySettings.skipSystem = value; }
      }
   }
}

using System;

namespace FileSearch
{
   /// <summary>
   /// Constant values for use in this application.
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
   /// [Curtis_Beard]		11/02/2006	ADD: Constants for plugin separators
   /// </history>
   public class Constants
   {
      // Maximum value constants
      /// <summary>Maximum number of mru paths allowed</summary>
      public const int MAX_STORED_PATHS = 25;
      /// <summary>Maximum number of context lines allowed</summary>
      public const int MAX_CONTEXT_LINES = 10;

      /// <summary></summary>
      public static string SEARCH_ENTRIES_SEPARATOR = "|;;|";
      /// <summary></summary>
      public static string COLOR_SEPARATOR = "-";
      /// <summary></summary>
      public static string TEXT_EDITOR_SEPARATOR = "|;;|";
      /// <summary></summary>
      public static string TEXT_EDITOR_ARGS_SEPARATOR = "|@@|";
      /// <summary></summary>
      public static string PLUGIN_SEPARATOR = "|;;|";
      /// <summary></summary>
      public static string PLUGIN_ARGS_SEPARATOR = "|@@|";

      // ListView column index constants
      /// <summary></summary>
      public const int COLUMN_INDEX_FILE = 0;
      /// <summary></summary>
      public const int COLUMN_INDEX_DIRECTORY = 1;
      /// <summary></summary>
      public const int COLUMN_INDEX_DATE = 2;
      /// <summary></summary>
      public const int COLUMN_INDEX_COUNT = 3;
      /// <summary></summary>
      public const int COLUMN_INDEX_GREP_INDEX  = 4;   //Must be last

      /// <summary>Identifier for all file types</summary>
      public const string ALL_FILE_TYPES = "*";

      /// <summary>Default language</summary>
      public static string DEFAULT_LANGUAGE = "English";

      /// <summary>Default extension exclusion list</summary>
      public static string DEFAULT_EXTENSION_EXCLUDE_LIST = ".exe;.dll;.pdb;.sys;.ppt";

      /// <summary>Product name</summary>
      public const string ProductName = "FileSearch";

      /// <summary>Product Location</summary>
      public static string ProductLocation
      {
         get
         {
            System.IO.FileInfo file = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);

            return file.Directory.FullName;
         }
      }
   }
}

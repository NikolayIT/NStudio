using System;
using System.Collections;
using System.Windows.Forms;

using libFileSearch;

namespace FileSearch.Windows
{
   /// <summary>
   /// Printing routines based on passed in listView and HashTable containing grep
   /// hit information.
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
   ///   [Theodore_Ward]   ??/??/????  Initial
   /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion/Comments/Option Strict
   /// 	[Curtis_Beard]	   09/10/2005	CHG: to class, pass in information
   /// 	[Curtis_Beard]	   07/19/2006	CHG: Apply correct namespace and reformat comments
   /// </history>
   public class GrepPrint
   {
      #region Declarations
      private string __document = string.Empty;
      private ListView __listView;
      private Hashtable __grepTable;
      #endregion

      #region Public Methods
      /// <summary>
      /// Initializes a new instance of the GrepPrint class.
      /// </summary>
      /// <param name="fileList">ListView containing the files.</param>
      /// <param name="greps">Hashtable containing HitObjects</param>
      /// <history>
      /// [Curtis_Beard]	   09/10/2005	Created
      /// </history>
      public GrepPrint(ListView fileList, Hashtable greps)
      {
         __listView = fileList;
         __grepTable = greps;
      }

      /// <summary>
      /// Print the file names only
      /// </summary>
      /// <returns>Document to print</returns>
      /// <history>
      /// [Theodore_Ward]   ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      public string PrintFileList()
      {
         HitObject _hit;

         SetupDocument(string.Empty);

         AddLine("----------------------------------------------------------------------");

         foreach (DictionaryEntry _entry in __grepTable)
         {
            _hit = (HitObject)_entry.Value;
            AddLine(_hit.FilePath);
            AddLine("----------------------------------------------------------------------");
         }

         return __document;
      }

      /// <summary>
      /// Print selected hits
      /// </summary>
      /// <returns>Document to print</returns>
      /// <history>
      /// [Theodore_Ward]   ??/??/????  Initial
      /// [Curtis_Beard]	   01/11/2005	.Net Conversion
      /// [Curtis_Beard]	   11/01/2005	CHG: Get correct hit object index
      /// </history>
      public string PrintSelectedItems()
      {
         HitObject _hit;

         SetupDocument(string.Empty);

         for (int _index = 0; _index < __listView.SelectedItems.Count; _index++)
         {

            _hit = (HitObject)__grepTable[int.Parse(__listView.SelectedItems[_index].SubItems[FileSearch.Constants.COLUMN_INDEX_GREP_INDEX].Text)];

            AddLine("----------------------------------------------------------------------");
            AddLine(_hit.FilePath);
            AddLine("----------------------------------------------------------------------");

            for (int _internalIndex = 0; _internalIndex < _hit.LineCount; _internalIndex++)
               PrintHit(_hit.RetrieveLine(_internalIndex));

            AddLine("");
         }

         return __document;
      }

      /// <summary>
      ///   Print all the hits
      /// </summary>
      /// <returns>Document to print</returns>
      /// <history>
      ///   [Theodore_Ward]   ??/??/????  Initial
      /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      public string PrintAllHits()
      {
         HitObject _hit;

         SetupDocument(string.Empty);

         foreach (DictionaryEntry _entry in __grepTable)
         {

            _hit = (HitObject)_entry.Value;

            AddLine("----------------------------------------------------------------------");
            AddLine(_hit.FilePath);
            AddLine("----------------------------------------------------------------------");

            for (int _index = 0; _index < _hit.LineCount; _index++)
               PrintHit(_hit.RetrieveLine(_index));

            AddLine("");
         }

         return __document;
      }

      /// <summary>
      ///   Print a single hit item
      /// </summary>
      /// <returns>Document to print</returns>
      /// <history>
      ///   [Theodore_Ward]   ??/??/????  Initial
      /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion
      ///   [Curtis_Beard]	   11/01/2005	CHG: Get correct hit object index
      /// </history>
      public string PrintSingleItem()
      {
         if (__listView.SelectedItems.Count > 0)
         {

            HitObject _hit = (HitObject)__grepTable[int.Parse(__listView.SelectedItems[0].SubItems[FileSearch.Constants.COLUMN_INDEX_GREP_INDEX].Text)];

            SetupDocument(string.Empty);

            AddLine("----------------------------------------------------------------------");
            AddLine(_hit.FilePath);
            AddLine("----------------------------------------------------------------------");

            for (int _index = 0; _index < _hit.LineCount; _index++)
               PrintHit(_hit.RetrieveLine(_index));
         }

         return __document;
      }
      #endregion

      #region Private Methods
      /// <summary>
      ///   Print a single hit
      /// </summary>
      /// <param name="hit">Hit to print</param>
      /// <history>
      ///   [Theodore_Ward]   ??/??/????  Initial
      /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void PrintHit(string hit)
      {
         // Remove the CR/LF at the end of each hit.
         if (hit.EndsWith("\r\n"))
            AddLine(hit.Substring(0, hit.Length - 2));
         else
            AddLine(hit);
      }

      /// <summary>
      ///   Setup the document
      /// </summary>
      /// <param name="header">Optional - Header of document</param>
      /// <history>
      /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void SetupDocument(string header)
      {
         __document = string.Empty;
      }

      /// <summary>
      ///   Add the line to the document
      /// </summary>
      /// <param name="line">Line to add</param>
      /// <history>
      /// 	[Curtis_Beard]	   01/11/2005	.Net Conversion
      /// </history>
      private void AddLine(string line)
      {
         __document += line + "\r\n";
      }
      #endregion
   }
}
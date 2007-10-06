using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace libFileSearch
{
	/// <summary>
   /// A HitObject contains the information of one instance of a file that contains
   /// the search text in a Grep search.  It contains every instance of the search text
   /// in a file.  This is done by creating an object and then calling Add passing in the
   /// line and line number in which the search text was found.  Other properties include 
   /// file name, full path, holding directory, file last write time, total count, and all 
   /// lines.  It is also possible to retrieve a specific line or line number based on 
   /// the index into the contained collection.
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
   /// 	[Curtis_Beard]    09/08/2005	Created
   ///   [Curtis_Beard]	   11/21/2005	ADD: support for total hit count
   ///   [Curtis_Beard]	   07/26/2006	ADD: 1512026, column position
   ///   [Curtis_Beard]    09/12/2006  CHG: Converted to C#
   /// </history>
	public class HitObject
	{
      #region Declarations
      private FileInfo __file;
      private StringCollection __lines;
      private StringCollection __lineNumbers;
      private int __index;
      private int __count = 0;
      private StringCollection __columns;
      #endregion

      #region Constructors
      /// <summary>
      /// Initializes a new instance of the HitObject class.
      /// </summary>
      /// <param name="file">FileInfo object</param>
      public HitObject(FileInfo file)
      {
         __file = file;

         __lines = new StringCollection();
         __lineNumbers = new StringCollection();
         __columns = new StringCollection();
      }

      /// <summary>
      /// Initializes a new instance of the HitObject class.
      /// </summary>
      /// <param name="path">File path</param>
      public HitObject(string path)
      {
         __file = new FileInfo(path);

         __lines = new StringCollection();
         __lineNumbers = new StringCollection();
         __columns = new StringCollection();
      }
      #endregion

      #region Public Properties
      /// <summary>
      /// Retrieve the name of the file
      /// </summary>
      /// <value>Name of file</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public string FileName
      {
         get 
         {
            return __file.Name;
         }
      }

      /// <summary>
      /// Retrieve the full path to the file
      /// </summary>
      /// <value>Full path to file</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public string FilePath
      {
         get 
         {
            return __file.FullName;
         }
      }

      /// <summary>
      /// Retrieve the holding directory of the file
      /// </summary>
      /// <value>Holding directory of file</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public string FileDirectory
      {
         get 
         {
            return __file.DirectoryName;
         }
      }

      /// <summary>
      /// Retrieve the last write time of the file
      /// </summary>
      /// <value>Last Write Time of file</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public DateTime FileModifiedDate
      {
         get 
         {
            return __file.LastWriteTime;
         }
      }

      /// <summary>
      /// Retrieve the FileInfo object of this object.
      /// </summary>
      /// <value>FileInfo object</value>
      /// <history>
      /// 	[Curtis_Beard]		07/27/2006	Created
      /// </history>
      public FileInfo File
      {
         get 
         {
            return __file;
         }
      }

      /// <summary>
      /// Retrieve all lines containing the search text
      /// </summary>
      /// <value>All lines</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public string Lines
      {
         get 
         {
            StringBuilder _lines = new StringBuilder(__lines.Count);

            foreach (string _line in __lines)
               _lines.Append(_line);

            return _lines.ToString();
         }
      }

      /// <summary>
      /// Retrieve the total number of lines
      /// </summary>
      /// <value>Total number of lines</value>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public int LineCount
      {
         get 
         {
            return __lines.Count;
         }
      }

      /// <summary>
      /// get {/Set the Index of the hit in the collection
      /// </summary>
      /// <value>Index position in collection</value>
      /// <returns>Index position in collection</returns>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public int Index
      {
         get 
         {
            return __index;
         }
         set 
         {
            __index = value;
         }
      }

      /// <summary>
      /// get {s the total hit count in the object
      /// </summary>
      /// <value>Total Hit Count</value>
      /// <returns>Total Hit Count</returns>
      /// <history>
      ///   [Curtis_Beard]	   11/21/2005	Created
      /// </history>
      public int HitCount
      {
         get 
         {
            return __count;
         }
      }
      #endregion

      #region Public Methods
      /// <summary>
      /// Retrieve a specified line
      /// </summary>
      /// <param name="index">line to retrieve</param>
      /// <returns>String.Empty if index is greater than total, line of text otherwise</returns>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public string RetrieveLine(int index)
      {
         if (index > __lines.Count)
            return string.Empty;

         return __lines[index];
      }

      /// <summary>
      /// Retrieve a specified line number
      /// </summary>
      /// <param name="index">line number to retrieve</param>
      /// <returns>0 if index is greater than total, line number otherwise</returns>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// </history>
      public int RetrieveLineNumber(int index)
      {
         if (index > __lineNumbers.Count)
            return 0;

         return int.Parse(__lineNumbers[index]);
      }

      /// <summary>
      /// Retrieve the first hit's column position.
      /// </summary>
      /// <param name="index">line number to retrieve</param>
      /// <returns>0 if index is greater than total, column position otherwise</returns>
      /// <history>
      /// 	[Curtis_Beard]		07/26/2006	ADD: 1512026, save column position
      /// </history>
      public int RetrieveColumn(int index)
      {
         if (index > __columns.Count)
            return 0;

         return int.Parse(__columns[index]);
      }

      /// <summary>
      /// Add a hit to the collection.
      /// </summary>
      /// <param name="line">line of text containing search text</param>
      /// <param name="lineNumber">line number of line in file</param>
      /// <returns>position of added item in collection</returns>
      /// <history>
      /// 	[Curtis_Beard]    09/09/2005	Created
      /// 	[Curtis_Beard]    07/26/2006	ADD: 1512026, save column position
      /// </history>
      public int Add(string line, int lineNumber)
      {
         __lines.Add(line);
         __lineNumbers.Add(lineNumber.ToString());
         __columns.Add("1");

         return __lines.Count - 1;
      }

      /// <summary>
      /// Add a hit to the collection.
      /// </summary>
      /// <param name="line">line of text containing search text</param>
      /// <param name="lineNumber">line number of line in file</param>
      /// <param name="column">column position of first hit in line</param>
      /// <returns>position of added item in collection</returns>
      /// <history>
      /// 	[Curtis_Beard]		07/26/2006	ADD: 1512026, save column position
      /// </history>
      public int Add(string line, int lineNumber, int column)
      {
         __lines.Add(line);
         __lineNumbers.Add(lineNumber.ToString());
         __columns.Add(column.ToString());

         return __lines.Count - 1;
      }

      /// <summary>
      /// Updates the total hit count
      /// </summary>
      /// <history>
      ///   [Curtis_Beard]	   11/21/2005	Created
      /// </history>
      public void SetHitCount()
      {
         __count += 1;
      }
      
      /// <summary>
      /// Updates the total hit count
      /// </summary>
      /// <param name="count">Value to add count to total</param>
      /// <history>
      ///   [Curtis_Beard]	   11/21/2005	Created
      /// </history>
      public void SetHitCount(int count)
      {
         __count += count;
      }
      #endregion
	}
}

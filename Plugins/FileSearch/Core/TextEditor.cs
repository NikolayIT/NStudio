using System;

namespace FileSearch
{
   /// <summary>
   /// Represents a Text Editor application.
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
   /// [Curtis_Beard]		07/21/2006	Created
   /// </history>
   public class TextEditor
   {
      #region Declarations
      private const string DELIMETER = "|";
      private string __type;
      private string __editor;
      private string __editorArgs;
      #endregion

      #region Constructors
      /// <summary>
      /// Initializes a new instance of the TextEditor class.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public TextEditor()
      {
         __type = string.Empty;
         __editor = string.Empty;
         __editorArgs = string.Empty;
      }

      /// <summary>
      /// Initializes a new instance of the TextEditor class.
      /// </summary>
      /// <param name="editorPath">Text Editor Path</param>
      /// <param name="editorArgs">Text Editor Command Line Arguments</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public TextEditor(string editorPath, string editorArgs)
      {
         __type = string.Empty;
         __editor = editorPath;
         __editorArgs = editorArgs;
      }

      /// <summary>
      /// Initializes a new instance of the TextEditor class.
      /// </summary>
      /// <param name="fileType">Text Editor File Type</param>
      /// <param name="editorPath">Text Editor Path</param>
      /// <param name="editorArgs">Text Editor Command Line Arguments</param>
      /// <history>
      /// [Curtis_Beard]		07/21/2006	Created
      /// </history>
      public TextEditor(string fileType, string editorPath, string editorArgs)
      {
         __type = fileType;
         __editor = editorPath;
         __editorArgs = editorArgs;
      }
      #endregion

      #region Properties
      /// <summary>
      /// Contains the file type.
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string FileType
      {
         get { return __type; }
         set { __type = value; }
      }

      /// <summary>
      /// Contains the location.
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string Editor
      {
         get { return __editor; }
         set { __editor = value; }
      }      

      /// <summary>
      /// Contains the command line arguments.
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]		07/21/2006	Created
      /// </history>
      public string Arguments
      {
         get { return __editorArgs; }
         set { __editorArgs = value; }
      }      
      #endregion

      #region public Methods
      /// <summary>
      /// Gets the string representation of this class.
      /// </summary>
      /// <returns></returns>
      /// <history>
      /// 	[Curtis_Beard]		07/21/2006	Created
      /// </history>
      public override string ToString()
      {
         return string.Format("{1}{0}{2}{0}{3}", DELIMETER, __type, __editor, __editorArgs);
      }

      /// <summary>
      /// Translates the given string representation into the class/s properties.
      /// </summary>
      /// <param name="classAsString">The string representation of this class</param>
      /// <history>
      /// 	[Curtis_Beard]		07/21/2006	Created
      /// </history>
      public void FromString(string classAsString)
      {
         if (classAsString.Length > 0 && classAsString.IndexOf(DELIMETER) > -1)
         {
            string[] values = classAsString.Split(char.Parse(DELIMETER));

            if (values.Length == 3)
            {
               __type = values[0];
               __editor = values[1];
               __editorArgs = values[2];
            }
         }
      }
      #endregion
   }
}

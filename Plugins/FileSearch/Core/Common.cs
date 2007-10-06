using System;

namespace FileSearch.Core
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
   /// [Curtis_Beard]	   11/03/2006	Created
   /// [Curtis_Beard] 	   05/18/2007	ADD: StoreDataLocal variable
   /// </history>
	public class Common
	{
      private Common()
      {}

      /// <summary>
      /// Determines if config files should be stored with the executable or 
      /// in the user's application data folder.
      /// </summary>
      public static bool StoreDataLocal = false;

      /// <summary>
      /// Split the given string by a string.
      /// </summary>
      /// <param name="stringToSplit">string to split</param>
      /// <param name="separator">separator as string</param>
      /// <returns>string array</returns>
      /// <history>
      /// [Curtis_Beard]	   11/03/2006	Created
      /// </history>
      public static string[] SplitByString(string stringToSplit, string separator)
      {
         int offset = 0;
         int index = 0;
         int[] offsets = new int[stringToSplit.Length + 1];

         while(index < stringToSplit.Length) 
         {
            int indexOf = stringToSplit.IndexOf(separator, index);
            if ( indexOf != -1 ) 
            {
               offsets[offset++] = indexOf;
               index = (indexOf+separator.Length);
            } 
            else 
            {
               index = stringToSplit.Length;
            }
         }

         string[] final = new string[offset+1];
         if ( offset == 0 ) //changed from 1, to fix when no split found
         {
            final[0] = stringToSplit;
         } 
         else 
         {
            offset--;

            final[0] = stringToSplit.Substring(0, offsets[0]);
            for(int i = 0; i < offset; i++) 
            {
               final[i+1] = stringToSplit.Substring(offsets[i]+separator.Length, offsets[i+1]-offsets[i]-separator.Length);
            }
            final[offset+1] = stringToSplit.Substring(offsets[offset]+separator.Length);
         }

         return final;
      }
	}
}

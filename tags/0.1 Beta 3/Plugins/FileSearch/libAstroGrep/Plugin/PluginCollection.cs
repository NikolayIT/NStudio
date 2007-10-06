using System.ComponentModel;
using System.Collections;

namespace libFileSearch.Plugin
{
   /// <summary>
   /// Used to store PluginWrapper modules in a type-specific collection.
   /// </summary>
   /// <remarks>
   ///   FileSearch File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002 AstroComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General publicLicense
   ///   as published by the Free Software Foundation; either version 2
   ///   of the License, or (at your option) any later version.
   ///   
   ///   This program is distributed in the hope that it will be useful,
   ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
   ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   ///   GNU General publicLicense for more details.
   ///   
   ///   You should have received a copy of the GNU General publicLicense
   ///   along with this program; if not, write to the Free Software
   ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
   /// 
   ///   The author may be contacted at:
   ///   ted@astrocomma.com or curtismbeard@gmail.com
   /// </remarks>
   /// <history>
   /// 	[Curtis_Beard]		07/31/2006	Created
   /// </history>
   public class PluginCollection
   {
      private ArrayList __List = null;

      /// <summary>
      /// Initializes a new instance of the PluginCollection class.
      /// </summary>
      /// <history>
      /// 	[Curtis_Beard]		07/31/2006	Created
      /// </history>
      public PluginCollection()
      {
         __List = new ArrayList();
      }

      /// <summary>
      /// Initializes a new instance of the PluginCollection class.
      /// </summary>
      /// <param name="capacity">The number of elements that the new list is initially capable of storing.</param>
      /// <history>
      /// 	[Curtis_Beard]		07/31/2006	Created
      /// </history>
      public PluginCollection(int capacity)
      {
         __List = new ArrayList(capacity);
      }

      /// <summary>
      /// Frees any resources for this class.
      /// </summary>
      ~PluginCollection()
      {
         __List.Clear();
         __List = null;
      }

      /// <summary>
      /// Adds a PluginWrapper to the end of the collection.
      /// </summary>
      /// <param name="plugin">The PluginWrapper to add to the end of the collection.</param>
      /// <returns>Position that the PluginWrapper was inserted.</returns>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public int Add(PluginWrapper plugin)
      {
         return __List.Add(plugin);
      }

      /// <summary>
      /// Gets the number of elements actually contained in the collection.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public int Count
      {
         get { return __List.Count; }
      }

      /// <summary>
      /// Removes the first occurrence of the given PluginWrapper.
      /// </summary>
      /// <param name="plugin">PluginWrapper object to remove.</param>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public void Remove(PluginWrapper plugin)
      {
         __List.Remove(plugin);
      }

      /// <summary>
      /// Removes the occurrence of the given PluginWrapper at the given index.
      /// </summary>
      /// <param name="index">The zero-based index of the PluginWrapper to remove.</param>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public void RemoveAt(int index)
      {
         __List.RemoveAt(index);
      }

      /// <summary>
      /// Gets or sets the element at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index of the element to get or set.</param>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public PluginWrapper this[int index]
      {
         get { return (PluginWrapper)__List[index]; }
         set { __List[index] = value; }
      }

      /// <summary>
      /// Inserts a PluginWrapper at the given index.
      /// </summary>
      /// <param name="index">The zero-based index at which value should be inserted.</param>
      /// <param name="plugin">The PluginWrapper to insert.</param>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public void Insert(int index, PluginWrapper plugin)
      {
         __List.Insert(index, plugin);
      }

      /// <summary>
      /// Removes all elements from the collection.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public void Clear()
      {
         __List.Clear();
      }

      /// <summary>
      /// Determines whether a PluginWrapper exists in the collection. 
      /// </summary>
      /// <param name="plugin">The PluginWrapper to locate in the collection.</param>
      /// <returns></returns>
      /// <history>
      /// [Curtis_Beard]		07/31/2006	Created
      /// </history>
      public bool Contains(PluginWrapper plugin)
      {
         return __List.Contains(plugin);
      }
   }
}
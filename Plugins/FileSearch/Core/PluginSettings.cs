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
   /// [Curtis_Beard]      04/25/2007  FIX: 1700029, always get correct config path
   /// </history>
   public sealed class PluginSettings
   {
      // This class is fully static.
      private PluginSettings()  {}

      #region Declarations
      private static PluginSettings __MySettings = null;

      private const string VERSION = "1.0";

      private string AllPlugins = string.Empty;
      #endregion

      /// <summary>
      /// Contains the static reference of this class.
      /// </summary>
      private static PluginSettings MySettings
      {
         get
         {
            if (__MySettings == null)
            {
               __MySettings = new PluginSettings();
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
               return Path.Combine(Constants.ProductLocation, "FileSearch.plugins.config");
            }
            else
            {
               string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.ProductName);

               return Path.Combine(path, "FileSearch.plugins.config");
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
      /// Gets/Sets the string containing all plugins.
      /// </summary>
      static public string Plugins
      {
         get { return MySettings.AllPlugins; }
         set { MySettings.AllPlugins = value; }
      }
   }
}

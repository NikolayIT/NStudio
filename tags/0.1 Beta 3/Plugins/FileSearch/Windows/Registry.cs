using System;
using System.Drawing;
using Microsoft.Win32;

namespace FileSearch.Windows
{
   /// <summary>
   /// Used to access the registry entries for this application.
   /// </summary>
   /// <remarks>
   ///   troGrep File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002 troComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General Public License
   ///    published by the Free Software Foundation; either version 2
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
   ///   ted@trocomma.com or curtismbeard@gmail.com
   /// </remarks>
   /// <history>
   /// [Curtis_Beard]		07/20/2006	Created
   /// </history>
   public class Registry
   {
      private static string APP_KEY = @"Software\VB and VBA Program Settings\FileSearch";
      private static string DEFAULT_SECTION_KEY = "Startup";

      /// <summary>
      /// Saves the string setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static void SaveStartupSetting(string key, string value)
      {
         SaveSetting(APP_KEY, DEFAULT_SECTION_KEY, key, value);
      }

      /// <summary>
      /// Saves the int setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static void SaveStartupSetting(string key, int value)
      {
         SaveSetting(APP_KEY, DEFAULT_SECTION_KEY, key, value.ToString());
      }

      /// <summary>
      /// Saves the bool setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static void SaveStartupSetting(string key, bool value)
      {
         SaveSetting(APP_KEY, DEFAULT_SECTION_KEY, key, value.ToString());
      }

      /// <summary>
      /// Saves the Color setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]   11/18/2005	Created
      /// </history>
      public static void SaveStartupSetting(string key, Color value)
      {
         SaveSetting(APP_KEY, DEFAULT_SECTION_KEY, key, value.ToArgb().ToString());
      }

      /// <summary>
      /// Gets the setting for a given key in the Startup section.
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static string GetStartupSetting(string key)
      {
         return GetSetting(APP_KEY, DEFAULT_SECTION_KEY, key, string.Empty);
      }

      /// <summary>
      /// Gets the setting for a given key in the Startup section.
      /// </summary>
      /// <param name="key"></param>
      /// <param name="defaultValue"></param>
      /// <returns></returns>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static string GetStartupSetting(string key, string defaultValue)
      {
         return GetSetting(APP_KEY, DEFAULT_SECTION_KEY, key, defaultValue);
      }

      /// <summary>
      /// Gets the setting for a given key in the Startup section.
      /// </summary>
      /// <param name="key"></param>
      /// <param name="defaultValue"></param>
      /// <returns></returns>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static int GetStartupSetting(string key, int defaultValue)
      {
         int _setting;

         try
         {
            _setting = int.Parse(GetSetting(APP_KEY, DEFAULT_SECTION_KEY, key, defaultValue.ToString()));
         }
         catch
         {
            _setting = defaultValue;
         }

         return _setting;
      }

      /// <summary>
      /// Gets the setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Son Le]	      07/28/2005	Created
      /// </history>
      public static bool GetStartupSetting(string key  , bool defaultValue  )
      {
         bool _setting;

         try
         {
            _setting = bool.Parse(GetSetting(APP_KEY, DEFAULT_SECTION_KEY, key, defaultValue.ToString()));
         }
         catch
         {
            _setting = defaultValue;
         }

         return _setting;
      }

      /// <summary>
      /// Gets the setting for a given key in the Startup section.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]   11/18/2005	Created
      /// </history>
      public static Color GetStartupSetting(string key, Color defaultValue)  
      {
         Color _setting;

         try
         {
            _setting = Color.FromArgb((int.Parse(GetSetting(APP_KEY, DEFAULT_SECTION_KEY, key, defaultValue.ToArgb().ToString()))));
         }
         catch
         {
            _setting = defaultValue;
         }

         return _setting;
      }

      /// <summary>
      /// Checks to see if a key exists in the Startup section.
      /// </summary>
      /// <param name="key">Name of setting to check</param>
      /// <returns>Returns true if found, false otherwise</returns>
      public static bool CheckStartupSetting(string key)
      {
         return CheckSetting(APP_KEY, DEFAULT_SECTION_KEY, key);
      }

      /// <summary>
      /// Deletes the setting in the Startup section.
      /// </summary>
      /// <param name="key">Name of setting to delete</param>
      /// <history>
      /// [Curtis_Beard]		07/20/2006	Created
      /// </history>
      public static void DeleteStartupSetting(string key)
      {
         try
         {
            DeleteSetting(APP_KEY, DEFAULT_SECTION_KEY, key);
         }
         catch {}
      }

      /// <summary>
      /// Get a specified registry key from a specified section for this application.
      /// </summary>
      /// <param name="section">Name of section</param>
      /// <param name="key">Name of key</param>
      /// <param name="defaultValue">Default value to return</param>
      /// <returns>Value of key, DefaultValue is not present</returns>
      /// <history>
      /// [Curtis_Beard]   07/10/2006	Created
      /// </history>
      public static string GetRegistrySetting(string section, string key, string defaultValue)
      {
         return GetSetting(APP_KEY, section, key, defaultValue);
      }
      
      /// <summary>
      /// Sets a specified registry key's value in a specified section for this application.
      /// </summary>
      /// <param name="section">Name of section</param>
      /// <param name="key">Name of key</param>
      /// <param name="value">Value to save</param>
      /// <history>
      /// [Curtis_Beard]   07/10/2006	Created
      /// </history>
      public static void SaveRegistrySetting(string section, string key, string value)
      {
         try
         {
            SaveSetting(APP_KEY, section, key, value);
         }
         catch {}
      }

      /// <summary>
      /// Deletes a given section from the registry for this application.
      /// </summary>
      /// <param name="section">Name of section</param>
      /// <history>
      /// [Curtis_Beard]   07/10/2006	Created
      /// </history>
      public static void DeleteRegistrySetting(string section)  
      {
         try
         {
            DeleteSetting(APP_KEY, section);
         }
         catch {}
      }

      /// <summary>
      /// Deletes a given section and given key from the registry for this application.
      /// </summary>
      /// <param name="section">Name of section</param>
      /// <param name="key">Name of key</param>
      /// <history>
      /// [Curtis_Beard]		07/20/2006	Created
      /// </history>
      public static void DeleteRegistrySetting(string section, string key)
      {
         try
         {
            DeleteSetting(APP_KEY, section, key);
         }
         catch {}
      }

      /// <summary>
      /// Deletes all registry entries for this application.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		10/11/2006	Created
      /// </history>
      public static void DeleteAllRegistry()
      {
         try
         {
            DeleteSetting(APP_KEY);
         }
         catch {}
      }

      #region Private Methods
      private static string GetSetting(string path, string section, string key, string defaultValue)
      {
         Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path + "\\" + section);
         if (regKey != null)
         {
            return regKey.GetValue(key, defaultValue).ToString();
         }
         return defaultValue;
      }

      private static void SaveSetting(string path, string section, string key, string value)
      {
         Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(path + "\\" + section);

         if (regKey != null)
         {
            regKey.SetValue(key, value);
         }
      }

      private static bool CheckSetting(string path, string section, string key)
      {
         Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path + "\\" + section, false);

         if (regKey != null)
         {
            if (regKey.GetValue(key) != null)
               return true;
         }

         return false;
      }

      private static void DeleteSetting(string path)
      {
         Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(path);
      }

      private static void DeleteSetting(string path, string section)
      {
         Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path, true);

         if (regKey != null)
         {
            regKey.DeleteSubKeyTree(section);
         }
      }

      private static void DeleteSetting(string path, string section, string key)
      {
         Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path + "\\" + section, true);

         if (regKey != null)
         {
            regKey.DeleteValue(key, false);
         }
      }
      #endregion
   }
}
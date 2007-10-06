using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FileSearch.Core
{
   /// <summary>
   /// Used to read or write class properties and their values to or from disk.
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
   /// </history>
	public sealed class SettingsIO
	{
		private SettingsIO() {}

      /// <summary>
      /// Loads the specified file into the given class with the given version.
      /// </summary>
      /// <param name="classRecord">Class</param>
      /// <param name="path">File path</param>
      /// <param name="version">Version of class</param>
      /// <returns>Returns True if class contains values from file, False otherwise.</returns>
      /// <history>
      /// [Curtis_Beard]      11/02/2006  Created
      /// [Curtis_Beard]      05/22/2007  CHG: only load properies that have CanWrite set to true
      /// </history>
      public static bool Load(object classRecord, string path, string version)
      {
         try
         {
            Type recordType = classRecord.GetType();
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = null;

            if (!File.Exists(path))
               return false;

            xmlDoc.Load(path);
            rootNode = xmlDoc.SelectSingleNode(recordType.Name);

            if (rootNode != null)
            {
               // check for correct version
               if (rootNode.Attributes.Count > 0 && rootNode.Attributes["version"] != null && rootNode.Attributes["version"].Value.Equals(version))
               {
                  XmlNodeList propertyNodes = rootNode.SelectNodes("property");

                  // check for at least 1 property node
                  if (propertyNodes != null && propertyNodes.Count > 0)
                  {
                     PropertyInfo[] properties = recordType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

                     //have properties
                     foreach (XmlNode node in propertyNodes)
                     {
                        string name = node.Attributes["name"].Value;
                        string data = node.FirstChild.InnerText;

                        foreach (PropertyInfo property in properties)
                        {
                           if (property.Name.Equals(name))
                           {
                              try
                              {
                                 // try for type's Parse method with a string parameter
                                 MethodInfo method = property.PropertyType.GetMethod("Parse", new Type[] {typeof(string)});
                                 if (method != null)
                                 {
                                    //property contains a parse
                                    property.SetValue(classRecord, method.Invoke(property, new object[]{data}), null);
                                 }
                                 else
                                 {
                                    // just try to set the object directly
                                    if (property.CanWrite)
                                       property.SetValue(classRecord, data, null);
                                 }
                                 method = null;
                              }
                              catch (Exception ex)
                              {
                                 Console.WriteLine(ex.ToString());
                              }

                              break;
                           }
                        }
                     }

                     return true;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
         }

         return false;
      }

      /// <summary>
      /// Saves the given class' properties to the given file with the given version.
      /// </summary>
      /// <param name="classRecord">Class to save</param>
      /// <param name="path">File path</param>
      /// <param name="version">Version of class</param>
      /// <returns>Returns True if succesfully saved, False otherwise</returns>
      /// <history>
      /// [Curtis_Beard]      11/02/2006  Created
      /// [Curtis_Beard]      04/15/2007  CHG: verify directory exists before saving file
      /// [Curtis_Beard]      05/22/2007  CHG: only write properies that have CanWrite set to true
      /// </history>
      public static bool Save(object classRecord, string path, string version)
      {
         try
         {
            Type recordType = classRecord.GetType();
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration decl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            XmlNode rootNode = xmlDoc.CreateElement(recordType.Name);
            XmlAttribute attrib = xmlDoc.CreateAttribute("version");
            XmlNode propertyNode = null;
            XmlNode valueNode = null;

            attrib.Value = version;
            rootNode.Attributes.Append(attrib);
            
            PropertyInfo[] properties = recordType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
               if (property.CanWrite)
               {
                  propertyNode = xmlDoc.CreateElement("property");
                  valueNode = xmlDoc.CreateElement("value");

                  attrib = xmlDoc.CreateAttribute("name");
                  attrib.Value = property.Name;
                  propertyNode.Attributes.Append(attrib);

                  attrib = xmlDoc.CreateAttribute("type");
                  attrib.Value = property.PropertyType.ToString();
                  propertyNode.Attributes.Append(attrib);

                  if (property.GetValue(classRecord, null) != null)
                     valueNode.InnerText = property.GetValue(classRecord, null).ToString();

                  propertyNode.AppendChild(valueNode);
                  rootNode.AppendChild(propertyNode);
               }
            }

            xmlDoc.AppendChild(decl);
            xmlDoc.AppendChild(rootNode);

            // verify directory exists before saving file
            FileInfo info = new FileInfo(path);
            if (!info.Directory.Exists)
               info.Directory.Create();

            xmlDoc.Save(path);

            // cleanup
            recordType = null;
            properties = null;
            xmlDoc = null;

            return true;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
         }

         return false;
      }

      /// <summary>
      /// Gets the class' properties as string values.
      /// </summary>
      /// <param name="classRecord">Class to retrieve</param>
      /// <returns>String containing class' properties as string values</returns>
      /// <history>
      /// [Curtis_Beard]      11/02/2006  Created
      /// </history>
      public static string ToString(object classRecord)
      {
         if (classRecord != null)
         {
            Type recordType = classRecord.GetType();
            PropertyInfo[] properties = recordType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            StringBuilder propBuilder = new StringBuilder(properties.Length);
            string data = string.Empty;

            foreach (PropertyInfo property in properties)
            {
               data = string.Empty;

               if (propBuilder.Length > 0)
                  propBuilder.Append("\r\n");

               if (property.GetValue(classRecord, null) != null)
                  data = property.GetValue(classRecord, null).ToString();

               propBuilder.AppendFormat("{0} ({1}) = {2}", property.Name, property.PropertyType.ToString(), data);
            }

            return propBuilder.ToString();
         }

         return string.Empty;
      }
	}
}

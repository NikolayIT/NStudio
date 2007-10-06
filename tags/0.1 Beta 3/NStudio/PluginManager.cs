using System;
using System.IO;
using System.Reflection;
using NStudioInterface;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
namespace NStudio
{
    public class PluginManager
    {
        public static List<PluginType> Plugins = new List<PluginType>();
        public static void LoadPlugin(string FileName, IMainForm Parent, bool ShowError)
        {
            try
            {
                Assembly pluginAssembly = Assembly.LoadFrom(FileName);
                Type[] types = pluginAssembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.Name.Equals("Plugin"))
                    {
                        IPlugin inst = (IPlugin)pluginAssembly.CreateInstance(type.FullName);
                        PluginType add = new PluginType(inst.Name, FileName, inst.Version);
                        if (!Plugins.Contains(add))
                        {
                            Plugins.Add(add);
                            inst.Initialize(Parent);
                            Parent.LoadPlugin(inst);
                        }
                        else if (ShowError) MessageBox.Show("This plugin is already loaded!", "Error");
                        pluginAssembly = null;
                        inst = null;
                        add = null;
                        return;
                    }
                }
                if (ShowError) MessageBox.Show("This is not valid plugin!", "Error");
            }
            catch (Exception ex)
            {
                if (ShowError) MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}

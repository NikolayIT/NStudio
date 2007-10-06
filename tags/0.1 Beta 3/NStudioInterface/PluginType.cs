using System;
using System.Collections.Generic;
using System.Text;

namespace NStudioInterface
{
    public class PluginType
    {
        public string name;
        public string path;
        public string version;
        public PluginType()
        {
        }
        public PluginType(string aName, string aPath, string aVersion)
        {
            name = aName;
            path = aPath;
            version = aVersion;
        }
        public override string ToString()
        {
            return name + " " + version;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() ^ path.GetHashCode() ^ version.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PluginType plugin = (PluginType)obj;
            bool equals = (name == plugin.name) && (path == plugin.path) && (version == plugin.version);
            return equals;
        }
    }
}

using System;
using System.Windows.Forms;
using System.Threading;
using NStudioInterface;
using System.IO;
using NStudioResources;
using System.Reflection;
using Scintilla.Configuration.SciTE;
using Scintilla.Configuration;
using System.Net;
using System.Text;

namespace NStudio
{
    public static class Global
    {
        public static IMainForm MainForm;

        public static SettingsManager Settings;
        public static LanguageBase Language;
        public static ResourceManager Resources = new ResourceManager();

        public static SciTEProperties ScintillaProperties;
        public static ScintillaConfig ScintillaConfig;

        public static bool HasWebBrowser = true;

        public const string Name = "NStudio";
        public const string Version = "v0.1-beta3 (0030)";
        public const string VersionID = "0030";
        public const string AssVersion = "0.0.3.0";
        public const string FullName = Name + " " + Version;
        public static string Path = Application.StartupPath;
        public static string[] Components = { 
            "ICSharpCode.TextEditor.dll 2.2.1.2622", 
            "SciLexer.dll 1.7.4.0",
            "ScintillaNET.dll 1.0.2626.22303",
            "WeifenLuo.WinFormsUI.Docking.dll 2.1.0.0",
            "HtmlEditControl.dll 1.0.0.0",
            "NStudioInterface.dll " + AssVersion,
            "NStudioResources.dll " + AssVersion,
            "Bulgarian.dll " + AssVersion,
            "Russian.dll " + AssVersion + " (translated by Moth)",
            "Latvian.dll " + AssVersion + " (translated by Moth)",
            "Hungarian.dll " + AssVersion + " (translated by Sasa)"};
        public static string SettingsFile = "config.xml";
        public static string ChangelogFile = "HISTORY.txt";
        public static string ReadmeFile = "README.txt";
        public static int DefXLocation = 0;
        public static int DefYLocation = 0;
        public static int DefWidth = 600;
        public static int DefHeight = 800;
        public static int MinWidth = 300;
        public static int MinHeight = 400;
        public static FormWindowState DefWinState = FormWindowState.Maximized;

        public static string ProgramSite = "http://nstudio.nrpg.info/";
        public static string ProgramForum = "http://nrpg.16.forumer.com/viewforum.php?f=27";
        public static string AuthorSite = "http://nrpg.info/";
        public static string AuthorMail = "mailto:nrpg666@yahoo.com";
        public static string OtherLink = "http://virus-bg.com/";
        public static string DefaultWebBrowserAddress = null;

        public static string CheckVersionScript = "http://nstudio.nrpg.info/vc.php";

        public static void Sleep(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }
        public static string VersionCheck(bool manual)
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append(CheckVersionScript);
            // http://vc.virus-bg.com/vc.php
            // ?
            // os=WinXP
            // &
            // dn=2.0.123.435546
            // &
            // v=0010
            // &
            // m=1
            string m = manual ? "1" : "0";
            sb.Append("?");
            sb.Append("os=" + Environment.OSVersion);
            sb.Append("&");
            sb.Append("dn=" + Environment.Version);
            sb.Append("&");
            sb.Append("v=" + VersionID);
            sb.Append("&");
            sb.Append("m=" + m);
            try
            {
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(sb.ToString());
                request1.Timeout = 2000;
                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                StreamReader reader1 = new StreamReader(response1.GetResponseStream());
                string asd = reader1.ReadToEnd();
                return asd;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static void LoadLanguage(string aName, IMainForm parent, bool ShowError)
        {
            if (aName == "English")
            {
                Language = new LanguageBase();
                Settings.Settings.Language = "English";
                parent.ChangeLanguage();
                return;
            }
            try
            {
                Assembly pluginAssembly = Assembly.LoadFrom(Path + "\\Languages\\" + aName + ".dll");
                Type[] types = pluginAssembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.Name.Equals("Language"))
                    {
                        Language = (LanguageBase)pluginAssembly.CreateInstance(type.FullName);
                    }
                }
                pluginAssembly = null;
            }
            catch (FileNotFoundException ex)
            {
                if (ShowError) MessageBox.Show(ex.Message, "Error");
                Language = new LanguageBase();
                Settings.Settings.Language = "English";
                parent.ChangeLanguage();
                return;
            }
            Settings.Settings.Language = aName;
            parent.ChangeLanguage();
        }
    }
}

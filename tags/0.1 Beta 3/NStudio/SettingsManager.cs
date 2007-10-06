using System;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using NStudioInterface;

namespace NStudio
{
    public class Settings
    {
        // Global settings
        public string Language = "English";
        public AvailableRenderers Renderer = AvailableRenderers.Professional;
        // Browser settings
        public bool BrowserDrop = true;
        public bool BrowserContextMenu = true;
        public bool BrowserScriptErrors = false;
        public bool BrowserScrollBar = true;
        public bool BrowserShortcuts = true;
        //
        public bool MinimizeToTray = false;
        public bool EnableDragAndDrop = true;
        public bool ShowStatusBar = true;
        public bool ShowFileToolBar = true;
        public bool ShowEditToolBar = true;
        public bool ShowViewToolBar = true;
        public bool ShowOthersToolBar = true;
    }
    public class SettingsManager
    {
        MainForm form;
        public Settings Settings = new Settings();

        #region Constructors
        public SettingsManager(MainForm aForm)
        {
            form = aForm;
        }
        #endregion

        #region Public Methods
        public void UpdateMenues()
        {
            form.MainMenu.RefreshMenu();        
        }
        public void RefreshForm()
        {
            form.StatusBar.Visible = Settings.ShowStatusBar;
            form.ToolBarFile.Visible = Settings.ShowFileToolBar;
            form.ToolBarEdit.Visible = Settings.ShowEditToolBar;
            form.ToolBarView.Visible = Settings.ShowViewToolBar;
            form.ToolBarOthers.Visible = Settings.ShowOthersToolBar;
            foreach (DockBase var in form.DockPane.Contents)
            {
                var.RefreshContent();
            }
        }
        public void SaveSettings()
        {
            XmlTextWriter writer = new XmlTextWriter(Global.Path + "\\" + Global.SettingsFile, Encoding.Unicode);
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");
                writer.WriteAttributeString("version", Global.Version);
                // Global
                WriteSetting(writer, "Language", Settings.Language.ToString());
                // Windows
                WriteSetting(writer, "Location.X", form.Location.X.ToString());
                WriteSetting(writer, "Location.Y", form.Location.Y.ToString());
                WriteSetting(writer, "Size.Width", form.Size.Width.ToString());
                WriteSetting(writer, "Size.Height", form.Size.Height.ToString());
                WriteSetting(writer, "WinState", form.WindowState.ToString());
                // Settings
                WriteSetting(writer, "MinimizeToTray", Settings.MinimizeToTray.ToString());
                WriteSetting(writer, "EnableDragAndDrop", Settings.EnableDragAndDrop.ToString());
                WriteSetting(writer, "ShowStatusBar", Settings.ShowStatusBar.ToString());
                WriteSetting(writer, "ShowFileToolBar", Settings.ShowFileToolBar.ToString());
                WriteSetting(writer, "ShowEditToolBar", Settings.ShowEditToolBar.ToString());
                WriteSetting(writer, "ShowViewToolBar", Settings.ShowViewToolBar.ToString());
                WriteSetting(writer, "ShowOthersToolBar", Settings.ShowOthersToolBar.ToString());
                // Browser
                WriteSetting(writer, "BrowserContextMenu", Settings.BrowserContextMenu.ToString());
                WriteSetting(writer, "BrowserDrop", Settings.BrowserDrop.ToString());
                WriteSetting(writer, "BrowserScriptErrors", Settings.BrowserScriptErrors.ToString());
                WriteSetting(writer, "BrowserScrollBar", Settings.BrowserScrollBar.ToString());
                WriteSetting(writer, "BrowserShortcuts", Settings.BrowserShortcuts.ToString());
                // Plugins
                WriteSetting(writer, "Plugins.Count", PluginManager.Plugins.Count.ToString());
                int n = 1;
                foreach (PluginType plugin in PluginManager.Plugins)
                {
                    WriteSetting(writer, "Plugins." + (n++), plugin.path);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            finally
            {
                writer.Close();
            }
        }
        public void LoadSettings()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Global.Path + "\\" + Global.SettingsFile);
                // Global
                Settings.Language = ReadElement(doc, "Language");
                Global.LoadLanguage(Settings.Language, form, false);
                // Location
                int x = Global.DefXLocation;
                int y = Global.DefYLocation;
                int.TryParse(ReadElement(doc, "Location.X"), out x);
                int.TryParse(ReadElement(doc, "Location.Y"), out y);
                form.Location = new Point(x, y);
                // Size
                int width = Global.DefWidth;
                int height = Global.DefHeight;
                int.TryParse(ReadElement(doc, "Size.Width"), out width);
                int.TryParse(ReadElement(doc, "Size.Height"), out height);
                if (width < Global.MinWidth) width = Global.MinWidth;
                if (height < Global.MinHeight) height = Global.MinWidth;
                form.Size = new Size(width, height);
                // WindowsState
                form.WindowState = WindowStateFromString(ReadElement(doc, "WinState"));
                // Settings
                Settings.MinimizeToTray = TryParseBool(doc, "MinimizeToTray", Settings.MinimizeToTray);
                Settings.EnableDragAndDrop = TryParseBool(doc, "EnableDragAndDrop", Settings.EnableDragAndDrop);
                Settings.ShowStatusBar = TryParseBool(doc, "ShowStatusBar", Settings.ShowStatusBar);
                Settings.ShowFileToolBar = TryParseBool(doc, "ShowFileToolBar", Settings.ShowFileToolBar);
                Settings.ShowEditToolBar = TryParseBool(doc, "ShowEditToolBar", Settings.ShowEditToolBar);
                Settings.ShowViewToolBar = TryParseBool(doc, "ShowViewToolBar", Settings.ShowViewToolBar);
                Settings.ShowStatusBar = TryParseBool(doc, "ShowStatusBar", Settings.ShowStatusBar);
                // Browser
                Settings.BrowserContextMenu = TryParseBool(doc, "BrowserContextMenu", Settings.BrowserContextMenu);
                Settings.BrowserDrop = TryParseBool(doc, "BrowserDrop", Settings.BrowserDrop);
                Settings.BrowserScriptErrors = TryParseBool(doc, "BrowserScriptErrors", Settings.BrowserScriptErrors);
                Settings.BrowserScrollBar = TryParseBool(doc, "BrowserScrollBar", Settings.BrowserScrollBar);
                Settings.BrowserShortcuts = TryParseBool(doc, "BrowserShortcuts", Settings.BrowserShortcuts);
                //
                // Plugins
                int count = 0;
                int.TryParse(ReadElement(doc, "Plugins.Count"), out count);
                for (int i = 1; i <= count; i++)
                {
                    try
                    {
                        PluginManager.LoadPlugin(ReadElement(doc, "Plugins." + i.ToString()), form, false);
                    }
                    catch { }
                }
            }
            catch { }
            RefreshForm();
        }
        #endregion

        #region Private Methods
        private static bool TryParseBool(XmlDocument doc, string aName, bool def)
        {
            bool temp;
            try
            {
                temp = bool.Parse(ReadElement(doc, aName));
            }
            catch
            {
                temp = def;
            }
            return temp;
        }
        private static void WriteSetting(XmlWriter doc, string Name, string Value)
        {
            //doc.WriteStartElement(Name);
            doc.WriteElementString(Name, Value);
        }
        private static FormWindowState WindowStateFromString(string state)
        {
            if (state == "Maximized") return FormWindowState.Maximized;
            else if (state == "Minimized") return FormWindowState.Minimized;
            else if (state == "Normal") return FormWindowState.Normal;
            else return Global.DefWinState;
        }
        private static string ReadElement(XmlDocument doc, string aName)
        {
            return doc.GetElementsByTagName(aName)[0].InnerText;
        }
        #endregion
    }
}
/*
[quote="The MAZZTer"]- Using icons can improve an interface, but there is such a thing as too many icons.  The icons on the top level menus (File, Edit, etc) conflict with the standard "text-only" style used by every other Windows program.  IMO you should consider removing those icons.[/quote]
I thing its better to have icons in  the top level menus. Its better for user to find what he need.

[quote="The MAZZTer"]- Have all plugins loaded by default and automatically (scan the plugins folder for DLL files and try to load them).  You can use an options dialog tab with a CheckListBox to allow the user to disable/enable plugins.[/quote]
I added ability to load all available plugins in the plugins folder.

[quote="The MAZZTer"]- It is possible to load the same plugin multiple times.  This should not be possible, IMO.[/quote]
Fixed!

[quote="The MAZZTer"]- I do not see a way to reopen a FileSearch tab without reloading the plugin.  You should be able to open as many FileSearch tabs as you want with one plugin.[/quote]
Done!

[quote="The MAZZTer"]- Your plugins' menu "Loaded Plugins" option has suboptions which do not do anything.  I recommend you move this into an options dialog as I described above, or make sure every plugin has a submenu under Plug-ins like FileSearch does.[/quote]
I thing to add unload ability there, but can't do this now. So for now I will not do anything there.

[quote="The MAZZTer"]- In addition, the FileSearch menu cascades into more menus... IMO you should try and consolidate them into one menu.  If you want to use top level menus, it should be on the top level (perhaps allowing plugins to add items to top level menus could be another alternative, but this would be messy).  Another solution is to allow plugins to add a tab to the options dialog, where plugin settings can be modified.  Also you can put buttons on the main FileSearch UI to replace some of the menu options.[/quote]
FileSearch Plugin menu is now on the top level.

[quote="The MAZZTer"]- The Mozilla Firefox Plugin is a dead link.  Please mirror it somewhere else, I like Firefox! :)[/quote]
This is really good to see IE and FireFox in one program. Isn't it? :)
Try this: http://files-upload.com/256749/MozillaFirefoxPlugin.rar.html

[quote="The MAZZTer"]- The browser tab has it's own statusbar, which doesn't look good if the other statusbar is there too.  In addition, it has a gripper in the lower right corner (usually for resizing a window) but it is unusable.  When in tab mode, the browser should not have a gripper in its' status bar.[/quote]
Fixed! Now Browser control uses program status bar instead of his own.

[quote="The MAZZTer"]- You have two ways of changing the Renderer.  Through the View menu or the View toolbar.  But if you use one to change, the other one stays selected on the old Renderer!  I have done similar UI things and I recommend making a function handle the MenuOpening event for both, to determine which renderer is being used and then to checkmark the appropriate menu option.  There are other ways of fixing it but I find this way works best for me.[/quote]


- When using File > Open, the menu stays open while you are using the dialog.  This doesn't fit with traditional Windows open dialogs (the menu closes before the dialog appears) and the menu can also sometimes obscure the dialog.

- Typo... "Standard Editor" In both File > New and File > Open.  I think you mean "Standard".

- The "Close" and "Save As" options are not disabled when there are no documents open.

- When opening a file, you should be able to determine which editor to use based on the file extension, the user should not have to explicitly select one.  In cases where you might want to override the extension, the user should be able to explicitly select one, but there should be a general purpose Open dialog which can autoselect an editor to use (Visual Studio handles this good by making the Open button in the dialog a dropdown button which allows you to pick another editor directly from the Open dialog, but you may find it not worth the effort to do all the dirty work needed to change the dialog).

This is a very interesting project, I look forward to seeing more plugins and useful developer tools built-in (sidebars are fun!) and I hope my suggestions help! :)[/quote]
*/
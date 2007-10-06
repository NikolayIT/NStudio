using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NStudioInterface
{
    public interface IMainMenu
    {
        void AddToUnloadPlugin(string aName);
        void AddPluginMenu(ToolStripMenuItem aMenu);
        void AddMenu(ToolStripMenuItem aMenu);
        void RemoveMenu(ToolStripMenuItem aMenu);
        void RefreshMenu();
        void ChangeLanguage();
    }
}

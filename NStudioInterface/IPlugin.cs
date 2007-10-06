using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace NStudioInterface
{

    public interface IPlugin
    {
        //IPluginHost Host { get;set;}
        string Name { get;}
        string Description { get;}
        string Author { get;}
        string Version { get;}
        string FullName { get;}

        void Initialize(IMainForm aParent);
        void Dispose();
    }
    /*
    public interface IPluginHost
    {
        void Feedback(string Feedback, IPlugin Plugin);
    }
     */
}

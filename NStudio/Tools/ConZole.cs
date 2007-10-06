using System;
using NStudioInterface;
using System.IO;
using System.Diagnostics;

namespace NStudio
{
    public partial class ConZole : DockBase
    {
        public ConZole()
        {
            InitializeComponent();
            dirInfo = new DirectoryInfo(Global.Path);
            commandPrompt1.PromptString = dirInfo.FullName;
        }
        public override string StatusBarName
        {
            get
            {
                return "ConZole v0.1";
            }
        }
        private DirectoryInfo dirInfo;
        private void commandPrompt1_Command(object aSender, CommandEventArgs aEventArgs)
        {
            if (aEventArgs.Command == "cls")
            {
                commandPrompt1.ClearMessages();
                aEventArgs.Cancel = true;
                return;
            }
            if (aEventArgs.Command == "date")
            {
                aEventArgs.Message = "  The current date is : " +
                    DateTime.Now.ToLongDateString();
                return;
            }
            if (aEventArgs.Command == "time")
            {
                aEventArgs.Message = "  The current time is : " +
                    DateTime.Now.ToLongTimeString();
                return;
            }
            if (aEventArgs.Command == "dir")
            {
                string msg = "";

                DirectoryInfo[] di = dirInfo.GetDirectories();
                foreach (DirectoryInfo d in di)
                {
                    msg += "  " + d.LastWriteTime.ToShortDateString()
                        + "\t" + d.LastWriteTime.ToShortTimeString()
                        + "\t<DIR>\t"
                        + "\t" + d.Name + "\n";
                }

                FileInfo[] fi = dirInfo.GetFiles();
                foreach (FileInfo f in fi)
                {
                    msg += "  " + f.LastWriteTime.ToShortDateString()
                        + "\t" + f.LastWriteTime.ToShortTimeString()
                        + "\t\t" + f.Length
                        + "\t" + f.Name + "\n";
                }
                aEventArgs.Message = msg;
                return;
            }
            if (aEventArgs.Command == "cd..")
            {
                if (dirInfo.Parent != null)
                    dirInfo = dirInfo.Parent;
                commandPrompt1.PromptString = dirInfo.FullName;
                return;
            }
            if (aEventArgs.Command.Length > 3 && aEventArgs.Command.Substring(0, 2) == "cd")
            {
                if (aEventArgs.Parameters.Length > 1)
                {
                    string path = aEventArgs.Parameters[1];
                    string newDir = dirInfo.FullName + "\\" + path;

                    path = dirInfo.FullName;
                    dirInfo = new DirectoryInfo(newDir);
                    if (dirInfo.Exists == false)
                    {
                        dirInfo = new DirectoryInfo(path);
                        aEventArgs.Message = "Could not find the specified path";
                    }
                    else
                        commandPrompt1.PromptString = dirInfo.FullName;

                    return;
                }
            }
            else
            {
                try
                {
                    Process.Start(dirInfo.FullName + "\\" + aEventArgs.Command);
                }
                catch
                {
                    aEventArgs.Message = "'" + aEventArgs.Command + "' is an unrecognized command";
                }
            }
        }
    }
}
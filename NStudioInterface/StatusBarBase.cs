using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NStudioInterface
{
    public abstract class StatusBarBase : StatusStrip
    {
        public IMainForm parent;
        public abstract void SetStatusBarText(string aText);
        public abstract void SetStatusBarName(string aName);
    }
}

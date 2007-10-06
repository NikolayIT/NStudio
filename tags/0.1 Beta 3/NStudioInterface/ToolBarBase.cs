using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NStudioInterface
{
    public abstract class ToolBarBase : ToolStrip
    {
        public abstract void RefreshToolBar();
    }
}

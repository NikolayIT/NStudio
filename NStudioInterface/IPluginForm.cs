using System;
using System.Collections.Generic;
using System.Text;

namespace NStudioInterface
{
    public interface IPluginForm
    {
        IMainForm ParentMainForm { set; get;}
    }
}

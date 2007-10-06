using System;
using System.Collections.Generic;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace NStudioInterface
{
    public partial class DockBase : DockContent
    {
        public event ControlChangedEventHandler ControlChanged;
        protected void OnControlChanged(ChangedControl change)
        {
            try
            {
                ControlChangedEventArgs args = new ControlChangedEventArgs(ChangedControl.TextChanged);
                ControlChanged(this, args);
            }
            catch(NullReferenceException) { }
        }
        public string Type = "Unknown";
        public virtual void RefreshContent() { }
        public virtual string StatusBarName
        {
            get { return ToString(); }
        }
    }
    public delegate void ControlChangedEventHandler(object aSender, ControlChangedEventArgs aEventArgs);
    public class ControlChangedEventArgs : EventArgs
    {
        private ChangedControl change;
        public ControlChangedEventArgs(ChangedControl aChange)
        {
            change = aChange;
        }
        public ChangedControl Change
        {
            get { return change; }
        }
    }
    public enum ChangedControl
    {
        TextChanged,
        TextSelected,
    }
}

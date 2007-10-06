using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NStudioInterface;

namespace NStudio
{
    public partial class ClipboardRing : DockBase
    {
        public override string StatusBarName
        {
            get
            {
                return "Clipboard Ring 0.1 (" + data.Count + ")";
            }
        }
        List<string> data = new List<string>();
        private string Last = null;
        public ClipboardRing()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!Clipboard.GetText().Equals(Last))
            {
                string dt = Clipboard.GetText();
                Last = dt;
                if (dt != null && dt != "" && !data.Contains(dt))
                {
                    listBox1.Items.Add(dt);
                    data.Add(dt);
                }
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                Clipboard.SetText(data[listBox1.SelectedIndex]);
        }
    }
}
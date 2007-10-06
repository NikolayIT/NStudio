using System;
using NStudioInterface;

namespace NStudio
{
    public partial class SearchReplace : DockBase
    {
        public SearchReplace()
        {
            InitializeComponent();
        }
        public override string StatusBarName
        {
            get
            {
                return "Search and Replace";
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Opacity = (trackBar2.Value/100.0);
        }
    }
}
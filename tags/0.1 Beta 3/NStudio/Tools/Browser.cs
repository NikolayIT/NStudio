using System;
using System.Drawing;
using System.Windows.Forms;
using NStudioInterface;

namespace NStudio
{
    public partial class Browser : DocumentBase
    {
        public override void RefreshContent()        {
            webBrowser1.IsWebBrowserContextMenuEnabled = Global.Settings.Settings.BrowserContextMenu;
            webBrowser1.AllowWebBrowserDrop = Global.Settings.Settings.BrowserDrop;
            webBrowser1.ScriptErrorsSuppressed = Global.Settings.Settings.BrowserScriptErrors;
            webBrowser1.ScrollBarsEnabled = Global.Settings.Settings.BrowserScrollBar;
            webBrowser1.WebBrowserShortcutsEnabled = Global.Settings.Settings.BrowserShortcuts;
        }
        public override string StatusBarName
        {
            get
            {
                return "WebBrowser v0.31 (IE " + webBrowser1.Version + ")";
            }
        }
        private IMainForm parent;
        private void AfterInit()
        {
            webBrowser1.StatusTextChanged += new EventHandler(webBrowser1_StatusTextChanged);
            Back.Image = Global.Resources.BackImage;
            Forward.Image = Global.Resources.ForwardImage;
            Refr.Image = Global.Resources.RefreshImage;
            Stop.Image = Global.Resources.DeleteImage;
            Home.Image = Global.Resources.HomeImage;
            Search.Image = Global.Resources.WebSearchImage;
            Go.Image = Global.Resources.GoImage;
            Check();
        }
        void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            parent.StatusBar.SetStatusBarText(webBrowser1.StatusText);
        }
        public Browser(IMainForm aParent)
        {
            parent = aParent;
            InitializeComponent();
            AfterInit();
        }
        public Browser(IMainForm aParent, string url)
        {
            parent = aParent;
            InitializeComponent();
            AfterInit();
            webBrowser1.Navigate(url);
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Check();
        }
        private void Check()
        {
            Back.Enabled = webBrowser1.CanGoBack;
            Forward.Enabled = webBrowser1.CanGoForward;
            if (webBrowser1.Url != null) Address.Text = webBrowser1.Url.ToString();
            TabText = Text = "Browser - " + webBrowser1.DocumentTitle;
            //toolStripProgressBar1.Value = (int)(e.CurrentProgress / e.MaximumProgress) * 100;
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == Back)
            {
                webBrowser1.GoBack();
                Check();
            }
            if (e.ClickedItem == Forward)
            {
                webBrowser1.GoForward();
                Check();
            }
            if (e.ClickedItem == Refr) webBrowser1.Refresh();
            if (e.ClickedItem == Stop) webBrowser1.Stop();
            if (e.ClickedItem == Home) webBrowser1.GoHome();
            if (e.ClickedItem == Search) webBrowser1.GoSearch();
            if (e.ClickedItem == Go) webBrowser1.Navigate(Address.Text);
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Check();
        }
        private void Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) webBrowser1.Navigate(Address.Text);
        }
        private void Browser_Resize(object sender, EventArgs e)
        {
            Address.Size = new Size(Size.Width - 185, 25);
        }
        private void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.AddBrowser(webBrowser1.StatusText);
            e.Cancel = true;
        }
    }
}
using System;
using System.Windows.Forms;
using NStudioInterface;
using System.Net;
using System.Collections;

namespace NStudio
{
    public partial class SystemInformationTool : DockBase
    {
        public SystemInformationTool()
        {
            InitializeComponent();
        }
        public override string StatusBarName
        {
            get
            {
                return "System Information v0.1";
            }
        }
        private void SystemInformation_Load(object sender, EventArgs e)
        {
            // Global Info
            listView1.Items.Add("OS Version: " + Environment.OSVersion);
            listView1.Items.Add(".NET Version: " + Environment.Version);
            listView1.Items.Add("Machine Name: " + Environment.MachineName);
            listView1.Items.Add("User Domain Name: " + Environment.UserDomainName);
            listView1.Items.Add("User Interactive: " + Environment.UserInteractive);
            listView1.Items.Add("User Name: " + Environment.UserName);
            listView1.Items.Add("Has Shutdown Started: " + Environment.HasShutdownStarted);
            // Hardware
            listView1.Items.Add("Processor Count: " + Environment.ProcessorCount);
            listView1.Items.Add("Working Set: " + Environment.WorkingSet);
            listView1.Items.Add("Monitor Size: " + SystemInformation.PrimaryMonitorSize.ToString());
            // Network
            listView1.Items.Add("Network: " + SystemInformation.Network);
            IPAddress[] ipEntry = Dns.GetHostAddresses(Dns.GetHostName());
            int i = 0;
            foreach (IPAddress address in ipEntry)
            {
                i++;
                listView1.Items.Add("IP_" + i + ": " + address);
            }
            // Directories
            listView1.Items.Add("Current Directory: " + Environment.CurrentDirectory);
            listView1.Items.Add("System Directory: " + Environment.SystemDirectory);
            // System Variables
            IDictionary dict = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry entry in dict)
            {
                listView1.Items.Add("SV_" + entry.Key + ": " + entry.Value);
            }
        }
    }
}
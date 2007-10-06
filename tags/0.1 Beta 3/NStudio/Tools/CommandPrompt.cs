using System;
using System.Drawing;
using System.Windows.Forms;

namespace NStudio
{
    public partial class CommandPrompt : UserControl
    {
        public event CommandEventHandler Command;
        private Color MessagesColor = Color.Cyan;
        private string promptstring;
        public CommandPrompt()
        {
            InitializeComponent();
        }
        /*
        private string promptString = ">";
        [Description("String showed as the prompt")]
        [DefaultValue(">")]
        public string PromptString
        {
            get { return promptString; }
            set
            {
                promptString = value;
                lblPrompt.Text = promptString;
            }
        }
         */
        private char[] delimiters = new char[] { ' ' };
        private string[] ParseInput()
        {
            string temp = textBox1.Text;
            return temp.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        public string PromptString
        {
            set { promptstring = value; }
        }

        private void PrintMessage(string aMessage)
        {
            int prevLength = richTextBox1.Text.Length;

            richTextBox1.AppendText(aMessage + Environment.NewLine);

            richTextBox1.SelectionStart = prevLength;
            richTextBox1.SelectionLength = richTextBox1.Text.Length - prevLength;
            richTextBox1.SelectionColor = MessagesColor;

            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();

            textBox1.Focus();
        }
        private void PrintCommand(string aCommand)
        {
            richTextBox1.AppendText(promptstring + ">> " + aCommand + Environment.NewLine);

            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
        public void ClearMessages()
        {
            richTextBox1.Text = "";
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                SuspendLayout();
                CommandEventArgs args = new CommandEventArgs(textBox1.Text, ParseInput());
                PrintCommand(textBox1.Text);
                Command(this, args);
                if (args.Cancel == false)
                {
                    if (args.Message != "")
                    {
                        PrintMessage(args.Message);
                    }
                }
                textBox1.Text = "";
                ResumeLayout();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = "";
            }
        }
    }
    public delegate void CommandEventHandler(object aSender, CommandEventArgs aEventArgs);
    public class CommandEventArgs : EventArgs
    {
        private bool cancel = false;
        private string command = "";
        private string message = "";
        private string[] parameters;
        //
        public CommandEventArgs(string aCommand, string[] param)
        {
            command = aCommand;
            parameters = param;
        }
        //
        public string Command
        {
            get { return command; }
        }
        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public string[] Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}

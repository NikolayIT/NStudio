using System;
using System.Text;
using NStudioInterface;

namespace NStudio
{
    public static class EditActions
    {
        public static void ToUpper()
        {
            //Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://" + Search.Text);
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText =
                    ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText.ToUpper();
            }
        }
        public static void ToLower()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText =
                    ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText.ToLower();
            }
        }
        public static void Capitalize()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                StringBuilder builder = new StringBuilder(((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText);
                for (int i = 0; i < builder.Length; i++)
                {
                    if (!char.IsLetter(builder[i]) && (i < (builder.Length - 1)))
                    {
                        builder[i + 1] = char.ToUpper(builder[i + 1]);
                    }
                }
                ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText = builder.ToString();
            }
        }
        public static void InvertCase()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                StringBuilder builder = new StringBuilder(((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText);
                for (int i = 0; i < builder.Length; i++)
                {
                    builder[i] = char.IsUpper(builder[i])
                                     ? char.ToLower(builder[i])
                                     : char.ToUpper(builder[i]);
                }
                ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText = builder.ToString();
            }
        }
        public static void ReverseText()
        {
            if (Global.MainForm.DockPane.ActiveContent is DocumentBase)
            {
                string text = ((DocumentBase) Global.MainForm.DockPane.ActiveContent).SelectedText;
                StringBuilder builder = new StringBuilder(text.Length);
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    builder.Append(text[i]);
                }
                ((DocumentBase)Global.MainForm.DockPane.ActiveContent).SelectedText = builder.ToString();
            }
        }
    }
}

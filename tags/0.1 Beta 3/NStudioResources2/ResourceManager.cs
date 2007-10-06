using System;
using System.Collections.Generic;
using System.Text;
using NStudioInterface;

namespace NStudioResources
{
    public class ResourceManager : IResources
    {

        #region IResources Members

        public System.Drawing.Bitmap BackImage
        {
            get { return NStudioResources.Properties.Resources.back; }
        }

        public System.Drawing.Bitmap ViewImage
        {
            get { return NStudioResources.Properties.Resources.color; }
        }

        public System.Drawing.Bitmap CopyImage
        {
            get { return NStudioResources.Properties.Resources.copy; }
        }

        public System.Drawing.Bitmap CutImage
        {
            get { return NStudioResources.Properties.Resources.cut; }
        }

        public System.Drawing.Bitmap DeleteImage
        {
            get { return NStudioResources.Properties.Resources.delete; }
        }

        public System.Drawing.Bitmap EditImage
        {
            get { return NStudioResources.Properties.Resources.edit; }
        }

        public System.Drawing.Bitmap FileImage
        {
            get { return NStudioResources.Properties.Resources.file; }
        }

        public System.Drawing.Bitmap ForwardImage
        {
            get { return NStudioResources.Properties.Resources.forward; }
        }

        public System.Drawing.Bitmap GoImage
        {
            get { return NStudioResources.Properties.Resources.go; }
        }

        public System.Drawing.Bitmap HelpImage
        {
            get { return NStudioResources.Properties.Resources.help; }
        }

        public System.Drawing.Bitmap HomeImage
        {
            get { return NStudioResources.Properties.Resources.home; }
        }

        public System.Drawing.Bitmap NewImage
        {
            get { return NStudioResources.Properties.Resources._new; }
        }

        public System.Drawing.Bitmap OpenImage
        {
            get { return NStudioResources.Properties.Resources.open; }
        }

        public System.Drawing.Bitmap PasteImage
        {
            get { return NStudioResources.Properties.Resources.paste; }
        }

        public System.Drawing.Bitmap PencilImage
        {
            get { return NStudioResources.Properties.Resources.pencil; }
        }

        public System.Drawing.Bitmap PluginsImage
        {
            get { return NStudioResources.Properties.Resources.plugins; }
        }

        public System.Drawing.Bitmap PrintImage
        {
            get { return NStudioResources.Properties.Resources.print; }
        }

        public System.Drawing.Bitmap PrintPreviewImage
        {
            get { return NStudioResources.Properties.Resources.printpreview; }
        }

        public System.Drawing.Bitmap PropertiesImage
        {
            get { return NStudioResources.Properties.Resources.properties; }
        }

        public System.Drawing.Bitmap RedoImage
        {
            get { return NStudioResources.Properties.Resources.redo; }
        }

        public System.Drawing.Bitmap RefreshImage
        {
            get { return NStudioResources.Properties.Resources.refresh; }
        }

        public System.Drawing.Bitmap SaveImage
        {
            get { return NStudioResources.Properties.Resources.save; }
        }

        public System.Drawing.Bitmap SaveAllImage
        {
            get { return NStudioResources.Properties.Resources.saveall; }
        }

        public System.Drawing.Bitmap UndoImage
        {
            get { return NStudioResources.Properties.Resources.undo; }
        }

        public System.Drawing.Bitmap WebImage
        {
            get { return NStudioResources.Properties.Resources.web; }
        }

        public System.Drawing.Bitmap WebSearchImage
        {
            get { return NStudioResources.Properties.Resources.websearch; }
        }

        #endregion
    }
}

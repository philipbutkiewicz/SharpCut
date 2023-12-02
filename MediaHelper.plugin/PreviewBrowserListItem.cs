using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHelper.plugin
{
    public partial class PreviewBrowserListItem : UserControl
    {
        public string FileName = "";

        public bool ShouldDelete = false;

        public bool IsSelected = false;

        private Font font = new Font("Segoe UI", 8.25f, FontStyle.Regular);

        private bool mouseEntered = false;

        public PreviewBrowserListItem()
        {
            InitializeComponent();
        }

        private void PreviewBrowserListItem_Paint(object sender, PaintEventArgs e)
        {
            if (IsSelected)
            {
                e.Graphics.Clear(SystemColors.ActiveBorder);
            }
            else if (!mouseEntered)
            {
                e.Graphics.Clear(SystemColors.Control);
            }
            else
            {
                e.Graphics.Clear(SystemColors.ControlLight);
            }

            string[] drawNameSlices = FileName.Replace("\\", "/").Split(new char[] { '/' });
            string drawName = drawNameSlices.Length > 0 ? drawNameSlices[drawNameSlices.Length - 1] : FileName.Replace("\\", "/").Replace("/", "");

            e.Graphics.DrawString(drawName, font, ShouldDelete ? Brushes.Red : Brushes.Green, new PointF(3, 3));
        }

        private void PreviewBrowserListItem_MouseEnter(object sender, EventArgs e)
        {
            mouseEntered = true;
            Invalidate();
        }

        private void PreviewBrowserListItem_MouseLeave(object sender, EventArgs e)
        {
            mouseEntered = false;
            Invalidate();
        }
    }
}

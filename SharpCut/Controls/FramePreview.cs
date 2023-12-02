using SharpCutCommon.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCut.Controls
{
    public partial class FramePreview : UserControl
    {
        #region Properties

        /// <summary>
        /// Video frame to preview.
        /// </summary>
        public Image VideoFrame { get => videoFrame; set => videoFrame = value; }

        /// <summary>
        /// Target preview frame height.
        /// </summary>
        public int FrameHeight { get => frameHeight; set => frameHeight = value; }

        #endregion

        #region Fields

        /// <summary>
        /// Video frame to preview.
        /// </summary>
        private Image videoFrame;

        /// <summary>
        /// Target preview frame height.
        /// </summary>
        private int frameHeight = 90;

        #endregion

        public FramePreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the preview frame.
        /// </summary>
        public void ShowFrame()
        {
            if (videoFrame == null || videoFrame.Width < 100 || videoFrame.Height < 100)
            {
                throw new Exception("Invalid or missing video frame!");
            }

            float aspectRatio = (float)videoFrame.Width / (float)videoFrame.Height;
            Bounds = new Rectangle(Bounds.X, Bounds.Y, (int)(frameHeight * aspectRatio), 90);

            Show();
        }

        #region Private methods

        /// <summary>
        /// Paints the video frame.
        /// </summary>
        /// <param name="g"></param>
        private void PaintFrame(Graphics g)
        {
            if (videoFrame != null)
            {
                g.DrawImage(videoFrame, 0, 0, Bounds.Width, Bounds.Height);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Paints this control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FramePreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Clear(Color.Gray);

            PaintFrame(g);
        }

        #endregion
    }
}

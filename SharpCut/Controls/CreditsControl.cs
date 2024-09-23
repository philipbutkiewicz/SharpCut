using Newtonsoft.Json.Linq;
using SharpCutCommon.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SharpCut.Controls
{
    public partial class CreditsControl : UserControl
    {
        #region Props

        /// <summary>
        /// List of lines to display as credits
        /// </summary>
        public List<string> Credits
        {
            set
            {
                yScroll = (value.Count * lineSpacing) / 2;
                credits = value;
            }
            get
            {
                return credits;
            }
        }

        /// <summary>
        /// Spacing between lines.
        /// </summary>
        public int LineSpacing
        {
            set
            {
                lineSpacing = value;
            }
            get
            {
                return lineSpacing;
            }
        }

        #endregion

        #region Fields

        private List<string> credits = new List<string>();

        private int lineSpacing = 14;

        private float yScroll = 0f;

        #endregion

        #region Constructor

        public CreditsControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private void CreditsControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.Clear(Color.White);

            yScroll = yScroll > -credits.Count * lineSpacing ? yScroll - 1f : (credits.Count * lineSpacing) / 2;

            for (int i = 0; i < credits.Count; i++)
            {
                float yOffset = yScroll + (i * lineSpacing);
                bool isBold = credits[i].StartsWith("**") && credits[i].EndsWith("**");

                TextDrawingUtil.DrawString(
                    g,
                    isBold ? credits[i].Replace("**", "") : credits[i],
                    new PointF(Bounds.Width / 2, yOffset),
                    isBold ? TextDrawingUtil.DefaultBoldFont : TextDrawingUtil.DefaultFont,
                    Brushes.Black,
                    TextDrawingUtil.Alignment.Center,
                    TextDrawingUtil.Alignment.Default
                );
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion
    }
}

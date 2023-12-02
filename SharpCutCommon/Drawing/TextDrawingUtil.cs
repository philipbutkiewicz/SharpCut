using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCutCommon.Drawing
{
    public class TextDrawingUtil
    {
        #region Enums

        public enum Alignment
        {
            Default,
            Center
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Measures given string.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static SizeF MeasureString(Graphics g, string text, PointF position, Font font = null)
        {
            font = SetDefaultFont(font);

            return g.MeasureString(text, font);
        }

        /// <summary>
        /// Draws given string.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        public static void DrawString(Graphics g, string text, PointF position, Font font = null, Brush brush = null, Alignment horizontalAlignment = Alignment.Default, Alignment verticalAlignment = Alignment.Default)
        {
            font = SetDefaultFont(font);
            brush = SetDefaultBrush(brush);

            g.DrawString(text, font, brush, GetAlignedPointF(g, text, position, font, horizontalAlignment, verticalAlignment));
        }

        /// <summary>
        /// Draws given string with a backdrop.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="backdropBrush"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        public static void DrawStringWithBackdrop(Graphics g, string text, PointF position, Font font = null, Brush brush = null, Brush backdropBrush = null, Alignment horizontalAlignment = Alignment.Default, Alignment verticalAlignment = Alignment.Default)
        {
            font = SetDefaultFont(font);
            brush = SetDefaultBrush(brush);

            if (backdropBrush == null)
            {
                backdropBrush = new SolidBrush(Color.FromArgb(127, Color.Black));
            }

            PointF alignedPosition = GetAlignedPointF(g, text, position, font, horizontalAlignment, verticalAlignment);

            g.FillRectangle(backdropBrush, new RectangleF(alignedPosition, MeasureString(g, text, alignedPosition, font)));
            g.DrawString(text, font, brush, alignedPosition);
        }

        /// <summary>
        /// Draws given string with a shadow.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        public static void DrawStringWithShadow(Graphics g, string text, PointF position, Font font = null, Brush brush = null, Alignment horizontalAlignment = Alignment.Default, Alignment verticalAlignment = Alignment.Default)
        {
            font = SetDefaultFont(font);
            brush = SetDefaultBrush(brush);

            PointF alignedPosition = GetAlignedPointF(g, text, position, font, horizontalAlignment, verticalAlignment);

            g.DrawString(text, font, new SolidBrush(Color.FromArgb(127, Color.Black)), new PointF(alignedPosition.X + 1, alignedPosition.Y + 1));
            g.DrawString(text, font, brush, alignedPosition);
        }

        #endregion

        #region Private methods

        private static Font SetDefaultFont(Font font)
        {
            if (font == null)
            {
                font = new Font(FontFamily.GenericSansSerif, 10f);
            }

            return font;
        }

        private static Brush SetDefaultBrush(Brush brush)
        {
            if (brush == null)
            {
                brush = Brushes.White;
            }

            return brush;
        }

        private static PointF GetAlignedPointF(Graphics g, string text, PointF position, Font font = null, Alignment horizontalAlignment = Alignment.Default, Alignment verticalAlignment = Alignment.Default)
        {
            SizeF size = MeasureString(g, text, position, font);

            return new PointF(horizontalAlignment == Alignment.Center ? position.X - (size.Width / 2) : position.X, verticalAlignment == Alignment.Center ? position.Y - (size.Height / 2) : position.Y);
        }

        #endregion
    }
}

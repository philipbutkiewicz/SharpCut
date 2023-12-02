using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCutCommon.Util;

namespace SharpCutCommon.Drawing
{
    public class ColorFilter
    {
        public static Color Brightness(Color color, float brightness = 1.0f)
        {
            return Color.FromArgb(color.A, (byte)Mathd.Clamp(color.R * brightness, 0, 255),
                (byte)Mathd.Clamp(color.G * brightness, 0, 255), (byte)Mathd.Clamp(color.B * brightness, 0, 255));
        }
    }
}

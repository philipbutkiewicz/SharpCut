using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCutCommon.Util
{
    public class Mathd
    {
        public static double Clamp(double value, double min, double max)
        {
            return value < min ? min : (value > max ? max : value);
        }
    }
}

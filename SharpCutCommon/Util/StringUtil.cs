using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCutCommon.Util
{
    public class StringUtil
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ParseTemplate(string template, string mediaFileName, string targetContainer, string segmentStart = "", string segmentEnd = "")
        {
            string cleanFileName = mediaFileName.Replace(Path.GetExtension(mediaFileName), "");
            string timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

            return template
                .Replace("$(OriginalFn)", cleanFileName)
                .Replace("$(Ext)", (targetContainer.Replace(".", "")))
                .Replace("$(SegStart)", segmentStart)
                .Replace("$(SegEnd)", segmentEnd)
                .Replace("$(Timestamp)", timestamp);
        }
    }
}

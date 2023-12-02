using Newtonsoft.Json;
using System;
using System.Drawing;

namespace SharpCutCommon.Video
{
    [Serializable]
    public class Section
    {
        #region Props

        /// <summary>
        /// Section start time (in seconds).
        /// </summary>
        [JsonProperty("start")]
        public double Start = 0f;

        /// <summary>
        /// Section end time (in seconds).
        /// </summary>
        [JsonProperty("end")]
        public double End = 0f;

        /// <summary>
        /// Section name (in seconds).
        /// </summary>
        [JsonProperty("name")]
        public string Name = "";

        /// <summary>
        /// Section color.
        /// </summary>
        [JsonProperty("sectionColor")]
        public Color SectionColor = Color.CornflowerBlue;

        #endregion

        #region Public methods

        /// <summary>
        /// Gets section start string.
        /// </summary>
        /// <returns></returns>
        public string GetStartString()
        {
            return TimeSpan.FromSeconds(Start).ToString(@"hh\:mm\:ss\:fff");
        }

        /// <summary>
        /// Gets section end string.
        /// </summary>
        /// <returns></returns>
        public string GetEndString()
        {
            return End != 0 ? TimeSpan.FromSeconds(End).ToString(@"hh\:mm\:ss\:fff") : "--:--:--:---";
        }

        /// <summary>
        /// Gets section start/end string.
        /// </summary>
        /// <returns></returns>
        public string GetStartEndString()
        {
            return $"{GetStartString()} - {GetEndString()}";
        }

        /// <summary>
        /// Gets section duration string.
        /// </summary>
        /// <returns></returns>
        public string GetDurationString()
        {
            return End != 0 ? TimeSpan.FromSeconds(End - Start).ToString(@"hh\:mm\:ss\:fff") : "--:--:--:---";
        }

        /// <summary>
        /// Generates a random color.
        /// </summary>
        /// <returns></returns>
        public static Color RandomColor()
        {
            Color[] brushes = new Color[] { Color.CornflowerBlue, Color.PaleVioletRed, Color.MediumSpringGreen, Color.BlanchedAlmond, Color.AliceBlue, Color.PaleGreen };

            return brushes[new Random().Next(brushes.Length)];
        }

        /// <summary>
        /// Serializes this object and returns result as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}

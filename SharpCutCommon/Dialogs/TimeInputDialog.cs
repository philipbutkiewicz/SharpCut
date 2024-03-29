using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpCutCommon.Dialogs
{
    public partial class TimeInputDialog : Form
    {
        #region Properties

        /// <summary>
        /// Main dialog label text.
        /// </summary>
        public string LabelText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Time. Duh? What the hell am I supposed to put in here?
        /// </summary>
        public double Time
        {
            get { return time; }
            set { SetTime(value); }
        }

        /// <summary>
        /// Minimum time value.
        /// </summary>
        public double MinTime
        {
            get { return minTime; }
            set { minTime = value; }
        }

        /// <summary>
        /// Maximum time value.
        /// </summary>
        public double MaxTime
        {
            get { return maxTime; }
            set { maxTime = value; }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Time. What else?
        /// </summary>
        private double time = 0;

        /// <summary>
        /// Minimum time value.
        /// </summary>
        private double minTime = 0;

        /// <summary>
        /// Maximum time value.
        /// </summary>
        private double maxTime = 0;

        #endregion

        #region Constructor

        public TimeInputDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods


        /// <summary>
        /// Set the time value and update text boxes.
        /// </summary>
        /// <param name="timeInSeconds"></param>
        private void SetTime(double timeInSeconds)
        {
            time = timeInSeconds;

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            textBoxHours.Text = timeSpan.Hours.ToString();
            textBoxMinutes.Text = timeSpan.Minutes.ToString();
            textBoxSeconds.Text = timeSpan.Seconds.ToString();
            textBoxMilliseconds.Text = timeSpan.Milliseconds.ToString();

            textBoxHours_TextChanged(this, null);
            textBoxMinutes_TextChanged(this, null);
            textBoxSeconds_TextChanged(this, null);
            textBoxMilliseconds_TextChanged(this, null);
        }

        /// <summary>
        /// Get an integer value from a time string.
        /// </summary>
        /// <param name="timeFragment"></param>
        /// <returns></returns>
        private int GetTimeFragmentValue(string timeFragment)
        {
            int intValue = 0;
            if (!int.TryParse(timeFragment, out intValue))
            {
                return -1;
            }

            return intValue;
        }

        /// <summary>
        /// Validate values in text boxes and update the time field.
        /// </summary>
        /// <returns></returns>
        private bool ValidateAndSetTime()
        {
            int hours = GetTimeFragmentValue(textBoxHours.Text);
            int minutes = GetTimeFragmentValue(textBoxMinutes.Text);
            int seconds = GetTimeFragmentValue(textBoxSeconds.Text);
            int milliseconds = GetTimeFragmentValue(textBoxMilliseconds.Text);

            if (hours == -1 || minutes == -1 || seconds == -1 || milliseconds == -1)
            {
                Console.WriteLine("Invalid input");
                buttonSet.Enabled = false;
                return false;
            }

            double calculatedTime = new TimeSpan(0, hours, minutes, seconds, milliseconds).TotalSeconds;
            if (calculatedTime > maxTime || calculatedTime < minTime)
            {
                Console.WriteLine("Invalid time");
                buttonSet.Enabled = false;
                return false;
            }

            time = calculatedTime;
            buttonSet.Enabled = true;

            return true;
        }

        /// <summary>
        /// Validate text boxes, change their background if needed and set the time.
        /// </summary>
        /// <param name="textBox"></param>
        private void ValidateTextBoxAndSetTime(TextBox textBox)
        {
            if (!ValidateAndSetTime())
            {
                textBox.BackColor = Color.FromArgb(235, 150, 150);
                textBox.Invalidate();
            }
            else
            {
                textBox.BackColor = SystemColors.Window;
                textBox.Invalidate();
            }
        }

        #endregion

        #region Event handlers

        private void textBoxHours_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxAndSetTime(textBoxHours);
        }

        private void textBoxMinutes_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxAndSetTime(textBoxMinutes);
        }

        private void textBoxSeconds_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxAndSetTime(textBoxSeconds);
        }

        private void textBoxMilliseconds_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxAndSetTime(textBoxMilliseconds);
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TimeInputDialog_Shown(object sender, EventArgs e)
        {
            SetTime(time);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back) || e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}

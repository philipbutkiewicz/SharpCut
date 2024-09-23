using SharpCutCommon.Drawing;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SharpCutCommon.Dialogs;
using SharpCutCommon.Util;

namespace SharpCut.Controls
{
    public partial class Timeline : UserControl
    {
        #region Event args

        public class TimeChangedEventArgs : EventArgs
        {
            public bool CausesDecodingUpdate;

            public TimeChangedEventArgs(bool causesDecodingUpdate = false)
            { 
                CausesDecodingUpdate = causesDecodingUpdate;
            }
        }

        #endregion


        #region Public event handlers

        /// <summary>
        /// Called whenever the current time value changes.
        /// </summary>
        public event EventHandler<TimeChangedEventArgs> TimeChanged
        {
            add
            {
                onTimeChanged += value;
            }
            remove
            {
                onTimeChanged -= value;
            }
        }

        /// <summary>
        /// Called whenever seeking starts.
        /// </summary>
        public event EventHandler SeekStart
        {
            add
            {
                onSeekStart += value;
            }
            remove
            {
                onSeekStart -= value;
            }
        }


        /// <summary>
        /// Called whenever seeking ends.
        /// </summary>
        public event EventHandler SeekEnd
        {
            add
            {
                onSeekEnd += value;
            }
            remove
            {
                onSeekEnd -= value;
            }
        }

        /// <summary>
        /// Called whenever sections are renamed.
        /// </summary>
        public event EventHandler SectionRenamed
        {
            add
            {
                onSectionRenamed += value;
            }
            remove
            {
                onSectionRenamed -= value;
            }
        }

        /// <summary>
        /// Calls whenever scrolling ends.
        /// </summary>
        public event EventHandler ForceClosePreviewFrame
        {
            add
            {
                onForceClosePreviewFrame += value;
            }
            remove
            {
                onForceClosePreviewFrame -= value;
            }
        }

        /// <summary>
        /// Called whenever selection changes.
        /// </summary>
        public event EventHandler SelectionChanged
        {
            add
            {
                onSelectionChanged += value;
            }
            remove
            {
                onSelectionChanged -= value;
            }
        }

        #endregion

        #region Private event handlers

        /// <summary>
        /// Called whenever the current time value changes.
        /// </summary>
        private EventHandler<TimeChangedEventArgs> onTimeChanged;

        /// <summary>
        /// Called whenever seeking starts.
        /// </summary>
        private EventHandler onSeekStart;

        /// <summary>
        /// Called whenever seeking ends.
        /// </summary>
        private EventHandler onSeekEnd;

        /// <summary>
        /// Called whenever section is renamed.
        /// </summary>
        private EventHandler onSectionRenamed;

        /// <summary>
        /// Called whenever scrolling ends.
        /// </summary>
        private EventHandler onForceClosePreviewFrame;

        /// <summary>
        /// Called whenever selection changes.
        /// </summary>
        private EventHandler onSelectionChanged;

        #endregion

        #region Properties

        /// <summary>
        /// List of all cut sections.
        /// </summary>
        public List<Section> Sections = new List<Section>();

        /// <summary>
        /// Gets or sets the current timeline time.
        /// </summary>
        public double Time
        {
            get { return time;  }
            set
            {
                time = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current timeline duration.
        /// </summary>
        public double Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Preview generation progress.
        /// </summary>
        public float PreviewProgress
        {
            get { return previewProgress; }
            set
            {
                previewProgress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Preview loading generating new frames?
        /// </summary>
        public bool PreviewGeneratingNewFrames
        {
            get { return previewGeneratingNewFrames; }
            set
            {
                previewGeneratingNewFrames = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Has the preview been loaded?
        /// </summary>
        public bool PreviewLoaded
        {
            get { return previewLoaded; }
            set
            {
                previewLoaded = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the X position of the caret.
        /// </summary>
        public float CaretX
        {
            get { return caretX; }
        }

        /// <summary>
        /// Timeline (mousewheel) scroll speed.
        /// </summary>
        public float ScrollSpeed
        {
            get { return scrollSpeed; }
            set
            {
                scrollSpeed = value;
            }
        }

        /// <summary>
        /// Selection label.
        /// </summary>
        public string SelectionLabel
        {
            get { return selectionLabel; }
            set
            {
                selectionLabel = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the currently selected section.
        /// </summary>
        public Section SelectedSection
        {
            get { return selectedSection; }
            set
            {
                selectedSection = value;
                OnSelectionChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Timeline time.
        /// </summary>
        private double time = 0;

        /// <summary>
        /// Timeline duration.
        /// </summary>
        private double duration = 0;

        /// <summary>
        /// Preview generation progress.
        /// </summary>
        private float previewProgress = 0f;

        /// <summary>
        /// Preview generation creating new frames?
        /// </summary>
        private bool previewGeneratingNewFrames = false;

        /// <summary>
        /// Has the preview been loaded?
        /// </summary>
        private bool previewLoaded = false;

        /// <summary>
        /// Caret X position.
        /// </summary>
        private float caretX = 0;

        /// <summary>
        /// Timeline (mousewheel) scroll speed.
        /// </summary>
        private float scrollSpeed = 1f;

        /// <summary>
        /// Selection label.
        /// </summary>
        private string selectionLabel = "(?)";

        /// <summary>
        /// Currently selected section.
        /// </summary>
        private Section selectedSection = null;

        /// <summary>
        /// Section the mouse is hovering over.
        /// </summary>
        private Section hoveringSection = null;

        /// <summary>
        /// Caret width.
        /// </summary>
        private float caretWidth = 12f;

        /// <summary>
        /// Caret height.
        /// </summary>
        private float caretHeight = 12f;

        /// <summary>
        /// Selection label height.
        /// </summary>
        private float selectionLabelHeight = 14f;

        /// <summary>
        /// Item spacing in the upper timeline.
        /// </summary>
        private float upperTimelineItemSpacing = 72f;


        /// <summary>
        /// Time string font.
        /// </summary>
        private Font timeFont = new Font(FontFamily.GenericMonospace, 11f);

        /// <summary>
        /// Duration string font.
        /// </summary>
        private Font sectionDurationStringFont = new Font(FontFamily.GenericMonospace, 8f, FontStyle.Bold);

        /// <summary>
        /// Start/end string font.
        /// </summary>
        private Font sectionStartEndStringFont = new Font(FontFamily.GenericMonospace, 6f, FontStyle.Bold);

        /// <summary>
        /// Selection label string font.
        /// </summary>
        private Font selectionLabelStringFont = new Font(FontFamily.GenericMonospace, 8f, FontStyle.Bold);

        private Timer scrollTimer = new Timer();

        #endregion

        #region State fields

        /// <summary>
        /// Are we currently seeking?
        /// </summary>
        private bool isSeeking = false;

        #endregion

        #region Consts

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;

        #endregion

        #region Constructor

        public Timeline()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Repaints the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.Clear(Color.Gray);

            PaintSections(g);
            PaintTime(g);
            PaintUpperTimeline(g);
            PaintPreviewProgress(g);
            PaintCaret(g);
            PaintSelectionLabel(g);
        }

        /// <summary>
        /// Called when mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isSeeking)
            {
                isSeeking = false;
                OnSeekEnd(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when mouse button is held down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float posX = time > 0 ? (float)(Bounds.Width * (time / duration)) : 0;

                if ((e.Location.X > (posX - (caretWidth / 2f)) && e.Location.X < posX + (caretWidth / 2f) && e.Location.Y > 0 && e.Location.Y < caretHeight) || e.Location.Y < caretHeight + 1)
                {
                    isSeeking = true;
                    OnSeekStart(EventArgs.Empty);
                }

                if (!isSeeking)
                {
                    double selectedTime = Mathd.Clamp(duration * ((double)e.Location.X / Bounds.Width), 0, Duration);
                    Section newSection = Sections.FindLast(item => item.Start <= selectedTime && item.End >= selectedTime);
                    if (newSection != null)
                    {
                        selectedSection = newSection;
                        OnSelectionChanged(EventArgs.Empty);
                    }

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Called when mouse is moved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeline_MouseMove(object sender, MouseEventArgs e)
        {
            float posX = time > 0 ? (float)(Bounds.Width * (time / duration)) : 0;

            if ((e.Location.X > (posX - (caretWidth / 2f)) && e.Location.X < posX + (caretWidth / 2f) && e.Location.Y > 0 && e.Location.Y < caretHeight) || isSeeking)
            {
                Cursor.Current = Cursors.SizeWE;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                hoveringSection = null;

                foreach (Section section in Sections)
                {
                    float startX = section.Start > 0 ? Bounds.Width * ((float)section.Start / (float)Duration) : 0;
                    float endW = section.End > 0 ? (Bounds.Width * ((float)section.End / (float)Duration)) - startX : 4;

                    if ((e.Location.X > startX && e.Location.X < startX + endW) && (e.Location.Y < caretHeight + 16 && e.Location.Y > caretHeight))
                    {
                        Cursor.Current = Cursors.IBeam;
                        hoveringSection = section;
                    }

                    if ((e.Location.X > startX && e.Location.X < startX + endW) && (e.Location.Y > caretHeight && e.Location.Y <= Bounds.Height - selectionLabelHeight - 1))
                    {
                        hoveringSection = section;
                    }
                }

                Invalidate();
            }



            if (!isSeeking) return;

            time = Mathd.Clamp(duration * ((double)e.Location.X / Bounds.Width), 0, Duration);

            Invalidate();

            OnTimeChanged(new TimeChangedEventArgs(true));
        }

        /// <summary>
        /// Occurs when the scroll event is called by the OS.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                Timeline_Scroll(m.WParam == (IntPtr)0x0000000000780000 ? 1f : -1f);
            }
        }

        /// <summary>
        /// Called when the user scrolls the timeline.
        /// </summary>
        private void Timeline_Scroll(float delta)
        {
            if (Duration <= 0) return;

            time = Mathd.Clamp(time + (delta * scrollSpeed), 0, Duration);

            Invalidate();

            OnTimeChanged(new TimeChangedEventArgs(false));

            scrollTimer.Interval = 2000;
            if (scrollTimer.Enabled)
            {
                scrollTimer.Stop();
            }

            scrollTimer.Tick += ScrollTimer_Tick;
            scrollTimer.Start();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            onForceClosePreviewFrame?.Invoke(sender, e);
            scrollTimer.Stop();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Clears the timeline and associated sections.
        /// </summary>
        public void Clear()
        {
            time = 0f;
            duration = 0f;

            selectedSection = null;
            Sections.Clear();

            Invalidate();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Paint the selection label.
        /// </summary>
        /// <param name="g"></param>
        private void PaintSelectionLabel(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 150, 150, 150)), new RectangleF(0, Bounds.Y + Bounds.Height - selectionLabelHeight, Bounds.Width, selectionLabelHeight));
            PointF selectionLabelStringPos = new PointF(4f, Bounds.Y + Bounds.Height - selectionLabelHeight - 1);

            TextDrawingUtil.DrawStringWithShadow(g,
                string.IsNullOrEmpty(selectionLabel) ? SharpCutCommon.Properties.Resources.SelectionLabelProjectNotOpen : selectionLabel,
                selectionLabelStringPos,
                selectionLabelStringFont,
                Brushes.White
            );
        }

        /// <summary>
        /// Paint timeline sections.
        /// </summary>
        /// <param name="g"></param>
        private void PaintSections(Graphics g)
        {
            foreach (Section section in Sections)
            {
                if (Duration > 0)
                {
                    float startX = section.Start > 0 ? Bounds.Width * ((float)section.Start / (float)Duration) : 0;
                    float endW = section.End > 0 ? (Bounds.Width * ((float)section.End / (float)Duration)) - startX : 4;

                    g.FillRectangle(new SolidBrush(hoveringSection == section ? ColorFilter.Brightness(section.SectionColor, 1.2f) : section.SectionColor), new RectangleF(startX, caretHeight + 1, endW, Bounds.Height - selectionLabelHeight));
                    if (section == selectedSection)
                    {
                        g.FillRectangle(Brushes.Red, new RectangleF(startX, Bounds.Height - 4 - selectionLabelHeight, endW, 4));
                    }

                    g.FillRectangle(new SolidBrush(ColorFilter.Brightness(section.SectionColor, hoveringSection == section ? 1.4f : 1.2f)), new RectangleF(startX, caretHeight + 1, endW, 18));

                    if (section.End > 0)
                    {
                        string durationString = section.GetDurationString();
                        string startEndString = section.GetStartEndString();
                        PointF durationStringPos = new PointF(startX + 2f, Bounds.Y + 34f + caretHeight - selectionLabelHeight - 1);
                        PointF startEndStringPos = new PointF(startX + 2f, Bounds.Height - 14f - selectionLabelHeight - 1);

                        if (TextDrawingUtil.MeasureString(g, startEndString, startEndStringPos, sectionStartEndStringFont).Width < endW)
                        {
                            TextDrawingUtil.DrawStringWithShadow(g,
                                durationString,
                                durationStringPos,
                                sectionDurationStringFont,
                                Brushes.White
                            );

                            TextDrawingUtil.DrawStringWithShadow(g,
                                startEndString,
                                startEndStringPos,
                                sectionStartEndStringFont,
                                Brushes.White
                            );
                        }

                        string sectionNameString = !string.IsNullOrEmpty(section.Name) ? section.Name : "Unnamed";
                        PointF sectionNameStringPos = new PointF(startX + 2f, Bounds.Y + 2f + caretHeight + 1f);
                        SizeF sectionNameStringSz = TextDrawingUtil.MeasureString(g, sectionNameString,
                            sectionNameStringPos, sectionDurationStringFont);

                        if (endW > 24)
                        {
                            bool shortened = false;
                            while (sectionNameStringSz.Width > endW)
                            {
                                sectionNameString = sectionNameString.Substring(0, sectionNameString.Length - 1);
                                sectionNameStringSz = TextDrawingUtil.MeasureString(g, sectionNameString + "...",
                                    sectionNameStringPos, sectionDurationStringFont);
                                shortened = true;
                            }

                            TextDrawingUtil.DrawStringWithShadow(g,
                                shortened ? sectionNameString + "..." : sectionNameString,
                                sectionNameStringPos,
                                sectionDurationStringFont,
                                new SolidBrush(ColorFilter.Brightness(section.SectionColor, 1.6f))
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Paint the current timeline time.
        /// </summary>
        /// <param name="g"></param>
        private void PaintTime(Graphics g)
        {
            TextDrawingUtil.DrawStringWithBackdrop(g,
                TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss\:fff"),
                new PointF(Bounds.Width / 2, (Bounds.Height / 2) + caretHeight - (selectionLabelHeight / 2) - 4),
                timeFont,
                null,
                null,
                TextDrawingUtil.Alignment.Center,
                TextDrawingUtil.Alignment.Center
            );
        }

        /// <summary>
        /// Paint the upper timeline part.
        /// </summary>
        /// <param name="g"></param>
        private void PaintUpperTimeline(Graphics g)
        {
            g.FillRectangle(Brushes.DarkGray, 0f, 0f, Bounds.Width, caretHeight + 1);
            for (int j = 0; j < (Bounds.Width / 4); j++)
            {
                g.DrawLine(Pens.Gray, j * 4f, 4f, j * 4f, caretHeight - 3f);
            }

            if (duration > 0)
            {
                for (int i = 1; i < (Bounds.Width / upperTimelineItemSpacing) - 1; i++)
                {
                    double t = Mathd.Clamp(duration * ((double)(i * upperTimelineItemSpacing) / Bounds.Width), 0, Duration);
                    TextDrawingUtil.DrawStringWithShadow(g, TimeSpan.FromSeconds(t).ToString(@"hh\:mm\:ss\:fff"), new PointF(i * upperTimelineItemSpacing, 2f), new Font(FontFamily.GenericSansSerif, 6f), null, TextDrawingUtil.Alignment.Center);
                }
            }
        }

        /// <summary>
        /// Paints the preview generation progress.
        /// </summary>
        /// <param name="g"></param>
        private void PaintPreviewProgress(Graphics g)
        {
            if (previewProgress == 0f) return;

            g.FillRectangle(new SolidBrush(Color.FromArgb(127, previewGeneratingNewFrames ? Color.Purple : Color.LimeGreen)), new RectangleF(0, 0, Bounds.Width * previewProgress, 2));
        }

        /// <summary>
        /// Paint the caret at current timeline time.
        /// </summary>
        /// <param name="g"></param>
        private void PaintCaret(Graphics g)
        {
            float posX = time > 0 ? (float)(Bounds.Width * (time / duration)) : 0;
            caretX = posX;

            g.DrawLine(Pens.Black, posX, 0, posX, Bounds.Height);

            g.FillRectangle(Brushes.LightGray, posX - (caretWidth / 2f), 0, caretWidth, caretHeight);
            g.DrawLine(Pens.DarkGray, (posX - (caretWidth / 2f)) + (caretWidth / 2f) - 2f, 2f, (posX - (caretWidth / 2f)) + (caretWidth / 2f) - 2f, caretHeight - 2);
            g.DrawLine(Pens.DarkGray, (posX - (caretWidth / 2f)) + (caretWidth / 2f) + 2f, 2f, (posX - (caretWidth / 2f)) + (caretWidth / 2f) + 2f, caretHeight - 2);
            g.DrawRectangle(Pens.DarkGray, (posX - (caretWidth / 2f)), 0, caretWidth, caretHeight);
        }

        #endregion

        #region Event callers

        protected virtual void OnTimeChanged(TimeChangedEventArgs e)
        {
            onTimeChanged?.Invoke(this, e);
        }

        protected virtual void OnSeekStart(EventArgs e)
        {
            onSeekStart?.Invoke(this, e);
        }

        protected virtual void OnSeekEnd(EventArgs e)
        {
            onSeekEnd?.Invoke(this, e);
        }

        protected virtual void OnSectionRenamed(EventArgs e)
        {
            onSectionRenamed?.Invoke(this, e);
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            onSelectionChanged?.Invoke(this, e);
        }

        #endregion

        private void Timeline_MouseClick(object sender, MouseEventArgs e)
        {
            if (isSeeking) return;
            foreach (Section section in Sections)
            {
                float startX = section.Start > 0 ? Bounds.Width * ((float)section.Start / (float)Duration) : 0;
                float endW = section.End > 0 ? (Bounds.Width * ((float)section.End / (float)Duration)) - startX : 4;

                if ((e.Location.X > startX && e.Location.X < startX + endW) && (e.Location.Y < caretHeight + 16 && e.Location.Y > caretHeight) && e.Button == MouseButtons.Left)
                {
                    using (TextInputDialog textInputDialog = new TextInputDialog())
                    {
                        textInputDialog.Text = SharpCutCommon.Properties.Resources.RenameSectionFormTitle;
                        textInputDialog.labelTitle.Text = SharpCutCommon.Properties.Resources.RenameSectionTitle;
                        textInputDialog.label.Text = SharpCutCommon.Properties.Resources.RenameSectionLabel;
                        textInputDialog.textBox.Text = selectedSection.Name;

                        if (textInputDialog.ShowDialog() == DialogResult.OK)
                        {
                            selectedSection.Name = textInputDialog.textBox.Text;
                            OnSectionRenamed(EventArgs.Empty);
                            Invalidate();
                        }
                    }
                }
            }
        }
    }
}

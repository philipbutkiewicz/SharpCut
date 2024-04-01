using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaHelper.plugin
{
    public partial class PreviewBrowserListForm : Form
    {
        #region Event agrs

        public class PreviewBrowserListItemDeletedEventArgs : EventArgs
        {
            public string FileName = "";
        }

        #endregion

        #region Properties

        /// <summary>
        /// List item click event handler.
        /// </summary>
        public event EventHandler PreviewBrowserListItemClicked;

        /// <summary>
        /// List item delete event handler.
        /// </summary>
        public event EventHandler<PreviewBrowserListItemDeletedEventArgs> PreviewBrowserListItemDeleted;

        #endregion

        #region Fields

        /// <summary>
        /// Controls mapped to file names.
        /// </summary>
        private Dictionary<string, PreviewBrowserListItem> controlsToFileNames = new Dictionary<string, PreviewBrowserListItem>();

        #endregion

        #region Constructor

        public PreviewBrowserListForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Set an item with a file name as selected.
        /// </summary>
        /// <param name="fileName"></param>
        public void SetSelected(string fileName)
        {
            foreach (KeyValuePair<string, PreviewBrowserListItem> kvp in controlsToFileNames)
            {
                kvp.Value.IsSelected = false;
                kvp.Value.Invalidate();
            }

            controlsToFileNames[fileName].IsSelected = true;
            controlsToFileNames[fileName].Invalidate();
        }

        /// <summary>
        /// Force update the item list
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="fileNamesToDelete"></param>
        public void Update(List<string> fileNames, List<string> fileNamesToDelete)
        {
            foreach (string name in fileNames)
            {
                if (!controlsToFileNames.ContainsKey(name))
                {
                    controlsToFileNames.Add(name, new PreviewBrowserListItem()
                    {
                        FileName = name,
                        Top = controlsToFileNames.Count > 0 ? controlsToFileNames[controlsToFileNames.Keys.Last()].Top + 21 : 0
                    });

                    controlsToFileNames[name].MouseUp += PreviewBrowserListForm_MouseUp;

                    panelList.Controls.Add(controlsToFileNames[name]);
                }
                else
                {
                    controlsToFileNames[name].ShouldDelete = false;
                }
            }

            foreach (string deleteName in fileNamesToDelete)
            {
                if (!controlsToFileNames.ContainsKey(deleteName))
                {
                    controlsToFileNames.Add(deleteName, new PreviewBrowserListItem()
                    {
                        FileName = deleteName,
                        Top = controlsToFileNames.Count > 0 ? controlsToFileNames[controlsToFileNames.Keys.Last()].Top + 21 : 0
                    });

                    controlsToFileNames[deleteName].MouseUp += PreviewBrowserListForm_MouseUp;

                    panelList.Controls.Add(controlsToFileNames[deleteName]);
                }
                else
                {
                    controlsToFileNames[deleteName].ShouldDelete = true;
                }
            }

            toolStripStatusLabelInfo.Text = string.Format(Properties.Resources.StatusBarInfoLabel, fileNamesToDelete.Count, fileNames.Count, fileNamesToDelete.Count > 0 && fileNames.Count > 0 ? Math.Round((double)fileNamesToDelete.Count / fileNames.Count * 100, 2) : 0);

            Invalidate(true);
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// List item mouse up event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowserListForm_MouseUp(object sender, MouseEventArgs e)
        {
            PreviewBrowserListItem item = (PreviewBrowserListItem)sender;

            if (e.Button == MouseButtons.Left)
            {
                item.IsSelected = true;
                item.Invalidate();

                foreach (KeyValuePair<string, PreviewBrowserListItem> kvp in controlsToFileNames)
                {
                    kvp.Value.IsSelected = false;
                    kvp.Value.Invalidate();
                }

                PreviewBrowserListItemClicked?.Invoke(sender, e);
            }

            if (e.Button == MouseButtons.Right)
            {
                PreviewBrowserListItemDeleted?.Invoke(sender, new PreviewBrowserListItemDeletedEventArgs()
                {
                    FileName = item.FileName
                });
            }
        }

        #endregion
    }
}

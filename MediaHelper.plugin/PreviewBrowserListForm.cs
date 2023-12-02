using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHelper.plugin
{
    public partial class PreviewBrowserListForm : Form
    {
        public class PreviewBrowserListItemDeletedEventArgs : EventArgs
        {
            public string FileName = "";
        }

        public event EventHandler PreviewBrowserListItemClicked;

        public event EventHandler<PreviewBrowserListItemDeletedEventArgs> PreviewBrowserListItemDeleted;

        private Dictionary<string, PreviewBrowserListItem> _controlsToFileNames = new Dictionary<string, PreviewBrowserListItem>();

        public PreviewBrowserListForm()
        {
            InitializeComponent();
        }

        public void SetSelected(string fileName)
        {
            foreach (KeyValuePair<string, PreviewBrowserListItem> kvp in _controlsToFileNames)
            {
                kvp.Value.IsSelected = false;
                kvp.Value.Invalidate();
            }

            _controlsToFileNames[fileName].IsSelected = true;
            _controlsToFileNames[fileName].Invalidate();
        }

        public void Update(List<string> fileNames, List<string> fileNamesToDelete)
        {
            foreach (string name in fileNames)
            {
                if (!_controlsToFileNames.ContainsKey(name))
                {
                    _controlsToFileNames.Add(name, new PreviewBrowserListItem()
                    {
                        FileName = name,
                        Top = _controlsToFileNames.Count > 0 ? _controlsToFileNames[_controlsToFileNames.Keys.Last()].Top + 21 : 0
                    });

                    _controlsToFileNames[name].MouseUp += PreviewBrowserListForm_MouseUp;

                    Controls.Add(_controlsToFileNames[name]);
                }
                else
                {
                    _controlsToFileNames[name].ShouldDelete = false;
                }
            }

            foreach (string deleteName in fileNamesToDelete)
            {
                if (!_controlsToFileNames.ContainsKey(deleteName))
                {
                    _controlsToFileNames.Add(deleteName, new PreviewBrowserListItem()
                    {
                        FileName = deleteName,
                        Top = _controlsToFileNames.Count > 0 ? _controlsToFileNames[_controlsToFileNames.Keys.Last()].Top + 21 : 0
                    });

                    _controlsToFileNames[deleteName].MouseUp += PreviewBrowserListForm_MouseUp;

                    Controls.Add(_controlsToFileNames[deleteName]);
                }
                else
                {
                    _controlsToFileNames[deleteName].ShouldDelete = true;
                }
            }

            Invalidate(true);
        }

        private void PreviewBrowserListForm_MouseUp(object sender, MouseEventArgs e)
        {
            PreviewBrowserListItem item = (PreviewBrowserListItem)sender;

            if (e.Button == MouseButtons.Left)
            {
                item.IsSelected = true;
                item.Invalidate();

                foreach (KeyValuePair<string, PreviewBrowserListItem> kvp in _controlsToFileNames)
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
    }
}

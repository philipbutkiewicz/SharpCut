using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDL2;
using SharpCutCommon.Video;
using static MediaHelper.plugin.PreviewBrowserListForm;

namespace MediaHelper.plugin
{
    public partial class PreviewBrowserForm : Form
    {
        #region Properties

        /// <summary>
        /// Should we load items from a list instead of a folder?
        /// </summary>
        public bool LoadFromList = false;

        #endregion

        #region Fields - refs

        /// <summary>
        /// Reference to the SharpCut project.
        /// </summary>
        private Project project;

        /// <summary>
        /// Reference to the preview renderer.
        /// </summary>
        private PreviewRenderer previewRenderer;

        /// <summary>
        /// Reference to the preview list form.
        /// </summary>
        private PreviewBrowserListForm previewListForm = new PreviewBrowserListForm();

        #endregion

        #region Fields - values

        /// <summary>
        /// List of all files.
        /// </summary>
        private List<string> files = new List<string>();

        /// <summary>
        /// List of all files to delete.
        /// </summary>
        private List<string> filesToDelete = new List<string>();

        /// <summary>
        /// Path to the delete list for saving without a dialog.
        /// </summary>
        private string deleteListSavePath = "";

        /// <summary>
        /// Currently selected file index.
        /// </summary>
        private int currentIndex = 0;


        #endregion

        #region Fields - flags

        /// <summary>
        /// Should the current file be deleted?
        /// </summary>
        private bool deleteCurrent = false;

        #endregion

        #region Public methods

        public PreviewBrowserForm()
        {
            InitializeComponent();

            previewListForm.PreviewBrowserListItemClicked += PreviewListForm_PreviewBrowserListItemClicked;
            previewListForm.PreviewBrowserListItemDeleted += PreviewListForm_PreviewBrowserListItemDeleted;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads files from a list file.
        /// </summary>
        /// <param name="path"></param>
        private void LoadList(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show(Properties.Resources.ListEmpty);
                Close();
            }

            files = File.ReadAllLines(path).ToList();
            if (files.Count == 0)
            {
                MessageBox.Show(Properties.Resources.ListEmpty);
                Close();
            }

            string delFilePath = path.Replace(Path.GetFileName(path), "del.txt");
            if (File.Exists(delFilePath))
            {
                filesToDelete = File.ReadAllLines(delFilePath).ToList();
            }

            previewListForm.Show();

            previewListForm.Left = (Bounds.X + 8) - previewListForm.Width;
            previewListForm.Top = Bounds.Y + Bounds.Height + 8;

            previewListForm.Update(files, filesToDelete);

            LoadCurrentFile();
        }

        /// <summary>
        /// Loads files from a path (*.mp4).
        /// </summary>
        /// <param name="path"></param>
        private void LoadFromPath(string path)
        {
            files = Directory.GetFiles(path, "*.mp4").ToList();
            if (files.Count == 0)
            {
                MessageBox.Show(Properties.Resources.NoFilesFound);
                Close();
            }

            string delFilePath = Path.Combine(path, "del.txt");
            if (File.Exists(delFilePath))
            {
                filesToDelete = File.ReadAllLines(delFilePath).ToList();
            }


            previewListForm.Show();

            previewListForm.Left = (Bounds.X + 8) - previewListForm.Width;
            previewListForm.Top = Bounds.Y + Bounds.Height + 8;

            previewListForm.Update(files, filesToDelete);

            LoadCurrentFile();
        }

        /// <summary>
        /// Loads the file with the currently selected index.
        /// </summary>
        private void LoadCurrentFile()
        {
            project = new Project()
            {
                MediaFileName = files[currentIndex]
            };

            if (previewRenderer != null)
            {
                previewRenderer.RenderTaskEnded -= PreviewRenderer_RenderTaskEnded;
                previewRenderer.TexturesLoaded -= PreviewRenderer_TexturesLoaded;
                previewRenderer.Dispose();

                previewRenderer = null;

                GC.Collect();
            }

            previewRenderer = new PreviewRenderer(Bounds);
            previewRenderer.RenderTaskEnded += PreviewRenderer_RenderTaskEnded;
            previewRenderer.TexturesLoaded += PreviewRenderer_TexturesLoaded;
            previewRenderer.StartRendering();

            comboBoxFrameskip_SelectedIndexChanged(this, EventArgs.Empty);
            comboBoxSpeed_SelectedIndexChanged(this, EventArgs.Empty);


            previewRenderer.LoadProject(project);
        }

        /// <summary>
        /// Goes to the previous index and loads the file.
        /// </summary>
        private void GoToPrev()
        {
            if (currentIndex != 0)
            {
                currentIndex--;
            }

            LoadCurrentFile();
        }

        /// <summary>
        /// Goes to the next index and loads the file.
        /// </summary>
        private void GoToNext()
        {
            if (currentIndex < (files.Count - 1))
            {
                currentIndex++;
            }

            LoadCurrentFile();
        }

        /// <summary>
        /// Marks the currently selected item for deletion.
        /// </summary>
        private void DeleteCurrentItem()
        {
            if (filesToDelete.Contains(files[currentIndex]))
            {
                buttonDelete.Text = Properties.Resources.MarkForDeletion;
                deleteCurrent = false;
                buttonDelete.Width = 122;

                filesToDelete.Remove(files[currentIndex]);
            }
            else
            {
                buttonDelete.Text = Properties.Resources.DontMarkForDeletion;
                deleteCurrent = true;
                buttonDelete.Width = 156;

                filesToDelete.Add(files[currentIndex]);
            }

            if (!string.IsNullOrEmpty(deleteListSavePath))
            {
                SaveDeletionList(deleteListSavePath);
            }

            previewListForm.Update(files, filesToDelete);
        }

        /// <summary>
        /// Saves the deletion list to a file at selected in a dialog.
        /// </summary>
        private void SaveDeletionList()
        {
            if (filesToDelete.Count == 0) return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = Properties.Resources.FilterTextFiles;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveDeletionList(saveFileDialog.FileName);
                    deleteListSavePath = saveFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Saves the deletion list to a file.
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveDeletionList(string fileName)
        {
            if (File.Exists(fileName))
            {
                string backupSavePath = $"{fileName}.old";
                if (File.Exists(backupSavePath))
                {
                    File.Delete(backupSavePath);
                }

                File.Copy(fileName, backupSavePath);
                File.Delete(fileName);
            }

            string content = "";
            foreach (string file in filesToDelete)
            {
                content += $"{file}\n";
            }

            File.WriteAllText(fileName, content);
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Sets default values and loads files from list/path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowserForm_Load(object sender, EventArgs e)
        {
            comboBoxSpeed.SelectedIndex = 2;
            comboBoxFrameskip.SelectedIndex = 0;

            if (LoadFromList)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadList(openFileDialog.FileName);
                    }
                }
            }
            else
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadFromPath(folderBrowserDialog.SelectedPath);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.ErrorSelectPath);
                        Close();
                    }
                }
            }
        }

        /// <summary>
        /// Saves the deletion list when the window is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (previewRenderer != null)
            {
                previewRenderer.Dispose();
            }

            SaveDeletionList();
            previewListForm.Close();
        }

        /// <summary>
        /// Changes the position of the preview renderer window alongside this window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBrowserForm_Move(object sender, EventArgs e)
        {
            previewListForm.Left = (Bounds.X + 8) - previewListForm.Width;
            previewListForm.Top = Bounds.Y + Bounds.Height + 8;

            if (previewRenderer != null)
            {
                previewRenderer.SetWindowPosition(Bounds.X + 8, Bounds.Y + Bounds.Height + 32);
            }
        }

        /// <summary>
        /// Loads a file selected in the preview list form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewListForm_PreviewBrowserListItemClicked(object sender, EventArgs e)
        {
            PreviewBrowserListItem listItem = (PreviewBrowserListItem)sender;
            int index = files.IndexOf(listItem.FileName);

            if (index > -1 && index < files.Count)
            {
                currentIndex = index;
                LoadCurrentFile();
            }
        }

        /// <summary>
        /// Called when the preview list form asks to delete an item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void PreviewListForm_PreviewBrowserListItemDeleted(object sender, PreviewBrowserListItemDeletedEventArgs e)
        {
            if (filesToDelete.Contains(e.FileName))
            {
                filesToDelete.Remove(e.FileName);
            }
            else
            {
                filesToDelete.Add(e.FileName);
            }

            if (!string.IsNullOrEmpty(deleteListSavePath))
            {
                SaveDeletionList(deleteListSavePath);
            }

            previewListForm.Update(files, filesToDelete);
        }


        /// <summary>
        /// Updates UI elements to reflect the status of currently the currently loaded file AFTER the textures have loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewRenderer_TexturesLoaded(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Console.WriteLine("Changing selection in the list dialog...");
                labelFile.Text = Path.GetFileName(files[currentIndex]);
                previewListForm.SetSelected(files[currentIndex]);

                if (filesToDelete.Contains(files[currentIndex]))
                {
                    buttonDelete.Text = Properties.Resources.DontMarkForDeletion;
                    deleteCurrent = true;
                    buttonDelete.Width = 156;
                }
                else
                {
                    buttonDelete.Text = Properties.Resources.MarkForDeletion;
                    deleteCurrent = false;
                    buttonDelete.Width = 122;
                }
            }));
        }

        /// <summary>
        /// Updates UI elements to reflect the status of currently the currently loaded file on each frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewRenderer_RenderTaskEnded(object sender, PreviewRenderer.RenderTaskEndedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelFile.Text = $"{Path.GetFileName(files[currentIndex])} ({previewRenderer.CurrentFrameIndex}/{project.PreviewFrames.Count})";
                if (deleteCurrent && labelFile.ForeColor != Color.Red)
                {
                    labelFile.ForeColor = Color.Red;
                }
                else if (!deleteCurrent && labelFile.ForeColor != SystemColors.ControlText)
                {
                    labelFile.ForeColor = SystemColors.ControlText;
                }
            }));
        }

        /// <summary>
        /// Updates the preview renderer frame skip value on combo box value change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFrameskip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previewRenderer != null)
            {
                previewRenderer.FrameSkip = comboBoxFrameskip.SelectedIndex;
            }
        }

        /// <summary>
        /// Updates the preview renderer frame interval value on combo box value change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previewRenderer != null)
            {
                switch (comboBoxSpeed.SelectedIndex)
                {
                    case 0:
                        previewRenderer.FrameInterval = 66.6666;
                        break;
                    case 1:
                        previewRenderer.FrameInterval = 33.3333;
                        break;
                    case 2:
                        previewRenderer.FrameInterval = 16.6666;
                        break;
                    case 3:
                        previewRenderer.FrameInterval = 8.3333;
                        break;
                }
            }

        }

        /// <summary>
        /// Goes to the previous index on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            GoToPrev();
        }

        /// <summary>
        /// Goes to the next index on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            GoToNext();
        }

        /// <summary>
        /// Marks the currently selected file for deletion on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrentItem();
        }

        /// <summary>
        /// Saves the deletion list on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveDeletionList();
        }

        #endregion
    }
}

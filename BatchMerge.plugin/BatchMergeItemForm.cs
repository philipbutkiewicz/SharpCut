using System;
using System.IO;
using System.Windows.Forms;

namespace BatchMerge.plugin
{
    public partial class BatchMergeItemForm : Form
    {

        public string OutputName
        {
            get
            {
                return textBoxOutput.Text;
            }
            set
            {
                textBoxOutput.Text = value;
            }
        }

        public BatchMergeItemForm()
        {
            InitializeComponent();
        }

        private void BatchMergeItemForm_Load(object sender, EventArgs e)
        {
            Files.DisplayMember = "DisplayName";
            Text = Path.GetFileName(textBoxOutput.Text);
        }

        private void BatchMergeItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonUp.Enabled = Files.SelectedIndex > 0;
            buttonDown.Enabled = Files.SelectedIndex > -1 && Files.SelectedIndex < Files.Items.Count - 1;
            buttonDelete.Enabled = Files.SelectedIndex > -1 && Files.Items.Count > 2;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = Files.SelectedIndex;

            BatchMergeFileItem item = Files.Items[index] as BatchMergeFileItem;
            Files.Items.RemoveAt(index);
            Files.Items.Insert(index - 1, item);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int index = Files.SelectedIndex;

            BatchMergeFileItem item = Files.Items[index] as BatchMergeFileItem;
            Files.Items.RemoveAt(index);
            Files.Items.Insert(index + 1, item);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Files.Items.RemoveAt(Files.SelectedIndex);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = Path.GetFileName(textBoxOutput.Text);
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    textBoxOutput.Text = saveFileDialog.FileName;
                    Text = Path.GetFileName(textBoxOutput.Text);
                }
            }
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            Text = Path.GetFileName(textBoxOutput.Text);
        }
    }
}

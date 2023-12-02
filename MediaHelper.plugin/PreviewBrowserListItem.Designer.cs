namespace MediaHelper.plugin
{
    partial class PreviewBrowserListItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PreviewBrowserListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PreviewBrowserListItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(348, 21);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PreviewBrowserListItem_Paint);
            this.MouseEnter += new System.EventHandler(this.PreviewBrowserListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.PreviewBrowserListItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

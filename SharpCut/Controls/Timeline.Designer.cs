﻿
namespace SharpCut.Controls
{
    partial class Timeline
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
            // Timeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Timeline";
            this.Size = new System.Drawing.Size(730, 86);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Timeline_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Timeline_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Timeline_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Timeline_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Timeline_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

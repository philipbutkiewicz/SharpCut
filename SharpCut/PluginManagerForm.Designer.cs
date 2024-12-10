namespace SharpCut
{
    partial class PluginManagerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManagerForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInstalled = new System.Windows.Forms.TabPage();
            this.panelInstalledPlugins = new System.Windows.Forms.Panel();
            this.listBoxPlugins = new System.Windows.Forms.ListBox();
            this.panelInstalledPluginsControls = new System.Windows.Forms.Panel();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonUpdatePlugins = new System.Windows.Forms.Button();
            this.tabPagePluginDirectory = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageInstalled.SuspendLayout();
            this.panelInstalledPlugins.SuspendLayout();
            this.panelInstalledPluginsControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInstalled);
            this.tabControl.Controls.Add(this.tabPagePluginDirectory);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(8, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(613, 365);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageInstalled
            // 
            this.tabPageInstalled.BackColor = System.Drawing.Color.White;
            this.tabPageInstalled.Controls.Add(this.panelInstalledPlugins);
            this.tabPageInstalled.Controls.Add(this.panelInstalledPluginsControls);
            this.tabPageInstalled.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstalled.Name = "tabPageInstalled";
            this.tabPageInstalled.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstalled.Size = new System.Drawing.Size(605, 339);
            this.tabPageInstalled.TabIndex = 0;
            this.tabPageInstalled.Text = "Installed";
            // 
            // panelInstalledPlugins
            // 
            this.panelInstalledPlugins.Controls.Add(this.listBoxPlugins);
            this.panelInstalledPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstalledPlugins.Location = new System.Drawing.Point(3, 3);
            this.panelInstalledPlugins.Name = "panelInstalledPlugins";
            this.panelInstalledPlugins.Size = new System.Drawing.Size(599, 306);
            this.panelInstalledPlugins.TabIndex = 0;
            // 
            // listBoxPlugins
            // 
            this.listBoxPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPlugins.FormattingEnabled = true;
            this.listBoxPlugins.Location = new System.Drawing.Point(0, 0);
            this.listBoxPlugins.Name = "listBoxPlugins";
            this.listBoxPlugins.Size = new System.Drawing.Size(599, 306);
            this.listBoxPlugins.TabIndex = 1;
            // 
            // panelInstalledPluginsControls
            // 
            this.panelInstalledPluginsControls.Controls.Add(this.buttonConfigure);
            this.panelInstalledPluginsControls.Controls.Add(this.buttonRemove);
            this.panelInstalledPluginsControls.Controls.Add(this.buttonUpdatePlugins);
            this.panelInstalledPluginsControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInstalledPluginsControls.Location = new System.Drawing.Point(3, 309);
            this.panelInstalledPluginsControls.Name = "panelInstalledPluginsControls";
            this.panelInstalledPluginsControls.Size = new System.Drawing.Size(599, 27);
            this.panelInstalledPluginsControls.TabIndex = 1;
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonConfigure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonConfigure.Location = new System.Drawing.Point(423, 0);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(85, 27);
            this.buttonConfigure.TabIndex = 2;
            this.buttonConfigure.Text = "Configure";
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRemove.Location = new System.Drawing.Point(508, 0);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(91, 27);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonUpdatePlugins
            // 
            this.buttonUpdatePlugins.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonUpdatePlugins.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonUpdatePlugins.Location = new System.Drawing.Point(0, 0);
            this.buttonUpdatePlugins.Name = "buttonUpdatePlugins";
            this.buttonUpdatePlugins.Size = new System.Drawing.Size(125, 27);
            this.buttonUpdatePlugins.TabIndex = 0;
            this.buttonUpdatePlugins.Text = "Update plugins";
            this.buttonUpdatePlugins.UseVisualStyleBackColor = true;
            // 
            // tabPagePluginDirectory
            // 
            this.tabPagePluginDirectory.BackColor = System.Drawing.Color.White;
            this.tabPagePluginDirectory.Location = new System.Drawing.Point(4, 22);
            this.tabPagePluginDirectory.Name = "tabPagePluginDirectory";
            this.tabPagePluginDirectory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePluginDirectory.Size = new System.Drawing.Size(605, 375);
            this.tabPagePluginDirectory.TabIndex = 1;
            this.tabPagePluginDirectory.Text = "Plugin directory";
            // 
            // PluginManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 381);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginManagerForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plugin manager";
            this.Load += new System.EventHandler(this.PluginManagerForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageInstalled.ResumeLayout(false);
            this.panelInstalledPlugins.ResumeLayout(false);
            this.panelInstalledPluginsControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInstalled;
        private System.Windows.Forms.TabPage tabPagePluginDirectory;
        private System.Windows.Forms.Panel panelInstalledPlugins;
        private System.Windows.Forms.ListBox listBoxPlugins;
        private System.Windows.Forms.Panel panelInstalledPluginsControls;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonUpdatePlugins;
    }
}
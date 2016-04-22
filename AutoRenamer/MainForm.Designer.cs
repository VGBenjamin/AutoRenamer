namespace AutoRenamer
{
    partial class MainForm
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
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinationDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.destinationDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBottomPortion = 0.33D;
            this.dockPanel.DockLeftPortion = 210D;
            this.dockPanel.DockRightPortion = 280D;
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(978, 556);
            this.dockPanel.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusText,
            this.toolStripStatusLabel1,
            this.tsslStatusProgressBar});
            this.statusStrip2.Location = new System.Drawing.Point(0, 580);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(978, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslStatusText
            // 
            this.tsslStatusText.Name = "tsslStatusText";
            this.tsslStatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // tsslStatusProgressBar
            // 
            this.tsslStatusProgressBar.Name = "tsslStatusProgressBar";
            this.tsslStatusProgressBar.Size = new System.Drawing.Size(100, 16);
            this.tsslStatusProgressBar.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceDirectoryToolStripMenuItem,
            this.destinationDirectoryToolStripMenuItem,
            this.queueToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // sourceDirectoryToolStripMenuItem
            // 
            this.sourceDirectoryToolStripMenuItem.Name = "sourceDirectoryToolStripMenuItem";
            this.sourceDirectoryToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.sourceDirectoryToolStripMenuItem.Text = "Source directory";
            this.sourceDirectoryToolStripMenuItem.Click += new System.EventHandler(this.sourceDirectoryToolStripMenuItem_Click);
            // 
            // destinationDirectoryToolStripMenuItem
            // 
            this.destinationDirectoryToolStripMenuItem.Name = "destinationDirectoryToolStripMenuItem";
            this.destinationDirectoryToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.destinationDirectoryToolStripMenuItem.Text = "Destination directory";
            this.destinationDirectoryToolStripMenuItem.Click += new System.EventHandler(this.destinationDirectoryToolStripMenuItem_Click);
            // 
            // queueToolStripMenuItem
            // 
            this.queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            this.queueToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.queueToolStripMenuItem.Text = "Queue";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // sourceDirectoryToolStripMenuItem1
            // 
            this.sourceDirectoryToolStripMenuItem1.Name = "sourceDirectoryToolStripMenuItem1";
            this.sourceDirectoryToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.sourceDirectoryToolStripMenuItem1.Text = "Source directory";
            // 
            // destinationDirectoryToolStripMenuItem1
            // 
            this.destinationDirectoryToolStripMenuItem1.Name = "destinationDirectoryToolStripMenuItem1";
            this.destinationDirectoryToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.destinationDirectoryToolStripMenuItem1.Text = "Destination directory";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 602);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsslStatusProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinationDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceDirectoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem destinationDirectoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}
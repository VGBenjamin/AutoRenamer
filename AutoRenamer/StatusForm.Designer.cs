namespace AutoRenamer
{
    partial class StatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSourceStillExist = new System.Windows.Forms.CheckBox();
            this.gbFileTypes = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFileTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExcluded = new System.Windows.Forms.CheckBox();
            this.cbInProgress = new System.Windows.Forms.CheckBox();
            this.cbSynched = new System.Windows.Forms.CheckBox();
            this.cbNonSyched = new System.Windows.Forms.CheckBox();
            this.btnSynchNow = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewSynchronization = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceFileColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationFileColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationFolderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynchDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceFileStillExistColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dockPanelFilters = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.dockPanelLogs = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbFileTypes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSynchronization)).BeginInit();
            this.panel3.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.gbFileTypes);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnSynchNow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 125);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSourceStillExist);
            this.groupBox2.Location = new System.Drawing.Point(509, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // cbSourceStillExist
            // 
            this.cbSourceStillExist.AutoSize = true;
            this.cbSourceStillExist.Checked = true;
            this.cbSourceStillExist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSourceStillExist.Location = new System.Drawing.Point(7, 20);
            this.cbSourceStillExist.Name = "cbSourceStillExist";
            this.cbSourceStillExist.Size = new System.Drawing.Size(101, 17);
            this.cbSourceStillExist.TabIndex = 0;
            this.cbSourceStillExist.Text = "Source still exist";
            this.cbSourceStillExist.UseVisualStyleBackColor = true;
            this.cbSourceStillExist.CheckedChanged += new System.EventHandler(this.cbSourceStillExist_CheckedChanged);
            // 
            // gbFileTypes
            // 
            this.gbFileTypes.Controls.Add(this.flowLayoutPanelFileTypes);
            this.gbFileTypes.Location = new System.Drawing.Point(234, 12);
            this.gbFileTypes.Name = "gbFileTypes";
            this.gbFileTypes.Size = new System.Drawing.Size(269, 100);
            this.gbFileTypes.TabIndex = 6;
            this.gbFileTypes.TabStop = false;
            this.gbFileTypes.Text = "File types";
            // 
            // flowLayoutPanelFileTypes
            // 
            this.flowLayoutPanelFileTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFileTypes.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelFileTypes.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelFileTypes.Name = "flowLayoutPanelFileTypes";
            this.flowLayoutPanelFileTypes.Size = new System.Drawing.Size(263, 81);
            this.flowLayoutPanelFileTypes.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbExcluded);
            this.groupBox1.Controls.Add(this.cbInProgress);
            this.groupBox1.Controls.Add(this.cbSynched);
            this.groupBox1.Controls.Add(this.cbNonSyched);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // cbExcluded
            // 
            this.cbExcluded.AutoSize = true;
            this.cbExcluded.Location = new System.Drawing.Point(128, 44);
            this.cbExcluded.Name = "cbExcluded";
            this.cbExcluded.Size = new System.Drawing.Size(70, 17);
            this.cbExcluded.TabIndex = 5;
            this.cbExcluded.Text = "Excluded";
            this.cbExcluded.UseVisualStyleBackColor = true;
            this.cbExcluded.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbInProgress
            // 
            this.cbInProgress.AutoSize = true;
            this.cbInProgress.Checked = true;
            this.cbInProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInProgress.Location = new System.Drawing.Point(128, 19);
            this.cbInProgress.Name = "cbInProgress";
            this.cbInProgress.Size = new System.Drawing.Size(78, 17);
            this.cbInProgress.TabIndex = 4;
            this.cbInProgress.Text = "In progress";
            this.cbInProgress.UseVisualStyleBackColor = true;
            this.cbInProgress.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbSynched
            // 
            this.cbSynched.AutoSize = true;
            this.cbSynched.Location = new System.Drawing.Point(6, 44);
            this.cbSynched.Name = "cbSynched";
            this.cbSynched.Size = new System.Drawing.Size(68, 17);
            this.cbSynched.TabIndex = 3;
            this.cbSynched.Text = "Synched";
            this.cbSynched.UseVisualStyleBackColor = true;
            this.cbSynched.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbNonSyched
            // 
            this.cbNonSyched.AutoSize = true;
            this.cbNonSyched.Checked = true;
            this.cbNonSyched.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNonSyched.Location = new System.Drawing.Point(6, 19);
            this.cbNonSyched.Name = "cbNonSyched";
            this.cbNonSyched.Size = new System.Drawing.Size(91, 17);
            this.cbNonSyched.TabIndex = 2;
            this.cbNonSyched.Text = "Non Synched";
            this.cbNonSyched.UseVisualStyleBackColor = true;
            this.cbNonSyched.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // btnSynchNow
            // 
            this.btnSynchNow.Location = new System.Drawing.Point(1051, 12);
            this.btnSynchNow.Name = "btnSynchNow";
            this.btnSynchNow.Size = new System.Drawing.Size(109, 94);
            this.btnSynchNow.TabIndex = 2;
            this.btnSynchNow.Text = "Synchronize now";
            this.btnSynchNow.UseVisualStyleBackColor = true;
            this.btnSynchNow.Click += new System.EventHandler(this.btnSynchNow_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1172, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dataGridViewSynchronization);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1172, 231);
            this.panel2.TabIndex = 3;
            // 
            // dataGridViewSynchronization
            // 
            this.dataGridViewSynchronization.AllowUserToAddRows = false;
            this.dataGridViewSynchronization.AllowUserToDeleteRows = false;
            this.dataGridViewSynchronization.AllowUserToOrderColumns = true;
            this.dataGridViewSynchronization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSynchronization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.StatusColumn,
            this.ReasonColumn,
            this.SourceFileColumn,
            this.DestinationFileColumn,
            this.IdColumn,
            this.DestinationFolderColumn,
            this.SynchDateColumn,
            this.SourceFileStillExistColumn,
            this.ReChecked});
            this.dataGridViewSynchronization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSynchronization.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSynchronization.Margin = new System.Windows.Forms.Padding(9);
            this.dataGridViewSynchronization.Name = "dataGridViewSynchronization";
            this.dataGridViewSynchronization.ReadOnly = true;
            this.dataGridViewSynchronization.Size = new System.Drawing.Size(1172, 231);
            this.dataGridViewSynchronization.TabIndex = 1;
            this.dataGridViewSynchronization.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewSynchronization_DataBindingComplete);
            this.dataGridViewSynchronization.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSynchronization_MouseClick);
            // 
            // SelectColumn
            // 
            this.SelectColumn.Frozen = true;
            this.SelectColumn.HeaderText = "Select";
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            this.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.Frozen = true;
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 62;
            // 
            // ReasonColumn
            // 
            this.ReasonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReasonColumn.DataPropertyName = "Reason";
            this.ReasonColumn.HeaderText = "Reason";
            this.ReasonColumn.Name = "ReasonColumn";
            this.ReasonColumn.ReadOnly = true;
            this.ReasonColumn.Visible = false;
            // 
            // SourceFileColumn
            // 
            this.SourceFileColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SourceFileColumn.DataPropertyName = "SourceFile";
            this.SourceFileColumn.HeaderText = "Source File";
            this.SourceFileColumn.Name = "SourceFileColumn";
            this.SourceFileColumn.ReadOnly = true;
            this.SourceFileColumn.Width = 78;
            // 
            // DestinationFileColumn
            // 
            this.DestinationFileColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DestinationFileColumn.DataPropertyName = "DestinationFile";
            this.DestinationFileColumn.HeaderText = "Destination File";
            this.DestinationFileColumn.Name = "DestinationFileColumn";
            this.DestinationFileColumn.ReadOnly = true;
            this.DestinationFileColumn.Width = 96;
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "IdColumn";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // DestinationFolderColumn
            // 
            this.DestinationFolderColumn.DataPropertyName = "DestinationFolder";
            this.DestinationFolderColumn.HeaderText = "Destination Folder";
            this.DestinationFolderColumn.Name = "DestinationFolderColumn";
            this.DestinationFolderColumn.ReadOnly = true;
            this.DestinationFolderColumn.Visible = false;
            // 
            // SynchDateColumn
            // 
            this.SynchDateColumn.DataPropertyName = "SynchDate";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.SynchDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SynchDateColumn.HeaderText = "Synch Date";
            this.SynchDateColumn.Name = "SynchDateColumn";
            this.SynchDateColumn.ReadOnly = true;
            // 
            // SourceFileStillExistColumn
            // 
            this.SourceFileStillExistColumn.DataPropertyName = "SourceFileStillExist";
            this.SourceFileStillExistColumn.HeaderText = "SourceFileStillExist";
            this.SourceFileStillExistColumn.Name = "SourceFileStillExistColumn";
            this.SourceFileStillExistColumn.ReadOnly = true;
            // 
            // ReChecked
            // 
            this.ReChecked.DataPropertyName = "ReChecked";
            this.ReChecked.HeaderText = "ReCheckedColumn";
            this.ReChecked.Name = "ReChecked";
            this.ReChecked.ReadOnly = true;
            this.ReChecked.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 381);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1172, 188);
            this.panel3.TabIndex = 4;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusText,
            this.toolStripStatusLabel1,
            this.tsslStatusProgressBar});
            this.statusStrip2.Location = new System.Drawing.Point(0, 166);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1172, 22);
            this.statusStrip2.TabIndex = 1;
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
            // dockPanelFilters
            // 
            this.dockPanelFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockPanelFilters.Location = new System.Drawing.Point(0, 150);
            this.dockPanelFilters.Name = "dockPanelFilters";
            this.dockPanelFilters.Size = new System.Drawing.Size(200, 231);
            this.dockPanelFilters.TabIndex = 8;
            // 
            // dockPanelLogs
            // 
            this.dockPanelLogs.Location = new System.Drawing.Point(998, -81);
            this.dockPanelLogs.Name = "dockPanelLogs";
            this.dockPanelLogs.Size = new System.Drawing.Size(200, 100);
            this.dockPanelLogs.TabIndex = 10;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1156, 172);
            this.rtbLog.TabIndex = 12;
            this.rtbLog.Text = "";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 569);
            this.Controls.Add(this.dockPanelLogs);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.dockPanelFilters);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StatusForm";
            this.Text = "Auto Renamer Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbFileTypes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSynchronization)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewSynchronization;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSynchNow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbNonSyched;
        private System.Windows.Forms.CheckBox cbExcluded;
        private System.Windows.Forms.CheckBox cbInProgress;
        private System.Windows.Forms.CheckBox cbSynched;
        private System.Windows.Forms.GroupBox gbFileTypes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileTypes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSourceStillExist;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsslStatusProgressBar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceFileColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationFileColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationFolderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SynchDateColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SourceFileStillExistColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReChecked;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelFilters;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelLogs;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}


namespace AutoRenamer.Panels
{
    partial class MainUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSynchNow = new System.Windows.Forms.Button();
            this.panelMiddle = new System.Windows.Forms.Panel();
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
            this.panelTop.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSynchronization)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSynchNow);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(886, 36);
            this.panelTop.TabIndex = 0;
            // 
            // btnSynchNow
            // 
            this.btnSynchNow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSynchNow.Location = new System.Drawing.Point(0, 0);
            this.btnSynchNow.Name = "btnSynchNow";
            this.btnSynchNow.Size = new System.Drawing.Size(886, 36);
            this.btnSynchNow.TabIndex = 3;
            this.btnSynchNow.Text = "Synchronize now";
            this.btnSynchNow.UseVisualStyleBackColor = true;
            this.btnSynchNow.Click += new System.EventHandler(this.btnSynchNow_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.dataGridViewSynchronization);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 36);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(886, 393);
            this.panelMiddle.TabIndex = 1;
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
            this.dataGridViewSynchronization.Size = new System.Drawing.Size(886, 393);
            this.dataGridViewSynchronization.TabIndex = 2;
            this.dataGridViewSynchronization.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSynchronization_CellFormatting);
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
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.SynchDateColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            // MainUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 429);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainUserControl";
            this.panelTop.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSynchronization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.DataGridView dataGridViewSynchronization;
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
        private System.Windows.Forms.Button btnSynchNow;
    }
}

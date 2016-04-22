namespace AutoRenamer.Panels
{
    partial class QueueUserControl
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
            this.dataGridViewQueue = new System.Windows.Forms.DataGridView();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressColumn = new AutoRenamer.DataGridColumns.DataGridViewProgressColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewProgressColumn1 = new AutoRenamer.DataGridColumns.DataGridViewProgressColumn();
            this.dataGridViewPercentageColumn1 = new AutoRenamer.DataGridColumns.DataGridViewProgressColumn();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewQueue
            // 
            this.dataGridViewQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueue.ColumnHeadersVisible = false;
            this.dataGridViewQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleColumn,
            this.ProgressColumn});
            this.dataGridViewQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQueue.Location = new System.Drawing.Point(0, 45);
            this.dataGridViewQueue.Name = "dataGridViewQueue";
            this.dataGridViewQueue.RowHeadersVisible = false;
            this.dataGridViewQueue.Size = new System.Drawing.Size(236, 411);
            this.dataGridViewQueue.TabIndex = 0;
            this.dataGridViewQueue.Tag = "";
            // 
            // TitleColumn
            // 
            this.TitleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TitleColumn.DataPropertyName = "Title";
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.ReadOnly = true;
            // 
            // ProgressColumn
            // 
            this.ProgressColumn.DataPropertyName = "ProgressionPercentage";
            this.ProgressColumn.HeaderText = "Progress";
            this.ProgressColumn.Name = "ProgressColumn";
            this.ProgressColumn.ProgressBarColor = System.Drawing.Color.Silver;
            this.ProgressColumn.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 45);
            this.panel1.TabIndex = 3;
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.DataPropertyName = "ProgressionPercentage";
            this.dataGridViewProgressColumn1.HeaderText = "Progress";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ProgressBarColor = System.Drawing.Color.Silver;
            this.dataGridViewProgressColumn1.ReadOnly = true;
            // 
            // dataGridViewPercentageColumn1
            // 
            this.dataGridViewPercentageColumn1.HeaderText = "Progress";
            this.dataGridViewPercentageColumn1.Name = "dataGridViewPercentageColumn1";
            this.dataGridViewPercentageColumn1.ProgressBarColor = System.Drawing.Color.Silver;
            this.dataGridViewPercentageColumn1.ReadOnly = true;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Image = global::AutoRenamer.Properties.Resources.Pause;
            this.btnPause.Location = new System.Drawing.Point(116, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(31, 32);
            this.btnPause.TabIndex = 3;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::AutoRenamer.Properties.Resources.Up2;
            this.btnUp.Location = new System.Drawing.Point(13, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 32);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::AutoRenamer.Properties.Resources.Down2;
            this.btnDown.Location = new System.Drawing.Point(53, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(31, 32);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // QueueUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 456);
            this.Controls.Add(this.dataGridViewQueue);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QueueUserControl";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.TabText = "Process Queue";
            this.Text = "Process Queue";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewQueue;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private DataGridColumns.DataGridViewProgressColumn dataGridViewPercentageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn;
        private DataGridColumns.DataGridViewProgressColumn ProgressColumn;
        private System.Windows.Forms.Panel panel1;
        private DataGridColumns.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.Button btnPause;
    }
}

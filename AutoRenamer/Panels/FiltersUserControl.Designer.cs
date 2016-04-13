namespace AutoRenamer.Panels
{
    partial class FiltersUserControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSourceStillExist = new System.Windows.Forms.CheckBox();
            this.gbFileTypes = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFileTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExcluded = new System.Windows.Forms.CheckBox();
            this.cbInProgress = new System.Windows.Forms.CheckBox();
            this.cbSynched = new System.Windows.Forms.CheckBox();
            this.cbNonSyched = new System.Windows.Forms.CheckBox();
            this.cbError = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.gbFileTypes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSourceStillExist);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 100);
            this.groupBox2.TabIndex = 11;
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
            this.gbFileTypes.Location = new System.Drawing.Point(12, 262);
            this.gbFileTypes.Name = "gbFileTypes";
            this.gbFileTypes.Size = new System.Drawing.Size(179, 137);
            this.gbFileTypes.TabIndex = 10;
            this.gbFileTypes.TabStop = false;
            this.gbFileTypes.Text = "File types";
            // 
            // flowLayoutPanelFileTypes
            // 
            this.flowLayoutPanelFileTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFileTypes.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelFileTypes.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelFileTypes.Name = "flowLayoutPanelFileTypes";
            this.flowLayoutPanelFileTypes.Size = new System.Drawing.Size(173, 118);
            this.flowLayoutPanelFileTypes.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbError);
            this.groupBox1.Controls.Add(this.cbExcluded);
            this.groupBox1.Controls.Add(this.cbInProgress);
            this.groupBox1.Controls.Add(this.cbSynched);
            this.groupBox1.Controls.Add(this.cbNonSyched);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 140);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // cbExcluded
            // 
            this.cbExcluded.AutoSize = true;
            this.cbExcluded.Location = new System.Drawing.Point(6, 90);
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
            this.cbInProgress.Location = new System.Drawing.Point(6, 67);
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
            // cbError
            // 
            this.cbError.AutoSize = true;
            this.cbError.Checked = true;
            this.cbError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbError.Location = new System.Drawing.Point(6, 113);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(48, 17);
            this.cbError.TabIndex = 6;
            this.cbError.Text = "Error";
            this.cbError.UseVisualStyleBackColor = true;
            this.cbError.Click += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // FiltersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbFileTypes);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FiltersUserControl";
            this.TabText = "Filters";
            this.Text = "Filters";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbFileTypes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSourceStillExist;
        private System.Windows.Forms.GroupBox gbFileTypes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbExcluded;
        private System.Windows.Forms.CheckBox cbInProgress;
        private System.Windows.Forms.CheckBox cbSynched;
        private System.Windows.Forms.CheckBox cbNonSyched;
        private System.Windows.Forms.CheckBox cbError;
    }
}

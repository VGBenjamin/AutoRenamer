namespace AutoRenamer.MessageBoxes
{
    partial class FileExistDialog
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
            this.btnOverride = new System.Windows.Forms.Button();
            this.btnSkipButSynched = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSkipAndLetStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOverride
            // 
            this.btnOverride.Location = new System.Drawing.Point(33, 72);
            this.btnOverride.Name = "btnOverride";
            this.btnOverride.Size = new System.Drawing.Size(75, 23);
            this.btnOverride.TabIndex = 0;
            this.btnOverride.Text = "Override";
            this.btnOverride.UseVisualStyleBackColor = true;
            this.btnOverride.Click += new System.EventHandler(this.btnOverride_Click);
            // 
            // btnSkipButSynched
            // 
            this.btnSkipButSynched.Location = new System.Drawing.Point(114, 72);
            this.btnSkipButSynched.Name = "btnSkipButSynched";
            this.btnSkipButSynched.Size = new System.Drawing.Size(159, 23);
            this.btnSkipButSynched.TabIndex = 1;
            this.btnSkipButSynched.Text = "Skip and march as synched";
            this.btnSkipButSynched.UseVisualStyleBackColor = true;
            this.btnSkipButSynched.Click += new System.EventHandler(this.btnSkipButSynched_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(34, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(129, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "The file XXX allready exist";
            // 
            // btnSkipAndLetStatus
            // 
            this.btnSkipAndLetStatus.Location = new System.Drawing.Point(279, 72);
            this.btnSkipAndLetStatus.Name = "btnSkipAndLetStatus";
            this.btnSkipAndLetStatus.Size = new System.Drawing.Size(159, 23);
            this.btnSkipAndLetStatus.TabIndex = 3;
            this.btnSkipAndLetStatus.Text = "Skip and let the previous status";
            this.btnSkipAndLetStatus.UseVisualStyleBackColor = true;
            this.btnSkipAndLetStatus.Click += new System.EventHandler(this.btnSkipAndLetStatus_Click);
            // 
            // FileExistDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 107);
            this.Controls.Add(this.btnSkipAndLetStatus);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSkipButSynched);
            this.Controls.Add(this.btnOverride);
            this.Name = "FileExistDialog";
            this.Text = "FileExistDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOverride;
        private System.Windows.Forms.Button btnSkipButSynched;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSkipAndLetStatus;
    }
}
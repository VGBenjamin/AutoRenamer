using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRenamer.MessageBoxes
{
    public partial class FileExistDialog : Form
    {
        public string OriginalFilePath { get; set; }
        public string TargetFilePath { get; set; }

        public FileExistDialog()
        {
            InitializeComponent();
            lblMessage.Text =
                $"The file '{TargetFilePath}' allready exist (source file is: '{OriginalFilePath}'). {Environment.NewLine}What do you want to do?";
        }

        private void btnOverride_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; 
        }

        private void btnSkipButSynched_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void btnSkipAndLetStatus_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;            
        }
    }
}

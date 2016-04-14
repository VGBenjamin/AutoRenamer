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
        [Flags]
        public enum FileExistActionEnum
        {
            None = 0, 
            All = 1,
            Override = 2, 
            OverrideAll = All | Override,
            SkipButSynched = 4, 
            SkipButSynchedAll = All | SkipButSynched,
            SkipAndLetStatus = 8, 
            SkipAndLetStatusAll = All | SkipButSynched
        }

        public string OriginalFilePath { get; set; }
        public string TargetFilePath { get; set; }

        public FileExistActionEnum SelectedAction { get; set; } = FileExistActionEnum.None;

        public FileExistDialog()
        {
            InitializeComponent();
            lblMessage.Text =
                $"The file '{TargetFilePath}' allready exist (source file is: '{OriginalFilePath}'). {Environment.NewLine}What do you want to do?";
        }

        public FileExistDialog(string originalFilePath, string targetFilePath)
        {
            TargetFilePath = targetFilePath;
            OriginalFilePath = originalFilePath;
            InitializeComponent();
            lblMessage.Text =
                $"The file '{TargetFilePath}' allready exist (source file is: '{OriginalFilePath}'). {Environment.NewLine}What do you want to do?";
        }

        private void btnOverride_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.Override;
            this.Close();
        }

        private void btnSkipButSynched_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.SkipButSynched;
            this.Close();
        }

        private void btnSkipAndLetStatus_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.SkipAndLetStatus;            
            this.Close();
        }

        private void btnOverrideAll_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.OverrideAll;
            this.Close();
        }

        private void btnSkipButSynchedAll_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.SkipButSynchedAll;
            this.Close();
        }

        private void btnSkipAndLetStatusAll_Click(object sender, EventArgs e)
        {
            this.SelectedAction = FileExistActionEnum.SkipAndLetStatusAll;
            this.Close();
        }
    }
}

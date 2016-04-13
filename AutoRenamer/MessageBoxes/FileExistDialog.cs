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
        public enum FileExistActionEnum
        {
            None,
            Override,
            OverrideAll,
            SkipButSynched,
            SkipButSynchedAll,
            SkipAndLetStatus,
            SkipAndLetStatusAll
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

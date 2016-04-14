using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class FiltersUserControl : DockContent
    {
        #region event FolderLoading
        public delegate void FilterChangedEventHandler(object sender,EventArgs e);
        public event FilterChangedEventHandler OnFilterChanged;
        #endregion

        public List<CheckBox> FileTypesCheckboxes { get; set; }
        public CheckBox CheckboxAll { get; set; }
        public TasksQueue Tasks { get; set; }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FiltersUserControl()
        {
            InitializeComponent();
            LoadFileTypes();
        }

        private void LoadFileTypes()
        {
            flowLayoutPanelFileTypes.SuspendLayout();

            FileTypesCheckboxes = new List<CheckBox>();
            var margin = new Padding(0, 0, 0, 0);

            bool someChecked = false;

            CheckboxAll = new CheckBox()
            {
                Text = "All",
                Tag = "*",
                Margin = margin
            };
            CheckboxAll.Click += CheckboxAll_Click;
            flowLayoutPanelFileTypes.Controls.Add(CheckboxAll);

            foreach (FileType fileType in AutoRenamerConfig.Instance.FilesTypes)
            {
                var cb = new CheckBox()
                {
                    Checked = fileType.Checked,
                    Text = fileType.Name,
                    Tag = fileType.Extensions,
                    Margin = margin
                };
                cb.Click += CbFileType_Click;

                someChecked = someChecked || fileType.Checked;

                FileTypesCheckboxes.Add(cb);
                flowLayoutPanelFileTypes.Controls.Add(cb);
            }

            CheckboxAll.Checked = !someChecked;

            flowLayoutPanelFileTypes.ResumeLayout();
        }

        #region events
        private void CbFileType_Click(object sender, EventArgs eventArgs)
        {
            CheckboxAll.Checked = false;
            OnFilterChanged?.Invoke(this, new EventArgs());
        }

        private void CheckboxAll_Click(object sender, EventArgs eventArgs)
        {
            foreach (var fileTypesCheckbox in FileTypesCheckboxes)
            {
                fileTypesCheckbox.Checked = !CheckboxAll.Checked;
            }
            OnFilterChanged?.Invoke(this, new EventArgs());

        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            OnFilterChanged?.Invoke(this, new EventArgs());
        }

        private void cbSourceStillExist_CheckedChanged(object sender, EventArgs e)
        {
            OnFilterChanged?.Invoke(this, new EventArgs());
        }
        #endregion
        public void FilterGrid(DataGridView dataGridView)
        {
            log.Debug("Refilter the grid");

            bool acceptAllExtensions = CheckboxAll.Checked;
            List<string> allowedExtensions = new List<string>();
            if (!acceptAllExtensions)
            {
                foreach (var fileTypesCheckbox in FileTypesCheckboxes)
                {
                    if (fileTypesCheckbox.Checked)
                    {
                        allowedExtensions.AddRange(((string)fileTypesCheckbox.Tag).Split(new char[] { '|' }));
                    }
                }
            }

            dataGridView.CurrentCell = null;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["StatusColumn"] != null && row.Cells["SourceFileColumn"] != null)
                {
                    var statusColumn = (StatusEnum)row.Cells["StatusColumn"].Value;
                    var sourceFile = (string)row.Cells["SourceFileColumn"].Value;
                    var sourceFileStillExist = (bool)row.Cells["SourceFileStillExistColumn"].Value;

                    row.Visible = StatusIsAccepted(statusColumn) &&
                        (acceptAllExtensions || FileTypeIsAccepted(sourceFile, allowedExtensions))
                        && (!cbSourceStillExist.Checked || sourceFileStillExist);
                }
            }
        }

        private bool FileTypeIsAccepted(string sourceFile, List<string> allowedExtensions)
        {
            var extension = Path.GetExtension(sourceFile);
            if (string.IsNullOrEmpty(extension))
                return false;
            extension = extension.Substring(1); // remove the dot

            return allowedExtensions.Contains(extension);
        }

        private bool StatusIsAccepted(StatusEnum statusColumn)
        {
            return (cbNonSyched.Checked && statusColumn == StatusEnum.NotSynched)
                   || (cbInProgress.Checked && statusColumn == StatusEnum.InProgress)
                   || (cbSynched.Checked && statusColumn == StatusEnum.Synched)
                   || (cbExcluded.Checked && statusColumn == StatusEnum.Excluded)
                   || (cbError.Checked && statusColumn == StatusEnum.Error);
        }
    }
}

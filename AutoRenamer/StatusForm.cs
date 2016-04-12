using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoRenamer.BOL.Base;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Log4Net;
using AutoRenamer.BOL.Objects;
using AutoRenamer.MessageBoxes;
using DataGridViewAutoFilter;

namespace AutoRenamer
{
    public partial class StatusForm : Form
    {
        #region variables
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private LogWatcher _logWatcher;            

        public Synchronization CurrentSynchronization { get; set; }

        #region menu properties
        public ContextMenu GridContextMenu { get; set; }
        public MenuItem ExcludeMenuItem { get; set; }
        public MenuItem ResetStatusMenuItem { get; set; }
        public MenuItem ExploreMenuItem { get; set; }
        
        public int SelectedGridRow { get; set; }

        public List<CheckBox> FileTypesCheckboxes { get; set; }
        public CheckBox CheckboxAll { get; set; }
        #endregion
        #endregion

        #region Properties
        private string _treatedXMlPath;
        public string TreatedXMlPath
        {
            get
            {
                if (string.IsNullOrEmpty(_treatedXMlPath))
                {
                    _treatedXMlPath = AutoRenamerConfig.Instance.TreatedXMlPath;
                    if (string.IsNullOrEmpty(_treatedXMlPath))
                        _treatedXMlPath = @"\treated.xml";

                    _treatedXMlPath = Path.GetFullPath(_treatedXMlPath);
                }
                return _treatedXMlPath;
            }
        }
        #endregion

        public StatusForm()
        {
            _logWatcher = new LogWatcher();
            _logWatcher.Updated += LogWatcherOnUpdated;
            
            InitializeComponent();
            log.Debug("Loading");
            LoadFileTypes();
            LoadTreatedFile();
            LoadUnTreatedFiles();
            LoadGridContextMenu();

            log.Debug($"Filebot expression: {AutoRenamerConfig.Instance.FilebotExpression.Value}");

            //Task.Factory.StartNew(FillFilesWhoStillExist); //Run but didn't wait for a result
        }

        /*private void FillFilesWhoStillExist()
        {
            if (InvokeRequired)            
                Invoke((MethodInvoker) delegate
                {
                    DisplayStatusText($"Checking the file who still exist", 0, dataGridViewSynchronization.Rows.Count);
                });            
            else
                DisplayStatusText($"Checking the file who still exist", 0, dataGridViewSynchronization.Rows.Count);
            
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if ((bool) row.Cells["SourceFileStillExistColumn"].Value)
                {
                    var sourceFile = (string)row.Cells["SourceFileColumn"].Value;
                    row.Cells["SourceFileStillExistColumn"].Value = File.Exists(sourceFile);
                }
                Thread.Sleep(300);
                if (InvokeRequired)
                    Invoke(new MethodInvoker(IncrementProgress));
                else
                    IncrementProgress();
            }

            FilterGrid();

            if (InvokeRequired)
                Invoke(new MethodInvoker(HideStatusText));
            else
                HideStatusText();
        }*/

        private void IncrementProgress()
        {
            tsslStatusProgressBar.Value++;
        }

        public void DisplayStatusText(string statusText, int min, int max)
        {
            tsslStatusText.Visible = true;
            tsslStatusProgressBar.Visible = true;
            tsslStatusText.Text = statusText;
            tsslStatusProgressBar.Minimum = min;
            tsslStatusProgressBar.Maximum = max;
            tsslStatusProgressBar.Value = min;
        }

        public void HideStatusText()
        {
            tsslStatusText.Visible = false;
            tsslStatusProgressBar.Visible = false;
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

        private void CbFileType_Click(object sender, EventArgs eventArgs)
        {
            CheckboxAll.Checked = false;
            FilterGrid();
        }

        private void CheckboxAll_Click(object sender, EventArgs eventArgs)
        {
            foreach (var fileTypesCheckbox in FileTypesCheckboxes)
            {
                fileTypesCheckbox.Checked = !CheckboxAll.Checked;
            }
            FilterGrid();
        }

        #region Methods

        #region Loading
        private void LoadGridContextMenu()
        {
            GridContextMenu = new ContextMenu();
            ExcludeMenuItem = new MenuItem("Exclude");
            ExcludeMenuItem.Click += ExcludeMenuItem_Click;
            ResetStatusMenuItem = new MenuItem("Reset status");
            ResetStatusMenuItem.Click += ResetStatusMenuItemOnClick;
            ExploreMenuItem = new MenuItem("Explore");
            ExploreMenuItem.Click += ExploreMenuItem_Click;
        }

        private void ExploreMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = (string) ExploreMenuItem.Tag;
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The selected file does not exist anymore", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process.Start("explorer.exe", $"/select, {filePath}");
            }
        }

        private void LoadUnTreatedFiles()
        {
            int folderTreated = 0;
            foreach (FolderToWatch folderPath in AutoRenamerConfig.Instance.FoldersToWatch)
            {
                folderTreated++;
                if (!Directory.Exists(folderPath.Source))
                {
                    log.Error($"The watched source directory '{folderPath.Source}' does not exist");
                    continue;
                }

                if (!Directory.Exists(folderPath.Source))
                {
                    log.Error($"The destination directory '{folderPath.Destination}' does not exist");
                    continue;
                }

                log.Debug($"Listing the files from '{folderPath.Source}'");
                var files = Directory.GetFiles(folderPath.Source);
                DisplayStatusText($"Loading files from folder {folderPath.Source} ({folderTreated}/{AutoRenamerConfig.Instance.FoldersToWatch.Count}", 0, files.Count());

                foreach (var file in files)
                {
                    var entry = CurrentSynchronization.StatusList.FirstOrDefault(status => status.SourceFile == file);

                    if (entry == null)
                    {
                        CurrentSynchronization.StatusList.Add(new StatusDetail()
                        {
                            SourceFile = file,
                            Status = StatusEnum.NotSynched,
                            DestinationFolder = folderPath.Destination,
                            ReChecked = true
                        });
                    }
                    else
                    {
                        entry.ReChecked = true;
                    }
                    IncrementProgress();
                }
            }

            //Mark all the files who haven't been recheck as SourceFileStillExist = false because we didn't have found it
            foreach (var statusDetail in CurrentSynchronization.StatusList)
            {
                statusDetail.SourceFileStillExist = statusDetail.ReChecked;
            }

            HideStatusText();
        }

        private void LoadTreatedFile()
        {
            EnsureTreatedFilesExist();

            CurrentSynchronization = Synchronization.DeserializeFromXml(TreatedXMlPath);
            dataGridViewSynchronization.DataSource = CurrentSynchronization.StatusList;
        }

        private void EnsureTreatedFilesExist()
        {
            if (!File.Exists(TreatedXMlPath))
            {
                log.Debug($"The file does not exist yet => create it in '{TreatedXMlPath}'");
                var synch = new Synchronization();
                synch.SerializeToXml(TreatedXMlPath);
            }
        }

        private void dataGridViewSynchronization_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if (row.Cells["SelectColumn"] != null)
                {
                    //Check all the checkbox for the NonSyched status
                    row.Cells["SelectColumn"].Value = row.Cells["StatusColumn"]?.Value != null
                                                      && (StatusEnum)row.Cells["StatusColumn"].Value == StatusEnum.NotSynched;
                }
            }
            FilterGrid();
        }
        #endregion


        private void ExcludeMenuItem_Click(object sender, EventArgs e)
        {
            var selectedCell = dataGridViewSynchronization.Rows[SelectedGridRow]?.Cells["StatusColumn"];
            if (selectedCell == null)
            {
                log.Error($"Cannot retreive the cell 'StatusColumn' from the row number: {SelectedGridRow}");
            }
            else
            {
                selectedCell.Value = StatusEnum.Excluded;
            }
        }

        private void ResetStatusMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            var selectedCell = dataGridViewSynchronization.Rows[SelectedGridRow]?.Cells["StatusColumn"];
            if (selectedCell == null)
            {
                log.Error($"Cannot retreive the cell 'StatusColumn' from the row number: {SelectedGridRow}");
            }
            else
            {
                selectedCell.Value = StatusEnum.NotSynched;
            }
        }

        #region Logs
        private void LogWatcherOnUpdated(object sender, EventArgs eventArgs)
        {
            UpdateLogTextbox(_logWatcher.LogContent);
        }

        public void UpdateLogTextbox(string value)
        {
            // Check whether invoke is required and then invoke as necessary
            if (InvokeRequired)
            {

                this.BeginInvoke(new Action<string>(UpdateLogTextbox), new object[] { value });
                return;
            }

            // Set the textbox value
            rtbLog.Text = value;
        }
        #endregion
      
        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            log.Info($"Saving the info into '{TreatedXMlPath}'");
            CurrentSynchronization.SerializeToXml(TreatedXMlPath);
            log.Info($"Saved!");
        }

        private void btnSynchNow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if (row.Visible)
                {
                    var selectedCell = row.Cells["SelectColumn"];

                    if ((bool) selectedCell.Value)
                    {
                        var sourceFile = (string) row.Cells["SourceFileColumn"].Value;
                        log.Info($"Calling filebot for the file: {sourceFile}");
                        var arguments = AutoRenamerConfig.Instance.FilebotExpression.Value.Replace("%FILENAME%",
                            sourceFile);
                        log.Debug($"Filebot arguments: {arguments}");

                        Process process = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                                FileName = "filebot",
                                Arguments = arguments,
                                UseShellExecute = false,
                                RedirectStandardOutput = true
                            }
                        };
                        process.Start();
                        var output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();

                        log.Debug(output);
                        var regex = new Regex(@"\[TEST\] Rename \[.+?\] to \[(.+?)\]");
                        var match = regex.Match(output);

                        if (match.Success && match.Groups.Count >= 2)
                        {
                            var newName = match.Groups[1].Value;
                            log.Info($"Detected new name: {newName}.");

                            var destinationFolder = (string) row.Cells["DestinationFolderColumn"].Value;
                            var targetPath = Path.Combine(destinationFolder,
                                newName.StartsWith("\\") ? newName.Substring(1) : newName);

                            CopyFile(sourceFile, targetPath, row);

                            
                        }
                        else
                        {
                            log.Error($"Cannot detect the tv show for the file: {sourceFile}");

                        }
                    }
                }
            }
            Save();
        }

        private void CopyFile(string sourceFile, string targetPath, DataGridViewRow row)
        {            
            bool copy = false;
            var status = (StatusEnum)row.Cells["StatusColumn"].Value;
            bool updated = true;

            if (File.Exists(targetPath))
            {
                using (var msgBox = new FileExistDialog()
                        {
                            OriginalFilePath = sourceFile, TargetFilePath = targetPath
                        })
                {
                    switch (msgBox.ShowDialog())
                    {
                        case DialogResult.Yes: // Override
                            copy = true;
                            row.Cells["StatusColumn"].Value = StatusEnum.Synched;
                            break;
                        case DialogResult.Retry: // Skip but mark as synched
                            row.Cells["StatusColumn"].Value = StatusEnum.Synched;
                            break;
                        case DialogResult.No: //Skip and do not change the status
                        default:
                            updated = false;
                            break;
                    }
                }

                log.Debug($"Conflict with the target file: '{targetPath}' - Source : '{sourceFile}' - Copy: {copy} - New status: {status}");          
            }
            else //No conflicts
            {
                copy = true;
            }

            if (copy)
            {
                string directory = Path.GetDirectoryName(targetPath);
                CreateDirectory(new DirectoryInfo(directory));

                log.Info($"Copying from: '{sourceFile}' to '{targetPath}'");
                File.Copy(sourceFile, targetPath);
                log.Info("File copied");

            }
            if (updated)
            {
                row.Cells["DestinationFileColumn"].Value = targetPath;
                row.Cells["SynchDateColumn"].Value = DateTime.Now;
            }
        }

        public static void CreateDirectory(DirectoryInfo directory)
        {
            if (directory?.Parent == null)
                return;

            if (!directory.Parent.Exists)
                CreateDirectory(directory.Parent);
            directory.Create();
        }

        private void dataGridViewSynchronization_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {               
                int currentMouseOverRow = dataGridViewSynchronization.HitTest(e.X, e.Y).RowIndex;
                SelectedGridRow = -1;

                if (currentMouseOverRow >= 0)
                {
                    SelectedGridRow = currentMouseOverRow;
                    if (SelectedGridRow >= 0)
                    {
                        var selectedRowStatus = (StatusEnum)dataGridViewSynchronization["StatusColumn", SelectedGridRow].Value;

                        GridContextMenu.MenuItems.Clear();
                        if (selectedRowStatus != StatusEnum.Excluded)
                            GridContextMenu.MenuItems.Add(ExcludeMenuItem);
                        if (selectedRowStatus != StatusEnum.NotSynched)
                            GridContextMenu.MenuItems.Add(ResetStatusMenuItem);

                        int columnClickedIndex = dataGridViewSynchronization.HitTest(e.X, e.Y).ColumnIndex;
                        if (dataGridViewSynchronization.Columns[columnClickedIndex].Name == "SourceFileColumn" ||
                            dataGridViewSynchronization.Columns[columnClickedIndex].Name == "DestinationFileColumn")
                        {
                            ExploreMenuItem.Tag = (string)dataGridViewSynchronization[columnClickedIndex, currentMouseOverRow].Value; //The file path
                            GridContextMenu.MenuItems.Add(ExploreMenuItem);
                        }

                        GridContextMenu.Show(dataGridViewSynchronization, new Point(e.X, e.Y));
                    }
                    
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                var hit = dataGridViewSynchronization.HitTest(e.X, e.Y);
                if (hit.ColumnIndex >= 0 && hit.RowIndex >= 0)
                {
                    var cell = dataGridViewSynchronization[hit.ColumnIndex, hit.RowIndex];
                    if (cell.ValueType == typeof (bool))
                        cell.Value = !(bool) cell.Value;
                }
            }
        }

        public void FilterGrid()
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

            dataGridViewSynchronization.CurrentCell = null;
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if (row.Cells["StatusColumn"] != null && row.Cells["SourceFileColumn"] != null)
                {
                    var statusColumn = (StatusEnum) row.Cells["StatusColumn"].Value;
                    var sourceFile = (string) row.Cells["SourceFileColumn"].Value;
                    var sourceFileStillExist = (bool) row.Cells["SourceFileStillExistColumn"].Value;

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
                   || (cbExcluded.Checked && statusColumn == StatusEnum.Excluded);
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            FilterGrid();
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.ScrollToCaret();
        }

        private void cbSourceStillExist_CheckedChanged(object sender, EventArgs e)
        {
            FilterGrid();
        }
    }

    
}

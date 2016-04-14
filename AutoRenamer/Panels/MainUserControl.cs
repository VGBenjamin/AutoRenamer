using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;
using AutoRenamer.Tasks;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class MainUserControl : DockContent
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Synchronizer.Synchronizer _synchronizer = new Synchronizer.Synchronizer();        

        #region event FolderLoading
        public delegate void SynchRebindedEventHandler(object sender, EventArgs e);
        public event SynchRebindedEventHandler OnSynchRebinded;
        #endregion

        public int SelectedGridRow { get; set; }

        #region menu properties
        public ContextMenu GridContextMenu { get; set; }
        public MenuItem ExcludeMenuItem { get; set; }
        public MenuItem ResetStatusMenuItem { get; set; }
        public MenuItem ExploreSourceMenuItem { get; set; }
        public MenuItem ExploreDestinationMenuItem { get; set; }
        public MenuItem SynchronizeNow { get; set; }


        private Synchronization _currentSynchronization;
        public Synchronization CurrentSynchronization
        {
            get { return _currentSynchronization; }
            set
            {
                _currentSynchronization = value;
                dataGridViewSynchronization.DataSource = _currentSynchronization.StatusList;
            }
        }

        #endregion
        public DataGridView MainGrid => dataGridViewSynchronization;
        public TasksQueue Tasks { get; set; }

        public MainUserControl()
        {
            InitializeComponent();
            LoadGridContextMenu();
        }

        private void LoadGridContextMenu()
        {
            GridContextMenu = new ContextMenu();
            ExcludeMenuItem = new MenuItem("Exclude");
            ExcludeMenuItem.Click += ExcludeMenuItem_Click;
            ResetStatusMenuItem = new MenuItem("Reset status");
            ResetStatusMenuItem.Click += ResetStatusMenuItemOnClick;
            ExploreSourceMenuItem = new MenuItem("Explore source folder");
            ExploreDestinationMenuItem = new MenuItem("Explore destination folder");
            ExploreSourceMenuItem.Click += ExploreSourceMenuItem_Click;
            ExploreDestinationMenuItem.Click += ExploreDestinationMenuItem_Click;
            SynchronizeNow = new MenuItem("Synchronize this file now");
            SynchronizeNow.Click += SynchronizeNowOnClick;

            GridContextMenu.MenuItems.Clear();
            GridContextMenu.MenuItems.Add(SynchronizeNow);
            GridContextMenu.MenuItems.Add(ExcludeMenuItem);
            GridContextMenu.MenuItems.Add(ResetStatusMenuItem);
            GridContextMenu.MenuItems.Add(ExploreSourceMenuItem);
            GridContextMenu.MenuItems.Add(ExploreDestinationMenuItem);
        }

        #region click events

        private void ExcludeMenuItem_Click(object sender, EventArgs e)
        {
            ApplyOnSelectedRows((row) =>
            {
                SetRowStatus(row, StatusEnum.Excluded);
            });
        }
        private void ResetStatusMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            ApplyOnSelectedRows((row) =>
            {
                SetRowStatus(row, StatusEnum.NotSynched);
            });
        }

        private void ApplyOnSelectedRows(Action<DataGridViewRow> action)
        {
            foreach (DataGridViewRow selectedRow in GetSelectedRows())
            {
                action(selectedRow);
            }
        }

        private void SetRowStatus(DataGridViewRow selectedRow, StatusEnum newStatus)
        {
            var selectedCell = selectedRow?.Cells["StatusColumn"];
            if (selectedCell == null)
            {
                log.Error($"Cannot retreive the cell 'StatusColumn' from the row number: {selectedRow?.Index}");
            }
            else
            {
                selectedCell.Value = newStatus;
            }
        }

        private void ExploreSourceMenuItem_Click(object sender, EventArgs e)
        {
            Explore((statusDetail) => statusDetail.SourceFile);
        }

        private void ExploreDestinationMenuItem_Click(object sender, EventArgs e)
        {
            Explore((statusDetail) => statusDetail.DestinationFile);            
        }

        private void Explore(Func<StatusDetail, string> filePathFunc)
        {
            if (SelectedGridRow >= 0)
            {
                var row = (StatusDetail) dataGridViewSynchronization.Rows[SelectedGridRow]?.DataBoundItem;
                var filePath = filePathFunc(row);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("The selected file does not exist anymore", "File missing", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    Process.Start("explorer.exe", $"/select, {filePath}");
                }
            }
        }

        private void SynchronizeNowOnClick(object sender, EventArgs eventArgs)
        {
            ApplyOnSelectedRows((row) => SynchRow(row, Guid.NewGuid()));

        }

        private void SynchRow(DataGridViewRow dataGridViewRow, Guid batchId)
        {
            Tasks.AddTask(new RenameAndCopyTasks(batchId, (StatusDetail)dataGridViewRow.DataBoundItem));

            /*var statusDetail = (StatusDetail) dataGridViewRow.DataBoundItem;
            try
            {
                _synchronizer.Synch(statusDetail, batchId);
            }
            catch (Exception ex)
            {
                var msg = $"Unexpected error: {ex.Message}. Stack trace: {ex.StackTrace}";
                log.Error(msg);
                statusDetail.Reason = msg;
                statusDetail.Status = StatusEnum.Error;
            }
            dataGridViewSynchronization.Refresh();*/
        }

        private IEnumerable<DataGridViewRow> GetSelectedRows()
        {
            if (dataGridViewSynchronization.SelectedRows.Count > 0)
            {
                return from DataGridViewRow r in dataGridViewSynchronization.SelectedRows
                    select r;
            }
            else if (dataGridViewSynchronization.SelectedCells.Count > 0)
            {
                return from DataGridViewCell c in dataGridViewSynchronization.SelectedCells
                    select dataGridViewSynchronization.Rows[c.RowIndex];
            }
            else if (SelectedGridRow != -1)
            {
                return new List<DataGridViewRow>()
                {
                    dataGridViewSynchronization.Rows[SelectedGridRow]
                };
            }
            else
            {
                return new List<DataGridViewRow>();
            }
        }

        private void dataGridViewSynchronization_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewSynchronization.HitTest(e.X, e.Y).RowIndex;
                SelectedGridRow = -1;

                if (currentMouseOverRow >= 0 || dataGridViewSynchronization.SelectedRows.Count > 0)
                {
                    SelectedGridRow = currentMouseOverRow;
                    
                    //var selectedRowStatus = (StatusEnum)dataGridViewSynchronization["StatusColumn", SelectedGridRow].Value;

                    GridContextMenu.Show(dataGridViewSynchronization, new Point(e.X, e.Y));

                    ExploreSourceMenuItem.Visible = ExploreDestinationMenuItem.Visible = SelectedGridRow != -1;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                var hit = dataGridViewSynchronization.HitTest(e.X, e.Y);
                if (hit.ColumnIndex >= 0 && hit.RowIndex >= 0)
                {
                    var cell = dataGridViewSynchronization[hit.ColumnIndex, hit.RowIndex];
                    if (cell.ValueType == typeof(bool))
                        cell.Value = !(bool)cell.Value;
                }
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
            OnSynchRebinded?.Invoke(this, e);
        }

        private void btnSynchNow_Click(object sender, EventArgs e)
        {
            var batchId = Guid.NewGuid();
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if (row.Visible)
                {
                    var selectedCell = row.Cells["SelectColumn"];

                    if ((bool)selectedCell.Value)
                    {
                        SynchRow(row, batchId);
                    }
                }
            }

            CurrentSynchronization.Save();
            OnSynchRebinded?.Invoke(this, e);
        }
        #endregion

        private void dataGridViewSynchronization_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridViewColumn = dataGridViewSynchronization.Columns["StatusColumn"];
            if (dataGridViewColumn != null &&
                e.ColumnIndex == dataGridViewColumn.Index &&
                ((StatusDetail)dataGridViewSynchronization.Rows[e.RowIndex].DataBoundItem).Status == StatusEnum.Error)
            {
                var cell = dataGridViewSynchronization.Rows[e.RowIndex].Cells[e.ColumnIndex];               
                cell.ToolTipText = dataGridViewSynchronization.Rows[e.RowIndex].Cells["ReasonColumn"].Value.ToString();
            }
        }
    }
}

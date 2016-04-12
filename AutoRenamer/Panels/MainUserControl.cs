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
        public MenuItem ExploreMenuItem { get; set; }
        public MenuItem SynchronizeNow { get; set; }
        public Synchronization CurrentSynchronization { get; set; }

        #endregion
        public DataGridView MainGrid => dataGridViewSynchronization;

        public MainUserControl()
        {
            InitializeComponent();

        }

        private void LoadGridContextMenu()
        {
            GridContextMenu = new ContextMenu();
            ExcludeMenuItem = new MenuItem("Exclude");
            ExcludeMenuItem.Click += ExcludeMenuItem_Click;
            ResetStatusMenuItem = new MenuItem("Reset status");
            ResetStatusMenuItem.Click += ResetStatusMenuItemOnClick;
            ExploreMenuItem = new MenuItem("Explore");
            ExploreMenuItem.Click += ExploreMenuItem_Click;
            SynchronizeNow = new MenuItem("Synchronize this file now");
            SynchronizeNow.Click += SynchronizeNowOnClick;
        }

        #region click events

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

        private void ExploreMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = (string)ExploreMenuItem.Tag;
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The selected file does not exist anymore", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process.Start("explorer.exe", $"/select, {filePath}");
            }
        }

        private void SynchronizeNowOnClick(object sender, EventArgs eventArgs)
        {
            _synchronizer.Synch((StatusDetail)dataGridViewSynchronization.Rows[SelectedGridRow].DataBoundItem);
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
                        GridContextMenu.MenuItems.Add(SynchronizeNow);

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
            foreach (DataGridViewRow row in dataGridViewSynchronization.Rows)
            {
                if (row.Visible)
                {
                    var selectedCell = row.Cells["SelectColumn"];

                    if ((bool)selectedCell.Value)
                    {
                        _synchronizer.Synch((StatusDetail)row.DataBoundItem);
                    }
                }
            }

            CurrentSynchronization.Save();
        }
        #endregion

    }
}

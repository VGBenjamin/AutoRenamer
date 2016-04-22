using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;
using AutoRenamer.DataGridColumns;
using AutoRenamer.Tasks;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class QueueUserControl : DockContent
    {
        public ILog Log { get; set; }

        public TasksQueue Tasks { get; set; }

        private BindingSource _bindingSource;

        private bool _inPause = false;

        public QueueUserControl(TasksQueue tasksQueue)
        {
            Tasks = tasksQueue;

            InitializeComponent();

            //_bindingSource = new BindingSource();
            //_bindingSource.DataSource = Tasks.TasksList;

               
            dataGridViewQueue.AutoGenerateColumns = false;
            dataGridViewQueue.DataSource = Tasks.TasksList;

            Tasks.OnTaskAdded += TasksOnOnTaskAdded;            
        }

        private void TasksOnOnTaskAdded(object sender, TaskEventArgs taskEventArgs)
        {
            dataGridViewQueue.Refresh();
            btnPause.Enabled = true;

            taskEventArgs.Task.OnTaskFinished += TaskOnOnTaskFinished;
            taskEventArgs.Task.OnProgressChanged += Task_OnProgressChanged;
        }

        private void Task_OnProgressChanged(object sender, double percentage)
        {
            dataGridViewQueue.Refresh();
        }

        private void TaskOnOnTaskFinished(object sender, EventArgs eventArgs)
        {
            //_bindingSource.ResetBindings(false);
            dataGridViewQueue.Refresh();

            btnPause.Enabled = Tasks.TasksList.Any();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in dataGridViewQueue.SelectedCells)
            {
                Tasks.MoveUp(((ITask)dataGridViewQueue.Rows[selectedCell.RowIndex].DataBoundItem));                
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in dataGridViewQueue.SelectedCells)
            {
                Tasks.MoveDown(((ITask)dataGridViewQueue.Rows[selectedCell.RowIndex].DataBoundItem));
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _inPause = !_inPause;
            var currentTask = Tasks.TasksList.FirstOrDefault();
            if (currentTask != null)
            {
                currentTask.Paused = _inPause;
                this.btnPause.Image = _inPause ? Properties.Resources.Play : Properties.Resources.Pause;
            }
        }
    }
}

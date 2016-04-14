using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Objects.TasksQueue;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class QueueUserControl : DockContent
    {
        public ILog Log { get; set; }

        private TasksQueue Tasks { get; set; } = new TasksQueue();

        public QueueUserControl()
        {
            InitializeComponent();
            dataGridViewQueue.DataSource = Tasks.TasksList;

            Tasks.OnTaskAdded += TasksOnOnTaskAdded;            
        }

        private void TasksOnOnTaskAdded(object sender, TaskEventArgs taskEventArgs)
        {
            taskEventArgs.Task.OnTaskFinished += TaskOnOnTaskFinished;
            dataGridViewQueue.Refresh();
        }

        private void TaskOnOnTaskFinished(object sender, EventArgs eventArgs)
        {
            dataGridViewQueue.Refresh();
        }
    }
}

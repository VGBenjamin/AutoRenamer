using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;

namespace AutoRenamer.Tasks
{
    public class TasksQueueManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TasksQueue TasksQueue { get; set; }

        private readonly object _inProgressLock = new object();
        private bool _inProgress = false;

        public TasksQueueManager()
        {
            TasksQueue = new TasksQueue();
            TasksQueue.OnTaskAdded += TasksQueueOnOnTaskAdded;
        }

        private void TasksQueueOnOnTaskAdded(object sender, TaskEventArgs taskEventArgs)
        {
            if (!_inProgress)
            {
                lock (_inProgressLock)
                {
                    if (!_inProgress)
                    {
                        _inProgress = true;
                        StartThread(TasksQueue.GetNextTask());
                    }
                }                
            }            
        }
        
        private void StartThread(ITask task)
        {
            BackgroundWorker thread = new BackgroundWorker();
            thread.DoWork += ThreadOnDoWork;
            thread.RunWorkerCompleted += ThreadOnRunWorkerCompleted;
            thread.RunWorkerAsync(task);
        }

        private void ThreadOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            doWorkEventArgs.Result = ((ITask)doWorkEventArgs.Argument).Execute();
        }

        private void ThreadOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            TasksQueue.TasksList.Remove((ITask) runWorkerCompletedEventArgs.Result);
            if (TasksQueue.TasksList.Any())
            {
                StartThread(TasksQueue.GetNextTask());
            }
            else
            {
                lock (_inProgressLock) //We could have two thread launched at the smae time here
                {
                    _inProgress = false;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public class TaskEventArgs : System.EventArgs
    {
        public ITask Task { get; set; }

        public TaskEventArgs(ITask task)
        {
            Task = task;
        }
    }
}

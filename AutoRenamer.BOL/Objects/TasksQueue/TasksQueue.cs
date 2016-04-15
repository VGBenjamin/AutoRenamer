using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRenamer.BOL.Extensions;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public class TasksQueue
    {
        #region event OnTaskAdded
        public delegate void TaskAddedEventHandler(object sender, TaskEventArgs e);
        public event TaskAddedEventHandler OnTaskAdded;
        #endregion

        public BindingList<ITask> TasksList { get; private set; }

        public Guid TaskQueueId { get; private set; }

        public TasksQueue()
        {
            TasksList = new BindingList<ITask>();
            TaskQueueId = Guid.NewGuid();
        }

        public void AddTask(ITask statusDetail)
        {
            TasksList.Add(statusDetail);
            OnTaskAdded?.Invoke(this, new TaskEventArgs(statusDetail));
        }

        public ITask GetNextTask()
        {
            return TasksList.FirstOrDefault();
        }

        public void MoveUp(ITask task)
        {
            int index = TasksList.IndexOf(task);
            if (index < 0)
                throw new KeyNotFoundException($"The task Id: {task.TaskId} is not found in the task list");

            if (index > 0)
            {
                TasksList.Swap(index, index - 1);
            }
        }

        public void MoveDown(ITask task)
        {
            int index = TasksList.IndexOf(task);
            if (index < 0)
                throw new KeyNotFoundException($"The status detail Id: {task.TaskId} is not found in the task list");

            if (index < TasksList.Count - 1)
            {
                TasksList.Swap(index, index + 1);
            }
        }
    }
}

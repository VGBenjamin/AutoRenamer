using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public abstract class BaseTask : ITask
    {
        public event TaskFinishedEventHandler OnTaskFinished;
        public event ProgressChangedEventHandler OnProgressChanged;

        public Guid TaskId { get; set; }
        public Guid TaskBatchId { get; set; }
        public int ProgressionPercentage { get; set; }

        protected BaseTask(Guid taskBatchId)
        {
            TaskId = Guid.NewGuid();
            TaskBatchId = taskBatchId;
        }

        protected void IncrementProgress(int percentage)
        {
            ProgressionPercentage = percentage;
            OnProgressChanged?.Invoke(this, percentage);

            if (percentage == 100)
            {
                OnTaskFinished?.Invoke(this, System.EventArgs.Empty);
            }
        }

        public virtual ITask Execute()
        {
            OnTaskFinished?.Invoke(this, System.EventArgs.Empty);
            return this;
        }

        public bool Equals(ITask other)
        {
            return this.TaskId == other.TaskId;
        }
    }
}

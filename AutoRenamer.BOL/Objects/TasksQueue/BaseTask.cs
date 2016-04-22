using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public abstract class BaseTask : ITask
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event TaskFinishedEventHandler OnTaskFinished;
        public event ProgressChangedEventHandler OnProgressChanged;

        public Guid TaskId { get; set; }
        public Guid TaskBatchId { get; set; }
        public int ProgressionPercentage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Paused { get; set; }


        protected BaseTask(Guid taskBatchId, string title, string description)
        {
            TaskId = Guid.NewGuid();
            TaskBatchId = taskBatchId;
            Title = title;
            Description = description;
        }

        protected void IncrementProgress(int percentage)
        {
            log.Debug($"Task '{Title}' (Id: {TaskId}) - Progression: {ProgressionPercentage}");
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

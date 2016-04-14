using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public delegate void TaskFinishedEventHandler(object sender, System.EventArgs e);
    public delegate void ProgressChangedEventHandler(object sender, double percentage);

    public interface ITask : IEquatable<ITask>
    {
        Guid TaskId { get; set; }
        Guid TaskBatchId { get; set; }
        int ProgressionPercentage { get; set; }

        ITask Execute();

        
        event TaskFinishedEventHandler OnTaskFinished;
        event ProgressChangedEventHandler OnProgressChanged;
    }
}

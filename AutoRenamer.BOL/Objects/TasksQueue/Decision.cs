using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public class Decision : IDecision
    {
        public Guid BatchGuid { get; set; }
        public int Choice { get; set; }

        public Decision(Guid batchGuid, int choice)
        {
            BatchGuid = batchGuid;
            Choice = choice;
        }
    }
}

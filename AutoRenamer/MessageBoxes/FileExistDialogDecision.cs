using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRenamer.BOL.Objects.TasksQueue;

namespace AutoRenamer.MessageBoxes
{
    public class FileExistDialogDecision : Decision
    {
        public FileExistDialogDecision(Guid batchGuid, int choice) : base(batchGuid, choice)
        {
        }
    }
}

using System;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public interface IDecision       
    {
        Guid BatchGuid { get; set; }
        int Choice { get; set; }
    }
}
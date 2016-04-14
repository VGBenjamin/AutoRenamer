using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRenamer.BOL.Objects.TasksQueue
{
    public class DecisionManager
    {
        private List<IDecision> Decisions { get; set; } = new List<IDecision>();

        private DecisionManager()
        {
        }

        private static  DecisionManager _instance;
        public static DecisionManager Instance => _instance ?? (_instance = new DecisionManager());

        public TDecision GetDecision<TDecision>(Guid batchId)
        {
            return (TDecision) Decisions.FirstOrDefault(d => d.GetType() == typeof(TDecision) && d.BatchGuid == batchId);
        }

        public void SaveDecision<TDecision>(TDecision decision)
            where TDecision : IDecision
        {
            Decisions.RemoveAll(d => d.GetType() == decision.GetType() && d.BatchGuid == decision.BatchGuid);
            Decisions.Add(decision);
        }

        public void EndBatch(Guid batchId)
        {
            Decisions.RemoveAll(d => d.BatchGuid == batchId);
        }
    }
}

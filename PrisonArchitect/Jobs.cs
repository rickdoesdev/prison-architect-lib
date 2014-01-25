using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Job
    {
        public Id Id;
        public string Type; //MoveObject, OperateEquipment, InstallObject, ImproveCellIndoor, ImproveCellOutdoor, StoreObject, EscortPrisoner // DismantleObject? DumpObject?
        public Point Cell;
        public float FailureTimer;
        public int NumFails;
        public bool HighPriority;
        public Entity ObjectAssigned;
        public float WorkTimer;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat("BEGIN \"[i {0}]\"", Id.Internal);
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Jobs : List<Job>
    {
        public int Next;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN WorkQ");
            output.AppendLine();

            output.AppendFormat("Next {0}", Next);
            output.AppendLine();

            output.Append("BEGIN Items");
            foreach (var job in this)
            {
                output.Append(job.ToPrisonFormat());
            }
            output.Append("END");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
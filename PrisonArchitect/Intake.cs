using System.Text;

namespace PrisonArchitect
{
    public struct Intake
    {
        public float Next { get; set; }
        public int NumPrisoners { get; set; }
        public bool ReqMin { get; set; }
        public bool ReqNormal { get; set; }
        public bool ReqMax { get; set; }

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat("Intake.next {0}", Next);
            output.AppendLine();
            output.AppendFormat("Intake.numPrisonsers {0}", NumPrisoners);
            output.AppendLine();
            output.AppendFormat("Intake.reqMin {0}", ReqMin ? "true" : "false");
            output.AppendLine();
            output.AppendFormat("Intake.reqNormal {0}", ReqNormal ? "true" : "false");
            output.AppendLine();
            output.AppendFormat("Intake.reqMax {0}", ReqMax ? "true" : "false");
            output.AppendLine();
            return output.ToString();
        }
    }

    
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Research
    {
        public string Type;
        public bool Desired;
        public float Progress;
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Research");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
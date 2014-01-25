using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Grants : List<Grant>
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Grants");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Grant
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN ");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
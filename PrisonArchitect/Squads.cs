using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Squads : List<Squad>
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

    public class Squad
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
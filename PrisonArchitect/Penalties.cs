using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Penalty
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

    public class Penalties : List<Penalty>
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
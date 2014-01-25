using System.Text;

namespace PrisonArchitect
{
    public class Misconduct
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

    public class MisconductReport
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
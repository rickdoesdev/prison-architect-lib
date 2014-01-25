using System.Text;

namespace PrisonArchitect
{
    public class Regime
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.Append("BEGIN Regime");
            output.AppendLine();
            return output.ToString();
        }
    }
}
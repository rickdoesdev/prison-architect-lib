using System.Text;

namespace PrisonArchitect
{
    public class Visitation
    {
        public int Waiting;
        public float Timer;

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
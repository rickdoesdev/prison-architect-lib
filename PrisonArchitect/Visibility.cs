using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Visibility
    {
        public Point Position;
        public float Vis;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat("    BEGIN \"{0} {1}\" Vis {2} END", this.Position.X, this.Position.Y, this.Vis);
            output.Append("END");
            return output.ToString();
        }
    }
}
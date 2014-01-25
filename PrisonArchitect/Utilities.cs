using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Electricity
    {
        public Point Position;
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Electricity");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Water
    {
        public Point Position;
        public string Type;
        public float Wtr;
        public Vector2 Pressure;        

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Water");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
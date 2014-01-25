using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Finance
    {
        public float Balance;
        public int LastDay;
        public float SalePrice; // int?

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Finance");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class SupplyChain
    {
        public float Timer;
        public byte PreviousHour;
        public byte PreviousGarbage;
        public byte PreviousConsumables;
        public List<Order> Order;
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN SupplyChain");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public struct Order
    {
        public string Type;
        public int Quantity;
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Order");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
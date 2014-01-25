using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    // Top Left is 0,0
    public struct Point
    {
        public int X;
        public int Y;
    }
    
    public struct Vector2
    {
        public float X;
        public float Y;
    }

    // Each grid space on the map, the base layer (ground, water, foundations, etc)
    public class Cell
    {
        public Point Position;
        public string Material;
        public float Condition;
        public Room Room;
        public bool Indoors;
    }

    public class Cells : List<Cell>
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Cells\n");
            foreach (var cell in this)
            {
                output.AppendFormat("    BEGIN\"{0} {1}", cell.Position.X, cell.Position.Y);
                output.AppendLine();
                if (cell.Material != "Dirt")
                {
                    output.AppendFormat("Mat {0} ", cell.Material);
                }
                output.AppendFormat("Con {0} ", cell.Condition);
                if (cell.Indoors)
                {
                    output.Append("Ind true ");
                }
                if (cell.Room != null)
                {
                    output.AppendFormat("Room.i {0} Room.u {1} ", cell.Room.Id.Internal, cell.Room.Id.Unique);
                }
                output.Append("END");
                output.AppendLine();
            }
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }

        public static Cells LoadFromPrisonFormat(string block)
        {
            var cells = new Cells();
            return cells;
        }
    }
}

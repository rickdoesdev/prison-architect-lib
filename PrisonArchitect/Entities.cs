using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Entity
    {
        public Id Id;
        public string Type;
        public int SubType;
        public Vector2 Position;
        public Vector2 Or; //? Object Rotation perhaps?
        public Room Room; // Office, Cell, ?

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.AppendFormat("BEGIN \"[i {0}]\"", Id.Internal);
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    // Objects includes staff, prisoners, doors, and all other random objects
    public class Objects : List<Entity>
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.Append("BEGIN Objects");
            output.AppendLine();
            output.AppendFormat("Size {0}", this.Count);
            output.AppendLine();
            foreach (var entity in this)
            {
                output.Append(entity.ToPrisonFormat());
            }
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }


    public class Container : Entity
    {
        public string Contents;
        public int Quantity;
    }

    public class Door : Entity
    {
        public float SectorTimer;
        public Point OpenDir;
    }

    public class Person : Entity
    {
        public Vector2 Vel;
        public Point Dest;        
        public float Energy;
        public float Timer;
        public string[] Equipment; //Clipboard, Leash, Needle, Baton ... Guns/Knives/Spoons/Forks?
    }

    // Is this needed ??
    public class Staff : Person
    {
    }
}

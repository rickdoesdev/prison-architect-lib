using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Patrol
    {
        public Point Cell;
        public bool Set;
        public float Visit;
        public Entity LastVisitor;

        public string ToPrisonFormat()
        {
            // BEGIN "67 119"     Set true  Visit 62954.6  LastVisitor.i 568  LastVisitor.u 77829  END
            var output = new StringBuilder();
            output.AppendFormat("BEGIN \"{0} {1}\"", Cell.X, Cell.Y);
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Patrols : List<Patrol>
    {
        public PatrolStations Stations;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Patrols");
            output.AppendLine();
            foreach (var pat in this)
            {
                output.Append(pat.ToPrisonFormat());
            }
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class PatrolStation
    {
        public Point Pos;
        public float LastVisit;
        public string EntityType;
        public Entity Visitor;

        public string ToPrisonFormat()
        {
            //BEGIN i          Pos.x 19  Pos.y 83  LastVisit 62985.3  EntityType Guard  Visitor.i 833  Visitor.u 526300  END
            var output = new StringBuilder("BEGIN i");
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class PatrolStations : List<PatrolStation>
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Stations");
            output.AppendLine();
            foreach (var station in this)
            {
                output.Append(station.ToPrisonFormat());
            }
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }


}
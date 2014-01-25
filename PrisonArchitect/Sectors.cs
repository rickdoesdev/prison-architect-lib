using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class SectorStation 
    {
        public Entity Entity;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            output.AppendLine();



            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
    public class SectorStations : List<SectorStation> 
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN stations");
            output.AppendLine();

            output.AppendFormat("Size {0}", this.Count);
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

    public class Sector
    {
        public int id;
        public Point TopLeft;
        public Point BottomRight;
        public Vector2 Centre;
        public bool Indoor;
        public int NumSquares;
        public string Zone; // StaffOnly, Unlocked, MinSecOnly, MedSecOnly, MaxSecOnly, Shared?

        public SectorStations stations;
        public SectorJobs jobs;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN []");
            output.AppendLine();



            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Sectors : List <Sector>
    {
        public int NextSectorId;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Sectors");
            output.AppendLine();

            output.AppendFormat("NextSectorId {0}", NextSectorId);
            output.AppendLine();

            // Yes this gets output again
            output.Append("BEGIN Sectors");
            output.AppendLine();

            output.AppendFormat("Size {0}", this.Count);
            output.AppendLine();

            foreach (var sector in this)
            {
                output.Append(sector.ToPrisonFormat());
            }

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class SectorJob
    {
        public int Id;
        public Entity Entity;
        public float LastOccupied;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();

            output.AppendFormat("BEGIN \"[i {0}]\"", Id);
            if (Entity != null)
            {
                output.AppendFormat("Entity.i {0} Entity.u", Entity.Id.Internal, Entity.Id.Unique);
            }
            else
            {
                output.AppendFormat("Entity.i {0} Entity.u", -1, -1);
            }
            output.AppendFormat("LastOccupied {0}", LastOccupied);
            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class SectorJobs : List<SectorJob>
    {
    }

}
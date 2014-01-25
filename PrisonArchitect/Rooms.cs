using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Room
    {
        public Id Id;
        public Entity Entity;
        public string RoomType;
        public string Name;
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

    public class Rooms : List<Room>
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Rooms");
            output.AppendLine();

            output.AppendFormat("Size {0}", this.Count);
            output.AppendLine();

            foreach (var room in this)
            {
                output.Append(room.ToPrisonFormat());
            }

            return output.ToString();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Contraband
    {
        public float Timer;
        public int ObjectIndex;
        public List<Prisoner> Prisoners;

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN ");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }

    public class Tracker
    {
        public string ItemType;
        public Vector2 FoundPos;
        public string State;
        public float BirthTime;
        public float FoundTime;
        public Prisoner Prisoner;
        public float PrisonerChance;
        public Room FromRoom;
        public List<LogEntry> Log;
    }

    public class LogEntry
    {
        public string Type; //Smuggled, Stolen, Position, Hidden, Detected, Dog, Found,
        public float  Time;
        public bool Confirmed;
        public Vector2 Pos;

    }
}
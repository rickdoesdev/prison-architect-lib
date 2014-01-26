using System.Collections.Generic;

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
        public List<Entity> Slots; // I might need to make a Slot class, but I think that the only things that can be "slot"ed are Entities anyway..
        
        // Are we carrying something or someone?
        public bool Loaded;
        public Entity Carrier;

        // Are we a structure that holds a thing? I think this only happens for dogcrates at this point.
        public int Occupied; // I've seen 4 and 5, not sure what that corresponds too
        public Entity Occupant;
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

    // Is this Necessary?
    public class Staff : Person
    {
    }

    public class Electrical : Entity
    {
        public bool Powered;
        public bool On;
        public bool ExternalPower;
    }

    public class Light : Electrical
    {
        public Light()
        {
            Type = "Light";
        }
    }

    public class OutdoorLight : Light
    {
        public OutdoorLight()
        {
            Powered = true;
            On = true;
            ExternalPower = true;
        }
    }

    public class Vehicle : Entity
    {
        public float Speed;
    }
}

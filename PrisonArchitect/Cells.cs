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

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    // Each grid space on the map, the base layer (ground, water, foundations, etc)
    public class Cell
    {
        public Point Position;
        public string Material = "";  // empty is dirt
        public float Condition;
        public Room Room = null;
        public bool Indoors = false;
    }
}

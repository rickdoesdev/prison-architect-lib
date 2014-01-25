using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Tunnels : List<Tunnel>
    {
        public List<Digger> Diggers;
        
        public string ToPrisonFormat()
        {
            return "";
        }
    }

    public class Tunnel
    {
        public Point Position;
        public float Dug;


        public string ToPrisonFormat()
        {
            return "";
        }
    }

    public class Digger
    {
        public string ToPrisonFormat()
        {
            return "";
        }
    }
}
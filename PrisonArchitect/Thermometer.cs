using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Thermometer
    {
        public float Desired; //-17.0384  
        public float RateOfChange; //-0.340769  
        public float HappyPrisoners; //19.0000  
        public float UnhappyPrisoners; //7.00000  
        public float WellFedPrisoners; //5.00000  
        public float SuppressedPrisoners; //8.00000  
        public float RecentDeaths; //1.26677e-042  
        public float RecentPunishments; //1.76324  
        public float RecentSearches; //3.74919

        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN ");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonArchitect
{
    public class Construction
    {
        public string ToPrisonFormat()
        {
            var output = new StringBuilder("BEGIN Construction");
            output.AppendLine();

            output.Append("END");
            output.AppendLine();
            return output.ToString();
        }
    }


    public class ConstructionJob
    {
        public string ToPrisonFormat()
        {
        //BEGIN "[i 0]"      
        //    Type                 Foundations  
        //    Material             1  
        //    PosX                 47  
        //    PosY                 35  
        //    SizeX                6  
        //    SizeY                3  
        //    Status               2  
        //    Hidden               true  
        //    Counter              11  
        //    Counter3             -1  
        //    Timer                144.486  
        //    Speed                60.0000  
        //    BEGIN "[i 0]"      x 47  y 35  END
        //    BEGIN "[i 1]"      x 47  y 36  END
        //    BEGIN "[i 2]"      x 47  y 37  END
        //    BEGIN "[i 3]"      x 48  y 35  END
        //    BEGIN "[i 4]"      x 48  y 36  END
        //    BEGIN "[i 5]"      x 48  y 37  END
        //    BEGIN "[i 6]"      x 49  y 35  END
        //    BEGIN "[i 7]"      x 49  y 36  END
        //    BEGIN "[i 8]"      x 49  y 37  END
        //    BEGIN "[i 9]"      x 50  y 35  END
        //    BEGIN "[i 10]"     x 50  y 36  END
        //    BEGIN "[i 11]"     x 50  y 37  END
        //    BEGIN "[i 12]"     x 51  y 35  END
        //    BEGIN "[i 13]"     x 51  y 36  END
        //    BEGIN "[i 14]"     x 51  y 37  END
        //    BEGIN "[i 15]"     x 52  y 35  END
        //    BEGIN "[i 16]"     x 52  y 36  END
        //    BEGIN "[i 17]"     x 52  y 37  END
        //END
            return "";
        }
    }

    public class ConstructionJobs : List<ConstructionJob>
    {        
        public string ToPrisonFormat()
        {
            //BEGIN Jobs       Size 0 END
            // or
            //BEGIN Jobs       
            //  Size {0} 
            //  ...
            //END
            return "";
        }
    }


    //Size doesn't seem to correspond ??

    //BEGIN PlanningJobs Size 8000  END    

    //BEGIN PlanningJobs 
    //    Size                 12000  
    //    BEGIN Job        x 7  y 18  Mode Wall  END
    //    BEGIN Job        x 7  y 19  Mode Wall  END
    //    BEGIN Job        x 7  y 20  Mode Wall  END
    //    BEGIN Job        x 7  y 21  Mode Wall  END
    //    BEGIN Job        x 7  y 22  Mode Wall  END
    //    BEGIN Job        x 7  y 23  Mode Wall  END
    //    BEGIN Job        x 7  y 24  Mode Wall  END
    //    BEGIN Job        x 7  y 25  Mode Wall  END
    //    BEGIN Job        x 7  y 26  Mode Wall  END
    //    BEGIN Job        x 7  y 27  Mode Wall  END
    //    BEGIN Job        x 7  y 28  Mode Wall  END
    //    BEGIN Job        x 7  y 29  Mode Wall  END
    //    BEGIN Job        x 7  y 30  Mode Wall  END
    //    BEGIN Job        x 7  y 31  Mode Wall  END
    //    BEGIN Job        x 7  y 32  Mode Wall  END
    //    BEGIN Job        x 7  y 33  Mode Wall  END
    //    BEGIN Job        x 7  y 34  Mode Wall  END
    //    BEGIN Job        x 7  y 35  Mode Wall  END
    //    BEGIN Job        x 7  y 36  Mode Wall  END
    //    BEGIN Job        x 7  y 37  Mode Wall  END
    //    BEGIN Job        x 7  y 38  Mode Wall  END
    //    BEGIN Job        x 7  y 39  Mode Wall  END
    //    BEGIN Job        x 7  y 40  Mode Wall  END
    //    BEGIN Job        x 7  y 41  Mode Wall  END
    //    BEGIN Job        x 7  y 42  Mode Wall  END
    //    BEGIN Job        x 7  y 43  Mode Wall  END
    //    BEGIN Job        x 7  y 44  Mode Wall  END
    //    BEGIN Job        x 7  y 45  Mode Wall  END
    //    BEGIN Job        x 7  y 46  Mode Wall  END
    //    BEGIN Job        x 7  y 47  Mode Wall  END
    //    BEGIN Job        x 7  y 48  Mode Wall  END
    //    BEGIN Job        x 7  y 49  Mode Wall  END
    //    BEGIN Job        x 7  y 50  Mode Wall  END
    //    BEGIN Job        x 7  y 51  Mode Wall  END
    //    BEGIN Job        x 7  y 52  Mode Wall  END
    //    BEGIN Job        x 7  y 53  Mode Wall  END
    //    BEGIN Job        x 7  y 54  Mode Wall  END
    //    BEGIN Job        x 8  y 18  Mode Wall  END
    //    BEGIN Job        x 8  y 52  Mode Wall  END
    //    BEGIN Job        x 9  y 18  Mode Wall  END
    //    BEGIN Job        x 9  y 52  Mode Wall  END
    //    BEGIN Job        x 10  y 18  Mode Wall  END
    //    BEGIN Job        x 10  y 52  Mode Wall  END
    //    BEGIN Job        x 10  y 96  Mode Wall  END
    //    BEGIN Job        x 10  y 99  Mode Wall  END
    //    BEGIN Job        x 10  y 102  Mode Wall  END
    //    BEGIN Job        x 10  y 105  Mode Wall  END
    //    BEGIN Job        x 10  y 108  Mode Wall  END
    //    BEGIN Job        x 10  y 111  Mode Wall  END
    //    BEGIN Job        x 10  y 114  Mode Wall  END
    //    BEGIN Job        x 11  y 18  Mode Wall  END
    //    BEGIN Job        x 11  y 52  Mode Wall  END
    //    BEGIN Job        x 12  y 18  Mode Wall  END
    //    BEGIN Job        x 12  y 52  Mode Wall  END
    //    BEGIN Job        x 13  y 18  Mode Wall  END
    //    BEGIN Job        x 13  y 52  Mode Wall  END
    //    BEGIN Job        x 14  y 18  Mode Wall  END
    //    BEGIN Job        x 14  y 52  Mode Wall  END
    //    BEGIN Job        x 14  y 88  Mode Wall  END
    //    BEGIN Job        x 15  y 18  Mode Wall  END
    //    BEGIN Job        x 15  y 52  Mode Wall  END
    //    BEGIN Job        x 16  y 18  Mode Wall  END
    //    BEGIN Job        x 16  y 52  Mode Wall  END
    //    BEGIN Job        x 17  y 18  Mode Wall  END
    //    BEGIN Job        x 17  y 52  Mode Wall  END
    //    BEGIN Job        x 18  y 18  Mode Wall  END
    //    BEGIN Job        x 18  y 52  Mode Wall  END
    //    BEGIN Job        x 18  y 105  Mode Wall  END
    //    BEGIN Job        x 18  y 108  Mode Wall  END
    //    BEGIN Job        x 18  y 111  Mode Wall  END
    //    BEGIN Job        x 18  y 114  Mode Wall  END
    //    BEGIN Job        x 19  y 18  Mode Wall  END
    //    BEGIN Job        x 19  y 52  Mode Wall  END
    //    BEGIN Job        x 20  y 18  Mode Wall  END
    //    BEGIN Job        x 20  y 52  Mode Wall  END
    //    BEGIN Job        x 21  y 18  Mode Wall  END
    //    BEGIN Job        x 21  y 52  Mode Wall  END
    //    BEGIN Job        x 22  y 18  Mode Wall  END
    //    BEGIN Job        x 22  y 52  Mode Wall  END
    //    BEGIN Job        x 23  y 18  Mode Wall  END
    //    BEGIN Job        x 23  y 52  Mode Wall  END
    //    BEGIN Job        x 24  y 18  Mode Wall  END
    //    BEGIN Job        x 24  y 52  Mode Wall  END
    //    BEGIN Job        x 25  y 18  Mode Wall  END
    //    BEGIN Job        x 25  y 52  Mode Wall  END
    //    BEGIN Job        x 26  y 18  Mode Wall  END
    //    BEGIN Job        x 26  y 52  Mode Wall  END
    //    BEGIN Job        x 27  y 18  Mode Wall  END
    //    BEGIN Job        x 27  y 52  Mode Wall  END
    //    BEGIN Job        x 28  y 18  Mode Wall  END
    //    BEGIN Job        x 28  y 52  Mode Wall  END
    //    BEGIN Job        x 29  y 18  Mode Wall  END
    //    BEGIN Job        x 29  y 52  Mode Wall  END
    //    BEGIN Job        x 30  y 18  Mode Wall  END
    //    BEGIN Job        x 30  y 52  Mode Wall  END
    //    BEGIN Job        x 31  y 18  Mode Wall  END
    //    BEGIN Job        x 31  y 52  Mode Wall  END
    //    BEGIN Job        x 32  y 18  Mode Wall  END
    //    BEGIN Job        x 32  y 52  Mode Wall  END
    //    BEGIN Job        x 33  y 18  Mode Wall  END
    //    BEGIN Job        x 33  y 52  Mode Wall  END
    //    BEGIN Job        x 34  y 18  Mode Wall  END
    //    BEGIN Job        x 34  y 52  Mode Wall  END
    //    BEGIN Job        x 35  y 18  Mode Wall  END
    //    BEGIN Job        x 35  y 19  Mode Wall  END
    //    BEGIN Job        x 35  y 20  Mode Wall  END
    //    BEGIN Job        x 35  y 21  Mode Wall  END
    //    BEGIN Job        x 35  y 22  Mode Wall  END
    //    BEGIN Job        x 35  y 23  Mode Wall  END
    //    BEGIN Job        x 35  y 24  Mode Wall  END
    //    BEGIN Job        x 35  y 25  Mode Wall  END
    //    BEGIN Job        x 35  y 26  Mode Wall  END
    //    BEGIN Job        x 35  y 27  Mode Wall  END
    //    BEGIN Job        x 35  y 28  Mode Wall  END
    //    BEGIN Job        x 35  y 29  Mode Wall  END
    //    BEGIN Job        x 35  y 30  Mode Wall  END
    //    BEGIN Job        x 35  y 31  Mode Wall  END
    //    BEGIN Job        x 35  y 32  Mode Wall  END
    //    BEGIN Job        x 35  y 33  Mode Wall  END
    //    BEGIN Job        x 35  y 34  Mode Wall  END
    //    BEGIN Job        x 35  y 35  Mode Wall  END
    //    BEGIN Job        x 35  y 36  Mode Wall  END
    //    BEGIN Job        x 35  y 37  Mode Wall  END
    //    BEGIN Job        x 35  y 38  Mode Wall  END
    //    BEGIN Job        x 35  y 39  Mode Wall  END
    //    BEGIN Job        x 35  y 40  Mode Wall  END
    //    BEGIN Job        x 35  y 41  Mode Wall  END
    //    BEGIN Job        x 35  y 42  Mode Wall  END
    //    BEGIN Job        x 35  y 43  Mode Wall  END
    //    BEGIN Job        x 35  y 44  Mode Wall  END
    //    BEGIN Job        x 35  y 45  Mode Wall  END
    //    BEGIN Job        x 35  y 46  Mode Wall  END
    //    BEGIN Job        x 35  y 47  Mode Wall  END
    //    BEGIN Job        x 35  y 48  Mode Wall  END
    //    BEGIN Job        x 35  y 49  Mode Wall  END
    //    BEGIN Job        x 35  y 50  Mode Wall  END
    //    BEGIN Job        x 35  y 51  Mode Wall  END
    //    BEGIN Job        x 35  y 52  Mode Wall  END
    //    BEGIN Job        x 44  y 61  Mode Wall  END
    //END

    public class Planning
    {
        public string ToPrisonFormat()
        {
            return "";
        }
    }
}
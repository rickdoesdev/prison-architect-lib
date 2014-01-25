using System.Collections.Generic;

namespace PrisonArchitect
{
    // Prisoner Stuff
    public class Prisoner : Person
    {
        public string Forname;//              Richard
        public string Surname;//              Elison
        public float Age;//                  34.0000
        public int BodyType;//             3
        public float BodyScale;//            0.928746
        public string HeadType;//             Head7         
        public List<string> Traits;    // Violent, RisksLife, Destructive, Theft, Clever
        public int Sentence; // 26            
        public float Served; //               15.3451  
        public int Parole; //          16  
        public int SkinColour;//  0x7b4413ff  ;
        public Bio Bio;
        public List<StatusEffect> StatusEffects;
        public List<Need> Needs;
    }

    public class Bio
    {
        public List<Conviction> Convictions;
        public List<FamilyMember> Family;
    }


    public class Conviction
    {
        public string Crime;
        public int Sentence;
        public bool Plea;
        public bool Guilty;
    }
    
    public class StatusEffect
    {
        public string Type;
        public float Charge;
    }
    
    public class Need
    {
        public Id Id;
        public string Type;
        public float ActionPoint;
        public float TimeToAction;
        public float TimeToFailure;
        public float Charge;
    }

    public class FamilyMember
    {
        public string Type; // ExWife
        public float Age; // 24.9000
        public string BodyType; // FemaleBody
        public string HeadType; // FaceWife
        public float BodyScale; // 1.03586
        public int SkinColour; //0xd1995dff
        public int ClothingColour; //0xf684caff
    }    
}

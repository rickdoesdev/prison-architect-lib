using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PrisonArchitect
{
    // Alpha 16
    public class Prison
    {
        public string Version { get; set; }

        public short NumCellsX { get; set; }

        public short NumCellsY { get; set; }

        public short OriginX { get; set; }

        public short OriginY { get; set; }

        public short OriginW { get; set; }

        public short OriginH { get; set; }

        public float TimeIndex { get; set; }

        public int RandomSeed { get; set; }

        public int ObjectIdNext { get; set; }

        public bool EnabledElectricity { get; set; }

        public bool EnabledWater { get; set; }

        public bool EnabledFood { get; set; }

        public bool EnabledMisconduct { get; set; }

        public bool EnabledDecay { get; set; }

        public bool EnabledVisibility { get; set; }

        public bool GenerateForests { get; set; }

        public bool GenerateLakes { get; set; }

        public bool ObjectsCentreAligned { get; set; }

        public short FoodQuantity { get; set; }

        public short FoodVariation { get; set; }

        public int BioVersions { get; set; }

        public Intake Intake;

        public Cells Cells = new Cells();
        public Objects Objects;
        public Rooms Rooms;
        public Jobs WorkQ;
        public Regime Regime;
        public SupplyChain SupplyChain;
        public Finance Finance;
        public Patrols Patrols;
        public Electricity Electricity;
        public Water Water;
        public Research Research;
        public Construction Construction;
        public Penalties Penalties;
        public Sectors Sectors;
        public Grants Grants  = new Grants();
        public Misconduct Misconduct;
        public Visitation Visitation;
        public Thermometer Thermometer;
        public Squads Squads;
        public Contraband Contraband;
        public Tunnels Tunnels;
        public List<Visibility> Visibility;

        public Prison()
        {
            ObjectsCentreAligned = true;
            GenerateLakes = true;
            GenerateForests = true;
            EnabledVisibility = true;
            EnabledDecay = true;
            EnabledMisconduct = true;
            EnabledFood = true;
            EnabledWater = true;
            EnabledElectricity = true;
        }

        

        public Prison Load()
        {
            var begincount = 0;
            var sections = new List<string>();
            var block = "";

            // load basic info
            
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (var sr = new StreamReader("D:/Dropbox/games/Prison Architect/saves/grantededit.prison"))
            {
                string line;
                // Read from the file until the end of the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();                    
                    if (line == string.Empty)
                    {
                        continue;
                    }

                    var parts = new List<string>(line.Split(' '));                    

                    parts.RemoveAll(str => string.IsNullOrEmpty(str));

                    if (parts[0] == "BEGIN")
                    {
                        if (begincount == 0)
                        {
                            block = parts[1];
                        }
                        begincount++;
                        if(parts[1].StartsWith('"'.ToString())) {
                            sections.Add(parts[1] + " " + parts[2]);
                        } else {
                            sections.Add(parts[1]);
                        }
                    }

                    if (block == "Cells")
                    {
                        // We're looking at nested begins, which are cells
                        if (begincount > 1)
                        {
                            var cell = new Cell
                            {
                                Position =
                                {
                                    X = int.Parse(parts[1].Trim(new char[] {'"'})),
                                    Y = int.Parse(parts[2].Trim(new char[] {'"'}))
                                }
                            };

                            var matindex = parts.IndexOf("Mat");
                            var conindex = parts.IndexOf("Con");
                            var indindex = parts.IndexOf("Ind");

                            if(matindex > 0 ) {
                                cell.Material = parts[matindex + 1];
                            }
                            if (conindex > 0)
                            {
                                cell.Condition = float.Parse(parts[conindex + 1]);
                            }
                            if (indindex > 0)
                            {
                                cell.Indoors = parts[indindex + 1] == "true" ? true : false;
                            }
                            
                            this.Cells.Add(cell);
                        }
                    }
                    
                    if (parts[0] == "END" || parts[parts.Count-1] == "END") {
                        begincount--;
                        if (begincount == 0)
                        {
                            block = "";
                        }
                        sections.RemoveAt(sections.Count-1);
                    }


                }
            }
            System.Console.Write(this.Cells.Count);
            System.Console.ReadLine(); 
            return this;
        }

        public string ToPrisonFormat()
        {
            var output = new StringBuilder();
            
            output.AppendFormat("Version {0}", Version);
            output.AppendLine();
            output.AppendFormat("NumCellsX {0}", NumCellsX);
            output.AppendLine();
            output.AppendFormat("NumCellsY {0}", NumCellsY);
            output.AppendLine();
            output.AppendFormat("OriginX {0}", OriginX);
            output.AppendLine();
            output.AppendFormat("OriginY {0}", OriginY);
            output.AppendLine();
            output.AppendFormat("OriginW {0}", OriginW);
            output.AppendLine();
            output.AppendFormat("OriginH {0}", OriginH);
            output.AppendLine();
            output.AppendFormat("TimeIndex {0}", TimeIndex);
            output.AppendLine();
            output.AppendFormat("RandomSeed {0}", RandomSeed);
            output.AppendLine();
            output.AppendFormat("ObjectId.next {0}", ObjectIdNext);
            output.AppendLine();
            output.AppendFormat("EnabledElectricity {0}", EnabledElectricity);
            output.AppendLine();
            output.AppendFormat("EnabledWater {0}", EnabledWater);
            output.AppendLine();
            output.AppendFormat("EnabledFood {0}", EnabledFood);
            output.AppendLine();
            output.AppendFormat("EnabledMisconduct {0}", EnabledMisconduct);
            output.AppendLine();
            output.AppendFormat("EnabledDecay {0}", EnabledDecay);
            output.AppendLine();
            output.AppendFormat("EnabledVisibility {0}", EnabledVisibility);
            output.AppendLine();
            output.AppendFormat("GenerateForests {0}", GenerateForests);
            output.AppendLine();
            output.AppendFormat("GenerateLakes {0}", GenerateLakes);
            output.AppendLine();
            output.AppendFormat("ObjectsCentreAligned {0}", ObjectsCentreAligned);
            output.AppendLine();
            output.AppendFormat("FoodQuantity {0}", FoodQuantity);
            output.AppendLine();
            output.AppendFormat("FoodVariation {0}", FoodVariation);
            output.AppendLine();
            output.AppendFormat("BioVersions {0}", BioVersions);
            output.AppendLine();

            output.Append(Intake.ToPrisonFormat());
            output.Append(Cells.ToPrisonFormat());
            output.Append(Objects.ToPrisonFormat());
            output.Append(Rooms.ToPrisonFormat());
            output.Append(WorkQ.ToPrisonFormat());
            output.Append(Regime.ToPrisonFormat());
            output.Append(SupplyChain.ToPrisonFormat());
            output.Append(Finance.ToPrisonFormat());
            output.Append(Patrols.ToPrisonFormat());
            output.Append(Electricity.ToPrisonFormat());
            output.Append(Water.ToPrisonFormat());
            output.Append(Research.ToPrisonFormat());
            output.Append(Construction.ToPrisonFormat());
            output.Append(Penalties.ToPrisonFormat());
            output.Append(Sectors.ToPrisonFormat());
            output.Append(Grants.ToPrisonFormat());
            output.Append(Misconduct.ToPrisonFormat());
            output.Append(Visitation.ToPrisonFormat());
            output.Append(Thermometer.ToPrisonFormat());
            output.Append(Squads.ToPrisonFormat());
            output.Append(Contraband.ToPrisonFormat());
            output.Append(Tunnels.ToPrisonFormat());

            output.Append("BEGIN Visibility");
            output.AppendLine();
            foreach (var vis in Visibility)
            {
                output.Append(vis.ToPrisonFormat());
            }
            output.Append("END");
            output.AppendLine();

            return output.ToString();
        }

    }

    // Contains both an internal ID within a list of items, and an unique global ID
    public struct Id
    {
        public int Internal;
        public int Unique;
    }


}

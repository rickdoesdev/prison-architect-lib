using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrisonArchitect.File
{
    public class Parser
    {
        private string _fileName;
        private StreamReader _streamReader;
        private Prison _prison;

        public Parser(string file)
        {
            if (file == null)
            {
                throw new ArgumentNullException();
            }
            _fileName = file;
            _prison = new Prison();
            Parse();
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        protected void Parse()
        {
            Console.WriteLine("Loading Prison File: " + _fileName);
            _streamReader = new StreamReader(_fileName);
            
            Console.WriteLine("Parsing Prison File.");

            string line;
            bool header = true;

            var blocklevel = 0;
            var currentBlock = new List<string>();
            string currentblocktype = "";
            // Read from the file until the end of the file is reached.
            while ((line = _streamReader.ReadLine()) != null)
            {

                line = line.Trim();
                if (line == string.Empty)
                {
                    continue;
                }
                
                // Once we hit our first BEGIN segment we're out of the header
                if (line.StartsWith("BEGIN") && header)
                {
                    header = false;
                }

                var parts = SplitLine(line);

                if (header)
                {
                    ParseHeaderLine(parts);
                }
                else
                {
                    if (line.StartsWith("BEGIN"))
                    {
                        if (blocklevel == 0)
                        {
                            currentblocktype = parts[1];
                        }
                        blocklevel++;
                    }
                    // Process the individual sections of the file
                    currentBlock.Add(line);
                    if (line.Contains("END"))
                    {
                        blocklevel--;
                    }
                    if (blocklevel == 0)
                    {
                        ParseBlock(currentblocktype, currentBlock);
                        currentblocktype = "";
                        currentBlock = new List<string>();
                    }
                }
            }
            
            Console.WriteLine("Parsing Completed.");
            _streamReader.Close();
        }

        private static List<string> SplitLine(string line)
        {
            var parts = new List<string>(line.Split(' '));
            parts.RemoveAll(str => string.IsNullOrEmpty(str));
            return parts;
        }

        private void ParseHeaderLine(List<string> parts)
        {
            string key = parts[0];
            string value = parts[1];
            if (_prison.HasProperty(key))
            {
                _prison.SetProperty(key, value);
                Console.WriteLine("Set property: " + key + ": " + value);
            }
            else
            {
                if (key.StartsWith("Intake"))
                {
                    var intake = key.Split('.');
                    _prison.Intake.SetProperty(intake[1].UcFirst(), value);
                    return;
                }

                if (key.StartsWith("ObjectId"))
                {
                    string[] k = key.Split('.');
                    string k2 = "" + k[0] + k[1].UcFirst();
                    _prison.SetProperty(k2, value);
                    return;
                }   

                Console.WriteLine("Unknown property: " + key + ": " + value);
            }
        }

        private bool ParseBlock(string type, List<string> block)
        {
            switch (type)
            {
                case "Cells":
                    return ParseCells(block);
                case "Objects":
                    return ParseObjects(block);
                case "Rooms":
                    return ParseRooms(block);
                case "Regime":
                    return ParseRegime(block);
                case "SupplyChain":
                    return ParseSupplyChain(block);
                case "Finance":
                    return ParseFinance(block);
                case "Electricity":
                    return ParseElectricity(block);
                case "Water":
                    return ParseWater(block);
                case "Research":
                    return ParseResearch(block);
                case "Construction":
                    return ParseConstruction(block);
                case "Penalties":
                    return ParsePenalties(block);
                case "Sectors":
                    return ParseSectors(block);
                case "Grants":
                    return ParseGrants(block);
                case "Misconduct":
                    return ParseMisconduct(block);
                case "Visitation":
                    return ParseVisitation(block);
                case "Thermometer":
                    return ParseThermometer(block);
                case "Squads":
                    return ParseSquads(block);
                case "Contraband":
                    return ParseContraband(block);
                case "Tunnels":
                    return ParseTunnels(block);
                case "Visibility":
                    return ParseVisibility(block);
                default:
                    return false;
            }
        }

        private bool ParseCells(IEnumerable<string> block)
        {
            var cells = new Cells();

            foreach (var line in block)
            {
                if (line.StartsWith("BEGIN Cells"))
                {
                    continue;
                }
                if (line.StartsWith("END"))
                {
                    continue;
                }

                var parts = SplitLine(line);
                Cell cell = new Cell();
                
                cell.Position.X = int.Parse(parts[1].Trim(new char[] {'"'}));
                cell.Position.Y = int.Parse(parts[2].Trim(new char[] {'"'}));

                var matindex = parts.IndexOf("Mat");
                var conindex = parts.IndexOf("Con");
                var indindex = parts.IndexOf("Ind");

                if (matindex > 0)
                {
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
                cells.Add(cell);
            }
            if (cells.Count > 0)
            {
                _prison.Cells = cells;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ParseObjects(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseRooms(List<string> block)
        {
            throw new NotImplementedException();
        }


        private static bool ParseRegime(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseSupplyChain(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseFinance(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseElectricity(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseWater(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseResearch(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseConstruction(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParsePenalties(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseSectors(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseGrants(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseMisconduct(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseVisitation(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseThermometer(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseSquads(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseContraband(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseTunnels(List<string> block)
        {
            throw new NotImplementedException();
        }

        private static bool ParseVisibility(List<string> block)
        {
            throw new NotImplementedException();
        }
    }
}
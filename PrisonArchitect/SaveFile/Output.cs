using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PrisonArchitect.SaveFile
{
    public class Output
    {
        private readonly Prison _prison;
        private readonly TextWriter _file;
        private string _filename;

        public Output(Prison prison, string file)
        {
            
            if (file == null || prison == null)
            {
                throw new ArgumentNullException();
            }
            _prison = prison;
            _filename = file;
            using (_file = System.IO.File.CreateText(_filename))
            {
                Serialize(_file);
            }
        }
        
        void Serialize(TextWriter writer)
        {
            OutputHeader();
            OutputCells();
            OutputObjects();
            OutputRooms();
            //OutputWorkQ();
            //OutputRegime();
            //OutputSupplyChain();
        }

        private void OutputHeader()
        {
           _file.Write("Version            {0}", _prison.Version);
            _file.WriteLine();
           _file.Write("NumCellsX            {0}", _prison.NumCellsX);
            _file.WriteLine();
           _file.Write("NumCellsY            {0}", _prison.NumCellsY);
            _file.WriteLine();
           _file.Write("OriginX            {0}", _prison.OriginX);
            _file.WriteLine();
           _file.Write("OriginY            {0}", _prison.OriginY);
            _file.WriteLine();
           _file.Write("OriginW            {0}", _prison.OriginW);
            _file.WriteLine();
           _file.Write("OriginH            {0}", _prison.OriginH);
            _file.WriteLine();
           _file.Write("TimeIndex            {0}", _prison.TimeIndex);
            _file.WriteLine();
           _file.Write("RandomSeed            {0}", _prison.RandomSeed);
            _file.WriteLine();
           _file.Write("ObjectId.next            {0}", _prison.ObjectIdNext);
            _file.WriteLine();
           _file.Write("EnabledElectricity            {0}", _prison.EnabledElectricity.ToString().ToLower());
            _file.WriteLine();
            _file.Write("EnabledWater            {0}", _prison.EnabledWater.ToString().ToLower());
            _file.WriteLine();
            _file.Write("EnabledFood            {0}", _prison.EnabledFood.ToString().ToLower());
            _file.WriteLine();
            _file.Write("EnabledMisconduct            {0}", _prison.EnabledMisconduct.ToString().ToLower());
            _file.WriteLine();
            _file.Write("EnabledDecay            {0}", _prison.EnabledDecay.ToString().ToLower());
            _file.WriteLine();
            _file.Write("EnabledVisibility            {0}", _prison.EnabledVisibility.ToString().ToLower());
            _file.WriteLine();
            _file.Write("GenerateForests            {0}", _prison.GenerateForests.ToString().ToLower());
            _file.WriteLine();
            _file.Write("GenerateLakes            {0}", _prison.GenerateLakes.ToString().ToLower());
            _file.WriteLine();
            _file.Write("ObjectsCentreAligned            {0}", _prison.ObjectsCentreAligned.ToString().ToLower());
            _file.WriteLine();
           _file.Write("FoodQuantity            {0}", _prison.FoodQuantity);
            _file.WriteLine();
           _file.Write("FoodVariation            {0}", _prison.FoodVariation);
            _file.WriteLine();
           _file.Write("BioVersions            {0}", _prison.BioVersions);
            _file.WriteLine();
           _file.Write("Intake.next            {0}", _prison.Intake.Next);
            _file.WriteLine();
           _file.Write("Intake.numPrisoners            {0}", _prison.Intake.NumPrisoners);
            _file.WriteLine();
           _file.Write("Intake.reqMin            {0}", _prison.Intake.ReqMin);
            _file.WriteLine();
           _file.Write("Intake.reqNormal            {0}", _prison.Intake.ReqNormal);
            _file.WriteLine();
           _file.Write("Intake.reqMax            {0}", _prison.Intake.ReqMax);
            _file.WriteLine();
        }

        private void OutputCells()
        {
            _file.Write("BEGIN Cells");
            _file.WriteLine();

            foreach (var cell in _prison.Cells)
            {
                _file.Write("    BEGIN \"{0} {1}\" ", cell.Position.X, cell.Position.Y);

                if (cell.Material != string.Empty)
                {
                    _file.Write("Mat {0} ", cell.Material);
                }

                _file.Write("Con {0} ", cell.Condition.ToString("0.0000"));

                if (cell.Indoors)
                {
                    _file.Write("Ind true ");
                }
                
                if (cell.Room != null)
                {
                    _file.Write("Room.i {0} Room.u {1} ", cell.Room.Id.Internal, cell.Room.Id.Unique);
                }

                _file.Write("END");
                _file.WriteLine();
            }

            _file.Write("END");
            _file.WriteLine();
        }

        private void OutputObjects()
        {
            _file.Write("BEGIN Objects");
            _file.WriteLine();
            _file.Write("    Size                 {0}", _prison.Objects.Count);
            _file.WriteLine();
            if (_prison.Objects.Count > 0)
            {
                foreach (var obj in _prison.Objects)
                {
                    _file.Write("    BEGIN \"[i {0}]\"      ", obj.Id.Internal);
                    _file.Write("Id.i {0} Id.u {1} ", obj.Id.Internal, obj.Id.Unique);
                    _file.Write("Type {0} ", obj.Type);
                    _file.Write("SubType {0} ", obj.SubType);

                    if (obj.GetType() == typeof (Electrical))
                    {
                        _file.Write("Powered {0} ", ((Electrical) obj).Powered);
                        _file.Write("On {0} ", ((Electrical) obj).On);
                        _file.Write("ExternalPower {0} ", ((Electrical) obj).ExternalPower);
                    }

                    if (obj.GetType() == typeof (Staff))
                    {
                        if (!((Staff) obj).Vel.Equals(default(Vector2)))
                        {
                            _file.Write("Vel.x {0} ", ((Staff) obj).Vel.X);
                            _file.Write("Vel.y {0} ", ((Staff)obj).Vel.Y);
                        }

                        if (!((Staff)obj).Dest.Equals(default(Point)))
                        {
                            _file.Write("Dest.x {0} ", ((Staff)obj).Dest.X);
                            _file.Write("Dest.y {0} ", ((Staff)obj).Dest.Y);
                        }

                        if (!((Staff)obj).Energy.Equals(default(float)))
                        {
                            _file.Write("Energy {0} ", ((Staff)obj).Energy);
                        }
                        if (!((Staff)obj).Timer.Equals(default(float)))
                        {
                            _file.Write("Timer {0} ", ((Staff)obj).Timer);
                        }

                        if (((Staff)obj).Equipment != null && ((Staff)obj).Equipment.Length > 0)
                        {
                            _file.Write("Equipment {0} ", ((Staff)obj).Equipment.ToString());
                        }
                    }


                    if (!obj.Position.Equals(default(Vector2)))
                    {
                        _file.Write("Pos.x {0} ", obj.Position.X);
                        _file.Write("Pos.y {0} ", obj.Position.Y);
                    }

                    if (!obj.Or.Equals(default(Vector2)))
                    {
                        _file.Write("Or.x {0} ", obj.Or.X);
                        _file.Write("Or.y {0} ", obj.Or.Y);
                    }

                    if (obj.Room != null)
                    {
                        _file.Write("Room.i {0} ", obj.Room.Id.Internal);
                        _file.Write("Room.u {0} ", obj.Room.Id.Unique);
                    }

                    if (obj.Slots != null && obj.Slots.Count > 0)
                    {
                                //Slot0.i              101  
                                //Slot0.u              103 
                        var i = 0;
                        foreach (var slot in obj.Slots)
                        {
                            _file.Write("        Slot{0}.i {1}  ", i, slot.Id.Internal);
                            _file.WriteLine();
                            _file.Write("        Slot{0}.u {1}  ", i, slot.Id.Unique);
                            _file.WriteLine();
                            i++;
                        }
                    }

                    if (obj.Loaded)
                    {
                        // Loaded true  CarrierId.i 317  CarrierId.u 23159
                        _file.Write("Loaded true  CarrierId.i {0}  CarrierId.u {1}  ", obj.Carrier.Id.Internal, obj.Carrier.Id.Unique);
                    }

                    if (obj.Occupied > 0)
                    {
                        // Slot0.i 866  Slot0.u 620008  Occupied 5  Occupier.i 866  Occupier.u 620008
                        // Seems to only be on dog crates?
                    }

                    //public List<Slot> Slots;


                    _file.Write("END");
                    _file.WriteLine();
                }
            }
            _file.Write("END");
            _file.WriteLine();
        }

        private void OutputRooms()
        {
            _file.Write("BEGIN Rooms");
            _file.WriteLine();
            _file.Write("    Size                 {0}", _prison.Rooms.Count);
            _file.WriteLine();
            if (_prison.Rooms.Count > 0)
            {
                foreach (var room in _prison.Rooms)
                {
                    //BEGIN "[i 0]"      Id.i 0  Id.u 90  RoomType Deliveries  END
                    _file.Write("    BEGIN \"[i {0}]\"      ", room.Id.Internal);
                    _file.Write("Id.i {0} Id.u {1} ", room.Id.Internal, room.Id.Unique);
                    _file.Write("RoomType {0} ", room.RoomType);
                    _file.Write("END");
                    _file.WriteLine();
                }
            }
            _file.Write("END");
            _file.WriteLine();
        }

        private void OutputWorkQ()
        {
            throw new NotImplementedException();
        }

        private void OutputRegime()
        {
            throw new NotImplementedException();
        }

        private void OutputSupplyChain()
        {
            throw new NotImplementedException();
        }

        private void OutputFinance()
        {
            throw new NotImplementedException();
        }

        private void OutputElectricity()
        {
            throw new NotImplementedException();
        }

        private void OutputWater()
        {
            throw new NotImplementedException();
        }

        private void OutputResearch()
        {
            throw new NotImplementedException();
        }

        private void OutputConstruction()
        {
            throw new NotImplementedException();
        }

        private void OutputPenalties()
        {
            throw new NotImplementedException();
        }

        private void OutputSectors()
        {
            throw new NotImplementedException();
        }

        private void OutputGrants()
        {
            throw new NotImplementedException();
        }

        private void OutputMisconduct()
        {
            throw new NotImplementedException();
        }

        private void OutputVisitation()
        {
            throw new NotImplementedException();
        }

        private void OutputThermometer()
        {
            throw new NotImplementedException();
        }

        private void OutputSquads()
        {
            throw new NotImplementedException();
        }

        private void OutputContraband()
        {
            throw new NotImplementedException();
        }

        private void OutputTunnels()
        {
            throw new NotImplementedException();
        }

        private void OutputVisibility()
        {
            throw new NotImplementedException();
        }
    }
}
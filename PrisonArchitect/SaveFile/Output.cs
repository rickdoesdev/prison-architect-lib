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
        public string FileName { get; set; }
        private readonly StringBuilder _output = new StringBuilder();

        public Output(Prison prison, string file)
        {
            
            if (file == null || prison == null)
            {
                throw new ArgumentNullException();
            }
            _prison = prison;
            FileName = file;
            using (_file = System.IO.File.CreateText(FileName))
            {
                Serialize(_file);
            }
        }
        
        void Serialize(TextWriter writer)
        {
            OutputHeader();
            OutputCells();
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
           _file.Write("EnabledElectricity            {0}", _prison.EnabledElectricity);
            _file.WriteLine();
           _file.Write("EnabledWater            {0}", _prison.EnabledWater);
            _file.WriteLine();
           _file.Write("EnabledFood            {0}", _prison.EnabledFood);
            _file.WriteLine();
           _file.Write("EnabledMisconduct            {0}", _prison.EnabledMisconduct);
            _file.WriteLine();
           _file.Write("EnabledDecay            {0}", _prison.EnabledDecay);
            _file.WriteLine();
           _file.Write("EnabledVisibility            {0}", _prison.EnabledVisibility);
            _file.WriteLine();
           _file.Write("GenerateForests            {0}", _prison.GenerateForests);
            _file.WriteLine();
           _file.Write("GenerateLakes            {0}", _prison.GenerateLakes);
            _file.WriteLine();
           _file.Write("ObjectsCentreAligned            {0}", _prison.ObjectsCentreAligned);
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

                _file.Write("Con {0} ", cell.Condition);

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
            _file.Write("    Size                 0");
            _file.Write("END");
            _file.WriteLine();
        }

        private void OutputRooms()
        {

            _file.Write("BEGIN Rooms");
            _file.WriteLine();
            _file.Write("    Size                 0");
            _file.Write("END");
            _file.WriteLine();
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
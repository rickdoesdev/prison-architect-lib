using System;
using System.Collections.Generic;

namespace PrisonArchitect
{
    // Alpha 16
    public class Prison
    {
        public string Version { get; set; }

        // Current Width of the Prison Map
        public short NumCellsX { get; set; }

        // Current Height of the Prison Map
        public short NumCellsY { get; set; }

        //Original TopX before any land extensions
        public short OriginX { get; set; }
        
        //Original TopY before any land extensions
        public short OriginY { get; set; }

        // Starting Width of the Prison Map, before any land extensions
        public short OriginW { get; set; }

        // Starting Height of the Prison Map, before any land extensions
        public short OriginH { get; set; }

        // Current Time in the game 0 is 12AM Day 1 480 is 8AM Day 1
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

        public Intake Intake = new Intake();

        public List<Cell> Cells;
        public List<Entity> Objects = new List<Entity>();
        public List<Room> Rooms;
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
        public Grants Grants = new Grants();
        public Misconduct Misconduct;
        public Visitation Visitation;
        public Thermometer Thermometer;
        public Squads Squads;
        public Contraband Contraband;
        public Tunnels Tunnels;
        public List<Visibility> Visibility;

        private const int RoadWidth = 5;
        private int _sectionWidth;
        private int _rightSidePadding;
        private int _roadLeftX;
        private int _roadRightX;
        private int _roadMiddleX;
        private readonly Random _rng;

        public Prison(short w, short h)
        {
            // Defaults, small prison
            Version = "alpha-16";
            NumCellsX = w;
            NumCellsY = h;
            OriginX = 0;
            OriginY = 0;
            OriginW = w;
            OriginH = h;
            TimeIndex = 480.0f; // 8AM Day 1
            RandomSeed = new Random().Next(0, 150000); // Anything much higher than 150000 causes really horrible blocky terrain and it's incredibly ugly.
            ObjectIdNext = 0;
            EnabledElectricity = true;
            EnabledWater = true;
            EnabledFood = true;
            EnabledMisconduct = true;
            EnabledDecay = true;
            EnabledVisibility = true;
            GenerateLakes = false;
            GenerateForests = true;
            ObjectsCentreAligned = true;
            BioVersions = 4;
            Intake.Next = 1919.00f;
            Intake.NumPrisoners = 8;

            _rng = new Random(RandomSeed);
        }

        public Prison() : this(100, 80)
        {
        }

        public void Generate()
        {
            InitialiseCells();
            PrettifyTerrain();
            PlaceRoad();
            PlaceLights();
            PlaceStartingRooms();
            QueueDeliveryTruck();
        }


        public void InitialiseCells()
        {
            Cells = new List<Cell>();

            for (var x = 0; x < NumCellsX; x++)
            {
                for (var y = 0; y < NumCellsY; y++)
                {
                    var cell = new Cell
                    {
                        // Every square is dirt!
                        Condition = 0.0f,
                        Position = new Point {X = x, Y = y},
                    };
                    // Except the borders which tend to be PavingStone
                    if (x == 0 || x == NumCellsX - 1 || y == 0 || y == NumCellsY - 1)
                    {
                        cell.Material = "PavingStone";
                    }

                    Cells.Add(cell);
                }
            }
        }

        public void PrettifyTerrain()
        {
            // Magic  procedural logic to build islands, grass patches, lakes, etc.
            // Condition = (float) _rng.NextDouble()*100,

            foreach (var cell in Cells)
            {
                //cell.Condition = (float) _rng.NextDouble()*100;
                var mat = "";
                switch (_rng.Next(0, 4))
                {
                    case 0:
                        break;
                    case 1:
                        //mat = "Grass";
                        break;
                    case 2:
                        //mat = "Sand";
                        break;
                    case 3:
                        //mat = "PavingStone";
                        break;
                }
                cell.Material = mat;
            }
        }

        // Given a material, build a nice patch of it.
        public void BuildPatch(string material)
        {
            // Pick a point on the map
            // build out a blob
            // add/substract points from blob
            // etc
        }

        public void PlaceRoad()
        {
            _sectionWidth = 1 + RoadWidth + 1; // Concrete barriers
            _rightSidePadding = 4;

            _roadLeftX = NumCellsX - (_sectionWidth + _rightSidePadding) - 1; // 100 - (7 + 5= 12) - 1 = 87
            // Subtract 1 from sectionWidth because we need to include leftX as the starting point
            _roadRightX = _roadLeftX + (_sectionWidth - 1);                         // 88 + (7 - 1) = 94

            _roadMiddleX = _roadLeftX + (int)Math.Round((float)_sectionWidth/2)-1; // 87 + (7/2 = Round(3.5)=4) = 91

            foreach (var cell in Cells)
            {
                // Set Road
                if (cell.Position.X >= _roadLeftX && cell.Position.X <= _roadRightX)      // 87 to 94
                {
                    cell.Condition = 0.0f;
                }

                if (cell.Position.X == _roadLeftX || cell.Position.X == _roadRightX)      // 87 || 94
                {
                    cell.Material = "ConcreteTiles";
                }

                if (cell.Position.X > _roadLeftX && cell.Position.X < _roadRightX)        // 88 to 93
                {
                    cell.Material = "Road";
                }

                if (cell.Position.X == _roadMiddleX && (cell.Position.Y % 2 == 0))    // 91
                {
                    cell.Material = "RoadMarkings";
                }

                if (cell.Position.X == _roadLeftX + 1)                               // 82
                {
                    cell.Material = "RoadMarkingsLeft";
                }

                if (cell.Position.X == _roadRightX - 1 )                             // 93
                {
                    cell.Material = "RoadMarkingsRight";
                }
                // End of Road
            }
        }

        // @todo Make these honour the height of the map
        public void PlaceLights()
        {
            var leftX = _roadLeftX + .5f;
            var rightX = _roadRightX + .5f;

            var i = 0;
            var j = 0;
            while (i < NumCellsY)
            {
                var x = (j % 2 == 0) ? leftX : rightX;
                var y = i +.5f;

                AddObjectToPrison(new OutdoorLight
                {
                    Position = new Vector2(x, y)
                });
                i += 10;
                j++;
            }

            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(rightX, 10.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(leftX, 20.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(rightX, 30.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(leftX, 40.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(rightX, 50.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(leftX, 60.5f)
            //});
            //AddObjectToPrison(new OutdoorLight
            //{
            //    Position = new Vector2(rightX, 70.5f)
            //});
        }

        public void PlaceStartingRooms()
        {
            var deliveries = new Room
            {
                RoomType = "Deliveries"
            };

            var garbage = new Room
            {
                RoomType = "Garbage"
            };

            const int roomHeight = 8;
            const int roomWidth = 5;

            var leftX = _roadLeftX - roomWidth;

            var midpoint = (int) Math.Round((float) NumCellsY/2) - 1;

            var deliveryY = midpoint - roomHeight - 1;
            var garbageY = midpoint + 2;

            for (var x = leftX; x < _roadLeftX; x++)
            {
                for (var y = deliveryY; y < deliveryY + roomHeight; y++)
                {
                    var cell = GetCellAt(x, y);
                    cell.Room = deliveries;
                }
                for (var y = garbageY; y < garbageY + roomHeight; y++)
                {
                    var cell = GetCellAt(x, y);
                    cell.Room = garbage;
                }
            }

            AddRoomToPrison(deliveries);

            AddRoomToPrison(garbage);
        }

        public void QueueDeliveryTruck()
        {
            // add the initial truck that brings in the Workers
            var truck = new Vehicle
            {
                Type = "SupplyTruck",
                Position = new Vector2(_roadMiddleX - 1, 0),
                Speed = 2f,
                Slots = new  List<Entity>() // Give it an inventory. trucks can carry people, items, etc
            };

            // Tell the prison about our  truck
            AddObjectToPrison(truck);

            // Create workers
            for (var i = 0; i < 8; i++)
            {
                var worker = new Staff
                {
                    Type = "Workman",
                    SubType = _rng.Next(0, 4), // I've only seen values 0 - 3 in the save file. Need to play with this and see what happens with changes.
                    Loaded = true,
                    Carrier = truck,
                    Position = new Vector2(truck.Position.X - (i % 2), truck.Position.Y),
                    Energy = Math.Min(70f, (float)_rng.NextDouble() * 100) // Make sure they're not exhausted on arrival
                };
                
                // Put this worker into the prison object queue
                AddObjectToPrison(worker);

                // Put workers into truck as luggage
                truck.Slots.Add(worker);
            }
        }

        protected void AddObjectToPrison(Entity item)
        {
            if (item == null) return;
            if (Objects == null) Objects = new List<Entity>();
            item.Id.Internal = Objects.Count;
            item.Id.Unique = ObjectIdNext++;
            Objects.Add(item);
        }

        protected void AddRoomToPrison(Room room)
        {
            if (room == null) return;
            if (Rooms == null) Rooms = new List<Room>();
            room.Id.Internal = Rooms.Count;
            room.Id.Unique = ObjectIdNext++;
            Rooms.Add(room);
        }

        public Cell GetCellAt(int x, int y)
        {

            var index = x * NumCellsY  + y;
            return Cells[index];
        }
    }
    // Contains both an internal ID within a list of items, and an unique global ID
    public struct Id
    {
        public int Internal;
        public int Unique;
    }
}

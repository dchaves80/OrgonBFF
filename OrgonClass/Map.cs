using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgonClass
{
    public class Map
    {
        List<List<Room>> RoomsList = null;

        public List<List<Room>> Rooms
        {
            get { return RoomsList; }
        }
        
        //make a function that accepts a Coordinate and thrws adyacent rooms
        



        public Map(long width, long height, int numberOfIslands, long IslandsSize)
        {

            Console.WriteLine("Generando Mapas");

            RoomsList = new List<List<Room>>();
            for (int h = 0; h < height; h++)
            {
                var row = new List<Room>();
                RoomsList.Add(row);
                for (int w = 0; w < width; w++)
                {
                    
                    row.Add(new Room(new Coordinates(w, h)));
                    
                }
            }

            for (long countIslands = 0; countIslands < numberOfIslands; countIslands++) {         
            int coordRandX = new Random().Next(0, int.Parse((width-1).ToString()));
            int coordRandY = new Random().Next(0, int.Parse((height-1).ToString()));
                Room R = RoomsList[coordRandY][coordRandX];
                R.RoomType = 'G';
                //store in a variable IslandsSize
                long IslandsSizeTemp = IslandsSize;
                //make a random algorithm that add 0 to 20% to IslandsSizeTemp
                IslandsSizeTemp += new Random().Next(0, int.Parse((IslandsSizeTemp * 0.2).ToString().Split('.')[0]));
                R.GeneratorLife = IslandsSizeTemp;
            }


            //Select only rooms with type G
            var GroundSeeds = RoomsList.SelectMany(x => x).Where(x => x.RoomType == 'G').ToList();
            foreach (Room R in GroundSeeds) 
            {
                GrowIslands(R,R.GeneratorLife,'░');
            }

            //Select only G type rooms
            var GroundRooms = RoomsList.SelectMany(x => x).Where(x => x.RoomType == '░').ToList();

            //Select 5 random G type rooms from GroundRooms
            var GroundRoomsRandom = GroundRooms.OrderBy(x => Guid.NewGuid()).Take(numberOfIslands).ToList();
            //Get 20% of IslandsSize
            long ForrestSizeTemp = int.Parse((IslandsSize * 0.5).ToString().Split('.')[0]);
            

            foreach (Room R in GroundRoomsRandom)
            {
                GrowIslands(R, ForrestSizeTemp, '¥');
            }

            //Select only F type rooms
            var ForrestRooms = RoomsList.SelectMany(x => x).Where(x => x.RoomType == '¥').ToList();

            //Select 5 random F type rooms from ForrestRooms

            var ForrestRoomsRandom = ForrestRooms.OrderBy(x => Guid.NewGuid()).Take(numberOfIslands).ToList();

            //Get 20% of IslandsSize
            long MountainSizeTemp = Convert.ToInt64((IslandsSize * 0.2).ToString().Split('.')[0]);

            foreach (Room R in ForrestRoomsRandom)
            {
                GrowIslands(R, MountainSizeTemp, '^');
            }

            //Select only ░ type rooms
            var Gorund = RoomsList.SelectMany(x => x).Where(x => x.RoomType == '░').ToList();


            foreach (Room R in Gorund)
            {
                GenerateBorder(R, new char[] { '~' }, '▒');
            }

            List<Room> MountainSea = SelectRoomsOfType('^');

            foreach (Room R in MountainSea)
            {
                GenerateBorder(R, new char[] { '~' },'|');
            }

            List<Room> ForrestSea = SelectRoomsOfType('¥');

            foreach (Room R in ForrestSea)
            {
                GenerateBorder(R, new char[] { '~' }, '▒');
            }


            Console.WriteLine("Mapa Generado con exito...");

            //generate a path in a string variable pattern: c:\Maps\map+(gui)+.map
            string path = "c:\\Maps\\map" + Guid.NewGuid().ToString() + ".map";
            //generate a file with the path
            System.IO.File.Create(path).Close();
            


            foreach (List<Room> lr in RoomsList)
            {
                string line = string.Empty;
                
                foreach (Room r in lr)
                {
                    Console.Write(r.RoomType);
                    line += r.RoomType;
                }
                File.AppendAllText(path, line + Environment.NewLine);
                
                Console.WriteLine();
            }


        }

        private void GenerateBorder(Room R, char[] borderTypes, char newChar)
        {
            //get adyacent rooms
            List<Room> adyacentRooms = GetAdyacentsRooms(R);
            //for each adyacent room
            foreach (Room adyacentRoom in adyacentRooms)
            {
                //if the room is not a border
                if (borderTypes.Contains(adyacentRoom.RoomType))
                {
                    //set the room as a border
                    R.RoomType = newChar;
                    break;
                }
            }
        }

        private List<Room> GetAdyacentsRooms(Room R, char avoidCharacter='0') 
        {
            List<Room> AdyacentsRooms = new List<Room>();
            //get the coordinates of the room
            Coordinates C = R.Coordinates;
            //get the x and y of the coordinates
            long x = C.X;
            long y = C.Y;
            //get the map
            List<List<Room>> map = RoomsList;
            //get the height and width of the map
            long height = map.Count-1;
            long width = map[0].Count-1;
            //check if the room is in the top of the map
            if (x >0)
            {
                if (map[(int)y][(int)x - 1].RoomType!=avoidCharacter) AdyacentsRooms.Add(map[(int)y][(int)x - 1]);
            }
            //check if the room is in the bottom of the map
            if (x < width)
            {
                //if it is, add the room below to the list
                if (map[(int)y][(int)x + 1].RoomType != avoidCharacter) AdyacentsRooms.Add(map[(int)y][(int)x+ 1]);
            }
            //check if the room is in the left of the map
            if (y > 0)
            {
                //if it is, add the room to the left to the list
                if (map[(int)y-1][(int)x].RoomType != avoidCharacter) AdyacentsRooms.Add(map[(int)y - 1][(int)x]);
            }
            //check if the room is in the right of the map
            if (y < height)
            {
                //if it is, add the room to the right to the list
                if (map[(int)y+1][(int)x].RoomType != avoidCharacter) AdyacentsRooms.Add(map[(int)y + 1][(int)x]);
            }
            //return the list
            return AdyacentsRooms;
        }

        private void GrowIslands(Room R, long generatorLife, char character)
        {
            if (generatorLife > 0)
            {
                R.GeneratorLife = 0;

                var randomValue = new Random().Next(1, 4);

                long newLife = generatorLife;

                if (randomValue == 1) { newLife = generatorLife - 1; }
                else if (randomValue == 2) { newLife = generatorLife - 3; }
                else if (randomValue == 3) { newLife = generatorLife + 1; }


                List<Room> AdyacentsRooms = GetAdyacentsRooms(R,character);
                foreach (Room AR in AdyacentsRooms)
                {
                    AR.RoomType = character;
                    AR.GeneratorLife = newLife;
                    GrowIslands(AR, newLife,character);
                }
            }
            else 
            {
                R.GeneratorLife = 0;
            }
        }

        private List<Room> SelectRoomsOfType(char RoomType) 
        {
            List<Room> trl = RoomsList.SelectMany(x => x).Where(x => x.RoomType == RoomType).ToList();
            return trl;
        }


    }
}

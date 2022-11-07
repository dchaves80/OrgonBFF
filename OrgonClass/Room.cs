using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgonClass
{
    public class Room
    {
        char roomType;
        Coordinates coordinates = null;
        long generatorLife = 0;

        //GENERATE A CONSTRUCTOR THAT ACCEPTS A CHAR AS ROOMTYPE

        public Room(Coordinates coordinates, char Type = '~') 
        {
            this.roomType = Type;
            this.coordinates = coordinates;
        }

        /// <summary>
        /// Clase ROOMTYPE
        /// </summary>
        public char RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        //generate get and setters for coords   
        public Coordinates Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        public long GeneratorLife
        {
            get { return generatorLife; }
            set { generatorLife = value; }
        }

        

    }
}

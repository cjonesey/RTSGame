using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class RTSGameMap
    {
        private byte[,] rtsMap;
        private Coords startLocation;
        private Coords endLocation;
        private int mapSize;

        public enum RTSGameMapOccupied: byte
        {
            False = 0,
            True = 1
        }
        public RTSGameMap(int mapSize)
        {
            rtsMap = new byte[mapSize, mapSize];
            startLocation = new Coords(0, 0); //Set the start location = row 0 / column 0
            endLocation = new Coords(mapSize-1, mapSize -1); //Set the end location column/row
            this.mapSize = mapSize;
        }

        public byte[,] RTSMap
        {
            get
            {
                return rtsMap;
            }
            set
            {
                rtsMap = value;
            }
        }

        public Coords StartLocation
        {
            get
            {
                return startLocation;
            }
            set
            {
                startLocation = value;
            }
        }
        public Coords EndLocation
        {
            get
            {
                return endLocation;
            }
            set
            {
                endLocation = value;
            }
        }

        public int MapSize
        {
            get
            {
                return mapSize;
            }
            set
            {
                mapSize = value;
            }

        }

        public List<Coords> GetAdjacent(int x, int y)
        {
            //Find the location in the RTS Game Map to see if occupied
            List<Coords> neighbours = new List<Coords>();
            var locn = rtsMap[x, y];
            if (x < (this.mapSize - 1))
                neighbours.Add(new Coords { x = (x + 1), y = y });
            if (x > 0)
                neighbours.Add(new Coords { x = (x - 1), y = y });
            if (y < (this.mapSize - 1))
                neighbours.Add(new Coords { x = x, y = (y + 1) });
            if (y > 0)
                neighbours.Add(new Coords { x = x, y = (y - 1) });
            return neighbours;
        }

        public List<Coords> GetNeighbours(int x, int y)
        {
            //Find the location in the RTS Game Map to see if occupied
            List<Coords> neighbours = new List<Coords>();
            var locn = rtsMap[x, y];
            if (x < (this.mapSize -1) && GetLocationType( (x+1) , y) == RTSGameMapOccupied.False)
                neighbours.Add(new Coords { x = (x+1), y = y });
            if (x > 0 && GetLocationType((x-1), y) == RTSGameMapOccupied.False)
                neighbours.Add(new Coords { x = x-1, y = y });
            if (y < (this.mapSize - 1) && GetLocationType(x, (y+1)) == RTSGameMapOccupied.False)
                neighbours.Add(new Coords { x = x, y = (y + 1) });
            if (y > 0 && GetLocationType(x, (y - 1)) == RTSGameMapOccupied.False)
                neighbours.Add(new Coords { x = x, y = (y - 1) });
            return neighbours;
        }


        public RTSGameMapOccupied GetLocationType(int x, int y)
        {
            //Find the location in the RTS Game Map to see if occupied
            var locn = rtsMap[x, y];
            if (locn == 1)
            {
                return RTSGameMapOccupied.True;
            }
            else
            {
                return RTSGameMapOccupied.False;
            }
        }
        public void SetLocationType(int x, int y, RTSGameMapOccupied type)
        {
            //Find the location in the RTS Game Map to see if occupied
            var locn = rtsMap[x, y];
            object val = Convert.ChangeType(type, type.GetTypeCode());
            rtsMap[x, y] = (byte)val;
        }
    }
}
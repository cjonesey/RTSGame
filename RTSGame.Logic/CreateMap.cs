using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class CreateMap
    {
        public RTSGameMap CreateMapTiles(int squareSize)
        {
            StringBuilder sb = new StringBuilder();
            var map = new RTSGameMap(squareSize);

            //Line 1 - Set first row to be a barrier
            //for (int i = 0; i < squareSize; i++)
            //{
            //    map.SetLocationType(i, 0, RTSGameMap.RTSGameMapOccupied.True);
            //}

            ////Set last row to be a barrier
            //for (int i = 0; i < squareSize; i++)
            //{
            //    map.SetLocationType(i, (squareSize - 1), RTSGameMap.RTSGameMapOccupied.True);
            //}

            ////Set first column to be a barrier (Row + barrier row)
            //for (int i = 2; i < squareSize; i++)
            //{
            //    map.SetLocationType(0, i, RTSGameMap.RTSGameMapOccupied.True);
            //}


            ////Set last column to be a barrier (row - 1 - barrier row)
            //for (int i = 0; i < (squareSize - 2); i++)
            //{
            //    map.SetLocationType((squareSize - 1), i, RTSGameMap.RTSGameMapOccupied.True);
            //}


            //Now do some randomisation to set the map to be occupied
            Random rnd = new Random();
            for (int i = 0; i < (squareSize - 1); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int col = rnd.Next(1, squareSize + 1);
                    if (col < squareSize)
                        map.SetLocationType(i, col, RTSGameMap.RTSGameMapOccupied.True);
                }
            }

            //map.SetLocationType(0, 1, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(1, 1, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(2, 1, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(3, 1, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(4, 1, RTSGameMap.RTSGameMapOccupied.True);

            //map.SetLocationType(4, 2, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(4, 3, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(4, 4, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(4, 5, RTSGameMap.RTSGameMapOccupied.True);

            //map.SetLocationType(6, 0, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(6, 1, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(6, 2, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(6, 3, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(6, 4, RTSGameMap.RTSGameMapOccupied.True);
            //map.SetLocationType(6, 4, RTSGameMap.RTSGameMapOccupied.True);

            //for (int i = 0; i < squareSize-1; i++)
            //{
            //    map.SetLocationType(i, 6, RTSGameMap.RTSGameMapOccupied.True);
            //}
            //for (int i = 2; i < squareSize; i++)
            //{
            //    map.SetLocationType(i, 8, RTSGameMap.RTSGameMapOccupied.True);
            //}

            //for (int i = 0; i < squareSize -1; i++)
            //{
            //    map.SetLocationType(i, 10, RTSGameMap.RTSGameMapOccupied.True);
            //}

            return map;
        }


    }
}

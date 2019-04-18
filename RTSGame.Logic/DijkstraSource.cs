using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class DijkstraSource
    {
        public Stack<Coords> FindPathThroughMap(RTSGameMap visitedMap)
        {
            StringBuilder sb = new StringBuilder();
            int[,] map = new int[visitedMap.MapSize, visitedMap.MapSize];


            for (int i = 0; i < visitedMap.MapSize; i++)
            {
                for (int j = 0; j < visitedMap.MapSize; j++)
                {
                    map[i, j] = 1000000;
                }
            }

            map[0, 0] = 0;

            int dist = 1;//Distance between squares
            List<Coords> next = new List<Coords>();
            next.Add(new Coords { x = 0, y = 0 }); //Start Location            
            while (next.Count != 0)
            {
                //Need to get each of its neighbours
                Coords ff = next.FirstOrDefault();
                int val = map[ff.x, ff.y];
                var neighbours = visitedMap.GetNeighbours(ff.x, ff.y);
                visitedMap.SetLocationType(ff.x, ff.y, RTSGameMap.RTSGameMapOccupied.True);
                next.Remove(ff);

                foreach (Coords coords in neighbours)
                {
                    if (map[coords.x, coords.y] > val + dist)
                        map[coords.x, coords.y] = val + dist;
                    if (!next.Where(f => f.x == coords.x && f.y == coords.y).Any())
                        next.Add(coords);
                }
            }

            //Start from the end point and traverse backwards
            //Last in first out stack
            Stack<Coords> st = new Stack<Coords>();
            Stack<Coords> validSt = new Stack<Coords>();
            for (int y = 0; y < visitedMap.MapSize; y++)
            {
                for (int x = 0 ; x < visitedMap.MapSize;  x++)
                {
                    st.Push(new Coords { x = x, y = y });
                }
            }

            //Get the first value from the stack and then remove
            int squareVal = -1;
            int lastSquareVal = -1;
            bool foundPath = false;
            Coords reverseLocation = visitedMap.EndLocation;
            lastSquareVal = map[reverseLocation.x, reverseLocation.y];
            validSt.Push(visitedMap.EndLocation);
            while (foundPath == false)
            {
                var adjacent = visitedMap.GetAdjacent(reverseLocation.x, reverseLocation.y);
                foreach (Coords coords in adjacent)
                {
                    squareVal = map[coords.x, coords.y];
                    if ((lastSquareVal-squareVal) == dist)
                    {
                        lastSquareVal = squareVal;
                        validSt.Push(coords);
                        reverseLocation = coords;
                        break;
                    }
                }
                if (reverseLocation.Equals(visitedMap.StartLocation))
                    foundPath = true;
            }

            sb.Clear();
            for (int x = 0; x < visitedMap.MapSize; x++)
            {
                for (int y = 0; y < visitedMap.MapSize; y++)
                {
                    sb.Append(":");
                    sb.Append(map[y, x]);
                }
                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }


            foreach (Coords coords in validSt)
            {
                Debug.WriteLine(String.Format("{0} - {1}", coords.x, coords.y));
            }

            return validSt;
        }

    }

}


using RTSGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int squareSize = 64;
            CreateMap cm = new CreateMap();
            var map = cm.CreateMapTiles(squareSize);

            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    if (map.GetLocationType(j, i) == RTSGameMap.RTSGameMapOccupied.True)
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

            DijkstraSource fp = new DijkstraSource();
            Stack<Coords> mapHistory = fp.FindPathThroughMap(map);

            while (mapHistory.Count != 0)
            {
                var t = mapHistory.Pop();
                Console.SetCursorPosition(t.x, t.y);
                Thread.Sleep(50);
                Console.Write("X");
            }

            var ff = Console.ReadLine();
        }
    }
}

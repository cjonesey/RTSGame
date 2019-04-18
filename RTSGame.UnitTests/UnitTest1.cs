using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTSGame.Logic;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace RTSGame.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestCoords tc = new TestCoords();
            tc.TestCOORDS();
        }

        [TestMethod]
        public void TestMethod3()
        {
            DijkstraSource d = new DijkstraSource();
            CreateMap cm = new CreateMap();
            int squareSize = 10;
            var map = cm.CreateMapTiles(squareSize);
            d.FindPathThroughMap(map);
        }

        [TestMethod]
        public void Create_Map()
        {
            StringBuilder sb = new StringBuilder();
            int squareSize = 20;

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
                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }

            FindPath fp = new FindPath();
            List<History> mapHistory = fp.FindPathThroughMap(map);

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
                        if (mapHistory.Where(x => x.Location.x == j && x.Location.y == i).Any())
                        {
                            sb.Append("X");
                        }
                        else
                        {
                            sb.Append(".");
                        }
                    }
                }
                Debug.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

    }
}

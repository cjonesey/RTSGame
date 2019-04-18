using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class TestCoords
    {
        public void TestCOORDS()
        {
            // Initialize:   
            Coords coords1 = new Coords();
            Coords coords2 = new Coords(10, 10);

            // Display results:
            Debug.WriteLine("Coords 1: ");
            Debug.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Debug.Write("Coords 2: ");
            Debug.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);

            //// Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
    }
}

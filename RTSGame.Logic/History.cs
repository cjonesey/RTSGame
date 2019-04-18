using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class History
    {
        public int StepNumber { get; set; }
        public Coords Location { get; set; }
        public Coords NewLocation { get; set; }
        public bool Valid { get; set; }
    }
}

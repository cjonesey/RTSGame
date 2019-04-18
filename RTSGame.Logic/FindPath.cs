using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSGame.Logic
{
    public class FindPath
    {
        public List<History> FindPathThroughMap(RTSGameMap map)
        {
            //Find the quickest way through the map?
            //The start and end point is fixed in this instance
            var startLocation = map.StartLocation;
            var endLocation = map.EndLocation;

            List<History> whereHaveIBeen = new List<History>();
            Coords whereWillIBe = new Coords();
            Coords whereAmI = new Coords();
            bool foundEnd = false;
            whereAmI = startLocation;
            int stepNumber = 0;
            do
            {
                whereWillIBe = whereAmI;
                
                bool dontMoveRight = false;
                bool dontMoveLeft = false;
                bool dontMoveDown = false;
                bool dontMoveUp = false;
                var nextStep = whereHaveIBeen.Where(f => f.Location.x == whereAmI.x && f.Location.y == whereAmI.y).ToList();
                if (nextStep != null)                    
                {
                    foreach (History next in nextStep)
                    {
                        next.Valid = false;
                        if ((next.NewLocation.x - next.Location.x) > 0)
                            dontMoveRight = true;
                        if ((next.NewLocation.x - next.Location.x) < 0)
                            dontMoveLeft = true;
                        if ((next.NewLocation.y - next.Location.y) > 0)
                            dontMoveDown = true;
                        if ((next.NewLocation.x - next.Location.x) < 0)
                            dontMoveUp = true;
                    }
                }

                if (map.GetLocationType((whereAmI.x + 1), whereAmI.y) == RTSGameMap.RTSGameMapOccupied.False && dontMoveRight == false)
                {
                    whereWillIBe.x++;
                }
                else if (map.GetLocationType(whereAmI.x, (whereAmI.y + 1)) == RTSGameMap.RTSGameMapOccupied.False && dontMoveDown == false)
                {
                    whereWillIBe.y++;
                }
                else if (map.GetLocationType((whereAmI.x -1), whereAmI.y) == RTSGameMap.RTSGameMapOccupied.False && dontMoveLeft == false)
                {
                    whereWillIBe.x--;
                }
                else if (map.GetLocationType(whereAmI.x, (whereAmI.y-1)) == RTSGameMap.RTSGameMapOccupied.False && dontMoveUp == false)
                {
                    whereWillIBe.y--;
                }
                map.SetLocationType(whereAmI.x, whereAmI.y, RTSGameMap.RTSGameMapOccupied.False);
                map.SetLocationType(whereWillIBe.x, whereWillIBe.y, RTSGameMap.RTSGameMapOccupied.True);

                if (whereWillIBe.Equals(startLocation))
                    break;

                whereHaveIBeen.Add(new History
                {
                    StepNumber = stepNumber,
                    Location = whereAmI,
                    NewLocation = whereWillIBe,
                    Valid = true
                });
                Debug.WriteLine(String.Format("{0} - {1} : {2} - {3}",whereAmI.x, whereAmI.y, whereWillIBe.x, whereWillIBe.y));
                whereAmI = whereWillIBe;

                if (whereAmI.Equals(endLocation))
                    foundEnd = true;

            } while (foundEnd != true);
            return whereHaveIBeen.Where(f => f.Valid == true).ToList();
        }
    }
}

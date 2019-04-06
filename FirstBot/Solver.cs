using FirstBot.Model;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IO.Swagger.Model.TurnModel;

namespace FirstBot
{
    public class Solver
    {


        public DirectionEnum Solve(PlayerSessionInfo info, TurnResult turn)
        {
            Location currentLocation = info.CurrentLocation;
            if (turn != null)
                currentLocation = turn.Location;
            var sosedi = info.NeighbourCells;
            if (turn != null)
                sosedi = turn.VisibleCells;

            var checker = new MovementChecker();

            var dict = Compass.GetDirection(currentLocation, info.Finish);

            var array = dict.ToArray().ToList();
            array.Sort((a, b) =>
            {
                if (a.Value < b.Value) return -1;
                if (a.Value > b.Value) return 1;
                return 0;
            });
            
            foreach (var cur in array)
            {
                if (checker.CanMove(cur.Key, currentLocation, sosedi, 4))
                    return cur.Key;
            }

            return DirectionEnum.East;

        }

    }

}


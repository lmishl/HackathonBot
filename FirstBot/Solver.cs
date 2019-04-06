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
        DirectionEnum lastDir = DirectionEnum.West;



        public (DirectionEnum, int) Solve(PlayerSessionInfo info, TurnResult turn, List<Location> visited)
        {
            Location currentLocation = info.CurrentLocation;
            if (turn != null)
                currentLocation = turn.Location;
            var sosedi = info.NeighbourCells;
            if (turn != null)
                sosedi = turn.VisibleCells;
            var speed = info.CurrentSpeed;


            var checker = new MovementChecker();

            var dict = Compass.GetDirection(currentLocation, info.Finish);

            var array = dict.ToArray().ToList();
            array.Sort((a, b) =>
            {
                if (a.Value < b.Value) return -1;
                if (a.Value > b.Value) return 1;
                return 0;
            });

            //go to good dir

            var dir = array[0];
            if (!dir.Key.Equals(lastDir))
            {
                var movementState = checker.CanMoveWithPit(dir.Key, currentLocation, sosedi, speed.Value);
                if (movementState.IsCanMove)
                {
                    lastDir = dir.Key.Next().Next().Next();
                    return (dir.Key, movementState.Acceleration);
                }
            }

            //go snova
            var dirq = lastDir.Next().Next().Next();
            if (!dirq.Equals(lastDir))
            {
                var movementState = checker.CanMoveWithPit(dirq, currentLocation, sosedi, speed.Value);
                if (movementState.IsCanMove)
                {
                    lastDir = dirq.Next().Next().Next();
                    return (dirq, movementState.Acceleration);
                }
            }

            //unvisited
            foreach (var cur in array.Where(q =>
            {
                var w = currentLocation.Plus(Constants.Deltas[q.Key]);
                return visited.Any(a => a.Equals(w)) == false;
            })) 
            {
                if (cur.Key.Equals(lastDir))
                    continue;
                var movementState = checker.CanMoveWithPit(cur.Key, currentLocation, sosedi, speed.Value);
                if (movementState.IsCanMove)
                {
                    lastDir = cur.Key.Next().Next().Next();
                    return (cur.Key, movementState.Acceleration);
                }

            }


            //go na poher



            foreach (var cur in array)
            {
                if (cur.Key.Equals(lastDir))
                    continue;
                var movementState = checker.CanMoveWithPit(cur.Key, currentLocation, sosedi, speed.Value);
                if (movementState.IsCanMove)
                {
                    lastDir = cur.Key.Next().Next().Next();
                    return (cur.Key, movementState.Acceleration);
                }
                    
            }
            lastDir = DirectionEnum.West;
            return (DirectionEnum.East, 0);

        }

        public DirectionEnum Solve2(PlayerSessionInfo info, TurnResult turn)
        {
            Location currentLocation = info.CurrentLocation;
            if (turn != null)
                currentLocation = turn.Location;
            var sosedi = info.NeighbourCells;
            if (turn != null)
                sosedi = turn.VisibleCells;

            var checker = new MovementChecker();

            var dir = lastDir;
            while (!checker.CanMove(dir, currentLocation, sosedi, 4))
            {
                dir = dir.Next();
            }
            return dir;
            

            return DirectionEnum.East;

        }

    }

}


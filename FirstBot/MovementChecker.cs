using System;
using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;
using static IO.Swagger.Model.ValueTupleLocationSurfaceType;

namespace FirstBot.Model
{
    public class MovementChecker
    {
        public bool CanMove (DirectionEnum direction, Location currentLocation, List<ValueTupleLocationSurfaceType> neighbourCells, int acceleration)
        {
            var newCell = GetNewCell (direction, currentLocation, neighbourCells);

            // Горы
            if (newCell == null && newCell.Item2.HasValue && newCell.Item2.Value == Item2Enum.Rock)
            {
                return false;
            }

            return true;
        }

        public MovementState CanMoveWithPit (DirectionEnum direction, Location currentLocation, List<ValueTupleLocationSurfaceType> neighbourCells, int speed)
        {
            int neededAcceleration;

            var newCell = GetNewCell (direction, currentLocation, neighbourCells);

            if (newCell == null || !newCell.Item2.HasValue)
            {
                return NoMove ();
            }

            // только горы
            if (newCell.Item2.Value == Item2Enum.Rock)
            {
                return NoMove ();
            }

            // только овраг и ускорение
            if (newCell.Item2.Value == Item2Enum.Pit)
            {
                if (speed == Constants.MinCanyonSpeed)
                {
                    return Move ();
                }

                if (speed > Constants.MinCanyonSpeed)
                {
                    return Move (speed - Constants.MinCanyonSpeed);
                }

                neededAcceleration = Constants.MinCanyonSpeed - speed;

                if (neededAcceleration > Constants.MaxAcceleration)
                {
                    return NoMove ();
                }

                if (neededAcceleration <= Constants.MaxAcceleration)
                {
                    return Move (neededAcceleration);
                }
            }

            if (newCell.Item2.Value == Item2Enum.DangerousArea)
            {
                if (speed <= Constants.MaxDuneSpeed)
                {
                    return Move ();
                }

                neededAcceleration = speed - Constants.MinCanyonSpeed;

                if (neededAcceleration <= Constants.MaxAcceleration)
                {
                    return Move (neededAcceleration);
                }

                if (neededAcceleration > Constants.MaxAcceleration)
                {
                    return NoMove ();
                }
            }

            if (speed != Constants.OurMustSped)
            {
                if (speed > Constants.OurMustSped)
                {
                    neededAcceleration = speed - Constants.OurMustSped >= Constants.MaxAcceleration
                        ? Constants.MaxAcceleration
                        : speed - Constants.OurMustSped;
                    return Move (neededAcceleration);
                }
                if (speed < Constants.OurMustSped)
                {
                    neededAcceleration = Constants.OurMustSped - speed <= Constants.MaxAcceleration
                        ? Constants.OurMustSped - speed
                        : Constants.MaxAcceleration;
                    return Move (neededAcceleration);
                }
            }

            return Move ();
        }

        public bool isDangerousArea (DirectionEnum direction, Location currentLocation, List<ValueTupleLocationSurfaceType> neighbourCells)
        {
            var newCell = GetNewCell (direction, currentLocation, neighbourCells);

            // Опасная зона
            if (newCell.Item2.HasValue && newCell.Item2.Value == Item2Enum.DangerousArea)
            {
                return true;
            }

            return false;
        }

        private ValueTupleLocationSurfaceType GetNewCell (DirectionEnum direction, Location currentLocation, List<ValueTupleLocationSurfaceType> neighbourCells)
        {
            var newLocation = currentLocation.Plus (Constants.Deltas[direction]);

            var newCell = neighbourCells.FirstOrDefault (cell => cell.Item1.Equals (newLocation));

            return newCell;
        }

        private MovementState NoMove ()
        {
            return new MovementState
            {
                IsCanMove = false,
                    Acceleration = 0
            };
        }

        private MovementState Move (int acceleration = 0)
        {
            return new MovementState
            {
            IsCanMove = true,
            Acceleration = acceleration
            };
        }
    }
}
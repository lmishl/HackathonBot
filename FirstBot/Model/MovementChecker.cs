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
            if (newCell.Item2.HasValue && newCell.Item2.Value == Item2Enum.Rock)
            {
                return false;
            }

            return true;
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

            var newCell = neighbourCells.First (cell => cell.Item1 == newLocation);

            return newCell;
        }
    }
}
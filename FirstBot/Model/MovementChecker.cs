using System.Linq;
using IO.Swagger.Model;
using static IO.Swagger.Model.ValueTupleLocationSurfaceType;

namespace FirstBot.Model
{
    public class MovementChecker
    {
        public bool CanMove (DirectionEnum direction, Location currentLocation, PlayerSessionInfo playerSession )
        {
            var newLocation = currentLocation.Plus(Constants.Deltas[direction]);

            var newCell = playerSession.NeighbourCells.First(cell => cell.Item1 == newLocation);

            if (!newCell.Item2.HasValue)
            {
                return false;
            }

            if (newCell.Item2.Value == Item2Enum.Rock )
            {
                return false;
            }

            return true;
        }
    }
}
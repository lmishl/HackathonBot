using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static IO.Swagger.Model.TurnCommand;

namespace FirstBot
{
    public class Сompass
    {
        public MovementDirectionEnum GetDirection(Location location, PlayerSessionInfo sessionInfo)
        {
            var diff = Diff(location, sessionInfo.Finish);

            return MovementDirectionEnum.East;
        }

        Location Diff(Location start, Location finish)
        {
            return new Location
            {
                X = finish.X - start.X,
                Y = finish.Y - start.Y,
                Z = finish.Z - start.Z
            };

        }
    }
}

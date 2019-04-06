using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static IO.Swagger.Model.TurnCommand;

namespace FirstBot
{
    public static class Constants
    {
        static Constants()
        {
            Deltas.Add(MovementDirectionEnum.East, new Location(1,-1,0));
            Deltas.Add(MovementDirectionEnum.West, new Location(-1, 1, 0));
            Deltas.Add(MovementDirectionEnum.NorthEast, new Location(1, 0, -1));
            Deltas.Add(MovementDirectionEnum.NorthWest, new Location(0, 1, -1));
            Deltas.Add(MovementDirectionEnum.SouthEast, new Location(0, -1, 1));
            Deltas.Add(MovementDirectionEnum.SouthWest, new Location(-1, 0, 1));
        }

        public static int MaxSpeed = 100;
        public static int MinSpeed = 100;
        public static int MaxAcceleration = 30;

        public static string JWT_Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcnpoYW5HZXRVcCIsImp0aSI6IjRkMWY4ODkxLWNkZmEtNDBlOS05N2ZmLWMxMmYwNWRhZmU4MyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWJjNTJhMWEtNDQ3Yi00ZWFjLTg4NzQtMmZhOWRmOGFlMTM0Iiwicm9sIjoiYXBpX2FjY2VzcyIsImV4cCI6MTU1NzEzMTQ3NSwiaXNzIjoibXNrZG90bmV0IiwiYXVkIjoibXNrZG90bmV0In0.gorYhnqPilzcAK0xjbbXhAWKQcfxgx8UM04orx1jadk";


        public static Dictionary<MovementDirectionEnum, Location> Deltas;

    }
}

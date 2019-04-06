using FirstBot.Model;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static IO.Swagger.Model.TurnCommand;
using static IO.Swagger.Model.TurnModel;

namespace FirstBot
{
    public static class Constants
    {
        static Constants()
        {
            Deltas.Add(DirectionEnum.East, new Location(1,-1,0));
            Deltas.Add(DirectionEnum.West, new Location(-1, 1, 0));
            Deltas.Add(DirectionEnum.NorthEast, new Location(1, 0, -1));
            Deltas.Add(DirectionEnum.NorthWest, new Location(0, 1, -1));
            Deltas.Add(DirectionEnum.SouthEast, new Location(0, -1, 1));
            Deltas.Add(DirectionEnum.SouthWest, new Location(-1, 0, 1));
        }

        public static int MaxSpeed = 100;
        public static int MinSpeed = 100;
        public static int MaxAcceleration = 30;

        public static string JWT_Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcnpoYW5HZXRVcCIsImp0aSI6IjRkMWY4ODkxLWNkZmEtNDBlOS05N2ZmLWMxMmYwNWRhZmU4MyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWJjNTJhMWEtNDQ3Yi00ZWFjLTg4NzQtMmZhOWRmOGFlMTM0Iiwicm9sIjoiYXBpX2FjY2VzcyIsImV4cCI6MTU1NzEzMTQ3NSwiaXNzIjoibXNrZG90bmV0IiwiYXVkIjoibXNrZG90bmV0In0.gorYhnqPilzcAK0xjbbXhAWKQcfxgx8UM04orx1jadk";


        public static Dictionary<DirectionEnum, Location> Deltas {get; set;}

    }
}

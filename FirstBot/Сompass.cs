using FirstBot.Model;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;


namespace FirstBot
{
    public static class Сompass
    {
        public static Dictionary<double, DirectionEnum> GetDirection(Location location, PlayerSessionInfo sessionInfo)
        {
            var dict = new Dictionary<double, DirectionEnum>();
            foreach (var pair in Constants.Deltas)
            {
                dict.Add(Absolut(location.Plus(pair.Value), sessionInfo.Finish), pair.Key);
            }

            return dict;
        }



        static double Absolut(Location start, Location finish)
        {
            var diff = finish.Minus(start);
            return Math.Sqrt(1.0 * diff.X.Value * diff.X.Value + diff.Y.Value * diff.Y.Value + diff.Z.Value * diff.Z.Value);

        }




    }
}

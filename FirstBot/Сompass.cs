using FirstBot.Model;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;


namespace FirstBot
{
    public static class Compass
    {
        public static Dictionary<DirectionEnum, double> GetDirection(Location location, Location finish)
        {
            var dict = new Dictionary<DirectionEnum, double>();
            foreach (var pair in Constants.Deltas)
            {
                dict.Add(pair.Key, Absolut(location.Plus(pair.Value), finish));
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

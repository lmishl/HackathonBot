﻿using FirstBot.Model;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IO.Swagger.Model.TurnCommand;
using static IO.Swagger.Model.TurnModel;

namespace FirstBot
{
    public class Сompass
    {
        public Dictionary<double, DirectionEnum> GetDirection(Location location, PlayerSessionInfo sessionInfo)
        {
            var dict = new Dictionary<double, DirectionEnum>();
            foreach (var pair in Constants.Deltas)
            {
                dict.Add(Absolut(location.Plus(pair.Value), sessionInfo.Finish), pair.Key);
            }

            return dict;
        }



        double Absolut(Location start, Location finish)
        {
            var diff = finish.Minus(start);
            return Math.Sqrt(1.0 * diff.X.Value * diff.X.Value + diff.Y.Value * diff.Y.Value + diff.Z.Value * diff.Z.Value );

        }



    }
}

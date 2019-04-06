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
        public DirectionEnum Solve(TurnResult turn)
        {
            return DirectionEnum.West;
        }

        public DirectionEnum Solve(PlayerSessionInfo info)
        {



            var dict = Compass.GetDirection(info.CurrentLocation, info);

            var array = dict.ToArray();
            var sorted = dict.Values.ToList();
            
            sorted.Sort();
            foreach (var min in sorted)
            {
                //var index = dict.Values.IndexOf()
                //info.CurrentLocation.Plus(dict[min]);
                //if ()
            }

            return DirectionEnum.West;
        }

        void Test()
        {
        }
        
    }
}

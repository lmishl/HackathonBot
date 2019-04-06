using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using static IO.Swagger.Model.TurnResult;

namespace FirstBot
{
    class Program
    {
        static void Main(string[] args) 
        {
            var visited = new List<Location>();
            var service = new GameService();
            var info = service.CreateRace("spin").Result;
            var solver = new Solver();
            var solution = solver.Solve(info, null, visited);
            var turnResult = service.Move(info.SessionId,solution.Item1 , 30).Result;
            while (turnResult.Status != StatusEnum.HappyAsInsane && turnResult.Status != StatusEnum.Punished)
            {
                Console.WriteLine(turnResult.Status.ToString());
                visited.Add(info.CurrentLocation);
                solution = solver.Solve(info, turnResult, visited);
                var acc = solution.Item2;
                turnResult = service.Move(info.SessionId, solution.Item1, acc).Result;
                info = service.GetCurrentState(info.SessionId).Result;
            }
            Console.WriteLine(turnResult.Status.ToString());
            Console.ReadLine();
        }

       
    }
}

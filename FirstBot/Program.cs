using System;
using static IO.Swagger.Model.TurnResult;

namespace FirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new GameService();
            var info = service.CreateRace("test").Result;
            var q = info.CurrentDirection;
            var solver = new Solver();
            var turnResult = service.Move(info.SessionId, solver.Solve(info, null), 30).Result;
            while (turnResult.Status != StatusEnum.HappyAsInsane && turnResult.Status != StatusEnum.Punished)
            {
                turnResult = service.Move(info.SessionId, solver.Solve(info, turnResult), turnResult.Speed>50? 30:-30).Result;
                info = service.GetCurrentState(info.SessionId).Result;
            }
        }
       
    }
}

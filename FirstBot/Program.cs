using System;

namespace FirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new GameService();
            var info = service.CreateRace("test").Result;
            var q = info.CurrentDirection;
        }
    }
}

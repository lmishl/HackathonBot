using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Templates;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GenerationTest()
        {
            var map = new Map(9);
            var racer = new Racer(new HexCoordinates(0, 0, 0), 100, map);
            var path = racer.BuildPath(new HexCoordinates(1, 0, -1), new HexCoordinates(5, -4, -1));
                     
        }
    }
}

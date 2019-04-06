using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class Racer
    {
        public HexCoordinates Location { get; private set; }
        private string _state;
        private byte _fuel;

        public Racer(HexCoordinates startingPoint, byte startingFuel)
        {
            Location = startingPoint;
            _state = Condition.NotBad;
        }


    }
}

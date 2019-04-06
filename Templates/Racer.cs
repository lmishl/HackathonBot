using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class Racer
    {
        public HexCell Position { get; private set; }
        private string _state;
        private int _fuel;
        private readonly Map _fullMap; 

        public Racer(HexCoordinates startingPoint, int startingFuel, Map map)
        {
            //Location = startingPoint;
            _state = Condition.NotBad;
            _fullMap = map;

            _fullMap.FrameWithRocks();
            _fullMap.ChangeCellState(startingPoint, HexType.Empty);
            Position = _fullMap.GetCell(startingPoint);        
        }
    }
}

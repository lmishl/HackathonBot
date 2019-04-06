using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class Map
    {
        private readonly byte _radius;
        private readonly Dictionary<HexCoordinates, HexType> _allCells;

        public Map(byte radius, bool onAngle)
        {
            int total = 3 * radius * (radius - 1) + 1;
            _allCells = new Dictionary<HexCoordinates, HexType>(total);
            int start = radius - 1;
            // fill all cells with Undiscovered value       x the most values
            for (int x = -start; x <= start; x++)
            {
                for (int y = 0; y <= start; y++)
                {
                    
                }
            }

        }
    }
}

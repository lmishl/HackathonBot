using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class Map
    {
        public readonly Dictionary<HexCoordinates, HexType> _allCells;
        private readonly byte _radius;

        public Map(byte radius)
        {
            _radius = radius;
            int total = 3 * radius * (radius - 1) + 1;
            _allCells = new Dictionary<HexCoordinates, HexType>(total);
            int start = radius - 1;
            for (int stp = 0; stp <= radius; stp++)
            {
                for (int y = start; y > -stp; y--)
                {
                    for (int x = -y; x < radius; x++)
                    {
                        int z = -(x + y);
                        if (Math.Abs(x) <= start && Math.Abs(y) <= start && Math.Abs(z) <= start)
                        {
                            List<HexCoordinates> tempCoords = new List<HexCoordinates>(radius * 2);
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(x), Convert.ToInt16(y), Convert.ToInt16(z)));
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(y), Convert.ToInt16(x), Convert.ToInt16(z)));
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(x), Convert.ToInt16(z), Convert.ToInt16(y)));
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(z), Convert.ToInt16(x), Convert.ToInt16(y)));
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(z), Convert.ToInt16(y), Convert.ToInt16(x)));
                            tempCoords.Add(new HexCoordinates(Convert.ToInt16(y), Convert.ToInt16(z), Convert.ToInt16(x)));

                            foreach (var coord in tempCoords)
                            {
                                if (!_allCells.ContainsKey(coord))
                                    _allCells.Add(coord, HexType.Undiscovered);
                            }
                        }                   
                    }
                }
            }

            if (_allCells.Count != total)
                new Exception("Invalid amount of hexagon cells");
        }

        public HexCell GetCell(HexCoordinates startingPoint)
        {
            return new HexCell(startingPoint, _allCells);
        }

        public void FrameWithRocks()
        {
            int maxVal = _radius - 1;
            foreach (var key in _allCells.Keys.ToList())
            {
                if (Math.Abs(key.X) == maxVal || Math.Abs(key.Y) == maxVal || Math.Abs(key.Z) == maxVal)
                    _allCells[key] = HexType.Rock;                  
            }
        }

        public bool ChangeCellState(HexCoordinates existingCoord, HexType newState)
        {
            if (_allCells.ContainsKey(existingCoord))
            {
                _allCells[existingCoord] = newState;
                return true;
            }
            return false;
        }

    }
}

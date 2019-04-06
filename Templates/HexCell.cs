using System;
using System.Collections.Generic;
using System.Linq;

namespace Templates
{
    public class HexCell
    {
        private readonly IDictionary<HexCoordinates, HexType> _allCells;
        public HexCoordinates Position { get; }
        public HexType State { get; }

        private HexCell(HexCoordinates pos, HexType state, IDictionary<HexCoordinates, HexType> allCells)
        {
            Position = pos;
            State = state;
            _allCells = allCells;
        }

        public HexCell(HexCoordinates pos, IDictionary<HexCoordinates, HexType> allCells)
        {
            Position = pos;
            _allCells = allCells;
        }


        public IEnumerable<HexCell> AdjacentCells
        {
            get
            {
                foreach (var combo in Position.GetAdjacentCombinations())
                {
                    if (_allCells.TryGetValue(combo, out HexType foundState))
                    {
                        yield return new HexCell(combo, foundState, _allCells);
                    }
                }       
            }
        }
    }
}

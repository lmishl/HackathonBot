using System;
using System.Collections.Generic;

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

        public List<HexCoordinates> BuildPath(HexCoordinates startingPoint, HexCoordinates targetNode)
        {
            Dictionary<HexCoordinates?, float> distance = new Dictionary<HexCoordinates?, float>();
            Dictionary<HexCoordinates?, HexCoordinates?> previous = new Dictionary<HexCoordinates?, HexCoordinates?>();
            List<HexCoordinates?> unvisited = new List<HexCoordinates?>();
            distance[startingPoint] = 0;
            previous[startingPoint] = null;
            // infinity for unreachable cells
            foreach (HexCoordinates coord in _fullMap._allCells.Keys)
            {
                if (!coord.Equals(startingPoint))
                {
                    distance[coord] = float.PositiveInfinity;
                    previous[coord] = null;
                }
                unvisited.Add(coord);
            }

            while (unvisited.Count > 0)
            {
                // unvisited node with shortest distance
                HexCoordinates? coord = null;
                foreach (var possibleCoord in unvisited)
                {
                    if (coord == null || distance[possibleCoord] < distance[coord])
                    {
                        coord = possibleCoord;

                    }
                }
                unvisited.Remove(coord);

                if (coord.Value.Equals(targetNode))
                {
                    break;
                }

                HexCell coordCell = _fullMap.GetCell(coord.Value);
                foreach (var neighbor in coordCell.AdjacentCells)
                {
                    float alt = distance[coord] + coordCell.DistanceTo(neighbor);
                    if (alt < distance[neighbor.Position])
                    {
                        distance[neighbor.Position] = alt;
                        previous[neighbor.Position] = coord;
                    }
                }
            }

            if (previous[targetNode] == null)
            {
                // No route to target
                return null;
            }

            List<HexCoordinates> currentPath = new List<HexCoordinates>();

            HexCoordinates? current = targetNode;

            while (previous[current] != null)
            {
                currentPath.Add(current.Value);
                current = previous[current];
            }
            currentPath.Reverse();
            return currentPath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public struct HexCoordinates : IEquatable<HexCoordinates>
    {
        public short X { get; }
        public short Y { get; }
        public short Z { get; }

        public HexCoordinates(short x, short y, short z)
        {
            if (x + y + z != 0)
            {
                throw new Exception("Given coordinates are invalid for Hexagonal field");
            }
            X = x;
            Y = y;
            Z = z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return X + " " + Y + " " + Z;
        }

        public override bool Equals(object obj)
        {
            return (obj is HexCoordinates coord) && Equals(coord);
        }

        public bool Equals(HexCoordinates other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        internal IEnumerable<HexCoordinates> GetAdjacentCombinations()
        {
            yield return new HexCoordinates(Convert.ToInt16(X - 1), Y, Convert.ToInt16(Z + 1));
            yield return new HexCoordinates(X, Convert.ToInt16(Y - 1), Convert.ToInt16(Z + 1));
            yield return new HexCoordinates(Convert.ToInt16(X + 1), Convert.ToInt16(Y - 1), Z);
            yield return new HexCoordinates(Convert.ToInt16(X + 1), Y, Convert.ToInt16(Z - 1));
            yield return new HexCoordinates(X, Convert.ToInt16(Y + 1), Convert.ToInt16(Z - 1));
            yield return new HexCoordinates(Convert.ToInt16(X - 1), Convert.ToInt16(Y + 1), Z);
        }
    }
}

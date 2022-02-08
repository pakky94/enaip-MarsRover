using System;

namespace MarsRover.Core
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position (int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static Position operator +(Position p1, Position other)
        {
            return new Position() { X = p1.X + other.X, Y = p1.Y + other.Y};
        }
        public static bool operator ==(Position p1, Position other)
        {
            return p1.X == other.X && p1.Y == other.Y;
        }
        public static bool operator !=(Position p1, Position other)
        {
            return p1.X != other.X || p1.Y != other.Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}

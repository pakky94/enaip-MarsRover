using System;

namespace MarsRover.Core
{
    public class Rover : IObstacle
    {
        public Position Position { get; private set; }
        public Direction Direction;

        public char MapIcon => Direction switch
        {
            Direction.North => 'A',
            Direction.South => 'V',
            Direction.East => '>',
            Direction.West => '<',
            _ => throw new NotImplementedException(),
        };

        internal void UpdatePosition(Position position)
        {
            Position = position;
        }

        internal Position TryMove(bool forward) => (forward ? Direction : Direction.Opposite()) switch
        {
            Direction.North => Position + new Position() { X = 0, Y = -1 },
            Direction.South => Position + new Position() { X = 0, Y = 1 },
            Direction.East => Position + new Position() { X = 1, Y = 0 },
            Direction.West => Position + new Position() { X = -1, Y = 0 },
            _ => throw new NotImplementedException(),
        };

        internal void RotateLeft()
        {
            Direction = Direction.RotateLeft();
        }

        internal void RotateRight()
        {
            Direction = Direction.RotateRight();
        }

        internal void WritePosition(IRoverPositionWriter roverPositionWriter)
        {
            roverPositionWriter.WritePosDir(Position, Direction);
        }
    }
}

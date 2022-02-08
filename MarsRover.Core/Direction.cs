using System;

namespace MarsRover.Core
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public static class DirectionExtensions
    {
        public static Direction Opposite(this Direction dir) => dir switch
        {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new System.NotImplementedException(),
        };

        public static Direction RotateRight(this Direction dir) => dir switch
        {
            Direction.North => Direction.East,
            Direction.South => Direction.West,
            Direction.East => Direction.South,
            Direction.West => Direction.North,
            _ => throw new System.NotImplementedException(),
        };

        public static Direction RotateLeft(this Direction dir) => RotateRight(RotateRight(RotateRight(dir)));

        public static string ToShortString(this Direction dir) => dir switch
        {
            Direction.North => "N",
            Direction.South => "S",
            Direction.West => "W",
            Direction.East => "E",
            _ => throw new InvalidOperationException($"Invalid value for Direction enum: {dir}")
        };
    }
}

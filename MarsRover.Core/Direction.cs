namespace MarsRover.Core
{
    public enum Direction
    {
        Nord,
        South,
        East,
        West
    }

    public static class DirectionExtensions
    {
        public static Direction Opposite(this Direction dir) => dir switch
        {
            Direction.Nord => Direction.South,
            Direction.South => Direction.Nord,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new System.NotImplementedException(),
        };

        public static Direction RotateRight(this Direction dir) => dir switch
        {
            Direction.Nord => Direction.East,
            Direction.South => Direction.West,
            Direction.East => Direction.South,
            Direction.West => Direction.Nord,
            _ => throw new System.NotImplementedException(),
        };

        public static Direction RotateLeft(this Direction dir) => RotateRight(RotateRight(RotateRight(dir)));
    }
}

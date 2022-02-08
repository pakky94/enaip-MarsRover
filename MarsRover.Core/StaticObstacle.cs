namespace MarsRover.Core
{
    public class StaticObstacle : IObstacle
    {
        public Position Position { get; private set; }
        public char MapIcon => 'O';

        public StaticObstacle(Position position)
        {
            Position = position;
        }
    }
}

namespace MarsRover.Core
{
    public class StaticObstacle : IObstacle
    {
        public Position Position { get; private set; }
        public string MapIcon => "O";

        public StaticObstacle(int x, int y)
        {
            Position = new Position(x, y);
        }
    }
}

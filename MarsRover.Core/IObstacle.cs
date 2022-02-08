namespace MarsRover.Core
{
    public interface IObstacle
    {
        Position Position { get; }
        char MapIcon { get; }
    }
}

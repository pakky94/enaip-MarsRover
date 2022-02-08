namespace MarsRover.Core
{
    public interface IObstacle
    {
        Position Position { get; }
        string MapIcon { get; }
    }
}

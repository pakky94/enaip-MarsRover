using System.IO;

namespace MarsRover.Core
{
    public interface IRoverPositionWriter
    {
        public void WritePosDir(Position position, Direction orientation);
    }

    public class RoverPositionFileWriter : IRoverPositionWriter
    {
        private readonly string filepath;

        public RoverPositionFileWriter(string filename)
        {
            var f = File.Create(filename);
            f.Dispose();
            filepath = filename;
        }

        public void WritePosDir(Position position, Direction orientation)
        {
            File.AppendAllText(filepath, $"({position.X},{position.Y},{orientation.ToShortString()})\n");
        }
    }
}

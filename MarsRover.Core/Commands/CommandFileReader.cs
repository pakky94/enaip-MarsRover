using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarsRover.Core
{
    public class CommandFileReader : IEnumerable<Command>
    {
        private static readonly Dictionary<char, Command> charCommandMapping = new()
        {
            ['F'] = Command.MoveForward,
            ['B'] = Command.MoveBackward,
            ['L'] = Command.RotateLeft,
            ['R'] = Command.RotateRight,
        };
        private readonly IEnumerable<Command> commands;

        public CommandFileReader(string filename)
        {
            commands = File.ReadAllText(filename)
                .ToUpper()
                .Where(charCommandMapping.ContainsKey)
                .Select(charCommandMapping.GetValueOrDefault);
        }

        public IEnumerator<Command> GetEnumerator() => commands.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => commands.GetEnumerator();
    }
}

using System;
using System.Collections.Generic;

using MarsRover.Core;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var map = Map.RandomMap(10, 7, 15);
            var rover = new Rover();
            map.LandRoverAtRandomPosition(rover);
            var consoleLogger = new ConsoleLogger();
            var roverPositionWriter = new RoverPositionFileWriter("output.txt");
            var roverController = new SimpleRoverController(rover, map, roverPositionWriter, consoleLogger);

            var commands = RandomCommands(20);
            //var commands = new CommandFileReader("input.txt");

            roverController.ExecuteCommands(commands);
        }

        static IEnumerable<Command> RandomCommands(int n)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
                yield return rand.Enum<Command>();
        }
    }
}

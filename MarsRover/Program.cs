using System;
using System.Collections.Generic;

using MarsRover.Core;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var map = Map.RandomMap(10, 7, 10);
            var rover = map.LandNewRover();
            var consoleLogger = new ConsoleLogger();
            var roverController = new SimpleRoverController(rover, map, consoleLogger);

            var commands = RandomCommands(20);

            roverController.ExecuteCommands(commands);
        }

        static IEnumerable<Command> RandomCommands(int n)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
                yield return rand.Enum<Command>();
        }
    }
    class ConsoleLogger : ILogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine();
        }

        public void LogInfo(string message)
        {
            Console.WriteLine();
        }
    }
    public static class RandomExtensions
    {
        public static T Enum<T>(this Random rand)
            where T : Enum
        {
            var values = typeof(T).GetEnumValues();
            return (T)values.GetValue(rand.Next(values.Length));
        }
    }
}

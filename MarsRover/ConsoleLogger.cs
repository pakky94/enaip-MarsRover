using System;

using MarsRover.Core;

namespace MarsRover
{
    class ConsoleLogger : ILogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}

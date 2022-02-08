using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogDebug(string message);
    }
}

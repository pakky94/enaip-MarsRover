using System;
using System.Collections.Generic;

namespace MarsRover.Core
{
    public class SimpleRoverController
    {
        private readonly Rover rover;
        private readonly Map map;
        private readonly ILogger logger;

        public SimpleRoverController(Rover rover, Map map, ILogger logger)
        {
            this.rover = rover;
            this.map = map;
            this.logger = logger;
        }

        public void ExecuteCommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
                ExecuteSingleCommand(command);
        }

        public void ExecuteSingleCommand(Command command)
        {
            logger.LogInfo($"\nExecuting command: {command}");
            switch (command)
            {
                case Command.MoveForward:
                    TryMoveRover(true);
                    break;
                case Command.MoveBackward:
                    TryMoveRover(false);
                    break;
                case Command.RotateLeft:
                    rover.RotateLeft();
                    break;
                case Command.RotateRight:
                    rover.RotateRight();
                    break;
                default:
                    throw new NotImplementedException();
            }
            logger.LogDebug($"\nExecuting command: {command}");
        }

        private void TryMoveRover(bool forward)
        {
            Position newRoverPos = rover.TryMove(forward);
            newRoverPos = map.WrapArount(newRoverPos);
            if (map.IsPositionFree(newRoverPos))
                rover.UpdatePosition(newRoverPos);
        }
    }
}

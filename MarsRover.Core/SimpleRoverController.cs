using System;
using System.Collections.Generic;

namespace MarsRover.Core
{
    public class SimpleRoverController
    {
        private static readonly Dictionary<Command, Action<SimpleRoverController>> commandActions = 
            new Dictionary<Command, Action<SimpleRoverController>>()
        {
            [Command.MoveForward] = src => src.TryMoveRover(true),
            [Command.MoveBackward] = src => src.TryMoveRover(false),
            [Command.RotateLeft] = src => src.rover.RotateLeft(),
            [Command.RotateRight] = src => src.rover.RotateRight(),
        };

        private readonly Rover rover;
        private readonly Map map;
        private readonly ILogger logger;
        private readonly IRoverPositionWriter roverPositionWriter;

        public SimpleRoverController(Rover rover, Map map, IRoverPositionWriter roverPositionWriter, ILogger logger)
        {
            this.rover = rover;
            this.map = map;
            this.roverPositionWriter = roverPositionWriter;
            this.logger = logger;
        }

        public void ExecuteCommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
                ExecuteSingleCommand(command);

            rover.WritePosition(roverPositionWriter);
        }

        public void ExecuteSingleCommand(Command command)
        {
            logger.LogInfo($"\nExecuting command: {command}");

            var action = commandActions.GetValueOrDefault(command, 
                _ => throw new NotImplementedException($"Not implemented Action for Command: {command}"));
            action(this);

            /*
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
            */
            logger.LogDebug($"Rover at {rover.Position} facing {rover.Direction}");
            logger.LogDebug(map.PrintMap());
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

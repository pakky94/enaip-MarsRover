using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public class Map
    {
        public readonly uint Width;
        public readonly uint Height;

        private readonly Dictionary<Position, IObstacle> Obstacles = new Dictionary<Position, IObstacle>();
        public Rover Rover;

        public Map(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public static Map RandomMap(uint width, uint height, uint obstacles)
        {
            var rand = new Random();
            var map = new Map(width, height);

            if (obstacles > width * height)
                throw new Exception($"Can't fit {obstacles} in a {width} by {height} map");

            while (map.Obstacles.Count < obstacles)
            {
                var obstaclePosition = new Position(rand.Next((int)width - 1), rand.Next((int)height - 1));
                obstaclePosition = map.GetNearestFreePosition(obstaclePosition);
                var obstacle = new StaticObstacle(obstaclePosition);
                map.Obstacles.TryAdd(obstacle.Position, obstacle);
            }
            return map;
        }

        public void LandRoverAt(Rover rover, Position position)
        {
            position = GetNearestFreePosition(position);
            rover.UpdatePosition(position);
            Rover = rover;
        }

        public Rover LandRoverAtRandomPosition(Rover rover)
        {
            var rand = new Random();
            Position position= new(rand.Next((int)Width - 1), rand.Next((int)Height - 1));
            position = GetNearestFreePosition(position);
            LandRoverAt(rover, position);
            return rover;
        }

        public bool IsPositionFree(Position position) {
            if (Rover is not null && Rover.Position == position)
                return false;
            return !Obstacles.ContainsKey(position);
        }

        private Position GetNearestFreePosition(Position position)
        {
            var requestedPosition = position;
            while (!IsPositionFree(position))
            {
                position.X += 1;
                if (position.X >= Width)
                {
                    position.X = 0;
                    position.Y = (position.Y + 1) % (int)Height;
                }
                if (position == requestedPosition)
                    throw new Exception("No free position found");
            }
            return position;
        }

        public Position WrapArount(Position position)
        {
            return new Position()
            {
                X = (int)(((position.X % Width) + Width) % Width),
                Y = (int)(((position.Y % Height) + Height) % Height),
            };
        }
        
        public string PrintMap()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                sb.Append("|");
                for (int x = 0; x < Width; x++)
                {
                    if (Obstacles.TryGetValue(new Position(x, y), out IObstacle obstacle))
                        sb.Append(obstacle.MapIcon);
                    else if (Rover is not null && Rover.Position == new Position(x, y))
                        sb.Append(Rover.MapIcon);
                    else
                        sb.Append(" ");
                    sb.Append("|");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}

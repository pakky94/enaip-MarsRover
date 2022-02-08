using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public class Map
    {
        public readonly uint Width;
        public readonly uint Height;

        private Dictionary<Position, IObstacle> Obstacles = new Dictionary<Position, IObstacle>();
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
            while (map.Obstacles.Count < obstacles)
            {
                var obstacle = new StaticObstacle(rand.Next((int)width - 1), rand.Next((int)height - 1));
                map.Obstacles.TryAdd(obstacle.Position, obstacle);
            }
            return map;
        }

        public Rover LandNewRover()
        {
            var rand = new Random();
            Rover rover = new Rover();
            Position position;

            do { 
                position = new Position(rand.Next((int)Width - 1), rand.Next((int)Height - 1));
            } while (!IsPositionFree(position));
            rover.UpdatePosition(position);
            Rover = rover;
            return rover;
        }

        public bool IsPositionFree(Position position) {
            if (Rover is not null && Rover.Position == position)
                return false;
            return !Obstacles.ContainsKey(position);
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

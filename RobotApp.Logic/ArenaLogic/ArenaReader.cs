using RobotApp.Models;
using RobotApp.Utils;
using RobotApp.Utils.Interfaces;

namespace RobotApp.Logic.ArenaLogic
{
    public sealed class ArenaReader<T> : FileReader<T>, IArenaReader<T> where T : class
    {
        RobotFactory<string[]> robotFactory;

        public ArenaReader(string[] filePath) : base(filePath)
        {
            robotFactory = new RobotFactory<string[]>(filePath);

        }

        /// <summary>
        /// This method iterates through the contents of the sample file and tries to create the robots arena.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public Grid ConstructArena()
        {
            Console.WriteLine("Building Arena.");

            Grid? grid = null;

            foreach (string line in fileContents)
            {
                if (line.StartsWith("GRID"))
                {
                    var dimensions = line.Substring(5).Split('x');

                    if (dimensions.Length != 2 || !int.TryParse(dimensions[0], out var width) || !int.TryParse(dimensions[1], out var height))
                    {
                        throw new InvalidDataException("Not enough co-ordinates provided to construct a grid.");
                    }
                    if (Grid.Instance != null)
                    {
                        grid = PlaceObstacles(Grid.Instance(width, height));
                    }
                }
            }

            if (grid != null)
            {
                Console.WriteLine("Arena built successfully.");
                return grid;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Logic to place only valid Obstacles onto the grid.
        /// </summary>
        /// <param name="grid"> Grid to add to.</param>
        /// <param name="obstacles"> Obstacles to add.</param>
        /// <returns></returns>
        public Grid PlaceObstacles(Grid grid, string? obstacles = null)
        {
            Console.WriteLine("Placing obstacles.");

            if (obstacles == null)
            {
                foreach (string line in fileContents)
                {
                    Obstacle obstacle = ObstacleLogic.ValidObstacle(line);

                    if (obstacle != null)
                    {
                        FileObject.Instance().AddObstacle(line);
                        grid.obstacles.Add(obstacle);
                    }
                }
            }
            else
            {
                var obstacle = ObstacleLogic.ValidObstacle(obstacles);

                if (obstacle != null)
                {
                    FileObject.Instance().AddObstacle(obstacles);
                    grid.obstacles.Add(obstacle);
                }
            }

            Console.WriteLine("Obstacles placed.");
            robotFactory.ConstructRobot(grid);

            return grid;
        }
    }
}

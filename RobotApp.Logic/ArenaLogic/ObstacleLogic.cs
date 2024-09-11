using RobotApp.Models;
using RobotApp.Utils;

namespace RobotApp.Logic.ArenaLogic
{
    public static class ObstacleLogic
    {
        /// <summary>
        /// This helper method calculates not only if an Obstacle string is valid but also wether it can be placed in a valid place on the grid.
        /// </summary>
        /// <param name="potentialObstacle"></param>
        /// <returns></returns>
        public static Obstacle ValidObstacle(string potentialObstacle)
        {
            if (((potentialObstacle.StartsWith("OBSTACLE"))) && (potentialObstacle.GetValidTuple() != null) && potentialObstacle.GetValidTuple().Item1 < Grid.GetWidth() && potentialObstacle.GetValidTuple().Item2 < Grid.GetHeight())
            {
                return new Obstacle(potentialObstacle.GetValidTuple().Item1, potentialObstacle.GetValidTuple().Item2);
            }
            else
            {
                return null;
            }
        }
    }
}

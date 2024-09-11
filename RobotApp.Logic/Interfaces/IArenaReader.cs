using RobotApp.Models;

namespace RobotApp.Utils.Interfaces
{
    public interface IArenaReader<T>
    {
        public Grid ConstructArena();

        public Grid PlaceObstacles(Grid grid, string? obstacles = null);

    }
}

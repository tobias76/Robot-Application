using RobotApp.Models;

namespace RobotApp.Utils.Interfaces
{
    public interface IRobotFactory<T>
    {
        void ConstructRobot(Grid grid);
    }
}

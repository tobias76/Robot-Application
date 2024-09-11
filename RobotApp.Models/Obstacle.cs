namespace RobotApp.Models
{
    public class Obstacle
    {
        public Cell position;

        public Obstacle(int x, int y)
        {
            position = new Cell(x, y);
        }
    }
}

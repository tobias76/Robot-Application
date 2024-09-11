namespace RobotApp.Models
{
    public class Grid
    {
        private static Grid? _instance = null;
        private static readonly object maximumSecurityGuard = new object();
        private int gridWidth { get; set; } = 0;
        private int gridHeight { get; set; } = 0;

        public List<Obstacle> obstacles = new List<Obstacle>();


        public static Grid Instance(int width, int height)
        {
            lock (maximumSecurityGuard)
            {
                if (_instance == null)
                {
                    return _instance = new Grid(width, height);
                }
                else
                {
                    return _instance;
                }
            }
        }

        private Grid(int width, int height)
        {
            gridHeight = height;
            gridWidth = width;
        }

        public static int GetWidth()
        {
            return _instance.gridWidth;
        }

        public static int GetHeight()
        {
            return _instance.gridHeight;
        }

    }
}

namespace RobotApp.Models
{
    public class FileObject
    {
        public List<RobotMission> robotMissions = new List<RobotMission>();
        public string? gridSize;
        public List<string> obstacles = new List<string>();

        private static FileObject? _instance = null;
        private static readonly object maximumSecurityGuard = new object();


        /// <summary>
        /// Static accessor for the singleton FileObject master.
        /// </summary>
        /// <param name="obstacles"> All obstacles in a file</param>
        /// <param name="robotMissions"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public static FileObject Instance(List<string> obstacles = null, List<RobotMission> robotMissions = null, string? gridSize = null)
        {
            lock (maximumSecurityGuard)
            {
                if (_instance == null)
                {
                    return _instance = new FileObject(obstacles, robotMissions, gridSize ?? Grid.GetHeight().ToString() + Grid.GetWidth().ToString());
                }
                else
                {
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <param name="obstacles"></param>
        /// <param name="robotMissions"></param>
        /// <param name="gridSize"></param>
        private FileObject(List<string> obstacles, List<RobotMission> robotMissions, string? gridSize = null)
        {

            this.gridSize = gridSize;
            this.obstacles = new List<string>();
            this.robotMissions = robotMissions;
        }

        /// <summary>
        /// A helper method to add an obstacle to a file object.
        /// </summary>
        /// <param name="obstacles"> Obstacle to add.</param>
        public void AddObstacle(string obstacles)
        {
            if (_instance != null)
            {
                _instance.obstacles.Add(obstacles);
            }
        }
    }
}

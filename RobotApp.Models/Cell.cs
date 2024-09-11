namespace RobotApp.Models
{
    /// <summary>
    /// A class build up of a cell on the grid, contains an X and Y location indicating where it is.
    /// </summary>
    public class Cell
    {
        readonly int xLocation;
        readonly int yLocation;

        /// <summary>
        /// Simple constructor for a cell.
        /// </summary>
        /// <param name="xLocation"></param>
        /// <param name="yLocation"></param>
        public Cell(int xLocation, int yLocation)
        {
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        /// <summary>
        /// Get the X value of a cell.
        /// </summary>
        /// <returns>Int value corresponding to the X value of a cell on the grid.</returns>
        public int GetX()
        {
            return xLocation;
        }


        /// <summary>
        /// Get the Y value of a cell.
        /// </summary>
        /// <returns>Int value corresponding to the Y value of a cell on the grid.</returns>
        public int GetY()
        {
            return yLocation;
        }
    }
}

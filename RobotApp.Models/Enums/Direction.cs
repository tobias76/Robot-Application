namespace RobotApp.Models.Enums
{

    /// <summary>
    /// An enum that contains all directions on a compass and an additional error state for when required.
    /// </summary>
    public enum Direction
    {
        North = 0,
        NorthEast = 45,
        East = 90,
        SouthEast = 135,
        South = 180,
        SouthWest = 220,
        West = 270,
        NorthWest = 310,
        Error
    }
}

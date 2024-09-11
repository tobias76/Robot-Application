using System.Text.RegularExpressions;

namespace RobotApp.Utils
{
    /// <summary>
    /// A class that holds an extension method.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// This extension method allows the project to convert from a string to co-ordinates.
        /// </summary>
        /// <param name="stringToCheck"> The string we are checking.</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"> This gets thrown if we do not have enough numbers for a tuple.</exception>
        public static Tuple<int, int> GetValidTuple(this string stringToCheck)
        {
            var numbers = Regex.Matches(stringToCheck, @"\d+").ToList();

            if (numbers.Count > 0)
            {
                if (numbers.Count != 2)
                {
                    return null;
                }
                else
                {
                    return new Tuple<int, int>(Int32.Parse(numbers[0].Value), Int32.Parse(numbers[1].Value));
                }
            }
            else
            {
                return null;
            }

        }
    }
}

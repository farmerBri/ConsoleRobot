using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    /// <summary>
    /// Mapping is a helper that encapsulates the logic for converting between different representations of data values
    /// </summary>
    internal static class Mapping
    {

        /// <summary>
        /// Data structure for mapping direction integers to vector arrays
        /// </summary>
        static int[][] vectorMap = new int[][] { new int[]{  0,  1 },               // 0 = NORTH
                                                 new int[]{  1,  0 },               // 1 = EAST
                                                 new int[]{  0, -1 },               // 2 = SOUTH
                                                 new int[]{ -1,  0 } };             // 3 = WEST


        /// <summary>
        /// Converts an integer direction to a vector array
        /// </summary>
        /// <param name="direction">A numeric direction</param>
        /// <returns>The corresponding vector array</returns>
        public static int[] toVector(this int direction)
        {
            int[] result = new int[] { 0, 0 };                                                                                  // default is the identity vector - the robot will remain stationary

            if(direction.isInRange(0, vectorMap.Length))                                                                        // if the direction is valid ...
            {
                result = vectorMap[direction];                                                                                      // get the corresponding vector array
            }
            return result;                                                                                                      // return either the default or the matching vector
        }


        /// <summary>
        /// Data structure for mapping human directions to direction integers 
        /// </summary>
        static Dictionary<string, int> compassPoints = new Dictionary<string, int>
                                                        {
                                                            { "NORTH", 0 },
                                                            { "EAST",  1 },
                                                            { "SOUTH", 2 },
                                                            { "WEST",  3 },
                                                        };


        /// <summary>
        /// Convert a human direction to an integer direction
        /// </summary>
        /// <param name="compassPoint">The human-readable direction</param>
        /// <returns>The robot's preferred numeric direction</returns>
        public static int toDirection(this string compassPoint)
        {
            int result = -1;                                                                                                    // set our default - an invalid direction
            compassPoint = compassPoint.ToUpper();                                                                              // ensure input case will match our data

            if(compassPoints.ContainsKey(compassPoint))                                                                         // if the input direction is valid ...
            {
                result = compassPoints[compassPoint];                                                                               // grab the direction
            }
            return result;                                                                                                      // return our numeric direction, or an invalid direction
        }


        /// <summary>
        /// Convert an integer direction to a human-readable direction
        /// </summary>
        /// <param name="direction">A robot direction integer</param>
        /// <returns>A human readable direction</returns>
        public static string toCompassPoint(this int direction)
        {
            var compassPoint = compassPoints.FirstOrDefault((point) => point.Value == direction);                               // Try to find a value that matches the passed integer          more ->                             - default KeyValuePair<string,int> is { null, 0 }
            return compassPoint.Key ?? $"INVALID DIRECTION ({direction})";                                                      // if the compass-point was found return the human-readable key, if not, let the humans know!       ... so Key will be null
        }
    }
}

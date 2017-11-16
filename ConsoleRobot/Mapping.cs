using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    internal static class Mapping
    {


        static int[][] vectorMap = new int[][] { new int[]{  0,  1 },               // 0 = NORTH
                                                 new int[]{  1,  0 },               // 1 = EAST
                                                 new int[]{  0, -1 },               // 2 = SOUTH
                                                 new int[]{ -1,  0 } };             // 3 = WEST


        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int[] toVector(this int direction)
        {
            int[] result = new int[] { 0, 0 };                                                              // defalut is the identity vector - the robot will remain stationary

            if(direction.isInRange(0, vectorMap.Length))
            {
                result = vectorMap[direction];
            }
            return result; 
        }



        static Dictionary<string, int> compassPoints = new Dictionary<string, int>
                                                        {
                                                            { "NORTH", 0 },
                                                            { "EAST",  1 },
                                                            { "SOUTH", 2 },
                                                            { "WEST",  3 },
                                                        };

        public static int toDirection(this string compassPoint)
        {
            int result = -1;
            compassPoint = compassPoint.ToUpper();

            if(compassPoints.ContainsKey(compassPoint))
            {
                result = compassPoints[compassPoint];
            }
            return result;
        }



        public static string toCompassPoint(this int direction)
        {
            var compassPoint = compassPoints.FirstOrDefault((point) => point.Value == direction);                               // default KeyValuePair<string,int> is { null, 0 }
            return compassPoint.Key ?? $"INVALID DIRECTION (${direction})";                                                     // ... so Key will be null
        }
    }
}

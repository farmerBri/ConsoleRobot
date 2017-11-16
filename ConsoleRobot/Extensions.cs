using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    /// <summary>
    /// Some general extensions to help our main logic be more semantic
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks the integer is within the bounds specified
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <param name="lowestIndex">The number must be EQUAL OR GREATER than this lower limit</param>
        /// <param name="length">The number must be LESS than this upper limit</param>
        /// <returns>true if the number is within the range specified</returns>
        public static bool isInRange(this int number, int lowestIndex, int length)
        {
            return lowestIndex <= number && number < length;
        }


        /// <summary>
        /// Adds two integer arrays together, cell by cell, returning a new array
        /// If arrays are differing lengths, only cells that have a corresponding value in the second array will be added
        /// The resulting array will be the length of the smaller of the two arrays
        /// </summary>
        /// <param name="first">The first array to add</param>
        /// <param name="second">The second array to add</param>
        /// <returns>A new array containing the freshly summed values</returns>
        public static int[] add(this int[] first, int[] second)
        {
            int numMatchingCells = Math.Min(first.Length, second.Length);                                                                       // get the length of the smallest array (arrays should be the )
            int[] result = new int[numMatchingCells];                                                                                           // create a result array of the correct length

            for(int i = 0; i < result.Length; i++)                                                                                              // for each cell in the result array ...
            {
                result[i] = first[i] + second[i];                                                                                                   // sum the corresponding values from the input arrays into the result array
            }

            return result;                                                                                                                      // return our nice new array
        }


        /// <summary>
        /// Parse a suspected string value - provide a default value in case we're wrong and it doesn't parse
        /// Handy!
        /// </summary>
        /// <param name="value">A string we think could be an int</param>
        /// <param name="d3fault">A sensible default integer</param>
        /// <returns>The parsed value or our default</returns>
        public static int safeParse(this string value, int d3fault)
        {
            int result = d3fault;                                                                                                               // default to our default value
            try                                                                                                                                 // try to ...
            {
                result = int.Parse(value);                                                                                                          // parse our string to an int
            }
            catch { }                                                                                                                           // if it fails to parse, the value won't be set and we don't care as we've provided a sensible default

            return result;                                                                                                                      // return a decend value, one way or another
        }

    }
}

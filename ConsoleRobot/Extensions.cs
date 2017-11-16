using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    public static class Extensions
    {
        public static bool isInRange(this int number, int lowestIndex, int length)
        {
            return lowestIndex <= number && number < length;
        }


        public static int[] add(this int[] first, int[] second)
        {
            int numMatchingCells = Math.Min(first.Length, second.Length);
            int[] result = new int[numMatchingCells];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = first[i] + second[i];
            }

            return result;
        }


        public static int safeParse(this string value, int d3fault)
        {
            int result = d3fault;
            try
            {
                result = int.Parse(value);
            }
            catch { /* don't care */ }

            return result;
        }

    }
}

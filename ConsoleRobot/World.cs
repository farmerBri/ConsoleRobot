using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    /// <summary>
    /// 
    /// </summary>
    public class World
    {

        public readonly int sizeX;
        public readonly int sizeY;


        /// <summary>
        /// Construct a world of a particular size
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public World(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool locationExists(int x, int y)
        {
            return x.isInRange(0, sizeX) && y.isInRange(0, sizeY);
        }
    }
}

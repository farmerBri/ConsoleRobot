using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    public class Robot
    {
        protected World world;

        public bool placed { get; protected set; }

        public int[] position { get; protected set; }
        public int direction { get; protected set; }


        public Robot(World world)
        {
            this.world = world;
            placed = false;
        }


        public void place(int x, int y, int direction)
        {
            if(world.locationExists(x, y) && direction.isInRange(0, 4))
            {
                position = new int[] { x, y };
                this.direction = direction;
                placed = true;
            }
        }


        public void move()
        {
            if(placed)
            {
                int[] newPosition = position.add(direction.toVector());

                if(world.locationExists(newPosition[0], newPosition[1]))
                {
                    position = newPosition;
                }
            }
        }

        public void turn(int moment)
        {
            if (placed)
            {
                direction = (direction + moment) % 4;
            }
        }
        
    }
}

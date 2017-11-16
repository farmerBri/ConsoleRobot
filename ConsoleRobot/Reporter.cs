using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    public class Reporter
    {
        Robot robot;
        const int x = 0;
        const int y = 1;

        public Reporter(Robot robot)
        {
            this.robot = robot;
        }

        public void report()
        {
            Console.WriteLine(robot.placed ?                                                                                        // if the robot has been placed ...
                                $"{robot.position[x]},{robot.position[y]},{robot.direction.toCompassPoint()}" :                         // output the report
                                "Robot not yet placed");                                                                                // otherwise: inform the user the robot hsn't been placed
        }
    }
}

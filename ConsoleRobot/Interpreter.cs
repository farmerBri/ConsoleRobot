using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    public class Interpreter
    {
        Robot robot;
        Reporter reporter;

        Regex commandPattern = new Regex(@"(\w+)(?:\s+(\d+),(\d+),(\w+))?", RegexOptions.Compiled);

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="reporter"></param>
        public Interpreter(Robot robot, Reporter reporter)
        {
            this.robot = robot;
            this.reporter = reporter;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void processCommand(string command)
        {
            Match match = commandPattern.Match(command);

            switch(match.Groups[1].Value.ToUpper())
            {
                case "LEFT":
                    robot.turn(-1);
                    break;

                case "RIGHT":
                    robot.turn(1);
                    break;

                case "MOVE":
                    robot.move();
                    break;

                case "PLACE":
                    int x = match.Groups[2].Value.safeParse(-1);
                    int y = match.Groups[3].Value.safeParse(-1);
                    int direction =match.Groups[4].Value.toDirection();

                    robot.place(x, y, direction);
                    break;

                case "REPORT":
                    reporter.report();
                    break;
            }
        }



    }
}

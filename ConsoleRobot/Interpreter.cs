using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    /// <summary>
    /// Interpreter's role is to convert human commands to program calls
    /// </summary>
    public class Interpreter
    {
        Robot robot;
        Reporter reporter;

        Regex commandPattern = new Regex(@"(\w+)(?:\s+(\d+),(\d+),(\w+))?", RegexOptions.Compiled);                                     // simple commands only need a simple parser


        /// <summary>
        /// Construct our Interpreter - it needs references to anything that can be 'commanded'
        /// </summary>
        /// <param name="robot">A robot to command</param>
        /// <param name="reporter">A reporter, for reporting!</param>
        public Interpreter(Robot robot, Reporter reporter)
        {
            this.robot = robot;
            this.reporter = reporter;
        }


        /// <summary>
        /// Our basic command parser
        /// </summary>
        /// <param name="command">Tell us what needs to be done</param>
        public void processCommand(string command)
        {
            Match match = commandPattern.Match(command);                                                                                // gather command tokens

            switch(match.Groups[1].Value.ToUpper())                                                                                     // group 1 will contain our command type
            {
                case "LEFT":                                                                                                                // if LEFT ...
                    robot.turn(-1);                                                                                                             // robot turns left - left is -1
                    break;

                case "RIGHT":                                                                                                               // if RIGHT ...
                    robot.turn(1);                                                                                                              // robot turns right - right turn is +1
                    break;

                case "MOVE":                                                                                                                // if MOVE ...
                    robot.move();                                                                                                               // tell the robot to move
                    break;

                case "PLACE":                                                                                                               // if PLACE ...
                    int x = match.Groups[2].Value.safeParse(-1);                                                                                // grab our Y token, with a default that will result in an invalid location
                    int y = match.Groups[3].Value.safeParse(-1);                                                                                // grab our X token, with a default that will result in an invalid location
                    int direction =match.Groups[4].Value.toDirection();                                                                         // grab our direction token and convert it to a numerical direction

                    robot.place(x, y, direction);
                    break;

                case "REPORT":
                    reporter.report();
                    break;
            }
        }



    }
}

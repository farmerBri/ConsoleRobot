using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            World world = new World(5, 5);

            Robot robby = new Robot(world);
            Reporter reporter = new Reporter(robby);

            Interpreter interp = new Interpreter(robby, reporter);

            do
            {
                command = Console.ReadLine() ?? "exit";
                
                interp.processCommand(command);

                /*
                interp.processCommand("PLACE 1,2,EAST");
                interp.processCommand("MOVE");
                interp.processCommand("MOVE");
                interp.processCommand("LEFT");
                interp.processCommand("MOVE");
                interp.processCommand("REPORT");
                */
            }
            while(command.ToLower() != "exit");
        }
    }
}

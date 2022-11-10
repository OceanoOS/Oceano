using Cosmos.Core.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class Shell
    {
        public static string path = @"0:\";
        public static void BeforeRun()
        {
            Drivers.Display.canvas.Disable();
            Run();
        }
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("root");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Boot.Kernel.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + path+ " ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "gui": Drivers.Display.InitSVGA(); break;
                case "shutdown": Cosmos.System.Power.Shutdown(); break;
                
                default: Console.WriteLine("Command Not Found."); break;
                case "": break;
            }
            Run();
        }
    }
}

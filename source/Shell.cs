using Cosmos.Core.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano
{
    public class Shell
    {
        public static void BeforeRun()
        {
            Boot.Kernel.canvas.Disable();
            Run();
        }
        public static void Run()
        {
            Console.WriteLine();
            Console.Write(">");
            var input = Console.ReadLine();
            switch (input)
            {
                case "gui": Graphics.VGA.Init(); break;
                case "shutdown":Cosmos.System.Power.Shutdown();break;
                default:Console.WriteLine("Command Not Found."); break;
                case "": break;
            }
            Run();
        }
    }
}

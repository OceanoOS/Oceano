using System;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static string file;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            Console.WriteLine();
            Console.Write(">");
            var input = Console.ReadLine();
            switch (input)
            {
                default: Console.WriteLine("Command " + input + " not found."); break;
                case "neofetch": Commands.neofetch.Init(); break;
                case "calc": Commands.calc.Init(); break;
                case "": break;
                case "clear": Commands.clear.Init(); break;
                case "miv": Commands.MIV.StartMIV(); break;
                case "shutdown": Commands.power.Shutdown(); break;
                case "reboot": Commands.power.Reboot(); break;
                case "beep": Console.Beep(); break;
                case "echo": break;
            }
        }
    }
}

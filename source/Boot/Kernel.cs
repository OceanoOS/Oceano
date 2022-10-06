using Oceano.Commands;
using System;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static string currentPath;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.White;
            Commands.fs.Init(Commands.fs.cosmosVFS);
            currentPath = @"0:\";
        }

        protected override void Run()
        {
            Console.WriteLine();
            Console.Write(currentPath + ">");
            var input = Console.ReadLine();
            switch (input)
            {
                default: Console.WriteLine("Command " + input + " not found."); break;
                case "neofetch": Commands.neofetch.Init(); break;
                case "calc": Commands.calc.Init(); break;
                case "gui": Commands.gui.Init(); break;
                case "fs info": Commands.fs.info(@"0:\", fs.cosmosVFS); break;
                case "fs create": Commands.fs.create(); break;
                case "fs delete": Commands.fs.delete(); break;
                case "fs write": Commands.fs.write(); break;
                case "clar": Commands.clear.Init(); break;
                case "cd": Commands.fs.cd(); break;
                case "mkdir": Commands.fs.mkdir(); break;
                case "deldir": Commands.fs.deldir(); break;
                case "": break;
                case "clear": Commands.clear.Init(); break;
                case "miv":Commands.miv.StartMIV(); break; 
            }
        }
    }
}

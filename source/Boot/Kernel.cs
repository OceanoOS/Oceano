using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static string file;
        CosmosVFS fs = new();
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.White;
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
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
                case "echo": Commands.echo.Init(); break;
                case "help": Commands.help.Init(); break;
                case "touch":Commands.touch.Init(); break;
                case "dir":Commands.dir.Init();break;
            }
        }
    }
}

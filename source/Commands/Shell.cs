using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;

namespace Oceano.Commands
{
    public class Shell
    {
        public static String path;
        public static void BeforeRun()
        {
            Run();
        }
        public static void Run()
        {
            Console.WriteLine();
            Console.Write("> ");
            var input=Console.ReadLine();
            switch (input)
            {
                default:Console.WriteLine("Command not found."); break;
                case "":break;
                case "gui": Graphics.SVGAII.Init(); break;
                case "calc":Commands.Text.Calculator(); break;
                case "neofetch":Commands.Text.Info(); break;
                case "clear":Commands.Text.Clear();break;
                case "shutdown":Commands.ACPI.Shutdown(); break;
                case "reboot":Commands.ACPI.Reboot();break;
            }
            Run();
        }
    }
}

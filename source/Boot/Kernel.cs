using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static string file;
        public static CosmosVFS fs = new();
        public static string path;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.White;
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            path = @"0:\";
        }

        protected override void Run()
        {
            Console.WriteLine();
            Console.Write(path + ">");
            var input = Console.ReadLine();
            switch (input)
            {
                default: Console.WriteLine("Command " + input + " not found."); break;
                case "neofetch": Commands.Text.Info(); break;
                case "calc": Commands.Text.Calculator(); break;
                case "": break;
                case "clear": Commands.Text.Clear(); break;
                case "miv": Commands.MIV.StartMIV(); break;
                case "shutdown": Commands.ACPI.Shutdown(); break;
                case "reboot": Commands.ACPI.Reboot(); break;
                case "beep": Console.Beep(); break;
                case "help": Commands.Text.Clear(); break;
                case "touch": Commands.Filesystem.CreateFile(); break;
                case "dir": Commands.Filesystem.DirectoryListing(); break;
                case "cd": Commands.Filesystem.Cd(); break;
                case "gui":Commands.Graphics.Init();break;
            }
        }
    }
}

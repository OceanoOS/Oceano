using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Oceano.Core.Graphics;
using Oceano.Shell;
using System;
using Console = System.Console;

namespace Oceano.Core
{
    public class Program : Kernel
    {
        public static string Name = "Oceano";
        public static string Version = "1.0.0";
        public static string Username = "root";
        public static string Host = "oceano";
        public static VMWareSVGAII VMWareSVGAII;
        public static CosmosVFS FileSystem;
        public static bool FilesystemEnabled;
        public static bool GraphicsMode = false;
        public static string CurrentPath;
        public static CommandManager commandManager = new();

        protected override void BeforeRun()
        {
            VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x25);
            Console.Clear();
            try
            {
                FileSystem = new();
                VFSManager.RegisterVFS(FileSystem, true, true);
                FilesystemEnabled = true;
                CurrentPath = "0:\\";
            }
            catch
            {
                FilesystemEnabled = false;
                CurrentPath = "";
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Oceano");
            Console.WriteLine();
        }

        protected override void Run()
        {
            if(GraphicsMode) 
            {
                Oceano.GUI.Graphics.Update();
            } else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Username);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Host);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" " + CurrentPath + ">");
                string input = Console.ReadLine();
                string response;
                response = commandManager.ProcessInput(input);
                Console.WriteLine(response);
            }
        }
    }
}

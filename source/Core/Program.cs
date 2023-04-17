using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Oceano.GUI;
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
        public static CosmosVFS FileSystem;
        public static bool FilesystemEnabled;
        public static string CurrentPath = "";
        public static CommandManager commandManager = new();
        public static PrismGraphics.Extentions.VMWare.SVGAIICanvas Canvas;
        public static bool GraphicsMode = false;

        protected override void BeforeRun()
        {
            try
            {
                FileSystem = new();
                VFSManager.RegisterVFS(FileSystem);
                FilesystemEnabled = true;
                CurrentPath = @"0:\";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                FilesystemEnabled = false;
            }
            VGAScreen.SetTextMode(Cosmos.HAL.VGADriver.TextSize.Size80x25);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Oceano");
            Console.WriteLine();
        }

        protected override void Run()
        {
            if (GraphicsMode)
            {
                Graphics.Update();
            }
            else
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
                Heap.Collect();
            }
        }
    }
}

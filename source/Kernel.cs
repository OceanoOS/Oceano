using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using System;

namespace Oceano
{
    public class Kernel : Cosmos.System.Kernel
    {
        public static string path = @"0:\";
        public static CosmosVFS fs = new();
        private CommandManager commandManager = new();
        public static Canvas canvas;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Oceano booted successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                VFSManager.RegisterVFS(fs, true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        protected override void Run()
        {
            Console.Write(path + ">");
            String repsonse;
            String input = Console.ReadLine();
            repsonse = this.commandManager.processInput(input);
            Console.WriteLine(repsonse);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

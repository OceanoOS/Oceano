using Oceano.Core;
using System;
using System.IO;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Ls : Command
    {
        public Ls(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Directories:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var dir in Directory.GetDirectories(Directory.GetCurrentDirectory()))
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Files:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
                {
                    Console.WriteLine(file);
                }
            }
            catch(Exception ex)
            {
                CustomConsole.PrintError("Error: " + ex.Message);
            }
            return "";
        }
    }
}

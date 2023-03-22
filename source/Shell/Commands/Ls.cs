using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Ls : Command
    {
        public Ls(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            try
            {
                var files = Directory.GetFiles(Kernel.CurrentPath);
                var directories = Directory.GetDirectories(Kernel.CurrentPath);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Files:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Directories: ");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var directory in directories)
                {
                    Console.WriteLine(directory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return "";
        }
    }
}

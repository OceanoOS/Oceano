using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell
{
    public static class Batch
    {
        public static void Execute(string filename)
        {
            try
            {
                if (filename.EndsWith(".bat"))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (!(line.StartsWith(";")))
                        {
                            string response = Kernel.commandManager.ProcessInput(line);
                            Console.WriteLine(response);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This file is not a valid script.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

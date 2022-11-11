using System;
using System.IO;

namespace Oceano.Commands
{
    public class Cd : Command
    {
        public Cd(String name) : base(name) { }
        public override String execute(String[] args)
        {
            string response = "";
            try
            {
                if (Directory.Exists(args[0]))
                {
                    Kernel.path = args[0];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    response = "Error: Directory not exists.";
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}

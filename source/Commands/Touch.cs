using System;
using System.IO;

namespace Oceano.Commands
{
    public class Touch : Command
    {
        public Touch(String name) : base(name) { }
        public override String execute(String[] args)
        {
            string response;
            try
            {
                File.Create(Kernel.path + args[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                response = "File " + args[0] + " created.";
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

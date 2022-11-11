using System;
using System.IO;

namespace Oceano.Commands
{
    public class Delete : Command
    {
        public Delete(String name) : base(name) { }
        public override String execute(String[] args)
        {
            string response;
            try
            {
                File.Delete(Kernel.path + args[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                response = "File " + args[0] + "deleted.";
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

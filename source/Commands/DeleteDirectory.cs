using System;
using System.IO;

namespace Oceano.Commands
{
    public class DeleteDirectory : Command
    {
        public DeleteDirectory(String name) : base(name) { }
        public override String execute(String[] args)
        {
            string response;
            try
            {
                Directory.Delete(Kernel.path + args[0]);
                Console.ForegroundColor = ConsoleColor.Green;
                response = "Directory " + args[0] + "deleted.";
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

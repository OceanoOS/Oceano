using System;
using System.IO;

namespace Oceano.Commands
{
    public class DirectoryListing : Command
    {
        public DirectoryListing(String name) : base(name) { }
        public override String execute(String[] args)
        {
            string response = "";
            try
            {
                var dir_list = Directory.GetDirectories(Kernel.path);
                foreach (var dir in dir_list)
                {
                    Console.WriteLine(dir);
                }
                var file_list = Directory.GetFiles(Kernel.path);
                foreach (var file in file_list)
                {
                    Console.WriteLine(file);
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

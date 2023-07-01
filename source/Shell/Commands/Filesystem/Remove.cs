using Oceano.Core;
using System;
using System.IO;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Remove : Command
    {
        public Remove(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + args[0]))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + args[0], true);
                }
                else if (File.Exists(Directory.GetCurrentDirectory() + args[0]))
                {
                    File.Delete(Directory.GetCurrentDirectory() + args[0]);
                }
                CustomConsole.PrintSuccess("File or directory deleted successfully!");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while deleting: " + ex.Message);
            }
            return "";
        }
    }
}

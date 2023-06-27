using Oceano.Core;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Remove : Command
    {
        public Remove(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                if (Directory.Exists(Kernel.CurrentPath + args[0]))
                {
                    Directory.Delete(Kernel.CurrentPath + args[0], true);
                }
                else if (File.Exists(Kernel.CurrentPath + args[0]))
                {
                    File.Delete(Kernel.CurrentPath + args[0]);
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

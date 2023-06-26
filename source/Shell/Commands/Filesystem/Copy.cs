using Oceano.Core;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Copy : Command
    {
        public Copy(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                if (!File.Exists(args[1]))
                {
                    File.Copy(Kernel.CurrentPath + args[0], Kernel.CurrentPath + args[1]);
                }
                else
                {
                    CustomConsole.PrintWarning("File destination exists already. Do you want to overwrite? y/n");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "y": File.Copy(Kernel.CurrentPath + args[0], Kernel.CurrentPath + args[1], true); break;
                        default: break;
                    }
                }
                CustomConsole.PrintSuccess("File copied successfully.");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while copying file: " + ex.Message);
            }
            return "";
        }
    }
}

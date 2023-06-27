using Oceano.Core;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Create : Command
    {
        public Create(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                File.Create(Kernel.CurrentPath + args[0]);
                CustomConsole.PrintSuccess("File created successfully");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while creating file: " + ex.Message);
            }
            return "";
        }
    }
}

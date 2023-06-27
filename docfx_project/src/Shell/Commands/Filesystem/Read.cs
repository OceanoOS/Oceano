using Oceano.Core;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;
namespace Oceano.Shell.Commands.Filesystem
{
    public class Read : Command
    {
        public Read(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            string response = "";
            try
            {
                response = File.ReadAllText(Kernel.CurrentPath + args[0]);
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while reading file: " + ex.Message);
            }
            return response;
        }
    }
}

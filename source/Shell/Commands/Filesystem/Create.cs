using Oceano.Core;
using System;
using System.IO;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Create : Command
    {
        public Create(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                File.Create(Directory.GetCurrentDirectory() + args[0]);
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

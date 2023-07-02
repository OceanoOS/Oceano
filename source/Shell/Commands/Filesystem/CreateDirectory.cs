using Oceano.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Shell.Commands.Filesystem
{
    public class CreateDirectory : Command
    {
        public CreateDirectory(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + args[0]);
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error: " + ex.Message);
            }
            return base.Execute(args);
        }
    }
}

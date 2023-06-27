using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Filesystem
{
    public class ChangeDirectory : Command
    {
        public ChangeDirectory(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (Directory.Exists(args[0]))
            {
                Kernel.CurrentPath = args[0];
            }
            if (!Kernel.CurrentPath.EndsWith('\\'))
            {
                Kernel.CurrentPath += "\\";
            }
            return "";
        }
    }
}

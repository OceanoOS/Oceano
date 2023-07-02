using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Users
{
    public class HostName : Command
    {
        public HostName(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (!File.Exists("0:\\hostname.cfg"))
            {
                File.Create("0:\\hostname.cfg");
            }
            else
            {
                File.WriteAllText("0:\\hostname.cfg", args[0]);
                Kernel.Host = args[0];
            }
            return "";
        }
    }
}

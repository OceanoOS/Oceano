using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Shell.Commands.General
{
    public class Information : Command
    {
        public Information(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            return base.Execute(args);
        }
    }
}

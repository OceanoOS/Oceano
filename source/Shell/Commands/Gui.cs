using Oceano.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Gui : Command
    {
        public Gui(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Graphics.Init();
            return "";
        }
    }
}

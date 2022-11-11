using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class Gui : Command
    {
        public Gui(String name) : base(name) { }
        public override String execute(String[] args)
        {
            Graphics.Display.Init();
            return "";
        }
    }
}

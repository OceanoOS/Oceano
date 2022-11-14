using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class Clear : Command
    {
        public Clear(String name) : base(name) { }
        public override String execute(String[] args)
        {
            Console.Clear();
            return "";
        }
    }
}

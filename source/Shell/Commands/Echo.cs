using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Shell.Commands
{
    public class Echo : Command
    {
        public Echo(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            foreach(var s in args)
            {
                Console.Write(s + " ");
            }
            return "";
        }
    }
}

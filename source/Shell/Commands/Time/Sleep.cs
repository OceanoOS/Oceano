using System;
using System.Threading;

namespace Oceano.Shell.Commands.Time
{
    public class Sleep : Command
    {
        public Sleep(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Thread.Sleep(Convert.ToInt16(args[0]) * 1000);
            return "";
        }
    }
}

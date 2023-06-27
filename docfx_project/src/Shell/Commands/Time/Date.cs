using System;

namespace Oceano.Shell.Commands.Time
{
    public class Date : Command
    {
        public Date(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            return DateTime.Now.ToString();
        }
    }
}

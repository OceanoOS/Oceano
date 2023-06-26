using System;

namespace Oceano.Shell.Commands.General
{
    public class Clear : Command
    {
        public Clear(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Console.Clear();
            return "";
        }
    }
}

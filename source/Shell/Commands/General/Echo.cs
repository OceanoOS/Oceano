using System;

namespace Oceano.Shell.Commands.General
{
    public class Echo : Command
    {
        public Echo(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            foreach (var arg in args)
            {
                Console.Write(arg + " ");
            }
            return base.Execute(args);
        }
    }
}

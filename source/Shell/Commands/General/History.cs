using System;

namespace Oceano.Shell.Commands.General
{
    public class History : Command
    {
        public History(string name, string description) : base(name, description)
        {

        }
        public override string Execute(string[] args)
        {
            int n = 0;
            foreach (var command in Core.Shell.history)
            {
                n += 1;
                Console.WriteLine(n.ToString() + " " + command);
            }
            return "";
        }
    }
}

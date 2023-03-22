using System;

namespace Oceano.Shell.Commands
{
    public class Clear : Command
    {
        public Clear(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Console.Clear();
            return "";
        }
    }
}

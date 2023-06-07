using System;

namespace Oceano.Shell.Commands.General
{
    public class Time : Command
    {
        public Time(string name) : base(name) { }
        public override string Execute(string[] args)
        {
            return DateTime.Now.ToString();
        }
    }
}

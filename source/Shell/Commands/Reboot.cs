using Cosmos.System;

namespace Oceano.Shell.Commands
{
    public class Reboot : Command
    {
        public Reboot(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Power.Reboot();
            return "";
        }
    }
}

using System;

namespace Oceano.Commands
{
    public class Reboot : Command
    {
        public Reboot(String name) : base(name) { }
        public override String execute(String[] args)
        {
            Cosmos.System.Power.Reboot();
            return "Reboot";
        }
    }
}

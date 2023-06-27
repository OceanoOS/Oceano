using Cosmos.System;

namespace Oceano.Shell.Commands.ACPI
{
    public class Reboot : Command
    {
        public Reboot(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Power.Reboot();
            return "";
        }
    }
}

using Cosmos.System;

namespace Oceano.Shell.Commands.ACPI
{
    public class Shutdown : Command
    {
        public Shutdown(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Power.Shutdown();
            return "";
        }
    }
}

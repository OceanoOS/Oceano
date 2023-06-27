using Cosmos.Core;

namespace Oceano.Shell.Commands.ACPI
{
    public class Halt : Command
    {
        public Halt(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            CPU.Halt();
            return "";
        }
    }
}

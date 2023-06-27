using Cosmos.Core;

namespace Oceano.Shell.Commands.Time
{
    public class Uptime : Command
    {
        public Uptime(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            return CPU.GetCPUUptime().ToString();
        }
    }
}

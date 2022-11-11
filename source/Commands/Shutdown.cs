using System;

namespace Oceano.Commands
{
    public class Shutdown : Command
    {
        public Shutdown(String name) : base(name) { }
        public override String execute(String[] args)
        {
            Cosmos.System.Power.Shutdown();
            return "Shutdown";
        }

    }
}

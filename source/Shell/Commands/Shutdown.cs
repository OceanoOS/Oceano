using Cosmos.System;

namespace Oceano.Shell.Commands
{
    public class Shutdown : Command
    {
        public Shutdown(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Power.Shutdown();
            return "";
        }
    }
}

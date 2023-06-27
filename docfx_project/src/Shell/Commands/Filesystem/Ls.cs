using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Filesystem
{
    public class Ls : Command
    {
        public Ls(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Kernel.fs.GetDirectoryListing(Kernel.CurrentPath);
            return "";
        }
    }
}

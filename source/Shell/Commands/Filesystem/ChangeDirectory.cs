using System.IO;

namespace Oceano.Shell.Commands.Filesystem
{
    public class ChangeDirectory : Command
    {
        public ChangeDirectory(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (Directory.Exists(args[0]))
            {
                Directory.SetCurrentDirectory(args[0]);
            }
            return "";
        }
    }
}

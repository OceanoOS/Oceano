using System.IO;
using Kernel = Oceano.Core.Program;
namespace Oceano.Shell.Commands.Filesystem
{
    public class Move : Command
    {
        public Move(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (File.Exists(Kernel.CurrentPath + args[0]))
            {
                if (!File.Exists(args[1]))
                {
                    File.Copy(Kernel.CurrentPath + args[0], args[1]);
                    File.Delete(Kernel.CurrentPath + args[0]);
                }
            }
            return "";
        }
    }
}

using System.IO;
namespace Oceano.Shell.Commands.Filesystem
{
    public class Move : Command
    {
        public Move(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + args[0]))
            {
                if (!File.Exists(args[1]))
                {
                    File.Copy(Directory.GetCurrentDirectory() + args[0], args[1]);
                    File.Delete(Directory.GetCurrentDirectory() + args[0]);
                }
            }
            return "";
        }
    }
}

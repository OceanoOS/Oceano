using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.General
{
    public class ExecuteFile : Command
    {
        public ExecuteFile(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            ShellLanguage.Execute(Kernel.CurrentPath + args[0]);
            return "";
        }
    }
}

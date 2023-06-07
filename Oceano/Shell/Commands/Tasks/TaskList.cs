using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Tasks
{
    public class TaskList : Command
    {
        public TaskList(string name) : base(name)
        {

        }

        public override string Execute(string[] args)
        {
            foreach (var proc in Kernel.processManager.Tasks)
            {
                Console.WriteLine("Name: " + proc.Name);
                Console.WriteLine("Description: " + proc.Description);
                Console.WriteLine("Version: " + proc.Version);
                Console.WriteLine();
            }
            return "";
        }
    }
}

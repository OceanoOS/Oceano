using Oceano.Shell;
using System;

namespace Oceano.Tasks.Processes
{
    public class ShellProcess : Process
    {
        readonly CommandManager commandManager = new();
        public ShellProcess() : base("shellproc", "2.0.0", "Used for make shell working.", Priority.Medium)
        {

        }
        public override void Run()
        {
            Console.ResetColor();
            var input = Console.ReadLine();
            string response = commandManager.ProcessInput(input);
            Console.WriteLine(response);
        }
    }
}

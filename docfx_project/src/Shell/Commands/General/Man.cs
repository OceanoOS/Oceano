using System;

namespace Oceano.Shell.Commands.General
{
    public class Man : Command
    {
        public Man(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Oceano Help");
            Console.ResetColor();
            foreach (var command in Core.Shell.commandManager.commands)
            {
                Console.WriteLine(command.name + ": " + command.description);
            }
            return "";
        }
    }
}

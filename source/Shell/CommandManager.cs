using Oceano.Shell.Commands.General;
using System;
using System.Collections.Generic;

namespace Oceano.Shell
{
    public class CommandManager
    {
        public List<Command> commands;
        public CommandManager()
        {
            this.commands = new List<Command>
            {
                new("", ""),
                new Clear("clear", "Clear the console.")
            };
        }

        public string ProcessInput(string input)
        {
            string[] split = input.Split(' ');
            string label = split[0];

            List<string> args = new();

            int ctr = 0;
            foreach (string s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }
            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.Execute(args.ToArray());

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command " + label + " not found.");
            Console.ResetColor();
            return "";
        }
    }
}
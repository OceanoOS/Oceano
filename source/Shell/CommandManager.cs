using Oceano.Shell.Commands;
using System;
using System.Collections.Generic;

namespace Oceano.Shell
{

    public class CommandManager
    {
        private List<Command> commands;

        public CommandManager()
        {
            this.commands = new();
            this.commands.Add(new Info("info"));
            this.commands.Add(new Kbm("kbm"));
        }

        public String processInput(String input)
        {
            String[] split = input.Split(' ');
            String label = split[0];

            List<String> args = new List<String>();

            int ctr = 0;
            foreach (String s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.Invoke(args.ToArray());

            }
            return "Command \"" + label + "\" not found.";
        }
    }
}
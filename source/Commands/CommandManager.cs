using System;
using System.Collections.Generic;

namespace Oceano.Commands
{

    public class CommandManager
    {
        private readonly List<Command> commands;

        public CommandManager()
        {
            this.commands = new()
            {
                new(""),
                new Clear("clear"),
                new Touch("touch"),
                new Fs("fs")
            };
        }

        public String ProcessInput(String input)
        {
            String[] split = input.Split(' ');
            String label = split[0];

            List<String> args = new();

            int ctr = 0;
            foreach (String s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in this.commands) //this calls on the "commands" list we made up at the top. We are checking to see if the user entered a command that is on the list (like a bouncer)
            {
                if (cmd.name == label)//seeing if the command is on the list
                    return cmd.Execute(args.ToArray());

            }
            return "Command \"" + label + "\" not found.";
        }
    }
}
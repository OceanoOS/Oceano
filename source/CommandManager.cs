using System;
using System.Collections.Generic;

namespace Oceano
{

    public class CommandManager
    {
        private List<Command> commands;

        public CommandManager()
        {
            this.commands = new List<Command>(5);
            this.commands.Add(new Commands.Shutdown("shutdown"));
            this.commands.Add(new Commands.Reboot("reboot"));
            this.commands.Add(new Commands.Touch("touch"));
            this.commands.Add(new Commands.Delete("del"));
            this.commands.Add(new Commands.MakeDirectory("mkdir"));
            this.commands.Add(new Commands.DeleteDirectory("deldir"));
            this.commands.Add(new Commands.DirectoryListing("ls"));
            this.commands.Add(new Commands.DirectoryListing("dir"));
            this.commands.Add(new Commands.Cd("cd"));
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
                    return cmd.execute(args.ToArray());

            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Command \"" + label + "\" not found.";
        }
    }
}
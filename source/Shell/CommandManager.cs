using Oceano.Shell.Commands;
using System;
using System.Collections.Generic;

namespace Oceano.Shell
{

    public class CommandManager
    {
        private readonly List<Command> commands;

        public CommandManager()
        {
            this.commands = new()
            {
                new(""),
                new Kbm("kbm"),
                new VM("vmtools"),
                new Touch("touch"),
                new Del("del"),
                new Mkdir("mkdir"),
                new Rmdir("rmdir"),
                new Run("run"),
                new StartMIV("miv"),
                new Clear("clear"),
                new Ls("ls"),
                new Ls("dir"),
                new Cd("cd"),
                new Ipconfig("ipconfig"),
                new HtmlView("htmlview")
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

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.Invoke(args.ToArray());

            }
            return "Command \"" + label + "\" not found.";
        }
    }
}
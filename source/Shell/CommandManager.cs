using Oceano.Shell.Commands.General;
using System;
using System.Collections.Generic;
using Oceano.Shell.Commands.Time;
using Oceano.Shell.Commands.Disks;
using Oceano.Shell.Commands.Users;
using Oceano.Shell.Commands.Filesystem;

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
                new Echo("echo", "Print text in the screen."),
                new Clear("clear", "Clear the console."),
                new History("history", "View the command history."),
                new Date("date", "View the current date and time."),
                new Sleep("sleep", "Pause the console for a few seconds."),
                new Uptime("uptime", "Get the CPU Uptime."),
                new Man("man", "Get a list with the commands and the functions."),
                new ListDisk("lsblk", "Get a list of the disks."),
                new Format("mkfs", "Format a disk."),
                new UserAdd("adduser","Create a new user."),
                new Ls("ls", "Directory listing."),
                new Copy("cp", "Copy a file."),
                new Remove("rm", "Remove a file or a directory."),
                new Move("mv", "Move a file."),
                new Create("touch", "Create a new file."),
                new Read("cat", "Read all text in a file.")
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
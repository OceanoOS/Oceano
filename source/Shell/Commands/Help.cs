using System;

namespace Oceano.Shell.Commands
{
    public class Help : Command
    {
        public Help(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Oceano Commands");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("calc [int] [operation] [int]: do a basic math expression.");
            Console.WriteLine("cd [path]: change the working directory.");
            Console.WriteLine("clear: clear the console.");
            Console.WriteLine("del [path]: delete a file.");
            Console.WriteLine("echo [string]: write text on console.");
            Console.WriteLine("gui [resX] [resY]: start Oceano GUI.");
            Console.WriteLine("help: show this command.");
            Console.WriteLine("hostname [string]: change hostname.");
            Console.WriteLine("htmlview [path]: parse a html file.");
            Console.WriteLine("kbm: set a keyboard layout.");
            Console.WriteLine("ls: get a directory listing.");
            Console.WriteLine("mkdir [path]: create a directory.");
            Console.WriteLine("neofetch: show information of system.");
            Console.WriteLine("reboot: do a acpi reboot.");
            Console.WriteLine("rmdir: remove a directory.");
            Console.WriteLine("run [path]: run a batch file.");
            Console.WriteLine("shutdown: do a acpi shutdown.");
            Console.WriteLine("miv [path]: start the MIV editor.");
            Console.WriteLine("user: user manager.");
            Console.WriteLine("vmtools: show if you are running oceano in a virtual machine.");
            return "";
        }
    }
}

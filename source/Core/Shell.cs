using Oceano.Shell;
using System;
using System.Collections.Generic;
using System.IO;

namespace Oceano.Core
{
    public static class Shell
    {
        public static CommandManager commandManager = new();
        public static List<string> history = new();
        public static void Update()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.Username);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.Host);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":" + Directory.GetCurrentDirectory());
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (Program.Username == "root")
            {
                Console.Write("# ");
            }
            else
            {
                Console.Write("$ ");
            }
            Console.ResetColor();
            string input = Console.ReadLine();
            string response = commandManager.ProcessInput(input);
            if (response != "")
            {
                Console.WriteLine(response);
            }
            if (input != "")
            {
                history.Add(input);
            }
        }
    }
}

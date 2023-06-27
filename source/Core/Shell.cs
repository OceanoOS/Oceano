using Oceano.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Core
{
    public static class Shell
    {
        public static CommandManager commandManager = new();
        public static List<string> history = new();
        public static void Update()
        {
            Console.WriteLine();
            Console.Write(">");
            string input = Console.ReadLine();
            string response = commandManager.ProcessInput(input);
            if (response != "")
            {
                Console.WriteLine(response);
            }
            history.Add(input);
        }
    }
}

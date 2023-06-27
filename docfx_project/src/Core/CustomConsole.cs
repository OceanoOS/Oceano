using System;

namespace Oceano.Core
{
    public static class CustomConsole
    {
        public static void PrintInfo(string message, bool newline = true)
        {
            if (newline)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("INFO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] " + message);
        }
        public static void PrintSuccess(string message, bool newline = true)
        {
            if (newline)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] " + message);
        }
        public static void PrintError(string message, bool newline = true)
        {
            if (newline)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] " + message);
        }
        public static void PrintWarning(string message, bool newline = true)
        {
            if (newline)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("WARN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] " + message);
        }
        public static void PrintCustom(string message, string title, ConsoleColor foreground, bool newline = true)
        {
            if (newline)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = foreground;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] " + message);
        }
    }
}

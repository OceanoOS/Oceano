using System;

namespace Oceano.Core
{
    /// <summary>
    /// CustomConsole, used for printing info, errors and warnings easily.
    /// </summary>
    public static class CustomConsole
    {
        /// <summary>
        /// Print a information.
        /// </summary>
        /// <param name="message">Message of the information</param>
        /// <param name="newline">Check if the console should write a new line.</param>
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
        /// <summary>
        /// Print a sucess action.
        /// </summary>
        /// <param name="message">Message of the sucess</param>
        /// <param name="newline">Check if the console should write a new line.</param>
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
        /// <summary>
        /// Print an error.
        /// </summary>
        /// <param name="message">Message of the error</param>
        /// <param name="newline">Check if the console should write a new line.</param>
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
        /// <summary>
        /// Print a warning.
        /// </summary>
        /// <param name="message">Message of the warning</param>
        /// <param name="newline">Check if the console should write a new line.</param>
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
        /// <summary>
        /// Print a custom message.
        /// </summary>
        /// <param name="message">Text of the message.</param>
        /// <param name="title">Title of the message.</param>
        /// <param name="foreground">Foreground color of the message.</param>
        /// <param name="newline">Check if the console should write a new line.</param>
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

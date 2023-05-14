using System;

namespace Oceano.Core
{
    public static class Console
    {
        public static void Print(string text, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.Write(text);
            System.Console.ResetColor();
        }
        public static void PrintLine(string text, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(text);
            System.Console.ResetColor();
        }
    }
}

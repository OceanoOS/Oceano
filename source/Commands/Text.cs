using System;

namespace Oceano.Commands
{
    public class Text
    {
        static readonly int total = (int)Cosmos.Core.CPU.GetAmountOfRAM();
        static readonly string cpu = Cosmos.Core.CPU.GetCPUBrandString();

        public static void Clear()
        {
            Console.Clear();
        }
        public static void Calculator()
        {
            int num1 = 0;
            int num2 = 0;
            // Ask the user to type the first number.  
            Console.Write("Number 1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            // Ask the user to type the second number.  
            Console.Write("Number 2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            // Ask the user to choose an option.  
            Console.WriteLine("Operation:");
            Console.WriteLine("\ta - Add (+)");
            Console.WriteLine("\ts - Subtract (-)");
            Console.WriteLine("\tm - Multiply (*)");
            Console.WriteLine("\td - Divide (/)");
            Console.Write("");
            // Use a switch statement to do the math.  
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine("Your result: = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine("Your result: = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine("Your result: = " + num1 * num2);
                    break;
                case "d":
                    Console.WriteLine("Your result: = " + num1 / num2);
                    break;
            }
        }
        public static void Info()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"  _.====.._               "); Console.Write("   Oceano");
            Console.WriteLine();
            Console.Write(@" ,:._       ~-_           "); Console.ForegroundColor = ConsoleColor.White; Console.Write("   ----------"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"    `\        ~-_         "); Console.Write("   OS: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("Oceano beta1 x86/x64"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"      |          `.       "); Console.Write("   Host: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("oceano"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"     /            ~-_     "); Console.Write("   Kernel: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("Cosmos Dev Kit v106027"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"..-''               ~~--.."); Console.Write("   Shell: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("Wave Shell 1.0"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"                          "); Console.Write("   Resolution: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("640x480@32"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"                          "); Console.Write("   CPU: "); Console.ForegroundColor = ConsoleColor.White; Console.Write(cpu); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write(@"                          "); Console.Write("   Memory: "); Console.ForegroundColor = ConsoleColor.White; Console.Write(total + "MB"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
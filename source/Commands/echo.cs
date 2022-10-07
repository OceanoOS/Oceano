using System;

namespace Oceano.Commands
{
    public class echo
    {
        public static void Init()
        {
            Console.Write("Text to echo");
            var input = Console.ReadLine;
            Console.WriteLine(input);
        }
    }
}

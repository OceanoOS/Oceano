using System;
using System.IO;

namespace Oceano.Commands
{
    public class cd
    {
        public static void Init()
        {
            Console.Write("Move to: ");
            var input = Console.ReadLine();
            if (Directory.Exists(input))
            {
                Boot.Kernel.path = input;
            }
        }
    }
}

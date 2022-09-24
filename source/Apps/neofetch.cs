using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Apps
{
    public class neofetch
    {
        public static void init() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  _.====.._               "); Console.Write("   root"); Console.ForegroundColor = ConsoleColor.White;Console.Write("@");Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("oceano");
            Console.WriteLine(@" ,:._       ~-_           "); Console.ForegroundColor = ConsoleColor.White; Console.Write("----------");
            Console.WriteLine(@"    `\        ~-_         "); Console.Write("   OS: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("Oceano beta1 x86/x64"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"      |          `.       "); Console.Write("   Host: "); Console.ForegroundColor = ConsoleColor.White; Console.Write("oceano"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"     /            ~-_     "); Console.Write("");
            Console.WriteLine(@"..-''               ~~--..");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

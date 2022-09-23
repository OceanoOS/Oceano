using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Apps
{
    public class echo
    {
        public static void Write(ConsoleColor color, String text)
        {
            Console.ForegroundColor= color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLine(ConsoleColor color, String text)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

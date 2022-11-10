using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Drivers
{
    public class ErrorScreen
    {
        public static void PrintErrorScreen(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("An error occurred in your device and needs to shutdown. Error: " + message);
        }
    }
}

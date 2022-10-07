using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class cd
    {
        public static void Init()
        {
            Console.Write("Move to: ");
            var input=Console.ReadLine();
            if (Directory.Exists(input))
            {
                Boot.Kernel.path = input;
            }
        }
    }
}

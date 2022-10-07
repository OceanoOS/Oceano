using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class touch
    {
        public static void Init()
        {
            Console.Write("File name: ");
            var input = Console.ReadLine();
            try
            {
                var file_stream = File.Create(Boot.Kernel.path+input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

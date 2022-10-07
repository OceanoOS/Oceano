using System;
using System.IO;

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
                var file_stream = File.Create(Boot.Kernel.path + input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

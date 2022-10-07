using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class help
    {
        public static void Init()
        {
            Console.WriteLine("======Help======");
            Console.WriteLine("help: show this message");
            Console.WriteLine("calc: open calculator");
            Console.WriteLine("miv: open a file text editor");
            Console.WriteLine("shutdown: do a cpu shutdown");
            Console.WriteLine("reboot: do a cpu reboot");
            Console.WriteLine("neofetch: show some information about the system");
            Console.WriteLine("touch: create a new file");
            Console.WriteLine("dir: show the directory listing of the current folder");

        }
    }
}

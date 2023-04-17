using Oceano.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Gui : Command
    {
        public Gui(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            try
            {
                Graphics.Init(Convert.ToUInt16(args[0]), Convert.ToUInt16(args[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return "";
        }
    }
}

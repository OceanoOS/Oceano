using Oceano.GUI;
using System;

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

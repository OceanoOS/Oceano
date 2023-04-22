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
                Graphics.Init(800, 600);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return "";
        }
    }
}

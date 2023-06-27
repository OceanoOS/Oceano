using Oceano.Core;
using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Apps
{
    public class MIVEditor : Command
    {
        public MIVEditor(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                switch (args[0])
                {
                    case "": Console.WriteLine("Usage: miv [filename]"); break;
                    default: MIV.MIV.StartMIV(Kernel.CurrentPath + args[0]); break;
                }
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while executing MIV: " + ex.Message);
            }
            return "";
        }
    }
}

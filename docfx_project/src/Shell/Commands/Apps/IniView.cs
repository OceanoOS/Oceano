using Oceano.Core;
using Oceano.Utilities;
using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Apps
{
    public class IniView : Command
    {
        public IniView(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            try
            {
                IniParser parser = new();
                parser.Parse(Kernel.CurrentPath + args[0]);
                foreach (var section in parser.sections)
                {
                    Console.WriteLine("Sections:");
                    Console.WriteLine(section.Value);
                    Console.WriteLine("Keys:");
                    Console.WriteLine(section.Key);
                }
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while parsing: " + ex.Message);
            }
            return base.Execute(args);
        }
    }
}

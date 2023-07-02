using Oceano.Core;

namespace Oceano.Shell.Commands.Graphics
{
    public class Start : Command
    {
        public Start(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "svgaii":
                        switch (args[1])
                        {
                            default: break;
                            case "": CustomConsole.PrintError("You must specify a resolution."); break;
                        }
                        break;
                    case "vbe": break;

                }
            }
            else
            {

            }
            return "";
        }
    }
}

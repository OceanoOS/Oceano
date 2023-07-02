using Oceano.Core;
using Oceano.GUI;
using Oceano.Services;
using System;

namespace Oceano.Shell.Commands.Graphics
{
    public class Start : Command
    {
        public Start(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            bool mouse = true;
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "disablemouse":
                        mouse = false;
                        break;
                    case "enablemouse":
                        mouse = true;
                        break;
                }
                switch (args[1])
                {
                    case "svgaii":
                        switch (args[2])
                        {
                            default:
                                if (mouse)
                                {
                                    WindowManager.Initialize("svgaii", true, Convert.ToUInt16(args[2]), Convert.ToUInt16(args[3]));
                                }
                                else
                                {
                                    WindowManager.Initialize("svgaii", false, Convert.ToUInt16(args[2]), Convert.ToUInt16(args[3]));
                                }
                                break;
                            case "": CustomConsole.PrintError("You must specify a resolution."); break;
                        }
                        break;
                    case "vbe":
                        if (mouse == true)
                        {
                            WindowManager.Initialize("vbe", true);
                        }
                        else
                        {
                            WindowManager.Initialize("vbe", false);
                        }
                        break;
                }
            }
            BootManager.shellprocess.Kill();
            TaskManager.RegisterTask(BootManager.owm);
            return "";
        }
    }
}

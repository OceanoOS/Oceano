using Oceano.Utilities;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands.Apps
{
    public class HTMLView : Command
    {
        public HTMLView(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            string response;
            switch (args[0])
            {
                default:
                    try
                    {
                        HTMLParser.ParseHtml(File.ReadAllText(Kernel.CurrentPath + args[0]));
                        response = "";
                    }
                    catch (Exception e)
                    {
                        response = e.Message;
                    }
                    break;
                case "":
                    response = "Usage: htmlview [filename]";
                    break;
            }
            return response;
        }
    }
}

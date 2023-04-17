using CosmosHTML;
using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class HtmlView : Command
    {
        public HtmlView(string name) : base(name) { }
        public override string Invoke(string[] args)
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

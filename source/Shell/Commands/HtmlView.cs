using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kernel = Oceano.Core.Program;
using System.Threading.Tasks;
using CosmosHTML;
using System.IO;

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
                case "": response = "Usage: htmlview [filename]";
                    break;
            }
            return response;
        }
    }
}

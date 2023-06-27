using Cosmos.System;
using Cosmos.System.ScanMaps;

namespace Oceano.Shell.Commands.General
{
    public class SetKbMap : Command
    {
        public SetKbMap(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            switch (args[0])
            {
                case "us": KeyboardManager.SetKeyLayout(new USStandardLayout()); break;
                case "de": KeyboardManager.SetKeyLayout(new DEStandardLayout()); break;
                case "fr": KeyboardManager.SetKeyLayout(new FRStandardLayout()); break;
                case "tr": KeyboardManager.SetKeyLayout(new TRStandardLayout()); break;
                case "gb": KeyboardManager.SetKeyLayout(new GBStandardLayout()); break;
                case "es": KeyboardManager.SetKeyLayout(new ESStandardLayout()); break;
                case "it": KeyboardManager.SetKeyLayout(new ITStandardLayout()); break;
                default:
                    System.Console.WriteLine("us = American, de = German, fr = French, tr = Turkish, gb = English, es = Spanish, it = Italian");
                    break;
            }
            return "";
        }
    }
}

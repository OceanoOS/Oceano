using Cosmos.System;
using Cosmos.System.ScanMaps;

namespace Oceano.Shell.Commands
{
    public class Kbm : Command
    {
        public Kbm(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            switch (args[0])
            {
                default:
                    response = "Use this command to change the keyboard layout, using 'setlayout'.";
                    break;
                case "ver":
                    response = "Kbm version 1.0.0, (c) 2023 Cosmos.";
                    break;
                case "setlayout":
                    switch (args[1])
                    {
                        default:
                            response = "us = American, fr = French, de = German, tr = Turkish, es = Spanish, gb = British";
                            break;
                        case "us":
                            KeyboardManager.SetKeyLayout(new USStandardLayout());
                            response = "US keyboard setting saved.";
                            break;
                        case "fr":
                            KeyboardManager.SetKeyLayout(new FRStandardLayout());
                            response = "FR keyboard setting saved.";
                            break;
                        case "de":
                            KeyboardManager.SetKeyLayout(new DEStandardLayout());
                            response = "DE keyboard setting saved.";
                            break;
                        case "tr":
                            KeyboardManager.SetKeyLayout(new TRStandardLayout());
                            response = "TR keyboard setting saved.";
                            break;
                        case "es":
                            KeyboardManager.SetKeyLayout(new ESStandardLayout());
                            response = "ES keyboard setting saved.";
                            break;
                        case "gb":
                            KeyboardManager.SetKeyLayout(new GBStandardLayout());
                            response = "GB keyboard setting saved.";
                            break;
                    }
                    break;
            }
            return response;
        }
    }
}
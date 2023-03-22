using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Run : Command
    {
        public Run(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            switch (args[0])
            {
                default:
                    try
                    {
                        Batch.Execute(Kernel.CurrentPath + args[0]);
                        response = "";
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                    break;
                case "":
                    response = "An utility to execute a batch file";
                    break;
                case "help":
                    response = "An utility to execute a batch file";
                    break;
                case "ver":
                    response = "RunABatch version 1.0.0 (c) 2023 Oceano.";
                    break;
            }
            return response;
        }
    }
}

using Cosmos.Core.Memory;

namespace Oceano.Shell.Commands
{
    public class StartMIV : Command
    {
        public StartMIV(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            switch (args[0])
            {
                default:
                    MIV.MIV.StartMIV(args[0]);
                    response = "";
                    break;
                case "":
                    response = "Usage: miv [filename]";
                    break;
                case "ver":
                    response = "MIV Version 1.2. Made by bartashevich.";
                    break;
            }
            Heap.Collect();
            return response;
        }
    }
}

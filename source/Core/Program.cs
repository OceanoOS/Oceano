using Cosmos.Core;
using Sys = Cosmos.System;
using System;
using Oceano.Shell;

namespace Oceano.Core
{
    public class Program : Sys.Kernel
    {
        public static string Name = "Oceano";
        public static string Version = "1.0.0";
        public static string TotalRam = CPU.GetAmountOfRAM().ToString();
        public static string CpuName = CPU.GetCPUBrandString();
        public static string CpuVendor = CPU.GetCPUVendorName();
        public CommandManager commandManager;
        protected override void BeforeRun()
        {

        }

        protected override void Run()
        {
            String repsonse;
            String input = Console.ReadLine();
            repsonse = this.commandManager.processInput(input);
            Console.WriteLine(repsonse);
        }
    }
}

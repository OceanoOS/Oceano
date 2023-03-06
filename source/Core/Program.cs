using Cosmos.Core;
using Sys = Cosmos.System;
using Oceano.GUI;
using System;

namespace Oceano.Core
{
    public class Program : Sys.Kernel
    {
        public static string Name = "Oceano";
        public static string Version = "1.0.0";
        public static string TotalRam = CPU.GetAmountOfRAM().ToString();
        public static string CpuName = CPU.GetCPUBrandString();
        public static string CpuVendor = CPU.GetCPUVendorName();

        public static bool GraphicalMode;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Wich mode you want to use?");
            Console.WriteLine("Warning: Select Graphical Mode only if you are on VMWare or you are using a VMSVGA graphics card. For more info, Read the Wiki.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Graphical Mode");
            Console.WriteLine("2. Console Mode");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Graphics.Init(1024, 768, true);
                    GraphicalMode = true;
                break;
                case "2":
                    GraphicalMode = false;
                    break;
            }
        }

        protected override void Run()
        {
            if(GraphicalMode == true)
            {
                Graphics.Update();
            }
            else
            {
                Console.WriteLine("Not on Graphical Mode.");
            }
        }
    }
}

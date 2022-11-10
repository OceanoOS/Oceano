using Cosmos.System.Graphics;
using Sys = Cosmos.System;
using System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Oceano.Graphics;
using Cosmos.HAL;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static uint ram;
        public static string cpu;
        public static string name;
        public static CosmosVFS fs = new();
        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs,true,true);
            ram = Cosmos.Core.CPU.GetAmountOfRAM();
            cpu = Cosmos.Core.CPU.GetCPUBrandString();
            name=Cosmos.Core.CPU.GetCPUVendorName();
            Drivers.Display.InitSVGA();
        }
        protected override void Run()
        {
        }
        protected override void OnBoot()
        {
            try
            {
                Sys.Global.Init(GetTextScreen(), true, true, true, true);
                Console.ForegroundColor = ConsoleColor.Green ;
                Console.WriteLine("Drivers booted successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Drivers.ErrorScreen.PrintErrorScreen(ex.Message);
            }
        }
    }
}

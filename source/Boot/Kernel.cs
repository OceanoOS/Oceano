using Cosmos.System.Graphics;
using Sys = Cosmos.System;
using System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Oceano.Graphics;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static uint ram;
        public static string cpu;
        public static CosmosVFS fs = new();
        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs,true,true);
            ram = Cosmos.Core.CPU.GetAmountOfRAM();
            cpu = Cosmos.Core.CPU.GetCPUBrandString();
            Drivers.Display.InitVBE();
        }
        protected override void Run()
        {
            
        }
    }
}

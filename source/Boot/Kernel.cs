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
        public static Canvas canvas;
        public static uint ram;
        public static string cpu;
        public static CosmosVFS fs = new();
        public static bool FsEnabled;
        protected override void BeforeRun()
        {
            ram = Cosmos.Core.CPU.GetAmountOfRAM();
            cpu = Cosmos.Core.CPU.GetCPUBrandString();
            SVGAII.Init();
        }

        protected override void Run()
        {
        }
    }
}

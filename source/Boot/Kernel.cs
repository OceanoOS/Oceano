using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static string path;
        public static uint ram;
        public static string cpu;
        protected override void BeforeRun()
        {
            ram = Cosmos.Core.CPU.GetAmountOfRAM();
            cpu = Cosmos.Core.CPU.GetCPUBrandString();
            Graphics.VGA.Init();
            Graphics.VGA.x = 640;
            Graphics.VGA.y = 480;
        }

        protected override void Run()
        {
            Graphics.VGA.Update();
        }
    }
}

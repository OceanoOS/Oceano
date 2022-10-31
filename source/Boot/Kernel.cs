using Cosmos.System.Graphics;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;
        public static uint ram;
        public static string cpu;
        protected override void BeforeRun()
        {
            ram = Cosmos.Core.CPU.GetAmountOfRAM();
            cpu = Cosmos.Core.CPU.GetCPUBrandString();
            Graphics.VGA.x = 800;
            Graphics.VGA.y = 600;
            Graphics.VGA.Init();
        }

        protected override void Run()
        {
            Graphics.VGA.Update();
        }
    }
}

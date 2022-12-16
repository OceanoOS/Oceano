using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;

namespace Oceano
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fs = new();
        public static Canvas canvas;

        protected override void BeforeRun()
        {
            Gui.Graphics.Init();
        }
        protected override void OnBoot()
        {
            Sys.Global.Init(GetTextScreen(), false, true, true, true);
        }
        protected override void Run()
        {

        }
    }
}

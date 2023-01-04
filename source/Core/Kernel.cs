using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using Oceano.Gui;
using Sys = Cosmos.System;

namespace Oceano.Core
{
    public class Kernel : Sys.Kernel
    {
        OceanoDE Desktop = new();

        protected override void BeforeRun()
        {
            Desktop.Init();
        }
        protected override void Run()
        {
            Desktop.Update();
        }
    }
}

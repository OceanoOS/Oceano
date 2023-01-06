using Oceano.Gui;
using Sys = Cosmos.System;

namespace Oceano.Core
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Graphics.Init();
        }
        protected override void Run()
        {
            Graphics.Update();
        }
    }
}

using System;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Graphics.SVGAII.Init();
        }
        protected override void Run()
        {
        }
        protected override void OnBoot()
        {
            Sys.Global.Init(GetTextScreen(),true,true,true,true);
        }
    }
}

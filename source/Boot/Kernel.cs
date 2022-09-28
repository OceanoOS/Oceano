using Oceano.Apps;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {


        protected override void BeforeRun()
        {
            Apps.neofetch.init();
        }

        protected override void Run()
        {
            
        }
    }
}

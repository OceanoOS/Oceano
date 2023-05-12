using Cosmos.System;
using Oceano.Core.VideoConsole;
using Sys = Cosmos.System;

namespace Oceano.Core
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            try
            {
                VBEConsole.Initialise();
            }
            catch
            {

            }
        }
        protected override void Run()
        {
        }
    }
}

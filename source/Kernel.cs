using Cosmos.Core.Memory;
using Cosmos.Core;
using Oceano.Gui;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Oceano
{
    public unsafe class Kernel : Sys.Kernel
    {
        public static readonly Graphics graphics = new();
        protected override void BeforeRun()
        {
            if (HeapSmall.SMT == null) GCImplementation.Init();
            graphics.InitWithDrivers();
        }
        
        protected override void Run()
        {
            
        }
    }
}

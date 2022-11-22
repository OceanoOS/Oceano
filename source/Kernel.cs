using Sys = Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.System;
using Cosmos.Core.Memory;
using IL2CPU.API.Attribs;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace Oceano
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS fs = new();

        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs);
            Drivers.VGA.Init();
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

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

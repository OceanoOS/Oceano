using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static string path;
        protected override void BeforeRun()
        {
            Graphics.VGA.Init();
        }

        protected override void Run()
        {
            Graphics.VGA.Update();
        }
    }
}

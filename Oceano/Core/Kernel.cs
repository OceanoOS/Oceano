using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
using System;
using System.IO;
using Cosmos.System.FileSystem.VFS;
using System.Threading;
using Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.HAL;
using Cosmos.System.Graphics;
using Oceano.Gui;

namespace Oceano.Core
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fs = new();
        public static bool FileSystemEnabled;

        public static Graphics graphics = new();
        protected override void BeforeRun()
        {
            try
            {
                VFSManager.RegisterVFS(fs);
                FileSystemEnabled = true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                FileSystemEnabled = false;
            }
            WindowManager.Init();
        }

        protected override void Run()
        {
            WindowManager.Update();
        }
    }
}

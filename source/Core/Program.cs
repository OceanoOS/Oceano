using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Oceano.GUI;
using Oceano.Shell;

namespace Oceano.Core
{
    public class Program : Kernel
    {
        public static string Name { get; set; } = "Oceano";
        public static string Version { get; set; } = "1.0.0";
        public static CosmosVFS FileSystem { get; set; } = new();
        public static CommandManager CommandManager { get; set; } = new();
        public static Graphics Graphics { get; set; } = new(true);
        protected override void BeforeRun()
        {

        }

        protected override void Run()
        {
            Graphics.Update();
        }
    }
}

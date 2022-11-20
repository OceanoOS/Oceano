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
        public static int screenWidth = 640;
        public static int screenHeight = 480;
        public static bool Pressed;
        public static Canvas canvas;
        public static List<App> apps = new();
        public static Color avgCol = Color.Cyan;
        public static Bitmap programlogo = new(Resources.program);
        public static CosmosVFS fs = new();
        readonly Dock dock = new();
        readonly Files files = new(300, 200, 20, 20);


        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs, false, true);
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Mode = new(screenWidth, screenHeight, ColorDepth.ColorDepth32);
            canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)screenWidth;
            MouseManager.ScreenHeight = (uint)screenHeight;
            MouseManager.X = (uint)screenWidth / 2;
            MouseManager.Y = (uint)screenHeight / 2;
            apps.Add(files);
        }
        protected override void OnBoot()
        {
            Sys.Global.Init(GetTextScreen(), false, true, true, true);
        }
        protected override void Run()
        {
            Heap.Collect();
            switch (MouseManager.MouseState)
            {
                case MouseState.Left:
                    Pressed = true;
                    break;
                case MouseState.None:
                    Pressed = false;
                    break;
            }
            foreach (App app in apps)
                app.Update();
            dock.Update();
            canvas.DrawLine(new(Color.White), (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X + 6, (int)Cosmos.System.MouseManager.Y);
            canvas.DrawLine(new(Color.White), (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 6);
            canvas.DrawLine(new(Color.White), (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X + 12, (int)Cosmos.System.MouseManager.Y + 12);
            canvas.Display();
            canvas.Clear(Color.Black);
        }
    }
}

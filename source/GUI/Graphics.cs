using Cosmos.Core.Memory;
using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Extentions.VMWare;
using System.Collections.Generic;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Graphics
    {
        static readonly int[] cursor = new int[]
           {
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,2,1,0,0,0,0,0,0,0,0,0,
                1,2,2,1,0,0,0,0,0,0,0,0,
                1,2,2,2,1,0,0,0,0,0,0,0,
                1,2,2,2,2,1,0,0,0,0,0,0,
                1,2,2,2,2,2,1,0,0,0,0,0,
                1,2,2,2,2,2,2,1,0,0,0,0,
                1,2,2,2,2,2,2,2,1,0,0,0,
                1,2,2,2,2,2,2,2,2,1,0,0,
                1,2,2,2,2,2,2,2,2,2,1,0,
                1,2,2,2,2,2,2,2,2,2,2,1,
                1,2,2,2,2,2,2,1,1,1,1,1,
                1,2,2,2,1,2,2,1,0,0,0,0,
                1,2,2,1,0,1,2,2,1,0,0,0,
                1,2,1,0,0,1,2,2,1,0,0,0,
                1,1,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,0,1,1,0,0,0
           };
        public static List<App> apps = new(Kernel.Canvas.Width / 40);
        public static void Init(ushort Width, ushort Height)
        {
            Kernel.Canvas = new(Width, Height);
            MouseManager.ScreenWidth = Width;
            MouseManager.ScreenHeight = Height;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
            Kernel.GraphicsMode = true;
            apps.Add(new Clock());
            apps.Add(new Notepad());
            apps.Add(new Information());
        }
        public static void Update()
        {
            Kernel.Canvas.Clear(Color.Black);
            foreach (App app in apps)
            {
                app.Update();
            }
            Taskbar.Update();
            DrawCursor(Kernel.Canvas, (int)MouseManager.X, (int)MouseManager.Y);
            Heap.Collect();
            Kernel.Canvas.Update();
        }
        static void DrawCursor(SVGAIICanvas Canvas, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        Canvas[w + x, h + y] = Color.Black;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        Canvas[w + x, h + y] = Color.White;
                    }
                }
            }
        }
    }
}

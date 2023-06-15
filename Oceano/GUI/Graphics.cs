using Cosmos.System;
using PrismAPI.Hardware.GPU;
using Kernel = Oceano.Core.Program;
using PrismAPI.Graphics;
using IL2CPU.API.Attribs;
using Cosmos.Core.Memory;

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
        public static void Initialize()
        {
            Kernel.display = Display.GetDisplay(1024, 768);
            MouseManager.ScreenWidth = Kernel.display.Width;
            MouseManager.ScreenHeight = Kernel.display.Height;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
        }
        public static void Update()
        {
            Kernel.display.Clear();
            DrawCursor(Kernel.display, (int)MouseManager.X, (int)MouseManager.Y);
            Kernel.display.Update();
        }
        static void DrawCursor(Display display, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        display[w + x, h + y] = Color.White;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        display[w + x, h + y] = Color.Black;
                    }
                }
            }
        }
    }
}
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using Kernel = Oceano.Core.Program;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.Core.Memory;
using Oceano.Core.Graphics;

namespace Oceano.GUI
{
    public static class Graphics
    {
        public static uint Width;
        public static uint Height;
        public static Bitmap wallpaper = new(Resources.wallpaper);
        public static Bitmap programlogo = new(Resources.program);
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
        public static Dock dock = new();
        public static List<App> apps = new();
        public static void Init()
        {
            Kernel.VMWareSVGAII = new();
            Kernel.VMWareSVGAII.SetMode(800, 600, 32);
            Width = 800;
            Height = 600;
            MouseManager.ScreenWidth = Width;
            MouseManager.ScreenHeight = Height;
            MouseManager.X = Width / 2;
            MouseManager.Y = Height / 2;
            apps.Add(new(300, 200, 20, 30));
        }
        public static void Update()
        {
            Kernel.VMWareSVGAII.Clear((uint)Color.Black.ToArgb());
            dock.Update();
            foreach(App app in apps) { app.Update(); }
            DrawCursor(Kernel.VMWareSVGAII,MouseManager.X,MouseManager.Y);
            Heap.Collect();
            Kernel.VMWareSVGAII.DoubleBufferUpdate();
        }
        public static void DrawCursor(VMWareSVGAII vMWareSVGAII, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vMWareSVGAII.SetPixel(w + x, h + y, (uint)Color.White.ToArgb());
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        vMWareSVGAII.SetPixel(w + x, h + y, (uint)Color.Black.ToArgb());
                    }
                }
            }
        }
    }
}

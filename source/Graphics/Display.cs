using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class Display
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.program.bmp")]
        public static byte[] program;
        public static Bitmap programlogo = new(program);
        public static DoubleBufferedVMWareSVGAII vMWareSVGAII;
        public static uint screenWidth = 640;
        public static uint screenHeight = 480;
        public static List<App> apps = new List<App>();
        static int[] cursor = new int[]
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
        static Settings settings = new(400,200,10,20);
        static Files files = new(400, 200, 10, 20);
        static Notepad notepad = new(400, 200, 10, 20);

        static Dock dock = new();
        public static void Init()
        {
            vMWareSVGAII = new DoubleBufferedVMWareSVGAII();
            vMWareSVGAII.SetMode(screenWidth, screenHeight);
            MouseManager.ScreenWidth = screenWidth;
            MouseManager.ScreenHeight = screenHeight;
            apps.Add(settings);
            apps.Add(files);
            apps.Add(notepad);
            Update();
        }
        static void Update()
        {
            foreach (App app in apps)
                app.Update();

            dock.Update();
            DrawCursor(vMWareSVGAII, MouseManager.X, MouseManager.Y);
            vMWareSVGAII.DoubleBuffer_Update();
            vMWareSVGAII.DoubleBuffer_Clear((uint)Color.Black.ToArgb());
            Heap.Collect();
            Update();
        }
        public static void DrawCursor(DoubleBufferedVMWareSVGAII vMWareSVGAII, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vMWareSVGAII.DoubleBuffer_SetPixel(w + x, h + y, (uint)Color.Black.ToArgb());
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        vMWareSVGAII.DoubleBuffer_SetPixel(w + x, h + y, (uint)Color.White.ToArgb());
                    }
                }
            }
        }
    }
}

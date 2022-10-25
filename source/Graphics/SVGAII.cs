using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace Oceano.Graphics
{
    public class SVGAII
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        static byte[] file;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.console.bmp")]
        static byte[] file1;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.shutdown.bmp")]
        static byte[] file2;
        public static DoubleBufferedVMWareSVGAII vMWareSVGAII;
        public static bool Pressed;
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
        public static Bitmap wallpaper = new(file);
        public static Bitmap console = new(file1);
        public static Bitmap shutdown = new(file2);
        static string time;
        public static void Init()
        {
            vMWareSVGAII = new DoubleBufferedVMWareSVGAII();
            vMWareSVGAII.SetMode(640, 480);
            MouseManager.ScreenWidth = 640;
            MouseManager.ScreenHeight = 480;
            vMWareSVGAII.DoubleBuffer_Update();
            Update();
        }
        public static void Update()
        {
            switch (MouseManager.MouseState)
            {
                case MouseState.Left:
                    Pressed = true;
                    break;
                case MouseState.None:
                    Pressed = false;
                    break;
            }
            time = DateTime.Now.ToString();
            vMWareSVGAII.DoubleBuffer_Update();
            vMWareSVGAII.DoubleBuffer_DrawImage(wallpaper, 0, 0);
            vMWareSVGAII.DoubleBuffer_DrawFillRectangle(0, 0, 640, 16, (uint)Color.Black.ToArgb());
            vMWareSVGAII.DoubleBuffer_DrawImage(console,0,0);
            vMWareSVGAII.DoubleBuffer_DrawImage(shutdown, 20, 0);
            if (Pressed)
            {
                if(MouseManager.X>=0 & MouseManager.Y >=0 & MouseManager.X <= 16 & MouseManager.Y <= 16)
                {
                    vMWareSVGAII.Disable();
                    Commands.Shell.BeforeRun();
                }
                if(MouseManager.X>20 & MouseManager.X <= 36 & MouseManager.Y > 0 & MouseManager.Y <= 16)
                {
                    Cosmos.System.Power.Shutdown();
                }
            }
            vMWareSVGAII._DrawACSIIString(time, (uint)Color.White.ToArgb(), 480, 0);
            DrawCursor(vMWareSVGAII, (uint)MouseManager.X, (uint)MouseManager.Y);
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

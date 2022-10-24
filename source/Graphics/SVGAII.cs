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
        static Bitmap bitmap = new(file);
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
            time = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString();
            vMWareSVGAII.DoubleBuffer_Update();
            vMWareSVGAII.DoubleBuffer_DrawImage(bitmap, 0, 0);
            vMWareSVGAII.DoubleBuffer_DrawFillRectangle(0, 0, 640, 16, (uint)Color.Black.ToArgb());
            vMWareSVGAII._DrawACSIIString("Console", (uint)Color.White.ToArgb(), 0, 0);
            string text = "Console";
            uint strX = 2;
            uint strY = (20 - 16) / 2;
            if (Pressed)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    vMWareSVGAII.Disable();
                    Commands.Shell.BeforeRun();
                }
            }
            vMWareSVGAII._DrawACSIIString(time, (uint)Color.White.ToArgb(), 560, 0);
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

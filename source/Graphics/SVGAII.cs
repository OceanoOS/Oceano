using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using nifanfa.CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class SVGAII
    {
        public static VMWareSVGAII sVGAII;
        public static uint screenWidth = 800;
        public static uint screenHeight= 600;
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
        public static void Init()
        {
            sVGAII = new VMWareSVGAII();
            sVGAII.SetMode(screenWidth, screenHeight);
            sVGAII.DoubleBufferUpdate();

            MouseManager.ScreenWidth = screenWidth;
            MouseManager.ScreenHeight = screenHeight;
            MouseManager.X = screenWidth / 2;
            MouseManager.Y = screenHeight / 2;
            sVGAII.Clear((uint)Color.Black.ToArgb());
            Update();
        }
        public static void Update()
        {
            sVGAII.Clear((uint)Color.Black.ToArgb());
            DrawCursor(sVGAII, MouseManager.X, MouseManager.Y);
            sVGAII.DoubleBufferUpdate();
            sVGAII.SetPixel(0, 0, (uint)Color.White.ToArgb());
            sVGAII._DrawACSIIString("Oceano Testing", (uint)Color.Cyan.ToArgb(), 16, 16);
            Update();
        }
        public static void DrawCursor(VMWareSVGAII vMWareSVGAII, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vMWareSVGAII.SetPixel(w + x, h + y, (uint)Color.Black.ToArgb());
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        vMWareSVGAII.SetPixel(w + x, h + y, (uint)Color.White.ToArgb());
                    }
                }
            }
        }
    }
}

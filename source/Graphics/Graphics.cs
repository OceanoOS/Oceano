using Cosmos.System.Graphics;
using Cosmos.System;
using System.Drawing;
using System.Collections.Generic;
using Display = Oceano.Drivers.VGA;
namespace Oceano.Graphics
{
    public class Graphics
    {
        public static List<App> apps = new List<App>();
        public static Bitmap programlogo;
        static readonly Dock dock = new();
        static Pen whitepen = new(Color.White);
        static Pen blackpen=new(Color.Black);
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
        public static void Update()
        {
            dock.Update();
            DrawCursor(Display.canvas,(int)MouseManager.X, (int)MouseManager.Y);
        }
        static void DrawCursor(Canvas cv, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        cv.DrawPoint(blackpen,w+x,h+y);
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        cv.DrawPoint(whitepen,w+x,h+y);
                    }
                }
            }
        }
    }
}
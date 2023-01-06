using Cosmos.System;
using Oceano.Core;
using PrismGraphics;
using PrismGraphics.Extentions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oceano.Gui
{
    public class Graphics
    {
        public static VBECanvas Canvas { get; set; } = new();
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
        public static string fps;
        public static void Init()
        {
            MouseManager.ScreenWidth = Canvas.Width;
            MouseManager.ScreenHeight = Canvas.Height;
            Image boot = Image.FromBitmap(Core.Resources.boot);
            Canvas.DrawImage(Convert.ToInt16((Canvas.Width / 2) - 150 ), Convert.ToInt16((Canvas.Height / 2) - 150), boot, false);
            Thread.Sleep(3000);
            Canvas.Update();
        }
        public static void Update()
        {
            fps = Canvas.GetFPS().ToString();
            Canvas.DrawString(2, (int)Canvas.Height - 20, fps, Font.Fallback, Color.White);
            DrawCursor(Canvas,(int)MouseManager.X, (int)MouseManager.Y);
            Canvas.Update();
            Canvas.Clear(Color.Black);
        }
        public static void DrawCursor(VBECanvas canvas, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        canvas[w + x, h + y] = Color.Black;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        canvas[w + x, h + y] = Color.White;
                    }
                }
            }
        }
    }
}

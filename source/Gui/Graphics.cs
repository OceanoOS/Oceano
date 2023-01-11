using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Extentions;
using System;
using System.Threading;

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
        public static string fps, time;
        public static Image wallpaper = Image.FromBitmap(Core.Resources.wallpaper);
        public static Image boot = Image.FromBitmap(Core.Resources.boot);
        public static void Init()
        {
            MouseManager.ScreenWidth = Canvas.Width;
            MouseManager.ScreenHeight = Canvas.Height;
            MouseManager.X = Canvas.Width / 2;
            MouseManager.Y = Canvas.Height / 2;
            AppManager.Init();
            Canvas.DrawImage(Convert.ToInt16((Canvas.Width / 2) - 150), Convert.ToInt16((Canvas.Height / 2) - 150), boot, false);
            Canvas.Update();
            Thread.Sleep(3000);
            Canvas.Clear(Color.Black);
        }
        public static void Update()
        {
            fps = Canvas.GetFPS().ToString();
            time = DateTime.Now.ToString("HH:mm");
            Canvas.DrawImage(Convert.ToInt16((Canvas.Width / 2) - 400), Convert.ToInt16((Canvas.Height / 2) - 300), wallpaper, false);
            Canvas.DrawFilledRectangle(0, 0, Canvas.Width, 20, 0, Color.Black);
            Canvas.DrawString((int)(Canvas.Width / 2) - 20, 0, time, Font.Fallback, Color.White);
            int oldy = 25;
            int oldx = 2;
            foreach (var app in AppManager.apps)
            {
                int y = oldy;
                int x = oldx;
                Canvas.DrawImage(x + 7, y, app.icon, false);
                Canvas.DrawString(x, y + 34, app.title, Font.Fallback, Color.White);
                if (MouseManager.X >= x & MouseManager.X <= x + 40 & MouseManager.Y >= y & MouseManager.Y <= y + 40 & MouseManager.MouseState == MouseState.Left)
                {
                    app.visible = true;
                }
                if (AppManager.apps.Count * 48 > Canvas.Height)
                {
                    oldx = 60;
                    oldy = 25;
                }
                else
                {
                    oldy += 60;
                }
                app.Update();
            }
            Canvas.DrawString(2, 0, "PowerOFF", Font.Fallback, Color.White);
            if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= 2 & MouseManager.Y >= 0 & MouseManager.X <= ("PowerOFF".Length * 8) + 2 & MouseManager.Y <= 20)
            {
                Power.Shutdown();
            }
            Canvas.DrawString(2, (int)Canvas.Height - 20, "FPS: " + fps, Font.Fallback, Color.White);
            DrawCursor(Canvas, (int)MouseManager.X, (int)MouseManager.Y);
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

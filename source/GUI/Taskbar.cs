using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Fonts;
using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Taskbar
    {
        public static ushort Width = Kernel.Canvas.Width;
        public static ushort Height = 40;
        public static int X = 0;
        public static int Y = Kernel.Canvas.Height - 40;
        public static Color color = new(32, 32, 32);
        public static void Update()
        {
            Kernel.Canvas.DrawFilledRectangle(0, 0, Kernel.Canvas.Width, 20, 0, color);
            Kernel.Canvas.DrawString(2, 0, "Shutdown", Font.Fallback, Color.White);
            if (MouseManager.X >= 0 & MouseManager.X <= 72 & MouseManager.Y >= 0 & MouseManager.Y <= 20 & MouseManager.MouseState == MouseState.Left)
            {
                Power.Shutdown();
            }
            Kernel.Canvas.DrawString(Kernel.Canvas.Width / 2 - 22, 0, DateTime.Now.ToString("HH:mm"), Font.Fallback, Color.White);
            Kernel.Canvas.DrawFilledRectangle(X, Y, Width, Height, 0, color);
            int x = 4;
            foreach (App app in Graphics.apps)
            {
                Kernel.Canvas.DrawImage(x, Y + 4, app.icon);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X >= x & MouseManager.Y >= Y & MouseManager.X <= x + 38 & MouseManager.Y <= Kernel.Canvas.Height)
                    {
                        app.visible = true;
                    }
                }
                x += 40;
            }
        }
    }
}
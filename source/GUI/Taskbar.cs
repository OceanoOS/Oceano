using Cosmos.System;
using PrismGraphics;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Taskbar
    {
        public static ushort Width = Kernel.Canvas.Width;
        public static ushort Height = 40;
        public static int X = 0;
        public static int Y = Kernel.Canvas.Height - Height;
        public static Color color = new(32, 32, 32);
        public static void Update()
        {
            Kernel.Canvas.DrawLine(X, Y, Width, Height, Color.GoogleBlue);
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
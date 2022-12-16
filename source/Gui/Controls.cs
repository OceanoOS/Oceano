using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Drawing;

namespace Oceano.Gui
{
    public static class Controls
    {
        public static void DrawButton(this Canvas canvas, int x, int y, string text, Action a)
        {
            canvas.DrawRectangle(Color.Cyan, x, y, text.Length * 8 + 4, 18);
            canvas.DrawFilledRectangle(Color.FromArgb(32, 32, 32), x + 1, y + 1, text.Length * 8 + 4 - 2, 17);
            canvas.DrawString(text, Graphics.font, Color.White, x + 2, y + 2);
            if (MouseManager.X >= x & MouseManager.X <= x + text.Length * 8 & MouseManager.Y >= y & MouseManager.Y <= y + 22 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
        public static void DrawDangerButton(this Canvas canvas, int x, int y, string text, Action a)
        {
            canvas.DrawRectangle(Color.Red, x, y, text.Length * 8 + 4, 18);
            canvas.DrawFilledRectangle(Color.FromArgb(32, 32, 32), x + 1, y + 1, text.Length * 8 + 4 - 2, 17);
            canvas.DrawString(text, Graphics.font, Color.White, x + 2, y + 2);
            if (MouseManager.X >= x & MouseManager.X <= x + text.Length * 8 & MouseManager.Y >= y & MouseManager.Y <= y + 22 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
        public static void DrawIcon(this Canvas canvas, int x, int y, string text, Bitmap image)
        {
            //Image 32x32
            canvas.DrawImageAlpha(image, x + 4, y);
            canvas.DrawString(text, Graphics.font, Color.White, x, y + 32);
        }
    }
}
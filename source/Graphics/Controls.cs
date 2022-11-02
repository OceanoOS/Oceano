using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Drawing;

namespace Oceano.Graphics
{
    public static class Controls
    {
        public static void DrawIcon(this Canvas canvas, string title, Bitmap image, int x, int y, Action a)
        {
            //Image 32x32
            canvas.DrawImage(image, x + 14, y + 1);
            canvas.DrawString(title, PCScreenFont.Default, new(Color.White), x, y + 33);
            if (MouseManager.X >= x & MouseManager.X <= x + 40 & MouseManager.Y >= y & MouseManager.Y <= y + 40 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
        public static void DrawButton(this Canvas canvas, string text, int x, int y, Action a)
        {
            canvas.DrawFilledRectangle(new(Color.Black),x+1,y,text.Length *8 -1,18);
            canvas.DrawRectangle(new(Color.Red), x, y, text.Length * 8, 16);
            canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
            if (MouseManager.X >= x & MouseManager.X <= x + text.Length * 8 & MouseManager.Y >= y & MouseManager.Y <= y + 17 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
        
    }
}
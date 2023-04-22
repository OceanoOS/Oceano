using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Extentions.VMWare;
using PrismGraphics.Fonts;
using System;

namespace Oceano.GUI
{
    public static class Controls
    {
        static Color black = new(32, 32, 32);
        public static void DrawButton(this SVGAIICanvas Canvas, int x, int y, string text, Color color, Action a = null)
        {
            Canvas.DrawFilledRectangle(x, y, Convert.ToUInt16((text.Length * 10) + 3), 20, 0, black);
            Canvas.DrawRectangle(x, y, Convert.ToUInt16((text.Length * 10) + 3), 20, 0, color);
            Canvas.DrawString(x + 2, y, text, Font.Fallback, Color.White);
            if (a != null)
            {
                if (MouseManager.X >= x & MouseManager.X <= (x + text.Length * 10) + 2 & MouseManager.Y >= y & MouseManager.Y <= y + 20 & MouseManager.MouseState == MouseState.Left)
                {
                    a();
                }
            }
        }
    }
}

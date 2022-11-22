using Cosmos.System.Graphics;
using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;

namespace Oceano.Graphics
{
    public static class Controls
    {
        public static void DrawLabel(this Canvas canvas, int x, int y, string s,Color color)
        {
            canvas.DrawString(s,PCScreenFont.Default,new(color),x,y);
        }
    }
}
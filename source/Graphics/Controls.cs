using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public static class Controls
    {
        public static void DrawButton(this Canvas c, int x, int y, string text, Action a = null)
        {
            c.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), x, y, text.Length * 8, 16);
            c.DrawString(text, PCScreenFont.Default, new(Color.White), x, y);
            if(MouseManager.X >=x & MouseManager.X <= x+text.Length*8 & MouseManager.Y >=y & MouseManager.Y <= y + 16 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
    }
}

using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano
{
    public static class Controls
    {
        public static void DrawIcon(this Canvas canvas, int x, int y, Bitmap image, string text, bool alpha = false, Action a = null)
        {
            //Image 32x32
            if(alpha == true)
            {
                canvas.DrawImageAlpha(image,x+4,y);
            }
            else
            {
                canvas.DrawImage(image,x+4,y);
            }
            canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x, y + 32);
            if (Kernel.Pressed)
            {
                if(MouseManager.X >=x & MouseManager.X <=x+40 & MouseManager.Y>=y & MouseManager.Y <= y + 40)
                {
                    a();
                }
            }
        }
    }
}

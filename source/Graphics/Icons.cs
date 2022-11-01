using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using nifanfa.CosmosDrawString;
using System;
using System.Drawing;

namespace Oceano.Graphics
{
    public static class Icons
    {
        public static void DrawIcon(this Canvas canvas, string title, Bitmap image, int x, int y, Action a)
        {
            //Image 32x32
            canvas.DrawImage(image, x + 14, y + 1);
            canvas.DrawACSIIString(new(Color.White),title, x, y + 33);
            if (MouseManager.X >= x & MouseManager.X <= x + 40 & MouseManager.Y >= y & MouseManager.Y <= y + 40 & MouseManager.MouseState == MouseState.Left)
            {
                a();
            }
        }
    }
}
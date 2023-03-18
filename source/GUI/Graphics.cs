using Cosmos.System;
using IL2CPU.API.Attribs;
using PrismGL2D;
using PrismGL2D.Extentions;

namespace Oceano.GUI
{
    public class Graphics
    {
        public VBECanvas Canvas { get; set; } = new();
        public uint Width;
        public uint Height;
        readonly int[] cursor = new int[]
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
        Image Desktop = Image.FromBitmap(Resources.desktop);
        public Graphics()
        {
            this.Width = Canvas.Width;
            this.Height = Canvas.Height;
        }
        public Graphics(bool Mouse)
        {
            this.Width = Canvas.Width;
            this.Height = Canvas.Height;
            if (Mouse)
            {
                MouseManager.ScreenWidth = this.Width;
                MouseManager.ScreenHeight = this.Height;
                MouseManager.X = this.Width / 2;
                MouseManager.Y = this.Height / 2;
            }
        }
        public void Update()
        {
            Canvas.Clear(Color.Black);
            Canvas.DrawImage(0, 0, Desktop, false);
            DrawCursor(Canvas, MouseManager.X, MouseManager.Y);
            Canvas.Update();
        }
        public void DrawCursor(VBECanvas canvas, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        canvas[w + x, h + y] = Color.White;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        canvas[w + x, h + y] = Color.Black;
                    }
                }
            }
        }
    }
}

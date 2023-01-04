using Cosmos.Core.Memory;
using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Gui
{
    public class Graphics
    {
        public Canvas Canvas;
        public readonly int[] Cursor = new int[]
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
        public Graphics() 
        {
            
        }
        public void Init(string Mode = "")
        {
            if(Mode == "VGA")
            {
                Canvas = new VGACanvas();
            }
            if(Mode == "VBE")
            {
                Canvas = new VBECanvas();
            }
            if(Mode == "SVGA")
            {
                Canvas = new SVGAIICanvas();
            }
            if(Mode == "")
            {
                Canvas = FullScreenCanvas.GetFullScreenCanvas();
            }
            MouseManager.ScreenWidth = (uint)Canvas.Mode.Width;
            MouseManager.ScreenHeight = (uint)Canvas.Mode.Height;
            MouseManager.X = (uint)Canvas.Mode.Width / 2;
            MouseManager.Y = (uint)Canvas.Mode.Height / 2;
            XInit();
        }
        public virtual void XInit()
        {

        }
        public void Update()
        {
            DrawCursor(Canvas,(int)MouseManager.X,(int)MouseManager.Y);
            XUpdate();
            Canvas.Display();
            Canvas.Clear(Color.Black);
            Heap.Collect();
        }
        public virtual void XUpdate()
        {

        }
        public void DrawCursor(Canvas C, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (this.Cursor[h * 12 + w] == 1)
                    {
                        C.DrawPoint(Color.Black, w + x, h + y);
                    }
                    if (this.Cursor[h * 12 + w] == 2)
                    {
                        C.DrawPoint(Color.White,w + x, h + y);
                    }
                }
            }
        }
    }
}

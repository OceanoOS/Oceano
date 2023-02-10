using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
using System.Drawing;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;

namespace Oceano
{
    public class Kernel: Sys.Kernel
    {
        Canvas canvas;
        protected override void BeforeRun()
        {
            canvas = new VGACanvas();
        }
        
        protected override void Run()
        {
            canvas.DrawRectangle(Color.White,0,0,300,300);
            canvas.Display();
            canvas.Clear(Color.Black);
        }
    }
}

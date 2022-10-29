using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Boot.Kernel;
using System.Drawing;
using Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.System.Graphics.Fonts;

namespace Oceano.Graphics
{
    public class VGA
    {
        public static void Init()
        {
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
            Kernel.canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = 640;
            MouseManager.ScreenHeight = 480;
            Cosmos.System.MouseManager.X = (uint)((int)Kernel.canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)Kernel.canvas.Mode.Rows / 2);
            TestApp.x = 120;
            TestApp.y = 140;
            TestApp.text = "TestApp";

        }
        public static void Update()
        {
            Graphics.Desktop.Update();
            Pen pen = new Pen(Color.White);
            Kernel.canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X + 6, (int)Cosmos.System.MouseManager.Y);
            Kernel.canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 6);
            Kernel.canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                (int)Cosmos.System.MouseManager.X + 12, (int)Cosmos.System.MouseManager.Y + 12);
            Heap.Collect();
            Kernel.canvas.Display();
            Kernel.canvas.Clear(Color.Black);
        }
    }
}

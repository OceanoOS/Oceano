using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;

namespace Oceano.Graphics
{
    public class VGA
    {
        public static int x;
        public static int y;
        public static void Init()
        {
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new(x,y,ColorDepth.ColorDepth32));
            Kernel.canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)x;
            MouseManager.ScreenHeight = (uint)y;
            Cosmos.System.MouseManager.X = (uint)((int)Kernel.canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)Kernel.canvas.Mode.Rows / 2);
            Update();
        }
        public static void Update()
        {
            try
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
                Update();
            }
            catch
            {

            }
        }
    }
}

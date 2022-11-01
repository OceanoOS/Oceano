using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;

namespace Oceano.Graphics
{
    public class VGA
    {
        public static int x;
        public static int y;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.cursor.bmp")]
        static byte[] cursor;
        public static void Init()
        {
            Kernel.canvas = new SVGAIICanvas(new(x,y,ColorDepth.ColorDepth32));
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
                Kernel.canvas.DrawImageAlpha(new Bitmap(cursor), (int)MouseManager.X, (int)MouseManager.Y);
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

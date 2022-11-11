using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class Display
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.cursor.bmp")]
        static byte[] cursor;
        public static int screenWidth = 800;
        public static int screenHeight = 600;
        public static void Init()
        {
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new(screenWidth, screenHeight, ColorDepth.ColorDepth32));
            Kernel.canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)screenWidth;
            MouseManager.ScreenHeight = (uint)screenHeight;
            Update();
        }
        static void Update()
        {
            Desktop.Update();
            Kernel.canvas.DrawImageAlpha(new Bitmap(cursor), (int)MouseManager.X, (int)MouseManager.Y);
            Kernel.canvas.Display();
            Kernel.canvas.Clear(Color.Black);
            Heap.Collect();
            Update();
        }
    }
}

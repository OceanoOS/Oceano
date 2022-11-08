using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using Cosmos.Core.Memory;
using IL2CPU.API.Attribs;

namespace Oceano.Drivers
{
    public class Display
    {
        public static Canvas canvas;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.cursor.bmp")]
        static byte[] cursor;
        public static void InitSVGA()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas(new(800, 600, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)800;
            MouseManager.ScreenHeight = (uint)600;
            Cosmos.System.MouseManager.X = (uint)((int)canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)canvas.Mode.Rows / 2);
            Update();
        }
        public static void InitSVGAII()
        {
            canvas = new SVGAIICanvas(new(800, 600, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)800;
            MouseManager.ScreenHeight = (uint)600;
            Cosmos.System.MouseManager.X = (uint)((int)canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)canvas.Mode.Rows / 2);
            Update();
        }
        public static void InitVBE()
        {
            canvas = new VBECanvas(new(800, 600, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)800;
            MouseManager.ScreenHeight = (uint)600;
            Cosmos.System.MouseManager.X = (uint)((int)canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)canvas.Mode.Rows / 2);
            Update();
        }
        public static void Update()
        {
            try
            {
                Graphics.Desktop.Update();
                canvas.DrawImageAlpha(new Bitmap(cursor), (int)MouseManager.X, (int)MouseManager.Y);
                canvas.Display();
                canvas.Clear(Color.Black);
                Heap.Collect();
                Update();
            }
            catch (Exception e)
            {
                canvas.Disable();
                System.Console.WriteLine("Error: " + e);
            }
        }
    }
}

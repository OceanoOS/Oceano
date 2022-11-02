using Cosmos.Core.Memory;
using Cosmos.HAL.Audio;
using Cosmos.HAL.Drivers.PCI.Audio;
using Cosmos.System;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;
using System;

namespace Oceano.Graphics
{
    public class SVGAII
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.cursor.bmp")]
        static byte[] cursor;
        public static void Init()
        {
            Kernel.canvas = new SVGAIICanvas(new(800, 600, ColorDepth.ColorDepth32));
            Kernel.canvas.Clear(Color.Black);
            MouseManager.ScreenWidth = (uint)800;
            MouseManager.ScreenHeight = (uint)600;
            Cosmos.System.MouseManager.X = (uint)((int)Kernel.canvas.Mode.Columns / 2);
            Cosmos.System.MouseManager.Y = (uint)((int)Kernel.canvas.Mode.Rows / 2);
            System.Console.Beep();
            Update();
        }
        public static void Update()
        {
            try
            {
                Graphics.Desktop.Update();
                Kernel.canvas.DrawImageAlpha(new Bitmap(cursor), (int)MouseManager.X, (int)MouseManager.Y);
                Kernel.canvas.Display();
                Kernel.canvas.Clear(Color.Black);
                Heap.Collect();
                Update();
            }
            catch(Exception e)
            {
                Kernel.canvas.Disable();
                System.Console.WriteLine("Error on canvas: " +e);
            }
        }
    }
}

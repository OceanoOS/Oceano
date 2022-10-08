using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Oceano.Drivers
{
    public class Display
    {
        public static Canvas canvas;
        public static void Init()
        {
            try
            {
                canvas = new SVGAIICanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
                canvas.Display();
                canvas.Clear(Color.Cyan);
                Update();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Your video driver is not supported. Make sure you have a compatible SVGAII driver.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void Update()
        {
            try
            {
                canvas.Clear(Color.Cyan);
                canvas.Display();
                canvas.DrawLine(new(Color.White), Sys.MouseManager.X, Sys.MouseManager.Y, Sys.MouseManager.X, Sys.MouseManager.Y + 12);
                canvas.DrawLine(new(Color.White), Sys.MouseManager.X, Sys.MouseManager.Y, Sys.MouseManager.X+12, Sys.MouseManager.Y);
                Update();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Your video driver is not supported. Make sure you have a compatible SVGAII driver.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

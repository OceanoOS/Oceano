using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using DrawString;
using RoundRect;

namespace Oceano.Apps
{
    public class gui
    {
        public static Canvas canvas;
        public static void Init()
        {
            try
            {
                canvas = new SVGAIICanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
                canvas.Clear(Color.Black);


                Sys.MouseManager.ScreenWidth = 800;
                Sys.MouseManager.ScreenHeight = 600;

                Sys.MouseManager.X = (uint)(canvas.Mode.Columns / 2);
                Sys.MouseManager.Y = (uint)(canvas.Mode.Rows / 2);
                Update();
            }
            catch
            {
                Console.WriteLine("Fatal Exception");
            }
        }
        public static void Update()
        {
            try
            {

                Pen pen = new(Color.White);

                canvas.DrawLine(pen, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y,
                    (int)Sys.MouseManager.X + 6, (int)Sys.MouseManager.Y);
                canvas.DrawLine(pen, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y,
                    (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y + 6);
                canvas.DrawLine(pen, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y,
                    (int)Sys.MouseManager.X + 12, (int)Sys.MouseManager.Y + 12);

                canvas.Display();
                canvas.Clear(Color.Black);
                Update();
            }
            catch
            {
                Console.WriteLine("Fatal Exception");
            }
        }
        public static void DrawDock()
        {
            
        }
    }
}

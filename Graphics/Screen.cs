using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Oceano.Graphics
{
    public class Screen
    {
        public static Canvas canvas;
        public static void Init()
        {
            canvas = new SVGAIICanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Green);


            Sys.MouseManager.ScreenWidth = 800;
            Sys.MouseManager.ScreenHeight = 600;

            Sys.MouseManager.X = (uint)((int)canvas.Mode.Columns / 2);
            Sys.MouseManager.Y = (uint)((int)canvas.Mode.Rows / 2);
            Update();
        }
        public static void Update()
        {
            try
            {

                Pen pen = new(Color.Cyan);

                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X + 6, (int)Cosmos.System.MouseManager.Y);
                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 6);
                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X + 12, (int)Cosmos.System.MouseManager.Y + 12);

                canvas.Display();
                canvas.Clear(Color.Black);
                Update();
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal Exception");
            }
        }

    }
}

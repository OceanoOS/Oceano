﻿using Cosmos.System.Graphics;
using Oceano.Graphics;
using System;
using System.Drawing;
using Sys = Cosmos.System;

namespace Oceano.Commands
{
    public class gui
    {
        public static Canvas canvas;

        public static void Init()
        {
            try
            {
                canvas = new SVGAIICanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
                canvas.Clear(Color.FromArgb(79, 78, 215));

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

                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X + 6, (int)Cosmos.System.MouseManager.Y);
                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 6);
                canvas.DrawLine(pen, (int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y,
                    (int)Cosmos.System.MouseManager.X + 12, (int)Cosmos.System.MouseManager.Y + 12);
                canvas.Display();
                canvas.Clear(Color.FromArgb(79, 78, 215));
                Taskbar.Main();
                Update();
            }
            catch
            {
                Console.WriteLine("Fatal Exception");
            }
        }
    }
}

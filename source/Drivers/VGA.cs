using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.System.Graphics.Fonts;
using Cosmos.Core.Memory;

namespace Oceano.Drivers
{
    public class VGA
    {
        public static Canvas canvas;
        public static int screenWidth;
        public static int screenHeight;

        public static void Init()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Black);
            screenWidth=canvas.Mode.Columns;
            screenHeight=canvas.Mode.Rows;
            MouseManager.ScreenWidth= (uint)screenWidth;
            MouseManager.ScreenHeight = (uint)screenHeight;
            Update();
        }
        static void Update()
        {
            Heap.Collect();
            Graphics.Graphics.Update();
            canvas.Display();
            canvas.Clear(Color.Black);
            Update();
        }
    }
}
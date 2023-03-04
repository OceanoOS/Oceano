using Cosmos.System;
using PrismGL2D;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Desktop
    {
        static int[] cursor = new int[]
            {
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,2,1,0,0,0,0,0,0,0,0,0,
                1,2,2,1,0,0,0,0,0,0,0,0,
                1,2,2,2,1,0,0,0,0,0,0,0,
                1,2,2,2,2,1,0,0,0,0,0,0,
                1,2,2,2,2,2,1,0,0,0,0,0,
                1,2,2,2,2,2,2,1,0,0,0,0,
                1,2,2,2,2,2,2,2,1,0,0,0,
                1,2,2,2,2,2,2,2,2,1,0,0,
                1,2,2,2,2,2,2,2,2,2,1,0,
                1,2,2,2,2,2,2,2,2,2,2,1,
                1,2,2,2,2,2,2,1,1,1,1,1,
                1,2,2,2,1,2,2,1,0,0,0,0,
                1,2,2,1,0,1,2,2,1,0,0,0,
                1,2,1,0,0,1,2,2,1,0,0,0,
                1,1,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,0,1,1,0,0,0
            };
        public static bool Pressed;
        public static Color avgCol;
        public static void BeforeRun()
        {
            MouseManager.ScreenWidth = Kernel.Canvas.Width;
            MouseManager.ScreenHeight = Kernel.Canvas.Height;
            MouseManager.X = (uint)Kernel.Canvas.Width / 2;
            MouseManager.Y = (uint)Kernel.Canvas.Height / 2;

        }
        public static void Run()
        {
            switch (MouseManager.MouseState)
            {
                case MouseState.Left:
                    Pressed = true;
                    break;
                case MouseState.None:
                    Pressed = false;
                    break;
            }
            Kernel.Canvas.Clear(Color.Black);
            DrawCursor(Kernel.Canvas, (int)MouseManager.X, (int)MouseManager.Y);
            Kernel.Canvas.Update();
        }
        static void DrawCursor(Graphics graphics, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        graphics[w + x, h + y] = Color.StackOverflowBlack;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        graphics[w + x, h + y] = Color.StackOverflowWhite;
                    }
                }
            }
        }
    }
}

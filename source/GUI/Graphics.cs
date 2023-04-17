using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosTTF;
using System.Drawing;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Graphics
    {
        public static void Init()
        {
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas();
            MouseManager.ScreenWidth = (uint)Kernel.canvas.Mode.Width;
            MouseManager.ScreenHeight = (uint)Kernel.canvas.Mode.Height;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
            Kernel.GraphicsMode = true;
        }
        public static void Update()
        {
            Kernel.canvas.Clear();
            DrawCursor();
            Kernel.canvas.DrawStringTTF(Color.White, "Hello", "default", 20,new(2,2));
            Heap.Collect();
            Kernel.canvas.Display();
        }
        public static void DrawCursor()
        {
            Kernel.canvas.DrawLine(Color.White, (int)MouseManager.X, (int)MouseManager.Y,
                (int)MouseManager.X + 6, (int)MouseManager.Y);
            Kernel.canvas.DrawLine(Color.White, (int)MouseManager.X, (int)MouseManager.Y,
                (int)MouseManager.X, (int)MouseManager.Y + 6);
            Kernel.canvas.DrawLine(Color.White, (int)MouseManager.X, (int)MouseManager.Y,
                (int)MouseManager.X + 12, (int)MouseManager.Y + 12);
        }
    }
}

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
using System.Drawing;
using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Oceano.GUI.Controls;
using Oceano.GUI.Themes;
=======
>>>>>>> main
>>>>>>> Stashed changes
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI;

public static class Graphics
{
<<<<<<< Updated upstream
    public static void Initialize()
    {
        
=======
<<<<<<< HEAD
    private static Button button = new(2, 2, 34, 20, "Test",
        new Theme(Color.Black, Color.White, Color.Cyan, Color.DarkCyan, Color.CadetBlue, Color.LightCyan),
        Button.ColorPriority.Primary, PCScreenFont.Default);

    public static void Initialize()
    {
        Kernel.Canvas = FullScreenCanvas.GetFullScreenCanvas();
        MouseManager.ScreenWidth = Kernel.Canvas.Mode.Width;
        MouseManager.ScreenHeight = Kernel.Canvas.Mode.Height;
=======
    public static void Initialize()
    {
        
>>>>>>> main
>>>>>>> Stashed changes
    }

    public static void Update()
    {
<<<<<<< Updated upstream
        
=======
<<<<<<< HEAD
        Kernel.Canvas.Clear();
        button.Update();
        Kernel.Canvas.DrawRectangle(Color.White, (int)MouseManager.X, (int)MouseManager.Y, 20, 20);
        Heap.Collect();
        Kernel.Canvas.Display();
=======
        
>>>>>>> main
>>>>>>> Stashed changes
    }
}
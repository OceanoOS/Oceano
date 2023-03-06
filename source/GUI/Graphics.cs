using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Extentions.VMWare;
using System.Collections.Generic;
using Oceano.GUI.Apps;

namespace Oceano.GUI
{
    public class Graphics
    {
        public static SVGAIICanvas vMWareSVGAII;
        public static ushort screenWidth;
        public static ushort screenHeight;
        static readonly int[] cursor = new int[]
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
        public static Image programlogo = Image.FromBitmap(Resources.program);
        public static Image wallpaper = Image.FromBitmap(Resources.wallpaper);
        public static List<App> apps = new();
        public static Color avgCol = Color.GetPacked(255,32,32,32);
        public static Dock dock = new();
        public static void Init(ushort width, ushort height, bool InitMouse = true)
        {
            screenWidth = width;
            screenHeight = height;
            vMWareSVGAII = new(screenWidth, screenHeight);
            if (InitMouse)
            {
                MouseManager.ScreenWidth = (uint)screenWidth;
                MouseManager.ScreenHeight = (uint)screenHeight;
                MouseManager.X = (uint)screenWidth / 2;
                MouseManager.Y = (uint)screenHeight / 2;
                apps.Add(new Terminal());
            }
        }
        public static void Update()
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
            vMWareSVGAII.Clear(Color.Black);
            vMWareSVGAII.DrawImage(0, 0, wallpaper, false);
            foreach(App app in apps)
            {
                app.Update();
            }
            dock.Update();
            DrawCursor(vMWareSVGAII, (int)MouseManager.X, (int)MouseManager.Y);
            vMWareSVGAII.Update();
        }
        static void DrawCursor(SVGAIICanvas canvas, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        canvas[w + x, h + y] = Color.Black;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        canvas[w + x, h + y] = Color.White;
                    }
                }
            }
        }
    }
}

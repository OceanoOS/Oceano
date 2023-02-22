using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Color = System.Drawing.Color;
using Kernel = Oceano.Core.Kernel;
using vbeColor = PrismGL2D.Color;

namespace Oceano.Gui
{
    public class WindowManager
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
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        static byte[] wallpaper;
        public static Bitmap bitmap = new(wallpaper);
        public static PrismGL2D.Image vbeImage = PrismGL2D.Image.FromBitmap(wallpaper);
        public static void Init()
        {
            Kernel.graphics.Init("SVGAII", 1024, 768);
            MouseManager.ScreenWidth = (uint)Core.Kernel.graphics.screenWidth;
            MouseManager.ScreenHeight = (uint)Core.Kernel.graphics.screenHeight;
            MouseManager.X = (uint)Core.Kernel.graphics.screenWidth / 2;
            MouseManager.Y = (uint)Core.Kernel.graphics.screenHeight / 2;
            
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
            Kernel.graphics.Clear(Color.Black, vbeColor.Black);
            if (Kernel.graphics.Mode == "SVGAII")
            {
                Kernel.graphics.vMWareSVGAII.DoubleBuffer_SetVRAM(bitmap.rawData, (int)Kernel.graphics.vMWareSVGAII.FrameSize);
            }
            else
            {
                Kernel.graphics.DrawImage(0, 0, bitmap, vbeImage);
            }
            DrawCursor(Kernel.graphics,(int)MouseManager.X, (int)MouseManager.Y);
            Kernel.graphics.Update();
        }
        static void DrawCursor(Graphics graphics, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        graphics.SetPixel(w + x, h + y, Color.Black, vbeColor.Black);
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        graphics.SetPixel(w + x, h + y, Color.White, vbeColor.White);
                    }
                }
            }
        }
    }
}

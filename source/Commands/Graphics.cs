using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Oceano.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Oceano.Commands
{
    public class Graphics
    {
        public static uint screenWidth = 640;
        public static uint screenHeight = 480;
        public static DoubleBufferedVMWareSVGAII vMWareSVGAII;
        public static Bitmap bitmap;
        public static Bitmap programlogo;
        public static Bitmap bootBitmap;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.program.bmp")] 
        static byte[] program;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        static byte[] wallpaper;

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

         static LogView logView;
         static Clock Clock;
         static Notepad notepad;
         static Dock dock;
        public static bool Pressed;

        public static List<App> apps = new List<App>();

        public static Color avgCol;

        public static void BeforeRun()
        {

            bootBitmap = new Bitmap(wallpaper);

            vMWareSVGAII = new DoubleBufferedVMWareSVGAII();
            vMWareSVGAII.SetMode(screenWidth, screenHeight);

            vMWareSVGAII.DoubleBuffer_DrawImage(bootBitmap, 640 / 4, 0);
            vMWareSVGAII.DoubleBuffer_Update();

            bitmap = new Bitmap(wallpaper);
            programlogo = new Bitmap(program);

            uint r = 0;
            uint g = 0;
            uint b = 0;
            for (uint i = 0; i < bitmap.rawData.Length; i++)
            {
                Color color = Color.FromArgb(bitmap.rawData[i]);
                r += color.R;
                g += color.G;
                b += color.B;
            }
            avgCol = Color.FromArgb((int)(r / bitmap.rawData.Length), (int)(g / bitmap.rawData.Length), (int)(b / bitmap.rawData.Length));

            MouseManager.ScreenWidth = screenWidth;
            MouseManager.ScreenHeight = screenHeight;
            MouseManager.X = screenWidth / 2;
            MouseManager.Y = screenHeight / 2;

            logView = new LogView(300, 200, 10, 30);
            Clock = new Clock(200, 200, 400, 200);
            notepad = new Notepad(200, 100, 10, 300);
            dock = new Dock();

            apps.Add(logView);
            apps.Add(Clock);
            apps.Add(notepad);
            Run();
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

            vMWareSVGAII.DoubleBuffer_Clear((uint)Color.Black.ToArgb());
            vMWareSVGAII.DoubleBuffer_SetVRAM(bitmap.rawData, (int)vMWareSVGAII.FrameSize);
            logView.text = $"Time: {DateTime.Now}\nInstall RAM: {CPU.GetAmountOfRAM()}MB, Video RAM: {vMWareSVGAII.Video_Memory.Size}Bytes";
            foreach (App app in apps)
                app.Update();

            dock.Update();

            DrawCursor(vMWareSVGAII, MouseManager.X, MouseManager.Y);

            vMWareSVGAII.DoubleBuffer_Update();
            Run();
        }

        public static void DrawCursor(DoubleBufferedVMWareSVGAII vMWareSVGAII, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vMWareSVGAII.DoubleBuffer_SetPixel(w + x, h + y, (uint)Color.Black.ToArgb());
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        vMWareSVGAII.DoubleBuffer_SetPixel(w + x, h + y, (uint)Color.White.ToArgb());
                    }
                }
            }
        }
    }
}
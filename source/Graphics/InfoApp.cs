using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;

namespace Oceano.Graphics
{
    public class InfoApp
    {
        public static int x = 40;
        public static int y = 40;
        public static string text = "System Information";
        public static bool Opened;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.logo.bmp")]
        static byte[] file;
        static Bitmap logo = new(file);
        public static int w = 600;
        public static int h = 300;
        public static void Update()
        {
            if (Opened)
            {
                Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), x, y, w, h);
                Kernel.canvas.DrawRectangle(new(Color.Red), x, y, w, h);
                Kernel.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
                Kernel.canvas.DrawImage(Desktop.close, x + w - 16, y);
                Kernel.canvas.DrawImage(logo, x + 5, y + 20);
                Kernel.canvas.DrawString("Oceano Operative System", PCScreenFont.Default, new(Color.White), x + 130, y + 20);
                Kernel.canvas.DrawString("Version: beta1", PCScreenFont.Default, new(Color.White), x + 130, y + 40);
                Kernel.canvas.DrawString("CPU: " + Kernel.cpu, PCScreenFont.Default, new(Color.White), x + 130, y + 60);
                Kernel.canvas.DrawString("RAM: " + Kernel.ram + " MB", PCScreenFont.Default, new(Color.White), x + 130, y + 80);
                if (MouseManager.X >= x & MouseManager.X <= x + 200 & MouseManager.Y >= y & MouseManager.Y <= y + 16 & MouseManager.MouseState == MouseState.Left)
                {
                    x = (int)MouseManager.X - 10;
                    y = (int)MouseManager.Y - 10;
                }
                if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= x + w - 16 & MouseManager.Y >= y & MouseManager.X <= x + w & MouseManager.Y <= y + 16)
                {
                    Opened = false;
                }
            }
        }
    }
}

using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display = Oceano.Drivers.Display;
using Cosmos.System;
using Cosmos.System.Graphics;

namespace Oceano.Graphics
{
    public class SettingsApp
    {
        public static int x = 100;
        public static int y = 100;
        public static int w = 600;
        public static int h = 300;
        public static string text = "Settings";
        public static bool Opened;
        public static void Update()
        {
            if (Opened)
            {
                Display.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), x, y, w, h);
                Display.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
                Display.canvas.DrawImage(Desktop.close, x + w - 16, y);
                Display.canvas.DrawString("WallpaperEnabled", PCScreenFont.Default, new(Color.White), x + 1, y + 20);
                Display.canvas.DrawButton("true", x + 1, y + 40,EnableWallpaper);
                Display.canvas.DrawButton("false", x + 40, y + 40, DisableWallpaper);
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
        public static void EnableWallpaper()
        {
            Desktop.WallpaperEnabled = true;
        }
        public static void DisableWallpaper()
        {
            Desktop.WallpaperEnabled = false;
        }
    }
}

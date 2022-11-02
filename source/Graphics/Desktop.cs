using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;
using Cosmos.HAL;
using Cosmos.Core.Memory;

namespace Oceano.Graphics
{
    public class Desktop
    {
        static string time;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.apps.bmp")]
        static byte[] apps;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.close.bmp")]
        static byte[] closefile;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        static byte[] wallpaper;
        public static Bitmap close = new(closefile);
        public static bool WallpaperEnabled = false;

        public static void Update()
        {
            time = DateTime.Now.ToString("hh:mm");
            if (WallpaperEnabled == true)
            {
                Kernel.canvas.DrawImageAlpha(new Bitmap(wallpaper), 0, 0);
            }
            Kernel.canvas.DrawIcon(" Apps", new(apps), 1, 1, OpenApps);
            Apps.Update();
            InfoApp.Update();
            SettingsApp.Update();
            FilesApp.Update();
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, 600 - 16, 800, 16);
            Kernel.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), 800 - 40, 600 - 16);
        }
        public static void OpenApps()
        {
            Graphics.Apps.Opened = true;
        }
        
    }
}

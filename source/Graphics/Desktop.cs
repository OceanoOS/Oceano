using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System;
using System.Drawing;
using Display = Oceano.Drivers.Display;

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

        public static void Update()
        {
            time = DateTime.Now.ToString("hh:mm");
            Apps.Update();
            InfoApp.Update();
            FilesApp.Update();
            Display.canvas.DrawButton("Apps", 0, 0, OpenApps);
            Display.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), 0, 20);
        }
        public static void OpenApps()
        {
            Graphics.Apps.Opened = true;
        }

    }
}

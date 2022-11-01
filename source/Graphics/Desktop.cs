using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System;
using System.Drawing;
using Kernel = Oceano.Boot.Kernel;
using Cosmos.HAL;
namespace Oceano.Graphics
{
    public class Desktop
    {
        static string time;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.apps.bmp")]
        static byte[] apps;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.close.bmp")]
        static byte[] closefile;
        public static Bitmap close = new(closefile);
        public static void Update()
        {
            time = DateTime.Now.ToString("hh:mm");
            Kernel.canvas.DrawIcon(" Apps", new(apps), 1, 1, Apps);
            InfoApp.Update();
            Graphics.Apps.Update();
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, VGA.y - 16, VGA.x, 16);
            Kernel.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), VGA.x - 40, VGA.y - 16);

        }
        public static void Apps()
        {
            Graphics.Apps.Opened = true;
        }
    }
}

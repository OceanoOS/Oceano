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
        [ManifestResourceStream(ResourceName = "Oceano.Resources.close.bmp")]
        static byte[] closefile;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.info.bmp")]
        static byte[] info;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.shutdown.bmp")]
        static byte[] shutdown;
        public static Bitmap close = new(closefile);
        public static void Update()
        {
            time = DateTime.Now.ToString("hh:mm");
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, VGA.y - 16, VGA.x, 16);
            Kernel.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), VGA.x - 40, VGA.y - 16);
            Kernel.canvas.DrawIcon("SysInfo", new(info), 1, 1, InfoOpened);
            Kernel.canvas.DrawIcon("Shutdown", new(shutdown), 1, 70,Cosmos.System.Power.Shutdown);
            Kernel.canvas.DrawIcon("Exit", new(shutdown), 1, 141, Shell.BeforeRun);
            InfoApp.Update();
        }
        public static void InfoOpened()
        {
            InfoApp.Opened = true;
        }
    }
}

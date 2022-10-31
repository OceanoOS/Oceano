using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using Oceano.Boot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Boot.Kernel;
namespace Oceano.Graphics
{
    public class Desktop
    {
        static string time;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        static byte[] file;
        static Bitmap wallpaper = new(file);
        static bool MenuOpened;
        public static void Update()
        {
            Kernel.canvas.DrawImage(wallpaper, 0, 0);
            time = DateTime.Now.ToString("hh:mm");
            Kernel.canvas.DrawFilledRectangle(new(Color.Black), 0, 0, VGA.x, 16);
            Kernel.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), VGA.x / 2 - time.Length * 8, 0);
            string powerOff = new("Shutdown");
            Kernel.canvas.DrawString(powerOff, PCScreenFont.Default, new(Color.White), 0, 0);
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, VGA.y - 16, VGA.x, 16);
            Kernel.canvas.DrawString("^", PCScreenFont.Default, new(Color.White), 0, VGA.y - 16);
            InfoApp.Update();
            if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= 0 & MouseManager.X <= powerOff.Length *8 & MouseManager.Y>=0 & MouseManager.Y <= 16){
                Cosmos.System.Power.Shutdown();
            }
            if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= 0 & MouseManager.X <= 8 & MouseManager.Y >= VGA.y - 16 & MouseManager.Y <= VGA.y & MouseManager.LastMouseState == MouseState.None)
            {
                if (MenuOpened == false)
                {
                    MenuOpened = true;
                }
                else
                {
                    MenuOpened = false;
                }
            }
            if (MenuOpened)
            {
                Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, VGA.y - 216, 300, 200);
            }
        }
    }
}

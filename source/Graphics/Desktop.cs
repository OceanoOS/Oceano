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
        public static void Update()
        {
            Kernel.canvas.DrawImage(wallpaper, 0, 0);
            time = DateTime.Now.ToString("hh:mm");
            Kernel.canvas.DrawFilledRectangle(new(Color.Black), 0, 0, 640, 16);
            Kernel.canvas.DrawString(time, PCScreenFont.Default, new(Color.White), 640 / 2 - time.Length * 8, 0);
            string powerOff = new("Shutdown");
            Kernel.canvas.DrawString(powerOff, PCScreenFont.Default, new(Color.White), 0, 0);
            string testApp = new("TestApp");
            Kernel.canvas.DrawString(testApp, PCScreenFont.Default, new(Color.White), 0, 16);
            
            TestApp.Update();
            if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= 0 & MouseManager.X <= powerOff.Length *8 & MouseManager.Y>=0 & MouseManager.Y <= 16){
                Cosmos.System.Power.Shutdown();
            }
            if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= 0 & MouseManager.X <= testApp.Length * 8 & MouseManager.Y >= 16 & MouseManager.Y <= 32)
            {
                if (TestApp.Opened == false)
                {
                    TestApp.Opened = true;

                }
                else
                {
                    TestApp.Opened = false;
                }
            }
        }
    }
}

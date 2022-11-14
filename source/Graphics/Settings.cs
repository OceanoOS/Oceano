using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class Settings : App
    {
        public Settings(uint width, uint height, uint x = 0, uint y = 0) : base(width, height, x, y)
        {
            name = "Settings";
        }

        public override void _Update()
        {
            Display.vMWareSVGAII.DrawACSIIString("Resolution", (uint)Color.White.ToArgb(), x, y);
            Display.vMWareSVGAII.DrawButton(x + 90, y, "640x480",Set640x480);
            Display.vMWareSVGAII.DrawButton(x + 150, y, "800x600",Set800x600);
            Display.vMWareSVGAII.DrawButton(x + 210 , y, "1024x576",Set1024x576);
            Display.vMWareSVGAII.DrawButton(x + 280, y, "1920x1080",Set1920x1080);
        }
        public static void Set640x480()
        {
            Display.vMWareSVGAII.SetMode(640,480);
            Display.screenWidth = 640;
            Display.screenHeight = 480;
            MouseManager.ScreenWidth = 640;
            MouseManager.ScreenHeight = 480;
        }
        public static void Set800x600()
        {
            Display.vMWareSVGAII.SetMode(800, 600);
            Display.screenWidth = 800;
            Display.screenHeight = 600;
            MouseManager.ScreenWidth = 800;
            MouseManager.ScreenHeight = 600;
        }
        public static void Set1024x576()
        {
            Display.vMWareSVGAII.SetMode(1024, 576);
            Display.screenWidth = 1024;
            Display.screenHeight = 576;
            MouseManager.ScreenWidth = 1024;
            MouseManager.ScreenHeight = 576;
        }
        public static void Set1920x1080()
        {
            Display.vMWareSVGAII.SetMode(1920, 1080);
            Display.screenWidth = 1920;
            Display.screenHeight = 1080;
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
        }
    }
}

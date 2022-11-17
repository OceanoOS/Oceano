using Cosmos.Core;
using Cosmos.System;
using System;
using System.Drawing;

namespace Oceano.Graphics
{
    class Dock
    {
        uint Width = 200;
        uint Height = 30;
        uint Devide = 20;
        static string time;

        public void Update()
        {
            time = DateTime.Now.ToString("HH:mm");
            Width = (uint)(Display.apps.Count * Display.programlogo.Width + Display.apps.Count * Devide);

            Display.vMWareSVGAII.DoubleBuffer_DrawFillRectangle(0, 0, Display.screenWidth, 20, (uint)Color.FromArgb(32,32,32).ToArgb());
            string text = "PowerOFF";
            uint strX = 2;
            uint strY = (20 - 16) / 2;
            Display.vMWareSVGAII.DrawACSIIString("PowerOFF", (uint)Color.White.ToArgb(), strX, strY);
            Display.vMWareSVGAII.DrawACSIIString(time, (uint)Color.White.ToArgb(), Display.screenWidth - 42, (20-16)/2);
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }

            Display.vMWareSVGAII.DoubleBuffer_DrawFillRectangle((Display.screenWidth - Width) / 2, Display.screenHeight - Height, Width, Height, (uint)Color.FromArgb(32,32,32).ToArgb());

            for (int i = 0; i < Display.apps.Count; i++)
            {
<<<<<<< Updated upstream
                Display.apps[i].dockX = (uint)(Devide / 2 + ((Display.screenWidth - Width) / 2) + (Display.programlogo.Width * i) + (Devide * i));
                Display.apps[i].dockY = Display.screenHeight - Display.programlogo.Height - Devide / 2;
                Display.vMWareSVGAII.DoubleBuffer_DrawImage(Display.programlogo, Display.apps[i].dockX, Display.apps[i].dockY);
=======
                Drivers.Display.apps[i].dockX = (int)(Devide / 2 + ((Kernel.screenWidth - Width) / 2) + (Drivers.Display.programlogo.Width * i) + (Devide * i));
                Drivers.Display.apps[i].dockY = Convert.ToInt32(Kernel.screenHeight - Drivers.Display.programlogo.Height - Devide / 2);
                Kernel.canvas.DrawImageAlpha(Drivers.Display.programlogo, Drivers.Display.apps[i].dockX, Drivers.Display.apps[i].dockY);
>>>>>>> Stashed changes
            }
        }
    }
}
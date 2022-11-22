using Cosmos.Core;
using Cosmos.System;
using System.Drawing;
using Display = Oceano.Drivers.VGA;
using System;

namespace Oceano.Graphics
{
    class Dock
    {
        int Width = 200;
        int Height = 30;
        int Devide = 20;

        public void Update()
        {
            Width = (int)(Graphics.apps.Count * Graphics.programlogo.Width + Graphics.apps.Count * Devide);
            Display.canvas.DrawFilledRectangle(new(Color.FromArgb(32,32,32)), 0, 0, Display.screenWidth, 20);
            string text = "PowerOFF";
            int strX = 2;
            int strY = (20 - 16) / 2;
            Display.canvas.DrawLabel(strX, strY, text, Color.White);
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }
            Display.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), (Display.screenWidth - Width) / 2, Display.screenHeight - Height, Width, Height);

            for (int i = 0; i < Graphics.apps.Count; i++)
            {
                Graphics.apps[i].dockX = (int)(Devide / 2 + ((Display.screenWidth - Width) / 2) + (Graphics.programlogo.Width * i) + (Devide * i));
                Graphics.apps[i].dockY = Convert.ToInt16(Display.screenHeight - Graphics.programlogo.Height - Devide / 2);
                Display.canvas.DrawImageAlpha(Graphics.programlogo,Graphics.apps[i].dockX, Graphics.apps[i].dockY);
            }
        }
    }
}
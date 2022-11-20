using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Drawing;

namespace Oceano
{
    class Dock
    {
        int Width = 200;
        int Height = 30;
        int Devide = 20;

        public void Update()
        {
            Width = Convert.ToInt16(Kernel.apps.Count * Kernel.programlogo.Width + Kernel.apps.Count * Devide);
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, 0, Kernel.screenWidth, 20);
            string text = "PowerOFF";
            int strX = 2;
            int strY = (20 - 16) / 2;
            Kernel.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), strX, strY);
            if (Kernel.Pressed)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }

            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), (Kernel.screenWidth - Width) / 2, Kernel.screenHeight - Height, Width, Height);
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32,32,32)), (Kernel.screenWidth - Width) / 2, Kernel.screenHeight - Height, Width, Height);
            int i = 0;
            for (; i < Kernel.apps.Count; i++)
            {
                Kernel.apps[i].dockX = (int)(Devide / 2 + ((Kernel.screenWidth - Width) / 2) + (Kernel.programlogo.Width * i) + (Devide * i));
                Kernel.apps[i].dockY = Convert.ToInt16(Kernel.screenHeight - Kernel.programlogo.Height - Devide / 2);
                Kernel.canvas.DrawImage(Kernel.programlogo, Kernel.apps[i].dockX, Kernel.apps[i].dockY);
            }
        }
    }
}
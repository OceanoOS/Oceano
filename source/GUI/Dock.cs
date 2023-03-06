using Cosmos.Core;
using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Fonts;
using System;

namespace Oceano.GUI
{
    public class Dock
    {
        int Width = 200;
        int Height = 30;
        int Devide = 20;
        string text = "PowerOFF";
        string time;
        int strX = 2;
        int strY = 0;

        public void Update()
        {
            time = DateTime.Now.ToString("HH:mm");
            Width = (Graphics.apps.Count * Graphics.programlogo.Width + Graphics.apps.Count * Devide);

            Graphics.vMWareSVGAII.DrawFilledRectangle(0, 0, Graphics.screenWidth, 20, 0, Graphics.avgCol);

            Graphics.vMWareSVGAII.DrawString(Graphics.screenWidth / 2 - (time.Length * 6) / 2,0,time,Font.Fallback,Color.White);
            Graphics.vMWareSVGAII.DrawString(strX, strY, "PowerOFF", Font.Fallback, Color.White);
            if (Graphics.Pressed)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }
            Graphics.vMWareSVGAII.DrawFilledRectangle((Graphics.screenWidth - Width) / 2, Graphics.screenHeight - Height, (ushort)Width, (ushort)Height, 0, Graphics.avgCol);

            for (int i = 0; i < Graphics.apps.Count; i++)
            {
                Graphics.apps[i].dockX = (Devide / 2 + ((Graphics.screenWidth - Width) / 2) + (Graphics.programlogo.Width * i) + (Devide * i));
                Graphics.apps[i].dockY = Graphics.screenHeight - Graphics.programlogo.Height - Devide / 2;
                Graphics.vMWareSVGAII.DrawImage(Graphics.apps[i].dockX, Graphics.apps[i].dockY, Graphics.programlogo, false);
            }
        }
    }
}
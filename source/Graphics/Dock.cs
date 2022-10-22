using Cosmos.Core;
using Cosmos.System;
using System.Drawing;

namespace Oceano.Graphics
{
    class Dock
    {
        uint Width = 200;
        uint Height = 30;
        uint Devide = 20;

        public void Update()
        {
            Width = (uint)(Commands.Graphics.apps.Count * Commands.Graphics.programlogo.Width + Commands.Graphics.apps.Count * Devide);

            Commands.Graphics.vMWareSVGAII.DoubleBuffer_DrawFillRectangle(0, 0, Commands.Graphics.screenWidth, 20, (uint)Commands.Graphics.avgCol.ToArgb());
            string text = "PowerOFF";
            uint strX = 2;
            uint strY = (20 - 16) / 2;
            Commands.Graphics.vMWareSVGAII._DrawACSIIString("PowerOFF", (uint)Color.White.ToArgb(), strX, strY);
            if (Commands.Graphics.Pressed)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }

            Commands.Graphics.vMWareSVGAII.DoubleBuffer_DrawFillRectangle((Commands.Graphics.screenWidth - Width) / 2, Commands.Graphics.screenHeight - Height, Width, Height, (uint)Commands.Graphics.avgCol.ToArgb());

            for (int i = 0; i < Commands.Graphics.apps.Count; i++)
            {
                Commands.Graphics.apps[i].dockX = (uint)(Devide / 2 + ((Commands.Graphics.screenWidth - Width) / 2) + (Commands.Graphics.programlogo.Width * i) + (Devide * i));
                Commands.Graphics.apps[i].dockY = Commands.Graphics.screenHeight - Commands.Graphics.programlogo.Height - Devide / 2;
                Commands.Graphics.vMWareSVGAII.DoubleBuffer_DrawImage(Commands.Graphics.programlogo, Commands.Graphics.apps[i].dockX, Commands.Graphics.apps[i].dockY);
            }
        }
    }
}
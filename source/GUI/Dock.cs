using Cosmos.Core;
using Cosmos.System;
using Oceano.GUI;
using System.Drawing;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public class Dock
    {
        uint Width = 200;
        readonly uint Height = 30;
        readonly uint Devide = 20;
        readonly string text = "PowerOFF";
        readonly uint strX = 2;
        readonly uint strY = (20 - 16) / 2;

        public void Update()
        {
            Width = (uint)(Graphics.apps.Count * Graphics.programlogo.Width + Graphics.apps.Count * Devide);

            Kernel.VMWareSVGAII.DrawFillRectangle(0, 0, Graphics.Width, 20, (uint)Color.FromArgb(32,32,32).ToArgb());

            Kernel.VMWareSVGAII.DrawACSIIString("PowerOFF", (uint)Color.White.ToArgb(), strX, strY);
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
                {
                    ACPI.Shutdown();
                }
            }
            Kernel.VMWareSVGAII.DrawFillRectangle((Graphics.Width - Width) / 2, Graphics.Height - Height, Width, Height, (uint)Color.FromArgb(32,32,32).ToArgb());
            for (int i = 0; i < Graphics.apps.Count; i++)
            {
                Graphics.apps[i].dockX = (uint)(Devide / 2 + ((Graphics.Width - Width) / 2) + (Graphics.programlogo.Width * i) + (Devide * i));
                Graphics.apps[i].dockY = Graphics.Height - Graphics.programlogo.Height - Devide / 2;
                Kernel.VMWareSVGAII.DrawImage(Graphics.programlogo, Graphics.apps[i].dockX, Graphics.apps[i].dockY);
            }
        }
    }
}
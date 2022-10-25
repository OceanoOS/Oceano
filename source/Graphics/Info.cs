using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    class Info
    {
        public static bool Opened;
        public static void DrawApp(int x, int y, int width, int height, String title)
        {
            if (Opened==true)
            {
                SVGAII.vMWareSVGAII.DoubleBuffer_DrawFillRectangle((uint)x, (uint)y,(uint)width, (uint)height, (uint)Color.WhiteSmoke.ToArgb());
                SVGAII.vMWareSVGAII.DoubleBuffer_DrawRectangle((uint)Color.Red.ToArgb(), x, y, width, height);
                SVGAII.vMWareSVGAII.DoubleBuffer_DrawFillRectangle((uint)x + 1, (uint)y + 1, (uint)width-1, 16, (uint)Color.White.ToArgb());
                SVGAII.vMWareSVGAII._DrawACSIIString(title, (uint)Color.Black.ToArgb(), (uint)x + 1, (uint)y + 1);
                if (MouseManager.X >= x & MouseManager.X <= width & MouseManager.Y >= y & MouseManager.Y <= y + 16 & MouseManager.MouseState == MouseState.Left)
                {
                    x = (int)MouseManager.X;
                    y = (int)MouseManager.Y;
                }
            }


        }
    }
}

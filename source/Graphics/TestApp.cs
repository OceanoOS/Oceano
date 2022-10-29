using Oceano.Boot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System;
using Kernel = Oceano.Boot.Kernel;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Oceano.Graphics
{
    public class TestApp
    {
        public static int x;
        public static int y;
        public static string text;
        public static bool Opened;
        public static void Update()
        {
            if (Opened)
            {
                Kernel.canvas.DrawFilledRectangle(new(Color.Black), x, y, 200, 100);
                Kernel.canvas.DrawRectangle(new(Color.Red), x, y, 200, 100);
                Kernel.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
                if(MouseManager.X >= x & MouseManager.X <=x+200 & MouseManager.Y >=y & MouseManager.Y <=y+16 & MouseManager.MouseState == MouseState.Left)
                {
                    x = (int)MouseManager.X - 10;
                    y = (int)MouseManager.Y - 10;
                }
            }
        }
    }
}

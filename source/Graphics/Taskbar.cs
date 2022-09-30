using Oceano.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Mouse = Cosmos.System.MouseManager;
using Cosmos.System;

namespace Oceano.Graphics
{
    public class Taskbar
    {
        static bool menuopened = false;

        public static void DrawMenu()
        {
            gui.canvas.DrawFilledRectangle(new(Color.Black), 0, 0, 800, 16);
            gui.canvas.DrawACSIIString(new(Color.White), "File", 0, 0);
            if (Mouse.X == 0)
            {
                menuopened = true;
            }
            if (menuopened = true)
            {
                
            }
        }
    }
}

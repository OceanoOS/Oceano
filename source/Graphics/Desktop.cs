using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class Desktop
    {
        public static void Update()
        {
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), 0, 0, Display.screenWidth, 16);
            Kernel.canvas.DrawButton(0, 0, "Shutdown",Cosmos.System.Power.Shutdown);
        }
    }
}

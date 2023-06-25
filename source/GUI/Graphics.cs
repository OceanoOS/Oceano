using Cosmos.System;
using PrismAPI.Hardware.GPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class Graphics
    {
        public static void Initialize()
        {
            Kernel.display = Display.GetDisplay(1024, 768);
            MouseManager.ScreenWidth = Kernel.display.Width;
            MouseManager.ScreenHeight = Kernel.display.Height;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
        }
    }
}

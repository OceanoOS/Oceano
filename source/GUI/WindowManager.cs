using Cosmos.HAL;
using Cosmos.System;
using PrismAPI.Hardware.GPU;
using PrismAPI.Hardware.GPU.Vesa;
using PrismAPI.Hardware.GPU.VMWare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public static class WindowManager
    {
        public static void Initialize(string mode, bool initmouse, ushort width = 1024, ushort height = 768)
        {
            switch(mode)
            {
                case "auto":
                    Kernel.display = Display.GetDisplay(width, height);
                    break;
                case "svgaii":
                    Kernel.display = new SVGAIICanvas(width, height);
                    break;
                case "vbe":
                    Kernel.display = new VBECanvas();
                    break;
            }
            switch(initmouse)
            {
                case true:
                    MouseManager.ScreenWidth = Kernel.display.Width;
                    MouseManager.ScreenHeight = Kernel.display.Height;
                    MouseManager.X = MouseManager.ScreenWidth / 2;
                    MouseManager.Y = MouseManager.ScreenHeight / 2;
                    break;
            }
        }
        public static void Update()
        {

        }
    }
}

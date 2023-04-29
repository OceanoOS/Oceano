using Cosmos.Core;
using PrismGraphics;
using PrismGraphics.Fonts;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public class Information : App
    {
        Image logo = Image.FromBitmap(Resources.logo);
        string ram = CPU.GetAmountOfRAM().ToString();
        string cpuname = CPU.GetCPUBrandString().ToString();
        public Information() : base("Information", false, Image.FromBitmap(Resources.info), 360, 400, 20, 30) { }
        public override void Run()
        {
            Kernel.Canvas.DrawImage(x, y, logo, false);
            Kernel.Canvas.DrawString(x, y + 202, Kernel.Name + " version " + Kernel.Version, Font.Fallback, Color.White);
            Kernel.Canvas.DrawString(x, y + 222, Kernel.Username + "@" + Kernel.Host, Font.Fallback, Color.White);
            Kernel.Canvas.DrawString(x, y + 242, "RAM: " + ram + "MB", Font.Fallback, Color.White);
            Kernel.Canvas.DrawString(x, y + 262, "CPU: " + cpuname, Font.Fallback, Color.White);
            Kernel.Canvas.DrawString(x, y + 282, "Big thanks to Terminal.cs, nifanfa and \nall the members of the Cosmos Team.", Font.Fallback, Color.White);
        }
    }
}

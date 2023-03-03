using Cosmos.System;
using Cosmos.Core;
using Oceano.GUI;

namespace Oceano.Core
{
    public class Program : Kernel
    {
        #region Information
        
        public static string Name = "Oceano";
        public static string Version = "1.0.0";
        public static string CPUName = CPU.GetCPUBrandString().ToString();
        public static string TotalRAM = CPU.GetAmountOfRAM().ToString();
        public static string CPUVendor = CPU.GetCPUVendorName().ToString();
        #endregion
        #region Graphics
        Graphics graphics = new(1024,768,"SVGAII");
        #endregion
        protected override void BeforeRun()
        {
            graphics.Init();
        }
        protected override void Run()
        {
            graphics.Clear(PrismGraphics.Color.Black);
            graphics.SetPixel((int)MouseManager.X, (int)MouseManager.Y,PrismGraphics.Color.White);
            graphics.DrawString(20,20,graphics.SVGAIICanvas.GetFPS().ToString(),PrismGraphics.Color.White,PrismGraphics.Fonts.Font.Fallback);
            graphics.Update();
        }
    }
}
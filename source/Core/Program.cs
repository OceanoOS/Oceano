using Cosmos.System;
using Cosmos.Core;
using PrismGL2D.Extentions;
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
        public static VBECanvas Canvas { get; set; } = new();
        #endregion
        protected override void BeforeRun()
        {
            Desktop.BeforeRun();
        }
        protected override void Run()
        {
            Desktop.Run();
        }
    }
}
using Cosmos.Core;
using Cosmos.System;
using PrismAPI.Hardware.GPU;

namespace Oceano.Core
{

    public class Program : Kernel
    {
        #region Information
        public static string Name = "Oceano";
        public static string Version = "2.0.0";
        public static string CPUName = CPU.GetCPUBrandString();
        public static string TotalRAM = CPU.GetAmountOfRAM().ToString();
        public static string CPUVendor = CPU.GetCPUVendorName();
        public static string CPUCycleSpeed = CPU.GetCPUCycleSpeed().ToString();
        #endregion
        #region Graphics
        public static Display display;
        #endregion
        protected override void BeforeRun()
        {
            BootManager.Boot();
        }
        protected override void Run()
        {

        }
    }
}

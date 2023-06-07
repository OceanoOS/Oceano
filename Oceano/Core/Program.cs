using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics;
using Oceano.Tasks;
using System.Runtime.InteropServices;

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
        public static string AvailableRAM;
        public static string CPUUptime;
        #endregion
        #region Tasks
        public static ProcessManager processManager = new();
        #endregion
        protected override void BeforeRun()
        {
            BootManager.Boot();
        }

        protected override void Run()
        {
            processManager.Run();
        }
    }
}

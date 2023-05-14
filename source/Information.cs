using Cosmos.Core;

namespace Oceano
{
    public static class Information
    {
        public static string Name = "Oceano";
        public static string Version = "2.0";
        public static string Build = "14052023";
        public static string BuildDate = "14 May 2023";
        public static string CPUVendor = CPU.GetCPUVendorName();
        public static string CPUName = CPU.GetCPUBrandString();
        public static string CPUCycle = CPU.GetCPUCycleSpeed().ToString();
        public static string CPUUptime = CPU.GetCPUUptime().ToString();
        public static string TotalRAM = CPU.GetAmountOfRAM().ToString();
        public static string AvailableRAM = CPU.GetEndOfKernel().ToString();
    }
}
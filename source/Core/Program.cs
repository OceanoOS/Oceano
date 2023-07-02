using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Oceano.Services;
using Oceano.Users;
using System.IO;

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

        #region Filesystem
        public static CosmosVFS fs;
        public static string CurrentPath = "0:\\";
        #endregion

        #region Login
        public static string Username;
        public static string Host = "oceano";
        public static bool LoggedIn = false;
        #endregion


        protected override void BeforeRun()
        {
            BootManager.Boot();
        }
        protected override void Run()
        {
            if (!LoggedIn)
            {
                LoginSystem.Login();
            }
            else
            {
                TaskManager.Update();
            }
        }
    }
}

using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Oceano.Services;
using Oceano.Users;
using System.IO;

namespace Oceano.Core
{
    /// <summary>
    /// Oceano entry point.
    /// </summary>
    public class Program : Kernel
    {
        #region Information
        /// <summary>
        /// Operating system name.
        /// </summary>
        public static string Name = "Oceano";
        /// <summary>
        /// Operating system version.
        /// </summary>
        public static string Version = "2.0.0";
        /// <summary>
        /// CPU Brand String.
        /// </summary>
        public static string CPUName = CPU.GetCPUBrandString();
        /// <summary>
        /// Total Random Acess Memory.
        /// </summary>
        public static string TotalRAM = CPU.GetAmountOfRAM().ToString();
        /// <summary>
        /// CPU Vendor Name.
        /// </summary>
        public static string CPUVendor = CPU.GetCPUVendorName();
        /// <summary>
        /// CPU Cycle speed.
        /// </summary>
        public static string CPUCycleSpeed = CPU.GetCPUCycleSpeed().ToString();
        #endregion

        #region Filesystem
        /// <summary>
        /// Oceano Cosmos VFS.
        /// </summary>
        public static CosmosVFS fs;
        #endregion

        #region Login
        /// <summary>
        /// Current username.
        /// </summary>
        public static string Username;
        /// <summary>
        /// Current host.
        /// </summary>
        public static string Host = "oceano";
        /// <summary>
        /// Check if user is logged in.
        /// </summary>
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

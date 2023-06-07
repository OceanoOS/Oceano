using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System;
using System.Threading;

namespace Oceano.Core
{
    public class BootManager
    {
        public static void Boot()
        {
            CustomConsole.PrintInfo("Setting 80x25 VGA resoultion...");
            Thread.Sleep(1000);
            try
            {
                Console.Clear();
                VGAScreen.SetTextMode(Cosmos.HAL.Drivers.Video.VGADriver.TextSize.Size80x25);
                CustomConsole.PrintSuccess("80x25 VGA resolution set.");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while setting resolution: " + ex.Message);
            }
            CustomConsole.PrintInfo("Connecting to network via DHCP...");
            try
            {
                using (var xClient = new DHCPClient())
                {
                    xClient.SendDiscoverPacket();
                }
                CustomConsole.PrintSuccess("Connected to network successfully.");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while connecting: " + ex.Message);
            }
            CustomConsole.PrintInfo("Initializing filesystem...");
            if (!Cosmos.System.VMTools.IsVMWare)
            {
                if (!Cosmos.System.VMTools.IsVirtualBox)
                {
                    if (!Cosmos.System.VMTools.IsQEMU)
                    {
                        CustomConsole.PrintWarning("You are using real hardware or a not known VM. If you want to prevent damage to the machine, turn off your computer now. We're not responsible for ANY software/hardware damage.");
                        Thread.Sleep(10000);
                        CustomConsole.PrintWarning("You have been warned.");
                    }
                }
            }
            try
            {
                CosmosVFS fs = new();
                VFSManager.RegisterVFS(fs, true, true);
                CustomConsole.PrintSuccess("Filesystem initlialized successfully.");
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error while initializing filesystem: " + ex.Message);
            }
            CustomConsole.PrintSuccess("Boot successful! Welcome to Oceano!");
            Console.WriteLine();
        }
    }
}

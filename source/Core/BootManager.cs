using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using IL2CPU.API.Attribs;
using System;
using System.Threading;

namespace Oceano.Core
{
    public class BootManager
    {
        public static void Boot()
        {
            Console.Clear();
            CustomConsole.PrintInfo("Starting Console...");
            Thread.Sleep(1000);
            try
            {
                PCScreenFont vgafont = PCScreenFont.Default;
                VGAScreen.SetFont(vgafont.CreateVGAFont(), vgafont.Height);
            }
            catch (Exception ex)
            {
                CustomConsole.PrintError("Error While starting console: " + ex.ToString());
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

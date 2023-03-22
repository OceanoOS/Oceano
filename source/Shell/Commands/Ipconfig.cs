using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System;

namespace Oceano.Shell.Commands
{
    public class Ipconfig : Command
    {
        public Ipconfig(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            switch (args[0])
            {
                case "set":
                    NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");
                    IPConfig.Enable(nic, new Address(Convert.ToByte(args[1]), Convert.ToByte(args[2]), Convert.ToByte(args[3]), Convert.ToByte(args[4])), new Address(Convert.ToByte(args[5]), Convert.ToByte(args[6]), Convert.ToByte(args[7]), Convert.ToByte(args[8])), new Address(Convert.ToByte(args[9]), Convert.ToByte(args[10]), Convert.ToByte(args[11]), Convert.ToByte(args[12])));
                    Console.WriteLine("Your ip: " + NetworkConfiguration.CurrentAddress.ToString());
                    break;
                case "auto":
                    using (var xClient = new DHCPClient())
                    {
                        xClient.SendDiscoverPacket();
                    }
                    Console.WriteLine("Your ip: " + NetworkConfiguration.CurrentAddress.ToString());
                    break;
            }
            return "";
        }
    }
}

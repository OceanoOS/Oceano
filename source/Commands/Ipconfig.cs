using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class Ipconfig : Command
    {
        public Ipconfig(String name) : base(name) { }

        public override String execute(String[] args)
        {
            string response = "";
            try
            {
                switch (args[0])
                {
                    case "/set":
                        try
                        {
                            NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");
                            IPConfig.Enable(nic, new Address(Convert.ToByte(args[1]), Convert.ToByte(args[2]), Convert.ToByte(args[3]), Convert.ToByte(args[4])), new Address(Convert.ToByte(args[5]), Convert.ToByte(args[6]), Convert.ToByte(args[7]), Convert.ToByte(args[8])), new Address(Convert.ToByte(args[9]), Convert.ToByte(args[10]), Convert.ToByte(args[11]), Convert.ToByte(args[12]))); //enable IPv4 configuration
                            Console.ForegroundColor = ConsoleColor.Green;
                            var ip = NetworkConfiguration.CurrentAddress.ToString();
                            response = "Network configured successfully! Your local ip address: " + ip;
                        }
                        catch(Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            response = ex.Message;
                        }
                        break;
                    case "/ask":
                        try
                        {
                            DHCPClient client = new DHCPClient();
                            client.SendDiscoverPacket();
                            var ip = NetworkConfiguration.CurrentAddress.ToString();
                            client.Close();
                            Console.ForegroundColor = ConsoleColor.Green;
                            response = "Network configured successfully! Your local ip address: " + ip;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            response = "Error: " + ex.Message;
                        }

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        response = "Error: Unexpected argument"; break;
                    case "": break;

                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                response = "Error: Unexpected argument";
            }
            return response;
        }
    }
}

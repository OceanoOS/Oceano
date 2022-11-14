using Cosmos.System.Network.Config;
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

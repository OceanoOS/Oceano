using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class power
    {
        public static void Shutdown()
        {
            Cosmos.System.Power.Shutdown();
            Cosmos.System.Power.QemuShutdown();
        }
        public static void Reboot()
        {
            Cosmos.System.Power.Reboot();
            Cosmos.System.Power.QemuReboot();
        }
    }
}

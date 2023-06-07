using Cosmos.Core;
using Kernel = Oceano.Core.Program;

namespace Oceano.Tasks.Processes
{
    public class MemoryProcess : Process
    {
        public MemoryProcess() : base("mmanager", "2.0.0", "Used for get available RAM and CPU Uptime", Priority.Medium)
        {

        }
        public override void Run()
        {
            Kernel.CPUUptime = CPU.GetCPUUptime().ToString();
            Kernel.AvailableRAM = CPU.GetEndOfKernel().ToString();
        }
    }
}

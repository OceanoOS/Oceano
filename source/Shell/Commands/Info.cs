using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Info : Command
    {
        public Info(string name) : base(name)
        {

        }

        public override string Invoke(string[] args)
        {
            return Kernel.Name + ", version" + Kernel.Version + ". Running on " + Kernel.CpuName + " From " + Kernel.CpuVendor + ". Total RAM: " + Kernel.TotalRam + " MB";
        }
    }
}

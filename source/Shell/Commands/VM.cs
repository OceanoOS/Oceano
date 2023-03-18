using Cosmos.System;

namespace Oceano.Shell.Commands
{
    public class VM : Command
    {
        public VM(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            if (VMTools.IsVMWare)
            {
                response = "You are running Oceano in VMWare.";
            }
            else
            {
                if (VMTools.IsVirtualBox)
                {
                    response = "You are running Oceano in VirtualBox.";
                }
                else
                {
                    if (VMTools.IsQEMU)
                    {
                        response = "You are running Oceano in QEMU.";
                    }
                    else
                    {
                        response = "You are running Oceano in Real Hardware or in a not known VM.";
                    }
                }
            }
            return response;
        }
    }
}

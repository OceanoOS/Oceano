using Cosmos.HAL;
using Cosmos.HAL.Drivers;
using Cosmos.Core;

namespace Oceano.Drivers{
    public class BootManager{
        public static bool SVGAsupported{
            get
            {
                return Cosmos.HAL.PCI.GetDevice(Cosmos.HAL.VendorID.VMWare, Cosmos.HAL.DeviceID.SVGAIIAdapter) != null;
            }
        }
        public static bool VBEsupported{
            get
            {
                return VBE.IsAvailable() ||
                    ((PCI.GetDevice(VendorID.VirtualBox, DeviceID.VBVGA)) != null) || 
                    ((PCI.GetDevice(VendorID.Bochs, DeviceID.BGA)) != null) || 
                    VBEDriver.ISAModeAvailable();
            }
        }
    }
}
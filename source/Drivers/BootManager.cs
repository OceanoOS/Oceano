using Cosmos.HAL;
using Cosmos.HAL.Drivers;
using Cosmos.Core;

namespace Oceano.Drivers{
    public class BootManager{
        public static bool SVGAsupported{
            get
            {
                return Cosmos.HAL.PCI.GetDevice(VendorID.VMWare, DeviceID.SVGAIIAdapter) != null;
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
        public static bool VBVGAsupported{
            get{
                return Cosmos.HAL.PCI.GetDevice(VendorID.VirtualBox,DeviceID.VBVGA) != null;
            }
        }
        public static bool Networksupported{
            get{
                return PCI.GetDevice(VendorID.Intel,DeviceID.BGA) != null;
            }
        }
    }
}
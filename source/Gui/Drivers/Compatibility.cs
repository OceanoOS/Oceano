using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.HAL.Drivers;

namespace Oceano.Gui.Drivers
{
    /// <summary>
    /// Compatibilty class, used to find the best graphics driver.
    /// </summary>
    public class Compatibility
    {
        /// <summary>
        /// SVGAII Compatibility
        /// </summary>
        public static bool SVGAIISupported
        {
            get
            {
                return Cosmos.HAL.PCI.GetDevice(Cosmos.HAL.VendorID.VMWare, Cosmos.HAL.DeviceID.SVGAIIAdapter) != null;
            }
        }
        /// <summary>
        /// VBE Compatibility
        /// </summary>
        public static bool VBESupported
        {
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

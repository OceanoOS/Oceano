using IL2CPU.API.Attribs;

namespace Oceano
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.generic.bmp")]
        public static byte[] generic;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.clock.bmp")]
        public static byte[] clock;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.notepad.bmp")]
        public static byte[] notepad;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.info.bmp")]
        public static byte[] info;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.logo.bmp")]
        public static byte[] logo;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.shutdown.bmp")]
        public static byte[] shutdown;
    }
}

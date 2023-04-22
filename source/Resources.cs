using IL2CPU.API.Attribs;

namespace Oceano
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.generic.bmp")]
        public static byte[] generic;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.clock.bmp")]
        public static byte[] clock;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        public static byte[] wallpaper;
    }
}
